/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * 容器
 * 
 */
public class SmartContainer {
	private static Object syncObject = new Object();

	private static HashMap<Object, Object> container;

	/**
	 * 静态构造函数
	 * 
	 */
	static {
		container = new HashMap<Object, Object>();
	}

	/**
	 * 增加键值对
	 * 
	 * @param key
	 *            ，键
	 * @param value
	 *            ，值
	 */
	public static <TKey, TValue> void add(TKey key, TValue value) {
		synchronized (syncObject) {
			container.put(key, value);
		}
	}

	/**
	 * 是否包含
	 * 
	 * @param key
	 *            ，键
	 * @return，结果
	 */
	public static <TKey> boolean containsKey(TKey key) {
		return container.containsKey(key);
	}

	/**
	 * 清空容器
	 */
	public static void clear() {
		synchronized (syncObject) {
			container.clear();
		}
	}

	/**
	 * 删除
	 * 
	 * @param key
	 *            ，键
	 */
	public static <TKey> void remove(TKey key) {
		synchronized (syncObject) {
			container.remove(key);
		}
	}

	/**
	 * 获取
	 * 
	 * @param key
	 *            ，键
	 * @return，值
	 */
	@SuppressWarnings("unchecked")
	public static <TKey, TValue> TValue get(TKey key) {
		return (TValue) container.get(key);
	}

	/**
	 * 设置
	 * 
	 * @param key，键
	 * @param value，值
	 */
	public static <TKey, TValue> void set(TKey key, TValue value) {
		synchronized (syncObject) {
			container.put(key, value);
		}
	}
}
