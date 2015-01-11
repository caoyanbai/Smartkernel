/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Microsoft.VisualStudio.SourceSafe.Interop;
using System;
using System.Collections.Generic;

namespace Smartkernel.Framework.Vss
{
    /// <summary>
    /// Vss的数据项
    /// </summary>
    [Serializable]
    public class SmartVssItem
    {
        private readonly List<string> checkedOutUsers = new List<string>();

        /// <summary>
        /// 获取文件地址
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// 获取是否被签出
        /// </summary>
        public bool IsCheckedOut { get; internal set; }

        /// <summary>
        /// 获取最后更新时间
        /// </summary>
        public DateTime LastModifyTime { get; internal set; }

        /// <summary>
        /// 获取最后更新人
        /// </summary>
        public string LastModifyUser { get; internal set; }

        /// <summary>
        /// 获取签出的用户列表
        /// </summary>
        public List<string> CheckedOutUsers { get { return checkedOutUsers; } }

        /// <summary>
        /// Item
        /// </summary>
        internal IVSSItem Item { get; set; }

        /// <summary>
        /// 判等方法
        /// </summary>
        /// <param name="obj">待比较的对象</param>
        /// <returns>是否相等</returns>
        public override bool Equals(object obj)
        {
            var other = obj as SmartVssItem;
            if (other == null)
            {
                return false;
            }
            return Path == other.Path;
        }

        /// <summary>
        /// 获得哈希码
        /// </summary>
        /// <returns>哈希码</returns>
        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }
    }
}
