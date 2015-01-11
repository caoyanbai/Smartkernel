/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.IO;
using System;
using System.IO;
using System.Reflection;

namespace Smartkernel.Framework.Diagnostics
{
    /// <summary>
    /// App上下文
    /// </summary>
    public static class SmartAppContext
    {
        /// <summary>
        /// 启动时间
        /// </summary>
        public static readonly DateTime StartupTime = DateTime.Now;

        /// <summary>
        /// 程序所在目录（有斜线结尾）
        /// </summary>
        public static readonly string Directory = SmartDirectory.GetFormatDirectoryPath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

        /// <summary>
        /// 程序名称
        /// </summary>
        public static readonly string Name = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
    }
}
