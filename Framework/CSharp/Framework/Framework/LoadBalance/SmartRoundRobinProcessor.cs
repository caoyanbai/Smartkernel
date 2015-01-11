/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.LoadBalance
{
    /// <summary>
    /// 轮询处理器
    /// </summary>
    public class SmartRoundRobinProcessor : SmartProcessor
    {
        /// <summary>
        /// 处理能力
        /// </summary>
        private int power;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">主机信息</param>
        /// <param name="power">处理能力权重</param>
        /// <param name="name">处理器的名称</param>
        public SmartRoundRobinProcessor(object host, int power, string name = null) : base(host, name)
        {
            Power = power;
        }

        /// <summary>
        /// 获取或设置处理器的处理能力，处理能力作为算法的调节权重。某个处理器的权重占同一组处理器权重之和的比例就是处理流量分配的比例。处理能力相同时，分配的处理流量也相同。处理能力是2的处理器将比处理能力是1的处理器多出一倍的负载
        /// </summary>
        public int Power
        {
            get { return power; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Power应该为正整数");
                }
                power = value;
            }
        }

        /// <summary>
        /// 获取真实的处理能力，将处理器组中的处理器权重除去最大公约数之后的数字
        /// </summary>
        public int TruePower { get; internal set; }

        /// <summary>
        /// 获取或设置当前的处理量，每次轮询开始都会刷新为0
        /// </summary>
        public int CurrentProcessQuantity { get; internal set; }
    }
}