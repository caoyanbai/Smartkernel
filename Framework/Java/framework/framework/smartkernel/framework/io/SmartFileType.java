/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

/**
 * 文件类型
 * 
 */
public enum SmartFileType {
	/**
	 * 文本文件
	 */
	Text(1),
	/**
	 * 压缩文件
	 */
	GZip(2);

	private int value;

	private SmartFileType(int value) {
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
