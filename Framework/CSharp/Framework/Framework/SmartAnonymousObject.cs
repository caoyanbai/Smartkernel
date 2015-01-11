/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
namespace Smartkernel.Framework
{
    /// <summary>
    /// 匿名类型
    /// </summary>
    public static class SmartAnonymousObject
    {
        /// <summary>
        /// 复活匿名类型，匿名类型是private的，跨越程序集是无法访问的，通过这个方法可以复活另外一个程序集传递过来的匿名对象
        /// </summary>
        /// <typeparam name="TLocal">匿名类型，不需要实际传递这个类型</typeparam>
        /// <param name="obj">从其他程序集传递过来的匿名对象</param>
        /// <param name="local">本地匿名对象（匿名对象只要属性相同，就认为是相同的匿名对象）</param>
        /// <returns>复活之后的本地匿名类型实例</returns>
        public static TLocal Relive<TLocal>(object obj, TLocal local)
        {
            return (TLocal)obj;
        }
    }
}
