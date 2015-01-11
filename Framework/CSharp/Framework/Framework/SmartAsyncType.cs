/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
namespace Smartkernel.Framework
{
    /// <summary>
    /// 异步的类型枚举
    /// </summary>
    public enum SmartAsyncType
    {
        /// <summary>
        ///  委托的方式
        /// </summary>
        Delegate,

        /// <summary>
        /// 创建新线程方法
        /// </summary>
        NewThread,

        /// <summary>
        /// 线程池的方式
        /// </summary>
        ThreadPool
    }
}
