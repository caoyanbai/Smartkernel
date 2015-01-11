/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

/**
 * 查询选项类型
 * 
 */
public enum SmartSearchOptionType {
	/**
	 * 顶层目录
	 */
	TopDirectoryOnly(0),
	/**
	 * 全部目录
	 */
	AllDirectories(1);

	private int value;

	private SmartSearchOptionType(int value) {
		this.value = value;
	}

	/* (non-Javadoc)
	 * @see java.lang.Enum#toString()
	 */
	public String toString() {
		return String.valueOf(this.value);
	}
}
