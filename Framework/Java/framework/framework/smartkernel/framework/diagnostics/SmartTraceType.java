/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.diagnostics;

/**
 * 追踪类型
 * 
 */
public enum SmartTraceType {
	/**
	 * 命令行
	 */
	Console(1),

	/**
	 * 日志
	 */
	Log(2);

	private int value;

	private SmartTraceType(int value) {
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
