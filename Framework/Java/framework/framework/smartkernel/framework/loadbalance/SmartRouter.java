/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.loadbalance;

import java.util.*;

import smartkernel.framework.SmartGuid;

/**
 * 负载均衡路由器的抽象基类
 * 
 */
public abstract class SmartRouter {
	/**
	 * 同步对象
	 */
	protected Object SyncRoot = new Object();

	/**
	 * 当前的处理器
	 */
	protected SmartProcessor current;

	/**
	 * 当前的处理器
	 * 
	 * @return，当前的处理器
	 */
	public SmartProcessor getCurrent() {
		return current;
	}

	/**
	 * 处理器列表
	 */
	protected ArrayList<SmartProcessor> processors = new ArrayList<SmartProcessor>();

	private String name;

	/**
	 * 路由器名称
	 * 
	 * @return，路由器名称
	 */
	public String getName() {
		return name;
	}

	/**
	 * 获取处理器的数量
	 * 
	 * @return，处理器的数量
	 */
	public int getCount() {
		return processors.size();
	}

	/**
	 * 只读处理器组
	 * 
	 * @return，只读处理器组
	 */
	public ArrayList<SmartProcessor> getProcessors() {
		return processors;
	}

	/**
	 * 增加处理器
	 * 
	 * @param processor
	 *            ，处理器
	 */
	public void add(SmartProcessor processor) {
		synchronized (SyncRoot) {
			processors.add(processor);
		}
	}

	/**
	 * 增加多个处理器
	 * 
	 * @param processors
	 *            ，处理器
	 */
	public void addRange(ArrayList<SmartProcessor> processors) {
		synchronized (SyncRoot) {
			this.processors.addAll(processors);
		}
	}

	/**
	 * 通过name删除处理器
	 * 
	 * @param name
	 *            ，处理器的name
	 */
	public void remove(String name) {
		synchronized (SyncRoot) {
			SmartProcessor find = null;
			for (SmartProcessor item : this.processors) {
				if (item.getName().equals(name)) {
					find = item;
					break;
				}
			}
			if (find != null) {
				this.processors.remove(find);
			}
		}
	}

	/**
	 * 清除掉全部处理器
	 */
	public void clear() {
		synchronized (SyncRoot) {
			processors.clear();
		}
	}

	/**
	 * 产生当前的路由器
	 * 
	 * @param parameter
	 *            ，可能用到的参数
	 * @return，当前的处理器
	 */
	public abstract SmartProcessor generate(int parameter);

	/**
	 * 产生当前的路由器
	 * 
	 * @return，当前的处理器
	 */
	public abstract SmartProcessor generate();

	@Override
	public int hashCode() {
		return this.name.hashCode();
	}

	@Override
	public boolean equals(Object obj) {
		SmartRouter other = (SmartRouter) obj;
		if (other == null) {
			return false;
		}
		return this.name.equals(other.name);
	}

	/**
	 * 构造函数
	 * 
	 * @param name
	 *            ，路由器名称
	 * @param processors
	 *            ，处理器数组
	 */
	protected SmartRouter(String name, ArrayList<SmartProcessor> processors) {
		this.name = name == null ? SmartGuid.newGuid() : name;
		if (processors != null) {
			this.processors.addAll(processors);
		}
	}

	/**
	 * 构造函数
	 * 
	 * @param name
	 *            ，路由器名称
	 */
	protected SmartRouter(String name) {
		this(name, null);
	}

	/**
	 * 构造函数
	 */
	protected SmartRouter() {
		this(null, null);
	}
}
