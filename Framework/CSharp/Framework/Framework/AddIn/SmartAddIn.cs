/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Smartkernel.Framework.AddIn
{
    /// <summary>
    /// 插件程序集辅助操作
    /// </summary>
    public class SmartAddIn
    {
        /// <summary>
        /// 创建插件对象，插件对象为dynamic对象，方法调用由客户端来决定
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns>插件对象列表</returns>
        public static IEnumerable<dynamic> CreateInstances(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var linq = from type in types
                       where type.GetCustomAttributes(typeof(SmartAddInAttribute), false).Length > 0
                       select type;
            return linq.Count() > 0 ? linq.ToList().Select(Activator.CreateInstance) : null;
        }

        /// <summary>
        /// 获得插件的特性信息
        /// </summary>
        /// <param name="obj">插件对象</param>
        /// <returns>特性对象</returns>
        public static SmartAddInAttribute GetAttribute(object obj)
        {
            return (SmartAddInAttribute)obj.GetType().GetCustomAttributes(typeof(SmartAddInAttribute), false)[0];
        }
    }
}
