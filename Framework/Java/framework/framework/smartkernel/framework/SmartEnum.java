/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * 枚举辅助操作类
 * 
 */
public class SmartEnum {
	/**
	 * 将字符串表示形式的枚举解析成枚举类型
	 * 
	 * @param type
	 *            ，枚举类型
	 * @param value
	 *            ，字符串表示形式
	 * @return，解析的结果
	 */
	public static <T extends Enum<T>> T parse(Class<T> type, String value) {
		ArrayList<T> list = SmartEnum.getAll(type);
		for (T one : list) {
			if (one.name().equalsIgnoreCase(value)) {
				return (T) one;
			}
		}
		throw new RuntimeException("枚举值不存在！");
	}

	/**
	 * 获得某种枚举类型下的所有枚举值
	 * 
	 * @param type
	 *            ，枚举类型
	 * @return，所有值
	 */
	public static <T extends Enum<T>> ArrayList<T> getAll(Class<T> type) {
		ArrayList<T> values = new ArrayList<T>();

		Iterator<T> iterator = EnumSet.allOf(type).iterator();
		while (iterator.hasNext()) {
			String currentString = iterator.next().name();
			values.add((T) Enum.valueOf(type, currentString));
		}
		return values;
	}
}
