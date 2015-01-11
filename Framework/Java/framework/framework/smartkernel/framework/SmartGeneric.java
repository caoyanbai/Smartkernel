/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.math.*;

/**
 * 泛型相关
 * 
 */
public class SmartGeneric {
	/**
	 * 加号（+），将返回为左操作数类型的结果
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，相加的和
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T add(T left, T right) {
		if (left instanceof BigDecimal) {
			return (T) (((BigDecimal) left).add((BigDecimal) right));
		} else if (left instanceof BigInteger) {
			return (T) (((BigInteger) left).add((BigInteger) right));
		} else if (left instanceof Byte) {
			return (T) (Object) ((Byte) left + (Byte) right);
		} else if (left instanceof Double) {
			return (T) (Object) ((Double) left + (Double) right);
		} else if (left instanceof Float) {
			return (T) (Object) ((Float) left + (Float) right);
		} else if (left instanceof Integer) {
			return (T) (Object) ((Integer) left + (Integer) right);
		} else if (left instanceof Long) {
			return (T) (Object) ((Long) left + (Long) right);
		} else if (left instanceof Short) {
			return (T) (Object) ((Short) left + (Short) right);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 减号（-），将返回为左操作数类型的结果
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，相减的差
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T subtract(T left, T right) {
		if (left instanceof BigDecimal) {
			return (T) (((BigDecimal) left).subtract((BigDecimal) right));
		} else if (left instanceof BigInteger) {
			return (T) (((BigInteger) left).subtract((BigInteger) right));
		} else if (left instanceof Byte) {
			return (T) (Object) ((Byte) left - (Byte) right);
		} else if (left instanceof Double) {
			return (T) (Object) ((Double) left - (Double) right);
		} else if (left instanceof Float) {
			return (T) (Object) ((Float) left - (Float) right);
		} else if (left instanceof Integer) {
			return (T) (Object) ((Integer) left - (Integer) right);
		} else if (left instanceof Long) {
			return (T) (Object) ((Long) left - (Long) right);
		} else if (left instanceof Short) {
			return (T) (Object) ((Short) left - (Short) right);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 乘号（×），将返回为左操作数类型的结果
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，相乘的积
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T multiply(T left, T right) {
		if (left instanceof BigDecimal) {
			return (T) (((BigDecimal) left).multiply((BigDecimal) right));
		} else if (left instanceof BigInteger) {
			return (T) (((BigInteger) left).multiply((BigInteger) right));
		} else if (left instanceof Byte) {
			return (T) (Object) ((Byte) left * (Byte) right);
		} else if (left instanceof Double) {
			return (T) (Object) ((Double) left * (Double) right);
		} else if (left instanceof Float) {
			return (T) (Object) ((Float) left * (Float) right);
		} else if (left instanceof Integer) {
			return (T) (Object) ((Integer) left * (Integer) right);
		} else if (left instanceof Long) {
			return (T) (Object) ((Long) left * (Long) right);
		} else if (left instanceof Short) {
			return (T) (Object) ((Short) left * (Short) right);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 除号（／），将返回为左操作数类型的结果
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，相除的商
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T divide(T left, T right) {
		if (left instanceof BigDecimal) {
			return (T) (((BigDecimal) left).divide((BigDecimal) right));
		} else if (left instanceof BigInteger) {
			return (T) (((BigInteger) left).divide((BigInteger) right));
		} else if (left instanceof Byte) {
			return (T) (Object) ((Byte) left / (Byte) right);
		} else if (left instanceof Double) {
			return (T) (Object) ((Double) left / (Double) right);
		} else if (left instanceof Float) {
			return (T) (Object) ((Float) left / (Float) right);
		} else if (left instanceof Integer) {
			return (T) (Object) ((Integer) left / (Integer) right);
		} else if (left instanceof Long) {
			return (T) (Object) ((Long) left / (Long) right);
		} else if (left instanceof Short) {
			return (T) (Object) ((Short) left / (Short) right);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 大于号（＞），左操作数是否大于右操作数
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，比较的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> boolean moreThan(T left, T right) {
		Comparable<T> leftTemp = (Comparable<T>) left;
		return leftTemp.compareTo(right) > 0;
	}

	/**
	 * 小于号（＜），左操作数是否小于右操作数
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，比较的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> boolean lessThan(T left, T right) {
		Comparable<T> leftTemp = (Comparable<T>) left;
		return leftTemp.compareTo(right) < 0;
	}

	/**
	 * 大于等于号（≥），左操作数是否大于等于右操作数
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，比较的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> boolean moreThanOrEquals(T left, T right) {
		Comparable<T> leftTemp = (Comparable<T>) left;
		return leftTemp.compareTo(right) >= 0;
	}

	/**
	 * 小于等于号（≤），左操作数是否小于等于右操作数
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，比较的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> boolean lessThanOrEquals(T left, T right) {
		Comparable<T> leftTemp = (Comparable<T>) left;
		return leftTemp.compareTo(right) <= 0;
	}

	/**
	 * 等于号（＝＝），左操作数是否等于右操作数
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，比较的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> boolean equals(T left, T right) {
		Comparable<T> leftTemp = (Comparable<T>) left;
		return leftTemp.compareTo(right) == 0;
	}

	/**
	 * 不等于号（!＝），左操作数是否不等于右操作数
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，比较的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> boolean notEquals(T left, T right) {
		Comparable<T> leftTemp = (Comparable<T>) left;
		return leftTemp.compareTo(right) != 0;
	}

	/**
	 * 求余数（%），将返回为左操作数类型的结果
	 * 
	 * @param left
	 *            ，左操作数
	 * @param right
	 *            ，右操作数
	 * @return，相除的商
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T divideRemainder(T left, T right) {
		if (left instanceof BigDecimal) {
			return (T) (Object) (((BigDecimal) left)
					.divideAndRemainder((BigDecimal) right));
		} else if (left instanceof BigInteger) {
			return (T) (Object) (((BigInteger) left)
					.divideAndRemainder((BigInteger) right));
		} else if (left instanceof Byte) {
			return (T) (Object) ((Byte) left % (Byte) right);
		} else if (left instanceof Double) {
			return (T) (Object) ((Double) left % (Double) right);
		} else if (left instanceof Float) {
			return (T) (Object) ((Float) left % (Float) right);
		} else if (left instanceof Integer) {
			return (T) (Object) ((Integer) left % (Integer) right);
		} else if (left instanceof Long) {
			return (T) (Object) ((Long) left % (Long) right);
		} else if (left instanceof Short) {
			return (T) (Object) ((Short) left % (Short) right);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 递增（++）
	 * 
	 * @param number
	 *            ，操作数
	 * @return，递增的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T increase(T number) {
		if (number instanceof BigDecimal) {
			return (T) (((BigDecimal) number).add(BigDecimal.ONE));
		} else if (number instanceof BigInteger) {
			return (T) (((BigInteger) number).add(BigInteger.ONE));
		} else if (number instanceof Byte) {
			return (T) (Object) ((Byte) number + (byte) 1);
		} else if (number instanceof Double) {
			return (T) (Object) ((Double) number + (double) 1);
		} else if (number instanceof Float) {
			return (T) (Object) ((Float) number + (float) 1);
		} else if (number instanceof Integer) {
			return (T) (Object) ((Integer) number + (int) 1);
		} else if (number instanceof Long) {
			return (T) (Object) ((Long) number + (long) 1);
		} else if (number instanceof Short) {
			return (T) (Object) ((Short) number + (short) 1);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 递减（--）
	 * 
	 * @param number
	 *            ，操作数
	 * @return，递减的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T decrease(T number) {
		if (number instanceof BigDecimal) {
			return (T) (((BigDecimal) number).subtract(BigDecimal.ONE));
		} else if (number instanceof BigInteger) {
			return (T) (((BigInteger) number).subtract(BigInteger.ONE));
		} else if (number instanceof Byte) {
			return (T) (Object) ((Byte) number - (byte) 1);
		} else if (number instanceof Double) {
			return (T) (Object) ((Double) number - (double) 1);
		} else if (number instanceof Float) {
			return (T) (Object) ((Float) number - (float) 1);
		} else if (number instanceof Integer) {
			return (T) (Object) ((Integer) number - (int) 1);
		} else if (number instanceof Long) {
			return (T) (Object) ((Long) number - (long) 1);
		} else if (number instanceof Short) {
			return (T) (Object) ((Short) number - (short) 1);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}

	/**
	 * 取反（-）
	 * 
	 * @param number
	 *            ，操作数
	 * @return，取反的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> T reverse(T number) {
		if (number instanceof BigDecimal) {
			return (T) (((BigDecimal) number).negate());
		} else if (number instanceof BigInteger) {
			return (T) (((BigInteger) number).negate());
		} else if (number instanceof Byte) {
			return (T) (Object) (-(Byte) number);
		} else if (number instanceof Double) {
			return (T) (Object) (-(Double) number);
		} else if (number instanceof Float) {
			return (T) (Object) (-(Float) number);
		} else if (number instanceof Integer) {
			return (T) (Object) (-(Integer) number);
		} else if (number instanceof Long) {
			return (T) (Object) (-(Long) number);
		} else if (number instanceof Short) {
			return (T) (Object) (-(Short) number);
		} else {
			throw new RuntimeException("类型不是数值类型！");
		}
	}
}
