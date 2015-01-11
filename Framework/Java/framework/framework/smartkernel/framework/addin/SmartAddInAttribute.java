/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.addin;

import java.lang.annotation.*;

/**
 * 插件的标识特性，实现插件类型时必须使用此标识
 * 
 */
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.TYPE)
public @interface SmartAddInAttribute {

}
