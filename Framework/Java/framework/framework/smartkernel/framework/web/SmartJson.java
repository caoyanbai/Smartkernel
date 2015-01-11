/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

import smartkernel.framework.*;
import net.sf.json.*;

/**
 * Json格式数据处理
 * 
 */
public class SmartJson {
	/**
	 * 将对象序列化为Json格式的字符串
	 * 
	 * @param source
	 *            ，源类型对象
	 * @return，Json格式的字符串
	 */
	public static String toJson(Object source) {
		return JSONObject.fromObject(source).toString();
	}

	/**
	 * 将Json格式的数据转换为对象
	 * 
	 * @param json
	 *            ，json格式的字符串
	 * @param beanClass
	 *            ，要转换的类型
	 * @return，序列化之后的格式
	 */
	@SuppressWarnings("rawtypes")
	public static Object fromJson(String json, Class beanClass) {
		JSONObject jsonObject = JSONObject.fromObject(json);
		return JSONObject.toBean(jsonObject, beanClass);
	}

	/**
	 * 判断是否相等
	 * 
	 * @param a
	 *            ，a
	 * @param b
	 *            ，b
	 * @return，结果
	 */
	public static boolean jsonEquals(Object a, Object b) {
		return toJson(a).equals(toJson(b));
	}

	/**
	 * 获得安全字符串
	 * 
	 * @param input，输入
	 * @return，结果
	 */
	@SuppressWarnings("unchecked")
	public static String getSafeJson(String input) {
		if (input == null || input.isEmpty()) {
			return "";
		}

		SmartRef<String> ref = new SmartRef<String>();
		ref.setValue(input);

		return ((SmartRef<String>) fromJson(toJson(ref), ref.getClass()))
				.getValue();
	}
}
