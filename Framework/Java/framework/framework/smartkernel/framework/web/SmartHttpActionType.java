/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

/**
 * 请求动作类型
 * 
 */
public enum SmartHttpActionType {
	/**
	 * Get方法
	 */
	Get(1),
	/**
	 * Post方法
	 */
	Post(2);

	private int value;

	private SmartHttpActionType(int value) {
		this.value = value;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.lang.Enum#toString()
	 */
	public String toString() {
		return String.valueOf(this.value);
	}
}
