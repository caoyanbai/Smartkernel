/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartkernel.Framework.Svn
{
    /// <summary>
    /// Svn数据项
    /// </summary>
    [Serializable]
    public class SmartSvnItem
    {
        /// <summary>
        /// 获取文件地址
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// 获取最后更新时间
        /// </summary>
        public DateTime LastModifyTime { get; internal set; }

        /// <summary>
        /// 获取最后更新人
        /// </summary>
        public string LastModifyUser { get; internal set; }
    }
}
