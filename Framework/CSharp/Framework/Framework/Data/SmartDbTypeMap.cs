/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
namespace Smartkernel.Framework.Data
{
	/// <summary>
	/// Db类型映射
	/// </summary>
	public static class SmartDbTypeMap
	{
		/// <summary>
		/// 映射
		/// </summary>
		/// <param name="dbType">数据库类型</param>
		/// <returns>.NET类型</returns>
		public static string Map(string dbType)
		{
			switch (dbType)
			{
				case "bigint":
					return "long";
				case "int":
					return "int";
				case "tinyint":
					return "byte";
				case "bit":
					return "bool";
				case "smalldatetime":
				case "date":
				case "datetime":
					return "DateTime";
				case "decimal":
					return "decimal";
				case "float":
					return "float";
				default:
					return "string";
			}
		}
	}
}
