/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.lang.reflect.*;
import java.util.*;

/**
 * 数组
 * 
 */
public class SmartArray {
	/**
	 * 解析为数组
	 * 
	 * @param c
	 *            ，类型
	 * @param value
	 *            ，值
	 * @param split
	 *            ，分割符
	 */
	@SuppressWarnings("unchecked")
	public static <T> T[] parse(Class<T> c, String value, String split) {
		String[] array = null;
		T[] result = null;

		if (!SmartString.isNullOrEmpty(value)) {
			array = value.split(split);
			result = (T[]) Array.newInstance(c, array.length);
			int length = array.length;

			for (int i = 0; i < length; i++) {
				result[i] = (T) SmartConvert.to(array[i].toString(), c);
			}
		}

		return result;
	}

	/**
	 * 解析为数组
	 * 
	 * @param c
	 *            ，类型
	 * @param value
	 *            ，值
	 */
	public static <T> T[] parse(Class<T> c, String value) {
		return parse(c, value, "\\|");
	}

	/**
	 * @param c
	 *            ，类型
	 * @param array
	 *            ，数组
	 * @return，结果
	 */
	@SuppressWarnings("unchecked")
	public static <T> T[] to(Class<T> c, Object[] array) {
		T[] result = null;

		result = (T[]) Array.newInstance(c, array.length);
		int length = array.length;

		for (int i = 0; i < length; i++) {
			result[i] = (T) SmartConvert.to(array[i].toString(), c);
		}

		return result;
	}

	/**
	 * 求交集
	 * 
	 * @param left
	 *            ，左
	 * @param right
	 *            ，右
	 * @return，结果
	 */
	public static <T> ArrayList<T> intersect(ArrayList<T> left,
			ArrayList<T> right) {
		ArrayList<T> result = new ArrayList<T>();
		for (T item : left) {
			if (right.contains(item) && !result.contains(item)) {
				result.add(item);
			}
		}
		return result;
	}

	/**
	 * 求并集
	 * 
	 * @param left
	 *            ，左
	 * @param right
	 *            ，右
	 * @return，结果
	 */
	public static <T> ArrayList<T> union(ArrayList<T> left, ArrayList<T> right) {
		ArrayList<T> result = new ArrayList<T>();
		for (T item : left) {
			if (!result.contains(item)) {
				result.add(item);
			}
		}
		for (T item : right) {
			if (!result.contains(item)) {
				result.add(item);
			}
		}
		return result;
	}

	/**
	 * 列表转换为数组
	 * 
	 * @param list
	 *            ，列表
	 * @return，结果
	 */
	@SuppressWarnings("unchecked")
	public static <T> T[] toArray(ArrayList<T> list) {
		if (list == null || list.isEmpty()) {
			return null;
		} else {
			T[] result = (T[]) Array.newInstance(list.get(0).getClass(),
					list.size());
			return result;
		}
	}

	/**
	 * 转换为列表
	 * 
	 * @param array，数组
	 * @return，结果
	 */
	public static <T> ArrayList<T> toList(T[] array) {
		ArrayList<T> list = new ArrayList<T>();
		for (T t : array) {
			list.add(t);
		}

		return list;
	}
}
