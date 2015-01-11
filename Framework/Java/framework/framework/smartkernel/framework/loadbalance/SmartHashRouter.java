/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.loadbalance;

import java.util.*;

/**
 * 负载均衡哈希路由器，根据哈希码计算分布到哪个处理器上进行处理。是线程安全的
 * 
 */
public class SmartHashRouter extends SmartRouter {
	/**
	 * 构造函数
	 * 
	 * @param name
	 *            ，路由器名称
	 * @param processors
	 *            ，处理器数组
	 */
	public SmartHashRouter(String name, ArrayList<SmartProcessor> processors) {
		super(name, processors);
	}

	/**
	 * 构造函数
	 * 
	 * @param name
	 *            ，路由器名称
	 */
	public SmartHashRouter(String name) {
		super(name);
	}

	/**
	 * 构造函数
	 */
	public SmartHashRouter() {
		super();
	}

	@Override
	public SmartProcessor generate(int parameter) {
		int currentIndex = parameter % processors.size();
		// 比Math.abs的性能高一些
		if (currentIndex < 0) {
			currentIndex = -currentIndex;
		}
		current = processors.get(currentIndex);
		return current;
	}

	@Override
	public SmartProcessor generate() {
		throw new RuntimeException("方法不支持！");
	}
}
