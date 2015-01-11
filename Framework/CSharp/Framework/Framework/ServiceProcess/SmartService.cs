/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace Smartkernel.Framework.ServiceProcess
{
    /// <summary>
    /// Windows服务控制器
    /// </summary>
    public static class SmartService
    {
        /// <summary>
        /// 判断服务是否存在
        /// </summary>
        /// <param name="serviceName">服务名（不区分大小写）</param>
        /// <returns>是否存在</returns>
        public static bool Exists(string serviceName)
        {
            var linq = from serviceController in ServiceController.GetServices() where serviceController.ServiceName.ToLower() == serviceName.ToLower() select serviceController;
            return linq.Count() > 0;
        }

        /// <summary>
        /// 获取指定服务名的服务控制器
        /// </summary>
        /// <param name="serviceName">服务名（不区分大小写）</param>
        /// <returns>服务控制器</returns>
        public static ServiceController GetService(string serviceName)
        {
            var linq = from serviceController in ServiceController.GetServices() where serviceController.ServiceName.ToLower() == serviceName.ToLower() select serviceController;
            return linq.Count() > 0 ? linq.ToList().First() : null;
        }

        /// <summary>
        /// 获取指定服务状态的服务控制器列表
        /// </summary>
        /// <param name="serviceControllerStatus">服务状态</param>
        /// <returns>服务控制器列表</returns>
        public static List<ServiceController> GetServices(ServiceControllerStatus serviceControllerStatus = ServiceControllerStatus.Running)
        {
            var linq = from serviceController in ServiceController.GetServices() where serviceController.Status == serviceControllerStatus select serviceController;
            return linq.ToList();
        }

        /// <summary>
        /// 启动指定名称的服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="args">参数数组</param>
        public static void Start(string serviceName, string[] args = null)
        {
            var serviceController = GetService(serviceName);
            if (serviceController.Status != ServiceControllerStatus.Running && serviceController.Status != ServiceControllerStatus.StartPending)
            {
                if (args == null)
                {
                    serviceController.Start();
                }
                else
                {
                    serviceController.Start(args);
                }
            }
        }

        /// <summary>
        /// 启动指定名称的服务（尝试，尝试之后等待一段时间）
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="args">参数数组</param>
        /// <param name="waitTime">等待时间</param>
        public static void TryStart(string serviceName, string[] args = null, TimeSpan waitTime = default(TimeSpan))
        {
            if (waitTime == null)
            {
                waitTime = TimeSpan.FromSeconds(60);
            }
            if (GetService(serviceName).Status != ServiceControllerStatus.Running)
            {
                //不是启动态
                Start(serviceName, args);//这句是异步执行的，所以等待执行完再继续

                TimeSpan time = TimeSpan.FromSeconds(0);

                while (GetService(serviceName).Status != ServiceControllerStatus.Running)
                {
                    time = time + TimeSpan.FromSeconds(1);
                    Thread.Sleep(1000);
                    if (time > waitTime)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 关闭指定名称的服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public static void Stop(string serviceName)
        {
            var serviceController = GetService(serviceName);
            if (serviceController.Status != ServiceControllerStatus.Stopped && serviceController.Status != ServiceControllerStatus.StopPending)
            {
                serviceController.Stop();
            }
        }

        /// <summary>
        /// 关闭指定名称的服务（尝试，尝试之后等待一段时间）
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="waitTime">等待时间</param>
        public static void TryStop(string serviceName, TimeSpan waitTime = default(TimeSpan))
        {
            if (waitTime == null)
            {
                waitTime = TimeSpan.FromSeconds(60);
            }
            if (GetService(serviceName).Status != ServiceControllerStatus.Stopped)
            {
                //不是停止态
                Stop(serviceName);//这句是异步执行的，所以等待执行完再继续

                TimeSpan time = TimeSpan.FromSeconds(0);

                while (GetService(serviceName).Status != ServiceControllerStatus.Stopped)
                {
                    time = time + TimeSpan.FromSeconds(1);
                    Thread.Sleep(1000);
                    if (time > waitTime)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 暂停指定名称的服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public static void Pause(string serviceName)
        {
            var serviceController = GetService(serviceName);
            if (serviceController.Status != ServiceControllerStatus.Paused && serviceController.Status != ServiceControllerStatus.PausePending)
            {
                serviceController.Pause();
            }
        }

        /// <summary>
        /// 继续执行指定名称的服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public static void Continue(string serviceName)
        {
            var serviceController = GetService(serviceName);
            if (serviceController.Status != ServiceControllerStatus.ContinuePending)
            {
                serviceController.Continue();
            }
        }

        /// <summary>
        /// 获取指定服务名的服务控制器状态
        /// </summary>
        /// <param name="serviceName">服务名（不区分大小写）</param>
        /// <returns>服务控制器的状态</returns>
        public static ServiceControllerStatus GetServiceStatus(string serviceName)
        {
            var serviceController = GetService(serviceName);
            return serviceController.Status;
        }
    }
}
