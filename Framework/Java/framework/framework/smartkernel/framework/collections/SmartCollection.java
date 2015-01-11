/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.collections;

import java.util.*;

import smartkernel.framework.*;

/**
 * 集合类的辅助工具
 * 
 */
public class SmartCollection {
	/**
	 * 将多个枚举类型合并成一个
	 * 
	 * @param lists
	 *            ，类型
	 * @return，多个枚举类型
	 */
	public static <T> List<T> unionAll(List<List<T>> lists) {
		List<T> result = new ArrayList<T>();

		if (lists != null) {
			for (List<T> list : lists) {
				if (list != null) {
					for (T item : list) {
						result.add(item);
					}
				}
			}
		}

		return result;
	}

	/**
	 * 判断集合是否为空或null
	 * 
	 * @param list
	 *            ，集合
	 * @return，是否为空
	 */
	public static boolean isNullOrEmpty(Collection<?> list) {
		return list == null || list.size() == 0;
	}

	/**
	 * 随机排序
	 * 
	 * @param list
	 *            ，列表
	 */
	public static <T> void randomSort(List<T> list) {
		List<T> temp = new ArrayList<T>();
		for (T item : list) {
			int index = SmartRandom.nextInt(0, temp.size());
			temp.add(index, item);
		}
		list.clear();
		list.addAll(temp);
	}

	/**
	 * 获得集合的字符串表示
	 * 
	 * @param list
	 *            ，集合
	 * @param leftEmbodySymbol
	 *            ，左包含符
	 * @param rightEmbodySymbol
	 *            ，右包含符
	 * @param splitSymbol
	 *            ，分隔符
	 * @return，字符串表示
	 */
	public static String toJoinString(ArrayList<?> list,
			String leftEmbodySymbol, String rightEmbodySymbol,
			String splitSymbol) {
		ArrayList<String> temp = new ArrayList<String>();
		for (Object current : list) {
			temp.add(leftEmbodySymbol + current.toString() + rightEmbodySymbol);
		}
		int length = temp.size();
		String result = "";
		for (int i = 0; i < length; i++) {
			String current = temp.get(i);
			if (i == length - 1) {
				result += current;
			} else {
				result += current + splitSymbol;
			}
		}
		return result;
	}

	/**
	 * 获得集合的字符串表示
	 * 
	 * @param list
	 *            ，集合
	 * @param leftEmbodySymbol
	 *            ，左包含符
	 * @param rightEmbodySymbol
	 *            ，右包含符
	 * @return，字符串表示
	 */
	public static String toJoinString(ArrayList<?> list,
			String leftEmbodySymbol, String rightEmbodySymbol) {
		return toJoinString(list, leftEmbodySymbol, rightEmbodySymbol, "|");
	}

	/**
	 * 获得集合的字符串表示
	 * 
	 * @param list
	 *            ，集合
	 * @param leftEmbodySymbol
	 *            ，左包含符
	 * @return，字符串表示
	 */
	public static String toJoinString(ArrayList<?> list, String leftEmbodySymbol) {
		return toJoinString(list, leftEmbodySymbol, "'", "|");
	}

	/**
	 * 获得集合的字符串表示
	 * 
	 * @param list
	 *            ，集合
	 * @return，字符串表示
	 */
	public static String toJoinString(ArrayList<?> list) {
		return toJoinString(list, "'", "'", "|");
	}

	/**
	 * 判断两个枚举类型是否相同，且具有相同数量的元素（每一个位置的值都相同）
	 * 
	 * @param source
	 *            ，源
	 * @param target
	 *            ，目标
	 * @return，是否相等
	 */
	public static boolean equalsByEachOne(ArrayList<?> source,
			ArrayList<?> target) {
		if (source == target) {
			return true;
		}

		if (source == null || target == null) {
			return false;
		}

		Iterator<?> sourceEnumerator = source.iterator();
		Iterator<?> targetEnumerator = source.iterator();

		boolean sourceHasValue = sourceEnumerator.hasNext();
		boolean targetHasValue = targetEnumerator.hasNext();

		while (sourceHasValue && targetHasValue) {
			if (!sourceEnumerator.next().equals(targetEnumerator.next())) {
				return false;
			}

			sourceHasValue = sourceEnumerator.hasNext();
			targetHasValue = targetEnumerator.hasNext();
		}

		// 如果为false，说明元素数量不相等
		return !(sourceHasValue || targetHasValue);
	}
}
