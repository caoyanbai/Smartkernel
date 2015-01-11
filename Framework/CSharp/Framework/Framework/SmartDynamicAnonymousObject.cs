/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 匿名对象因为是private的，无法跨越程序集以DynamicObject对象传递，因此参数的打包传递使用SmartDynamicAnonymousObject对象。默认不是线程安全的。
    /// </summary>
    [SerializableAttribute]
    public class SmartDynamicAnonymousObject : DynamicObject
    {
        /// <summary>
        /// 对象的成员
        /// </summary>
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        /// <summary>
        /// 获取对象的成员
        /// </summary>
        public virtual SmartReadOnlyDictionary<string, object> DynamicMembers { get { return new SmartReadOnlyDictionary<string, object>(dictionary); } }

        /// <summary>
        /// 尝试获取成员的值
        /// </summary>
        /// <param name="binder">绑定器</param>
        /// <param name="result">成员的值</param>
        /// <returns>是否获取成功</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var isContains = false;
            result = null;
            if (dictionary.ContainsKey(binder.Name))
            {
                result = dictionary[binder.Name];
                isContains = true;
            }

            return isContains;
        }

        /// <summary>
        /// 尝试设置成员的值
        /// </summary>
        /// <param name="binder">绑定器</param>
        /// <param name="value">成员的值</param>
        /// <returns>是否设置成功</returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (dictionary.ContainsKey(binder.Name))
            {
                dictionary[binder.Name] = value;
            }
            else
            {
                dictionary.Add(binder.Name, value);
            }
            return true;
        }

        /// <summary>
        /// 获得成员名称列表
        /// </summary>
        /// <returns>枚举器</returns>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return dictionary.Keys;
        }

        /// <summary>
        /// 获取是否是线程安全的
        /// </summary>
        public virtual bool IsSynchronized { get { return false; } }

        /// <summary>
        /// 同步对象
        /// </summary>
        public virtual object SyncRoot { get { return this; } }

        /// <summary>
        /// 创建线程安全的参数对象
        /// </summary>
        /// <param name="parameter">非线程安全的参数对象</param>
        /// <returns>线程安全的参数对象</returns>
        public static SmartDynamicAnonymousObject Synchronized(SmartDynamicAnonymousObject parameter)
        {
            if (parameter == null)
            {
                throw new Exception("parameter参数不能为null。");
            }
            if (parameter.GetType() == typeof(SmartSyncParameter))
            {
                throw new Exception("parameter已经是线程安全的对象了。");
            }
            return new SmartSyncParameter(parameter);
        }

        /// <summary>
        /// 线程安全的参数
        /// </summary>
        private sealed class SmartSyncParameter : SmartDynamicAnonymousObject
        {
            private readonly object syncRoot;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="parameter">非线程安全的参数对象</param>
            internal SmartSyncParameter(SmartDynamicAnonymousObject parameter)
            {
                syncRoot = parameter.SyncRoot;
            }

            /// <summary>
            /// 获取是否是线程安全的
            /// </summary>
            public override bool IsSynchronized { get { return true; } }

            /// <summary>
            /// 同步对象
            /// </summary>
            public override object SyncRoot { get { return syncRoot; } }

            /// <summary>
            /// 尝试获取成员的值
            /// </summary>
            /// <param name="binder">绑定器</param>
            /// <param name="result">成员的值</param>
            /// <returns>是否获取成功</returns>
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                lock (syncRoot)
                {
                    return base.TryGetMember(binder, out result);
                }
            }

            /// <summary>
            /// 尝试设置成员的值
            /// </summary>
            /// <param name="binder">绑定器</param>
            /// <param name="value">成员的值</param>
            /// <returns>是否设置成功</returns>
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                lock (syncRoot)
                {
                    return base.TrySetMember(binder, value);
                }
            }
        }
    }
}
