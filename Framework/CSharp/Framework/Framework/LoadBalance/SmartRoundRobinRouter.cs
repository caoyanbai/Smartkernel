/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartkernel.Framework.LoadBalance
{
    /// <summary>
    /// 负载均衡轮询路由器，处理器组中的每个处理器都有相同的机会（可根据处理能力进行权重调节）被使用
    /// </summary>
    public class SmartRoundRobinRouter : SmartRouter
    {
        /// <summary>
        /// 当前处理器的索引
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">路由器名称</param>
        /// <param name="processors">处理器数组</param>
        public SmartRoundRobinRouter(string name = null, IEnumerable<SmartProcessor> processors = null) : base(name, processors)
        {
            UpdateTruePower();
        }

        /// <summary>
        /// 生成当前的处理器
        /// </summary>
        /// <param name="parameter">对于轮训路由器来说，这个参数无效</param>
        /// <returns>当前的处理器</returns>
        public override SmartProcessor Generate(int? parameter = null)
        {
            lock (SyncRoot)
            {
                //当前的处理器
                var currentProcessor = processors[currentIndex%processors.Count] as SmartRoundRobinProcessor;
                //增加当前处理器的处理量
                currentProcessor.CurrentProcessQuantity++;
                //当当前处理器处理量等于权重数时，使用下一个处理器处理，且刷新当前处理器的处理量
                if (currentProcessor.CurrentProcessQuantity == currentProcessor.TruePower)
                {
                    currentProcessor.CurrentProcessQuantity = 0;
                    currentIndex++;
                }
                current = currentProcessor;
                return currentProcessor;
            }
        }

        /// <summary>
        /// 更新实际处理权重
        /// </summary>
        private void UpdateTruePower()
        {
            lock (SyncRoot)
            {
                //没有处理器的时候不用更新
                if (processors.Count == 0)
                {
                    return;
                }

                //获得所有处理权重列表
                var powerList = processors.Select((item, i) =>
                                                  {
                                                      var roundRobinProcessor = item as SmartRoundRobinProcessor;
                                                      return roundRobinProcessor.Power;
                                                  });

                //求得最大公约数
                var maxDivisor = SmartMath.GetMaxDivisor(powerList.ToList());

                //将设置的权重除以最大公约数
                processors.ForEach(item =>
                                   {
                                       var roundRobinProcessor = item as SmartRoundRobinProcessor;
                                       roundRobinProcessor.TruePower = roundRobinProcessor.Power/maxDivisor;
                                   });
            }
        }

        /// <summary>
        /// 增加多个处理器
        /// </summary>
        /// <param name="processors">处理器</param>
        public override void AddRange(IEnumerable<SmartProcessor> processors)
        {
            base.AddRange(processors);
            UpdateTruePower();
        }

        /// <summary>
        /// 增加处理器
        /// </summary>
        /// <param name="processor">处理器</param>
        public override void Add(SmartProcessor processor)
        {
            base.Add(processor);
            UpdateTruePower();
        }

        /// <summary>
        /// 通过name删除处理器
        /// </summary>
        /// <param name="name">处理器的name</param>
        public override void Remove(string name)
        {
            UpdateTruePower();
        }
    }
}