/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.loadbalance;

import smartkernel.framework.*;

/**
 * 处理器
 * 
 */
public class SmartProcessor {
	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，主机信息
	 */
	public SmartProcessor(Object host) {
		this(host, null);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，主机信息
	 * @param name
	 *            ，处理器的名称
	 */
	public SmartProcessor(Object host, String name) {
		name = name == null ? SmartGuid.newGuid() : name;
		this.name = name;
		this.host = host;
	}

	private String name;

	private Object host;

	/**
	 * 获取处理器的名称
	 * 
	 * @return，处理器的名称
	 */
	public String getName() {
		return name;
	}

	/**
	 * 获取主机信息
	 * 
	 * @return，主机信息
	 */
	public Object getHost() {
		return host;
	}

	@Override
	public int hashCode() {
		return this.name.hashCode();
	}

	@Override
	public boolean equals(Object obj) {
		SmartProcessor other = (SmartProcessor) obj;
		if (other == null) {
			return false;
		}
		return this.name.equals(other.name);
	}

}
