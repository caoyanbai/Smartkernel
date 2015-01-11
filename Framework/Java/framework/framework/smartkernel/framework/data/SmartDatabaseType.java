/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

/**
 * 数据库类型
 * 
 */
public enum SmartDatabaseType {
	/**
	 * OleDb数据库
	 */
	OleDb(1),

	/**
	 * SqlServer数据库
	 */
	SqlServer(2),

	/**
	 * SQLite数据库
	 */
	SQLite(3),

	/**
	 * MySql数据库
	 */
	MySql(4),

	/**
	 * Oracle数据库
	 */
	Oracle(5),

	/**
	 * SqlCe数据库
	 */
	SqlCe(6),

	/**
	 * Odbc数据库
	 */
	Odbc(7);

	private int value;

	private SmartDatabaseType(int value) {
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
