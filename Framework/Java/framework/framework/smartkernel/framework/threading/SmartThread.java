/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.threading;

/**
 * 线程
 * 
 */
public class SmartThread {

	/**
	 * @param millis
	 *            ，时间（毫秒）
	 */
	public static void sleep(long millis) {
		try {
			Thread.sleep(millis);
		} catch (Exception err) {
		}
	}
}
