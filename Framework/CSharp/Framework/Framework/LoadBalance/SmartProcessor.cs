/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
namespace Smartkernel.Framework.LoadBalance
{
    /// <summary>
    /// 处理器
    /// </summary>
    public class SmartProcessor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">主机信息</param>
        /// <param name="name">处理器的名称</param>
        public SmartProcessor(object host, string name = null)
        {
            name = name ?? SmartGuid.NewGuid();
            Name = name;
            Host = host;
        }

        /// <summary>
        /// 获取或设置处理器的名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取或设置主机信息
        /// </summary>
        public object Host { get; set; }

        /// <summary>
        /// 判等方法
        /// </summary>
        /// <param name="obj">待比较的对象</param>
        /// <returns>是否相等</returns>
        public override bool Equals(object obj)
        {
            var other = obj as SmartProcessor;
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
    }
}