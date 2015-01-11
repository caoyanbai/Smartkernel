/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using LumiSoft.Net.Mail;
using LumiSoft.Net.POP3.Client;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 邮件服务器Pop3客户端类
    /// </summary>
    public class SmartPop3Client
    {
        private readonly List<string> list = new List<string>();

        private readonly SmartPop3ClientConfig pop3ClientConfig;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pop3ClientConfig">配置实体</param>
        public SmartPop3Client(SmartPop3ClientConfig pop3ClientConfig)
        {
            this.pop3ClientConfig = pop3ClientConfig;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">Pop3服务器地址</param>
        /// <param name="username">接收者用户名</param>
        /// <param name="password">接收者密码</param>
        /// <param name="port">Pop3服务器端口</param>
        public SmartPop3Client(string host, string username, string password, int port = 110)
        {
            pop3ClientConfig = new SmartPop3ClientConfig();
            pop3ClientConfig.Host = host;
            pop3ClientConfig.Port = port;
            pop3ClientConfig.Username = username;
            pop3ClientConfig.Password = password;
        }

        /// <summary>
        /// 获取已经获取的列表
        /// </summary>
        public List<string> AlreadyMimes { get { return list; } }

        /// <summary>
        /// 获得邮件列表（已经获取过的，不会再获取）
        /// </summary>
        /// <returns>获取的列表</returns>
        public List<SmartMailInfo> GetMimes()
        {
            var smartMimes = new List<SmartMailInfo>();
            using (var pop3 = new POP3_Client())
            {
                pop3.Connect(pop3ClientConfig.Host, pop3ClientConfig.Port, false);
                pop3.Authenticate(pop3ClientConfig.Username, pop3ClientConfig.Password, false);

                for (var i = 0; i < pop3.Messages.Count; i++)
                {
                    if (!list.Contains(pop3.Messages[i].UID))
                    {
                        var mime = Mail_Message.ParseFromByte(pop3.Messages[i].MessageToByte());
                        list.Add(pop3.Messages[i].UID);
                        var smartMime = new SmartMailInfo(mime);
                        smartMimes.Add(smartMime);
                    }
                }
            }
            return smartMimes;
        }
    }
}