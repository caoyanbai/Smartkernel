/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Microsoft.VisualStudio.SourceSafe.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Smartkernel.Framework.Vss
{
    /// <summary>
    /// VSS源代码管理器操作类
    /// </summary>
    public class SmartVssManager : IDisposable
    {
        private IVSSDatabase database;

        /// <summary>
        /// 是否释放资源
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="iniFile">配置文件的路径</param>
        public SmartVssManager(string username, string password, string iniFile)
        {
            Username = username;
            Password = password;
            IniFile = iniFile;
            database = new VSSDatabase();
            database.Open(IniFile, Username, Password);
        }

        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置配置文件的路径
        /// </summary>
        public string IniFile { get; set; }

        #region IDisposable Members

        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// 关闭，关闭之后将无法再访问
        /// </summary>
        public void Close()
        {
            database.Close();
            Marshal.ReleaseComObject(database);
            database = null;
            isDisposed = true;
        }

        /// <summary>
        /// 下载最新源代码
        /// </summary>
        /// <param name="saveDirectory">保存的路径</param>
        /// <param name="vssProjectPath">项目路径</param>
        public void Download(string saveDirectory, string vssProjectPath = "$/")
        {
            Parallel.ForEach(GetItems(vssProjectPath), delegate(SmartVssItem vssItem)
            {
                var savePath = saveDirectory.TrimEnd('/') + "/" + vssItem.Path.Replace(vssProjectPath, "").Replace("/", @"\");
                vssItem.Item.Get(savePath);
            });
        }

        /// <summary>
        /// 获得项
        /// </summary>
        /// <param name="vssProjectPath">vss项目的路径</param>
        /// <returns>项的列表</returns>
        public List<SmartVssItem> GetItems(string vssProjectPath = "$/")
        {
            IVSSItem item = database.VSSItem[vssProjectPath];
            var list = new List<SmartVssItem>();
            GetItems(item, list);
            return list;
        }

        /// <summary>
        /// 获得列表，递归查找全部
        /// </summary>
        /// <param name="parentItem">要递归的项</param>
        /// <param name="list">列表</param>
        private static void GetItems(IVSSItem parentItem, ICollection<SmartVssItem> list)
        {
            foreach (IVSSItem item in parentItem.Items[false])
            {
                if (!item.Deleted)
                {
                    if (item.Type == (int)VSSItemType.VSSITEM_FILE)
                    {
                        var vssItem = new SmartVssItem();
                        vssItem.Path = item.Spec;
                        vssItem.LastModifyTime = item.VSSVersion.Date;
                        vssItem.LastModifyUser = item.VSSVersion.Username;
                        if (item.IsCheckedOut == (int)VSSFileStatus.VSSFILE_CHECKEDOUT || item.IsCheckedOut == (int)VSSFileStatus.VSSFILE_CHECKEDOUT_ME)
                        {
                            vssItem.IsCheckedOut = true;
                            foreach (IVSSCheckout checkoutClass in item.Checkouts)
                            {
                                vssItem.CheckedOutUsers.Add(checkoutClass.Username);
                            }
                        }
                        else
                        {
                            vssItem.IsCheckedOut = false;
                        }

                        list.Add(vssItem);
                    }
                    else
                    {
                        GetItems(item, list);
                    }
                }
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SmartVssManager()
        {
            Dispose(false);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isDispose">是否释放</param>
        private void Dispose(bool isDispose)
        {
            if (isDisposed)
            {
                return;
            }
            if (isDispose)
            {
                Close();
            }
            isDisposed = true;
        }
    }
}
