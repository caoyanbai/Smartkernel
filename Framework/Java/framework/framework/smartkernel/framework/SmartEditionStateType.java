/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * 版本状态类型
 * 
 */
public enum SmartEditionStateType {
	/**
	 * 调试
	 */
	Debug(1),

	/**
	 * 发布
	 */
	Release(2);

	private int value;

	private SmartEditionStateType(int value) {
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
