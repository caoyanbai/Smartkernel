/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Reflection;

namespace Smartkernel.Framework.Reflection
{
    /// <summary>
    /// 远程程序集的抽象基类，如果要实现程序集加载到独立的应用程序域中，应该实现此类型
    /// </summary>
    public abstract class SmartRemoteAssemblyProxy : MarshalByRefObject
    {
        /// <summary>
        /// 远程程序集
        /// </summary>
        protected Assembly RemoteAssembly { get; private set; }

        /// <summary>
        /// 加载远程程序集
        /// </summary>
        /// <param name="assemblyFile">程序集的路径</param>
        public void LoadFrom(string assemblyFile)
        {
            this.RemoteAssembly = Assembly.LoadFrom(assemblyFile);
        }
    }
}
