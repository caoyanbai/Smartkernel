/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.IO;
using System;
using System.IO;
using System.Web;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// Http上下文
    /// </summary>
    public static class SmartHttpContext
    {
        /// <summary>
        /// 启动时间
        /// </summary>
        public static readonly DateTime StartupTime = DateTime.Now;

        /// <summary>
        /// Bin目录（有斜线结尾）
        /// </summary>
        public static readonly string BinDirectory = SmartDirectory.GetFormatDirectoryPath(Path.GetDirectoryName(HttpRuntime.BinDirectory));

        /// <summary>
        /// 项目所在目录（有斜线结尾）
        /// </summary>
        public static readonly string Directory = SmartDirectory.GetFormatDirectoryPath(Path.GetDirectoryName(HttpRuntime.AppDomainAppPath));
    }
}
