/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Smartkernel.Framework.LoadBalance
{
    /// <summary>
    /// 负载均衡路由器的抽象基类
    /// </summary>
    public abstract class SmartRouter
    {
        /// <summary>
        /// 同步对象
        /// </summary>
        protected object SyncRoot = new object();

        /// <summary>
        /// 当前的处理器
        /// </summary>
        protected SmartProcessor current;

        /// <summary>
        /// 处理器列表
        /// </summary>
        protected List<SmartProcessor> processors = new List<SmartProcessor>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">路由器名称</param>
        /// <param name="processors">处理器数组</param>
        protected SmartRouter(string name = null, IEnumerable<SmartProcessor> processors = null)
        {
            Name = name ?? SmartGuid.NewGuid();
            if (processors != null)
            {
                this.processors.AddRange(processors);
            }
        }

        /// <summary>
        /// 路由器名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取当前的处理器
        /// </summary>
        public SmartProcessor Current { get { return current; } private set { current = value; } }

        /// <summary>
        /// 获取处理器的数量
        /// </summary>
        public int Count { get { return processors.Count; } }

        /// <summary>
        /// 只读处理器组
        /// </summary>
        public ReadOnlyCollection<SmartProcessor> Processors { get { return processors.AsReadOnly(); } }

        /// <summary>
        /// 增加处理器
        /// </summary>
        /// <param name="processor">处理器</param>
        public virtual void Add(SmartProcessor processor)
        {
            lock (SyncRoot)
            {
                processors.Add(processor);
            }
        }

        /// <summary>
        /// 增加多个处理器
        /// </summary>
        /// <param name="processors">处理器</param>
        public virtual void AddRange(IEnumerable<SmartProcessor> processors)
        {
            lock (SyncRoot)
            {
                this.processors.AddRange(processors);
            }
        }

        /// <summary>
        /// 通过name删除处理器
        /// </summary>
        /// <param name="name">处理器的name</param>
        public virtual void Remove(string name)
        {
            lock (SyncRoot)
            {
                processors.FindAll(processor => processor.Name == name).ForEach(processor => processors.Remove(processor));
            }
        }

        /// <summary>
        /// 清除掉全部处理器
        /// </summary>
        public virtual void Clear()
        {
            lock (SyncRoot)
            {
                processors.Clear();
            }
        }

        /// <summary>
        /// 判等方法
        /// </summary>
        /// <param name="obj">待比较的对象</param>
        /// <returns>是否相等</returns>
        public override bool Equals(object obj)
        {
            var other = obj as SmartRouter;
            if (other == null)
            {
                return false;
            }
            return Name == other.Name;
        }

        /// <summary>
        /// 获得哈希码
        /// </summary>
        /// <returns>哈希码</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// 产生当前的路由器
        /// </summary>
        /// <param name="parameter">可能用到的参数</param>
        /// <returns>当前的处理器</returns>
        public abstract SmartProcessor Generate(int? parameter = null);
    }
}