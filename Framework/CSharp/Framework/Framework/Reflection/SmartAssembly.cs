/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Reflection;

namespace Smartkernel.Framework.Reflection
{
    /// <summary>
    /// 更续集
    /// </summary>
    public static class SmartAssembly
    {
        /// <summary>
        /// 获得程序集的信息
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns>程序集的信息</returns>
        public static SmartAssemblyInfo GetAssemblyInfo(Assembly assembly)
        {
            return new SmartAssemblyInfo(assembly);
        }
    }
}
