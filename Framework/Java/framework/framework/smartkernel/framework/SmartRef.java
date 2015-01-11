/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * 引用类型包装
 * 
 * @param <T>，被包装的类型
 */
public class SmartRef<T> {
	private T value;

	/**
	 * 构造函数
	 * 
	 * @param value
	 *            ，值
	 */
	public SmartRef(T value) {
		this.value = value;
	}

	/**
	 * 构造函数
	 * 
	 */
	public SmartRef() {

	}

	/**
	 * 设置值
	 * 
	 * @param value
	 *            ，值
	 */
	public void setValue(T value) {
		this.value = value;
	}

	/**
	 * 获取值
	 * 
	 * @return，值
	 */
	public T getValue() {
		return this.value;
	}
}
