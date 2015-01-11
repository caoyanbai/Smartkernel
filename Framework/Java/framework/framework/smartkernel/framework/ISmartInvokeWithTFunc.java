/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * ISmartInvokeWithTFunc
 *
 * @param <T>，类型
 */
public interface ISmartInvokeWithTFunc<T> {
	/**
	 * 运行
	 */
	void invoke(T param1);
}
