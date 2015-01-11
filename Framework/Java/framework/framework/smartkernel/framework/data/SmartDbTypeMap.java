/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

/**
 * Db类型映射
 * 
 */
public class SmartDbTypeMap {
	/**
	 * 映射
	 * 
	 * @param dbType
	 *            ，数据库类型
	 * @return，.NET类型
	 */
	public static String map(String dbType) {
		switch (dbType) {
		case "bigint":
			return "long";
		case "int":
			return "int";
		case "tinyint":
			return "byte";
		case "bit":
			return "boolean";
		case "smalldatetime":
		case "date":
		case "datetime":
			return "Date";
		case "decimal":
			return "BigDecimal";
		case "double":
			return "double";
		case "float":
			return "float";
		default:
			return "String";
		}
	}
}
