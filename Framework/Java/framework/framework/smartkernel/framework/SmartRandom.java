/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * 随机数类，提供多种产生随机数的方式，不光可以产生随机数字，还可以产生随机字符串等任何格式的字符
 * 
 */
public class SmartRandom {

	private static final Random random = new Random(new Long(
			new Date().getTime()).hashCode());

	/**
	 * 产生指定范围的随机数，随机数可以取开始和结束两个边界值
	 * 
	 * @param start
	 *            ，开始边界
	 * @param end
	 *            ，结束边界
	 * @return，随机数
	 */
	public static int nextInt(int start, int end) {
		start = start - 1;
		end = end - 1;

		int length = end - start + 1;

		return random.nextInt(length) + start + 1;
	}

	/**
	 * 产生指定范围的随机数，随机数可以取开始和结束两个边界值
	 * 
	 * @param start
	 *            ，开始边界
	 * @param end
	 *            ，结束边界
	 * @return，随机数
	 */
	public static double nextDouble(double start, double end) {
		double offset = 0;

		if (start < 0) {
			offset = -start + 1;
		}

		start = start + offset;
		end = end + offset;

		int scaleStart = getMaxScaleupMultiple(start);
		int scaleEnd = getMaxScaleupMultiple(end);

		int scaleMin = Math.min(scaleStart, scaleEnd);

		int startInt = (int) (start * scaleMin);
		int endInt = (int) (end * scaleMin);

		int result = nextInt(startInt, endInt);

		return (double) result / (double) scaleMin - offset;
	}

	/**
	 * 获得放大为无小数的整数所需的放大倍数
	 * 
	 * @param number
	 *            ，浮点数
	 * @return，放大倍数
	 */
	private static int getMaxScaleupMultiple(double number) {
		int i = 1;
		try {
			while (number * i < Integer.MAX_VALUE) {
				// Java数值没有溢出检查
				if (i * 10L > Integer.MAX_VALUE) {
					throw new RuntimeException();
				}
				i = i * 10;
			}
		} catch (Exception err) {
		}
		i = i / 10;
		return i;
	}

	/**
	 * 产生指定范围和指定长度的随机字符串，随机字符串的长度不受范围长度的限制
	 * 
	 * @param scope
	 *            ，随机字符串的范围，可以取任何字符串
	 * @param length
	 *            ，需要返回的随机字符串的长度
	 * @return，随机字符串
	 */
	public static String nextString(String scope, int length) {
		char[] chars = scope.toCharArray();
		int maxIndex = scope.length();
		StringBuilder result = new StringBuilder(length);
		for (int i = 0; i < length; i++) {
			result.append(chars[nextInt(0, maxIndex - 1)]);
		}
		return result.toString();
	}

	/**
	 * 获得随机大写字符串，字符串范围ABCDEFGHIJKLMNOPQRSTUVWXYZ
	 * 
	 * @param length
	 *            ，字符串长度
	 * @return，随机字符串
	 */
	public static String nextCapitalString(int length) {
		String scope = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		return nextString(scope, length);
	}

	/**
	 * 生成一个随机数学表达式
	 * 
	 * @param start
	 *            ，表达式中使用数字的左边界，不应该包括0
	 * @param end
	 *            ，表达式中使用数字的右边界，不应该包括0
	 * @param result
	 *            ，表达式的计算结果
	 * @return，生成的随机表达式
	 */
	public static String nextMathExpression(int start, int end,
			SmartRef<Double> result) {
		String expression = String.format("%s %s %s", nextInt(start, end),
				nextString("+-*", 1), nextInt(start, end));
		result.setValue(SmartMath.eval(expression));
		return expression;
	}

	/**
	 * 生成一个随机数学表达式
	 * 
	 * @param start
	 *            ，表达式中使用数字的左边界，不应该包括0
	 * @param end
	 *            ，表达式中使用数字的右边界，不应该包括0
	 * @return，生成的随机表达式
	 */
	public static String nextMathExpression(int start, int end) {
		return nextMathExpression(start, end, new SmartRef<Double>());
	}

	/**
	 * 从列表中获得随机对象
	 * 
	 * @param list
	 *            ，对象列表
	 * @return，随机对象
	 */
	@SuppressWarnings("unchecked")
	public static <T> T nextObject(ArrayList<T> list) {
		Object[] array = list.toArray();
		return (T) array[nextInt(0, array.length - 1)];
	}

	/**
	 * 获得随机布尔值
	 * 
	 * @return，随机布尔值
	 */
	public static boolean nextBool() {
		ArrayList<Boolean> booleans = new ArrayList<Boolean>();
		booleans.add(true);
		booleans.add(false);
		return nextObject(booleans);
	}
}
