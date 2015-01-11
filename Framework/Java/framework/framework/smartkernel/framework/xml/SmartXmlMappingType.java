/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.xml;

/**
 * 平面文件数据与对象映射依据的类型枚举，例如数据库字段与对象的映射，可通过特性标识、属性或字段
 * 
 */
public enum SmartXmlMappingType {

	/**
	 * 根据特性标识
	 */
	Attribute,

	/**
	 * 根据字段，字段可以是公有也可以是私有
	 */
	Field,

	/**
	 * 自动（按照特性、属性和字段的顺序）
	 */
	Auto
}
