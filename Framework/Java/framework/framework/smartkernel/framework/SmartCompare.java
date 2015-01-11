/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * 比较
 * 
 */
public class SmartCompare {
	/**
	 * 判断一个值是否在一个值范围内
	 * 
	 * @param input
	 *            ，输入
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static <T extends Comparable<T>> boolean inScope(T input, T start,
			T end) {
		return input.compareTo(start) >= 0 && input.compareTo(end) <= 0;
	}

	/**
	 * 判断一个值是否不在一个值范围内
	 * 
	 * @param input
	 *            ，输入
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static <T extends Comparable<T>> boolean notInScope(T input,
			T start, T end) {
		return !inScope(input, start, end);
	}

	/**
	 * 判断一个值是否在一个值范围内（有一个在其范围内即为真）
	 * 
	 * @param inputs
	 *            ，输入
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static <T extends Comparable<T>> boolean anyInScope(
			ArrayList<T> inputs, T start, T end) {
		for (T input : inputs) {
			if (inScope(input, start, end)) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 判断一个值是否不在一个值范围内（有一个在其范围内即为假）
	 * 
	 * @param inputs
	 *            ，输入
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static <T extends Comparable<T>> boolean notAnyInScope(
			ArrayList<T> inputs, T start, T end) {
		return !anyInScope(inputs, start, end);
	}

	/**
	 * 判断一个值是否在一个值范围内（有一个在其范围内即为真）
	 * 
	 * @param inputs
	 *            ，输入
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static <T extends Comparable<T>> boolean allInScope(
			ArrayList<T> inputs, T start, T end) {
		for (T input : inputs) {
			if (!inScope(input, start, end)) {
				return false;
			}
		}
		return true;
	}

	/**
	 * 判断一个值是否不在一个值范围内（有一个在其范围内即为假）
	 * 
	 * @param inputs
	 *            ，输入
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static <T extends Comparable<T>> boolean notAllInScope(
			ArrayList<T> inputs, T start, T end) {
		return !allInScope(inputs, start, end);
	}
}
