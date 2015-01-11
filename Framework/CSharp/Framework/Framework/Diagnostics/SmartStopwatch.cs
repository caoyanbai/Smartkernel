/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Diagnostics;

namespace Smartkernel.Framework.Diagnostics
{
    /// <summary>
    /// 计时器
    /// </summary>
    public static class SmartStopwatch
    {
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="action">行为</param>
        /// <returns>结果</returns>
        public static TimeSpan Execute(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
