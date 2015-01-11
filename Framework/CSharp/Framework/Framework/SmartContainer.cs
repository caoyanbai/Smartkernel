﻿/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 容器
    /// </summary>
    /// <typeparam name="TKey">键</typeparam>
    /// <typeparam name="TValue">值</typeparam>
    public static class SmartContainer<TKey, TValue>
    {
        private static object syncObject = new object();

        private static Dictionary<TKey, TValue> container;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static SmartContainer()
        {
            container = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// 增加键值对
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Add(TKey key, TValue value)
        {
            lock (syncObject)
            {
                container.Add(key, value);
            }
        }

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>结果</returns>
        public static bool ContainsKey(TKey key)
        {
            return container.ContainsKey(key);
        }

        /// <summary>
        /// 清空容器
        /// </summary>
        public static void Clear()
        {
            lock (syncObject)
            {
                container.Clear();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">键</param>
        public static void Remove(TKey key)
        {
            lock (syncObject)
            {
                container.Remove(key);
            }
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static TValue Get(TKey key)
        {
            return container[key];
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Set(TKey key, TValue value)
        {
            lock (syncObject)
            {
                container[key] = value;
            }
        }
    }
}
