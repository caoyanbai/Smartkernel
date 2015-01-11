/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.xml;

import java.lang.annotation.*;

/**
 * XML文件中节点与实体对象字段或属性的映射标识类
 * 
 */
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface SmartNodeMappingAttribute {
	/**
	 * 映射到XML文件中的节点，不区分大小写
	 * 
	 * @return，结果
	 */
	String NodeName();

	/**
	 * 如果XML文件中没有对应的值时，所赋给实体字段或属性的默认值，如果没有设置默认值，则取字段或属性初始化时的默认值
	 * 
	 * @return，结果
	 */
	String DefaultValue();
}
