/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.IO;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 应用程序域
    /// </summary>
    public static class SmartAppDomain
    {
        /// <summary>
        /// 卸载应用程序域
        /// </summary>
        /// <param name="appDomain">应用程序域</param>
        public static void Unload(AppDomain appDomain)
        {
            AppDomain.Unload(appDomain);
            appDomain = null;
        }

        /// <summary>
        /// 创建新的应用程序域
        /// </summary>
        /// <param name="appDomainName">应用程序域的名称</param>
        /// <param name="applicationName">应用程序的名称</param>
        /// <returns>应用程序域</returns>
        public static AppDomain CreateDomain(string appDomainName = null, string applicationName = null)
        {
            AppDomainSetup appDomainSetup = new AppDomainSetup();
            appDomainSetup.ApplicationName = applicationName ?? SmartGuid.NewGuid();
            appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            appDomainSetup.PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "private");
            appDomainSetup.CachePath = appDomainSetup.ApplicationBase;
            appDomainSetup.ShadowCopyFiles = "true";
            appDomainSetup.ShadowCopyDirectories = appDomainSetup.ApplicationBase;
            return AppDomain.CreateDomain(appDomainName ?? SmartGuid.NewGuid(), null, appDomainSetup);
        }
    }
}
