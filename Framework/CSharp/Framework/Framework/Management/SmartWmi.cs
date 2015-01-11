/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Smartkernel.Framework.Management
{
    /// <summary>
    /// Wmi服务
    /// </summary>
    public class SmartWmi
    {
        /// <summary>
        /// 查询WMI获得数据的键值对表示形式
        /// </summary>
        /// <param name="wmiSql">查询语句</param>
        /// <param name="managementScope">作用区域，默认是本机</param>
        /// <returns>数据的键值对表示</returns>
        public static List<Dictionary<string, string>> Query(string wmiSql, ManagementScope managementScope = null)
        {
            var list = new List<Dictionary<string, string>>();
            var objectQuery = new ObjectQuery(wmiSql);
            using (var managementObjectSearcher = managementScope == null ? new ManagementObjectSearcher(objectQuery) : new ManagementObjectSearcher(managementScope, objectQuery))
            {
                var managementObjectCollection = managementObjectSearcher.Get();
                foreach (var managementBaseObject in managementObjectCollection)
                {
                    var dictionary = new Dictionary<string, string>();
                    var enumerator = managementBaseObject.Properties.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        if (!dictionary.ContainsKey(current.Name))
                        {
                            dictionary.Add(current.Name, current.Value == null ? string.Empty : current.Value.ToString());
                        }
                    }
                    managementBaseObject.Dispose();
                    list.Add(dictionary);
                }
            }
            return list;
        }

        /// <summary>
        /// 查询WMI获得数据的键值对表示形式
        /// </summary>
        /// <param name="win32ClassType">Win32Class类型</param>
        /// <param name="managementScope">作用区域，默认是本机</param>
        /// <returns>数据的键值对表示</returns>
        public static List<Dictionary<string, string>> Query(SmartWin32ClassType win32ClassType, ManagementScope managementScope = null)
        {
            var wmiSql = string.Format("SELECT * FROM {0}", win32ClassType.ToString());
            var list = new List<Dictionary<string, string>>();
            var objectQuery = new ObjectQuery(wmiSql);
            using (var managementObjectSearcher = managementScope == null ? new ManagementObjectSearcher(objectQuery) : new ManagementObjectSearcher(managementScope, objectQuery))
            {
                var managementObjectCollection = managementObjectSearcher.Get();
                foreach (var managementBaseObject in managementObjectCollection)
                {
                    var dictionary = new Dictionary<string, string>();
                    var enumerator = managementBaseObject.Properties.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        if (!dictionary.ContainsKey(current.Name))
                        {
                            dictionary.Add(current.Name, current.Value == null ? string.Empty : current.Value.ToString());
                        }
                    }
                    managementBaseObject.Dispose();
                    list.Add(dictionary);
                }
            }
            return list;
        }
    }
}
