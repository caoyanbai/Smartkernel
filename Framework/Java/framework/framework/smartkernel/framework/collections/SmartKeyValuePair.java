/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.collections;

/**
 * 键值对
 *
 */
public class SmartKeyValuePair<K, V> {

	/**
	 * 构造函数
	 * 
	 * @param key，Key
	 * @param value，Value
	 */
	public SmartKeyValuePair(K key, V value) {
		this.key = key;
		this.value = value;
	}

	private K key;
	private V value;

	/**
	 * 获取Key
	 * 
	 * @return，Key
	 */
	public K getKey() {
		return key;
	}

	/**
	 * 设置Key
	 * 
	 * @param key
	 *            ，Key
	 */
	public void setKey(K key) {
		this.key = key;
	}

	/**
	 * 获取Value
	 * 
	 * @return，Value
	 */
	public V getValue() {
		return value;
	}

	/**
	 * 设置Value
	 * 
	 * @param value
	 *            ，Value
	 */
	public void setValue(V value) {
		this.value = value;
	}

	@SuppressWarnings("unchecked")
	@Override
	public boolean equals(Object arg0) {
		if (arg0 == null) {
			return false;
		}

		SmartKeyValuePair<K, V> other = (SmartKeyValuePair<K, V>) arg0;
		return this.key.equals(other.key) && this.value.equals(other.value);
	}

	@Override
	public int hashCode() {
		return (this.key.hashCode() + "," + this.value.hashCode()).hashCode();
	}

}
