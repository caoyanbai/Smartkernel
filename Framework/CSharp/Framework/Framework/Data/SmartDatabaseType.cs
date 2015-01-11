/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
namespace Smartkernel.Framework.Data
{
	/// <summary>
	/// 数据库类型
	/// </summary>
	public enum SmartDatabaseType
	{
		/// <summary>
		/// OleDb数据库
		/// </summary>
		OleDb = 1,

		/// <summary>
		/// SqlServer数据库
		/// </summary>
		SqlServer = 2,

		/// <summary>
		/// SQLite数据库
		/// </summary>
		SQLite = 3,

		/// <summary>
		/// MySql数据库
		/// </summary>
		MySql = 4,

		/// <summary>
		/// Oracle数据库
		/// </summary>
		Oracle = 5,

		/// <summary>
		/// SqlCe数据库
		/// </summary>
		SqlCe = 6,

		/// <summary>
		/// Odbc数据库
		/// </summary>
		Odbc = 7
	}
}
