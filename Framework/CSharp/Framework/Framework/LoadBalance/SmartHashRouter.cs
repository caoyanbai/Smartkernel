/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;

namespace Smartkernel.Framework.LoadBalance
{
    /// <summary>
    /// 负载均衡哈希路由器，根据哈希码计算分布到哪个处理器上进行处理。是线程安全的
    /// </summary>
    public class SmartHashRouter : SmartRouter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">路由器名称</param>
        /// <param name="processors">处理器数组</param>
        public SmartHashRouter(string name = null, IEnumerable<SmartProcessor> processors = null) : base(name, processors) { }

        /// <summary>
        /// 生成当前的处理器
        /// </summary>
        /// <param name="hashCode">分区的Key，一般用Guid、IP等</param>
        /// <returns>当前的处理器</returns>
        public override SmartProcessor Generate(int? hashCode)
        {
            int currentIndex = hashCode.Value % processors.Count;
            //比Math.Abs的性能高一些
            if (currentIndex < 0)
            {
                currentIndex = -currentIndex;
            }
            current = processors[currentIndex];
            return current;
        }
    }
}