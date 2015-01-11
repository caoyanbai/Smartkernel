/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Linq;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 数组
    /// </summary>
    public static class SmartArray
    {
        /// <summary>
        /// 解析为数组
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">值</param>
        /// <param name="split">分割符</param>
        /// <returns>结果</returns>
        public static T[] Parse<T>(string value, char split = '|')
        {
            var type = typeof(T);
            T[] array = null;
            if (!string.IsNullOrEmpty(value))
            {
                array = value.Split(split).Select(item =>
                {
                    if (type.IsEnum)
                    {
                        return (T)Enum.Parse(type, item, true);
                    }
                    else
                    {
                        return (T)Convert.ChangeType(item, typeof(T));
                    }
                }).ToArray();
            }
            return array;
        }
    }
}
