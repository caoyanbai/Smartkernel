/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Diagnostics;
namespace Smartkernel.Framework.ServiceProcess
{
    /// <summary>
    /// Iis操作类
    /// </summary>
    public class SmartIis
    {
        private const string iisadmin = "iisadmin";

        /// <summary>
        /// 停止IIS服务
        /// </summary>
        public static void Stop()
        {
            SmartService.Stop(iisadmin);
        }

        /// <summary>
        /// 停止IIS服务（尝试，尝试之后等待一段时间）
        /// </summary>
        public static void TryStop()
        {
            SmartService.TryStop(iisadmin);
        }

        /// <summary>
        /// 启动IIS服务
        /// </summary>
        public static void Start()
        {
            SmartService.Start(iisadmin);
        }

        /// <summary>
        /// 启动IIS服务（尝试，尝试之后等待一段时间）
        /// </summary>
        public static void TryStart()
        {
            SmartService.TryStart(iisadmin);
        }

        /// <summary>
        /// 重启IIS服务
        /// </summary>
        public static void Reset()
        {
            SmartProcess.ExecuteCommand("iisreset");
        }
    }
}
