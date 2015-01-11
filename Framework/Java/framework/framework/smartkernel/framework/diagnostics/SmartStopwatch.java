/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.diagnostics;

import smartkernel.framework.*;

/**
 * 计时器
 * 
 */
public class SmartStopwatch {
	/**
	 * 运行
	 * 
	 * @param invokeFunc
	 *            ，行为
	 * @return，结果
	 */
	public static double execute(ISmartInvokeFunc invokeFunc) {

		long startTime = System.nanoTime();
		invokeFunc.invoke();
		long endTime = System.nanoTime();

		return (double) (endTime - startTime) / (double) (100000000);
	}
}
