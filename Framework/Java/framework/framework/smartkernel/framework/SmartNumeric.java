/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.math.BigInteger;
import java.text.DecimalFormat;

import smartkernel.framework.text.*;

/**
 * 数字类型相关
 * 
 */
public class SmartNumeric {

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @param compareValue
	 *            ，比较的值
	 * @return，结果
	 */
	public static boolean isZero(double input, double compareValue) {
		return Math.abs(input) < compareValue;
	}

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @return，结果
	 */
	public static boolean isZero(double input) {
		return isZero(input, 2.2204460492503131E-15);
	}

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @param compareValue
	 *            ，比较的值
	 * @return，结果
	 */
	public static boolean isZero(float input, float compareValue) {
		return Math.abs(input) < compareValue;
	}

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @return，结果
	 */
	public static boolean isZero(float input) {
		return isZero(input, 2.2204460492503131E-15);
	}

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @return，结果
	 */
	public static boolean isZero(int input) {
		return input == 0;
	}

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @return，结果
	 */
	public static boolean isZero(long input) {
		return input == 0;
	}

	/**
	 * 是否是0
	 * 
	 * @param input
	 *            ，待检查的数字
	 * @return，结果
	 */
	public static boolean isZero(BigInteger input) {
		return input.equals(BigInteger.ZERO);
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @param compareValue
	 *            ，比较的值
	 * @return，是否相等
	 */
	public static boolean nearEquals(double left, double right,
			double compareValue) {
		if (left == right) {
			return true;
		}
		double a = (Math.abs(left) + Math.abs(right) + 10.0) * compareValue;
		double b = left - right;
		return (-a < b) && (a > b);
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，是否相等
	 */
	public static boolean nearEquals(double left, double right) {
		return nearEquals(left, right, 2.2204460492503131E-16f);
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @param compareValue
	 *            ，比较的值
	 * @return，是否相等
	 */
	public static boolean nearEquals(float left, float right, float compareValue) {
		if (left == right) {
			return true;
		}
		double a = (Math.abs(left) + Math.abs(right) + 10.0) * compareValue;
		double b = left - right;
		return (-a < b) && (a > b);
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，是否相等
	 */
	public static boolean nearEquals(float left, float right) {
		return nearEquals(left, right, 2.2204460492503131E-16f);
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，是否相等
	 */
	public static boolean nearEquals(int left, int right) {
		return left == right;
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，是否相等
	 */
	public static boolean nearEquals(long left, long right) {
		return left == right;
	}

	/**
	 * 近似相等
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，是否相等
	 */
	public static boolean nearEquals(BigInteger left, BigInteger right) {
		return left.equals(right);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @param isLimitTo
	 *            ，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(double number, double from, double to,
			boolean isLimitFrom, boolean isLimitTo) {
		if (from == to) {
			return number == from;
		}

		if (from > to) {
			throw new RuntimeException("左侧边界不能大于右侧边界！");
		}

		if (isLimitFrom && isLimitTo) {
			return from <= number && number <= to;
		} else if (isLimitFrom && !isLimitTo) {
			return from <= number && number < to;
		} else if (!isLimitFrom && isLimitTo) {
			return from < number && number <= to;
		} else {
			return from < number && number < to;
		}
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(double number, double from, double to,
			boolean isLimitFrom) {
		return between(number, from, to, isLimitFrom, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @return，结果
	 */
	public static boolean between(double number, double from, double to) {
		return between(number, from, to, false, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @param isLimitTo
	 *            ，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(float number, float from, float to,
			boolean isLimitFrom, boolean isLimitTo) {
		if (from == to) {
			return number == from;
		}

		if (from > to) {
			throw new RuntimeException("左侧边界不能大于右侧边界！");
		}

		if (isLimitFrom && isLimitTo) {
			return from <= number && number <= to;
		} else if (isLimitFrom && !isLimitTo) {
			return from <= number && number < to;
		} else if (!isLimitFrom && isLimitTo) {
			return from < number && number <= to;
		} else {
			return from < number && number < to;
		}
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(float number, float from, float to,
			boolean isLimitFrom) {
		return between(number, from, to, isLimitFrom, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @return，结果
	 */
	public static boolean between(float number, float from, float to) {
		return between(number, from, to, false, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @param isLimitTo
	 *            ，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(int number, int from, int to,
			boolean isLimitFrom, boolean isLimitTo) {
		if (from == to) {
			return number == from;
		}

		if (from > to) {
			throw new RuntimeException("左侧边界不能大于右侧边界！");
		}

		if (isLimitFrom && isLimitTo) {
			return from <= number && number <= to;
		} else if (isLimitFrom && !isLimitTo) {
			return from <= number && number < to;
		} else if (!isLimitFrom && isLimitTo) {
			return from < number && number <= to;
		} else {
			return from < number && number < to;
		}
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(int number, int from, int to,
			boolean isLimitFrom) {
		return between(number, from, to, isLimitFrom, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @return，结果
	 */
	public static boolean between(int number, int from, int to) {
		return between(number, from, to, false, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @param isLimitTo
	 *            ，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(long number, long from, long to,
			boolean isLimitFrom, boolean isLimitTo) {
		if (from == to) {
			return number == from;
		}

		if (from > to) {
			throw new RuntimeException("左侧边界不能大于右侧边界！");
		}

		if (isLimitFrom && isLimitTo) {
			return from <= number && number <= to;
		} else if (isLimitFrom && !isLimitTo) {
			return from <= number && number < to;
		} else if (!isLimitFrom && isLimitTo) {
			return from < number && number <= to;
		} else {
			return from < number && number < to;
		}
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(long number, long from, long to,
			boolean isLimitFrom) {
		return between(number, from, to, isLimitFrom, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @return，结果
	 */
	public static boolean between(long number, long from, long to) {
		return between(number, from, to, false, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @param isLimitTo
	 *            ，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(BigInteger number, BigInteger from,
			BigInteger to, boolean isLimitFrom, boolean isLimitTo) {
		if (from == to) {
			return number == from;
		}

		if (from.compareTo(to) > 0) {
			throw new RuntimeException("左侧边界不能大于右侧边界！");
		}

		if (isLimitFrom && isLimitTo) {
			return from.compareTo(number) <= 0 && number.compareTo(to) <= 0;
		} else if (isLimitFrom && !isLimitTo) {
			return from.compareTo(number) <= 0 && number.compareTo(to) < 0;
		} else if (!isLimitFrom && isLimitTo) {
			return from.compareTo(number) < 0 && number.compareTo(to) <= 0;
		} else {
			return from.compareTo(number) < 0 && number.compareTo(to) < 0;
		}
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @param isLimitFrom
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(BigInteger number, BigInteger from,
			BigInteger to, boolean isLimitFrom) {
		return between(number, from, to, isLimitFrom, false);
	}

	/**
	 * 是否在两个数字之间
	 * 
	 * @param number
	 *            ，要比较的数字
	 * @param from
	 *            ，开始
	 * @param to
	 *            ，结束
	 * @return，结果
	 */
	public static boolean between(BigInteger number, BigInteger from,
			BigInteger to) {
		return between(number, from, to, false, false);
	}

	/**
	 * 验证是不是Double类型的数字：25，1.23，-10等都是合法的数字
	 * 
	 * @param input
	 *            ，待检查的字符串
	 * @return，验证的结果
	 */
	public static boolean isDouble(String input) {
		try {
			Double.parseDouble(input);
			return true;
		} catch (Exception err) {
			return false;
		}
	}

	/**
	 * 验证是不是正整数：大于0的整数（2.0，+32.0,3.也判断为正整数）
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isPositiveInteger(String input) {
		String pattern1 = "^[+]?[0-9]+[.]?[0]*$";
		String pattern2 = "^[+-]?[0]+[.]?[0]*$";
		return isDouble(input)
				&& Double.parseDouble(input) > 0
				&& (SmartRegex.isMatch(input, pattern1) || SmartRegex.isMatch(
						input, pattern2));
	}

	/**
	 * 验证是不是整数：可以为正也可以为负（0.0，2.0，+32.0，-123.00000，3.也判断为整数）
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isInteger(String input) {
		String pattern = "^[+-]?[0-9]+[.]?[0]*$";
		return SmartRegex.isMatch(input, pattern);
	}

	/**
	 * 验证是不是数字
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isNumberic(String input) {
		return isDouble(input);
	}

	/**
	 * 验证小数位数是不是在指定的范围内
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @param start
	 *            ，起始边界
	 * @param end
	 *            ，结束边界
	 * @return，验证的结果
	 */
	public static boolean isDecimalDigitsBetween(String input, int start,
			int end) {
		String pattern = String.format("^[+-]?[0-9]+(.[0-9]{{%s,%s}})$", start,
				end);
		return SmartRegex.isMatch(input, pattern);
	}

	/**
	 * 验证小数位数是不是指定的长度
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @param length
	 *            ，指定的长度
	 * @return，验证的结果
	 */
	public static boolean isDecimalDigits(String input, int length) {
		String pattern = String.format("^[+-]?[0-9]+(.[0-9]{{%s}})$", length);
		return SmartRegex.isMatch(input, pattern);
	}

	/**
	 * 格式化字符串
	 * 
	 * @param number，数字
	 * @param format，格式
	 * @return，结果
	 */
	public static String toString(double number, String format) {
		DecimalFormat decimalFormat = new DecimalFormat(format);
		return decimalFormat.format(number);
	}
}
