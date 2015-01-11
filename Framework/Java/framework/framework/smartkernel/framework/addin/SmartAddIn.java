/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.addin;

import java.util.*;

import smartkernel.framework.*;

/**
 * 插件程序集辅助操作
 * 
 */
public class SmartAddIn {
	/**
	 * 创建插件对象，插件对象为dynamic对象，方法调用由客户端来决定
	 * 
	 * @param assemblyFilePath
	 *            ，程序集
	 * @return，插件对象列表
	 */
	public static ArrayList<Object> createInstances(String assemblyFilePath) {
		ArrayList<Object> result = new ArrayList<Object>();

		ArrayList<Class<?>> cs = SmartJar.getAllClasses(assemblyFilePath);
		cs.forEach((c) -> {
			try {
				SmartAddInAttribute addInAttribute = c
						.getAnnotation(SmartAddInAttribute.class);
				if (addInAttribute != null) {
					result.add(c.newInstance());
				}
			} catch (Exception err) {
				throw new RuntimeException(err);
			}

		});
		return result;
	}

	/**
	 * 获得插件的特性信息
	 * 
	 * @param obj
	 *            ，插件对象
	 * @return，特性对象
	 */
	public static SmartAddInAttribute getAttribute(Object obj) {
		return obj.getClass().getAnnotation(SmartAddInAttribute.class);
	}
}
