/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.Map.*;

/**
 * 
 * 
 */
/**
 * ISmartInvokeWithEntryFunc
 *
 * @param <K>，K的类型
 * @param <V>，V的类型
 */
public interface ISmartInvokeWithEntryFunc<K, V> {
	/**
	 * 运行
	 */
	void invoke(Entry<K, V> param1);
}
