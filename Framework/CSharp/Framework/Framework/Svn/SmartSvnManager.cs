/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Smartkernel.Framework.Svn
{
    /// <summary>
    /// Svn管理器
    /// </summary>
    public class SmartSvnManager
    {
        /// <summary>
        /// 获取或设置远程路径
        /// </summary>
        public string RemotePath { get; set; }

        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="remotePath">远程路径</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public SmartSvnManager(string remotePath, string username, string password)
        {
            this.RemotePath = remotePath;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="dateTime">时间（这个时间之后的修改会列出）</param>
        /// <param name="sleepSecond">休眠时间以使svn log命令能执行完</param>
        /// <param name="encoding">编码</param>
        /// <returns>结果</returns>
        public List<SmartSvnItem> GetItems(DateTime dateTime, int sleepSecond = 30, Encoding encoding = null)
        {
            var items = new List<SmartSvnItem>();
            var xml = SmartProcess.ExecuteCommand(string.Format("svn log {0} --username {1} --password {2} -v --xml", RemotePath, Username, Password), encoding);

            var start = xml.IndexOf("<?xml");
            var end = xml.LastIndexOf("</log>") + 6;

            xml = xml.Substring(start, end - start);

            Thread.Sleep(1000 * sleepSecond);

            XDocument document = XDocument.Parse(xml);
            var elements = document.Element("log").Elements("logentry").ToList();

            foreach (var element in elements)
            {
                if (Convert.ToDateTime(element.Element("date").Value) > dateTime)
                {
                    var pathElements = element.Element("paths").Elements("path").Take(100).ToList();
                    foreach (var pathElement in pathElements)
                    {
                        try
                        {
                            items.Add(new SmartSvnItem()
                            {
                                Path = pathElement.Value,
                                LastModifyTime = Convert.ToDateTime(element.Element("date").Value),
                                LastModifyUser = element.Element("author").Value
                            });
                        }
                        catch
                        {
                        }
                    }

                }
            }
            items = items.OrderByDescending(item => item.LastModifyTime).ToList();
            return items;
        }
    }
}
