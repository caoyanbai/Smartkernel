/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.awt.*;
import java.util.*;
import java.util.AbstractMap.*;

import javax.script.*;

/**
 * 数学辅助类
 * 
 */
public class SmartMath {
	/**
	 * 四舍五入
	 * 
	 * @param number，数字
	 * @param decimalPlaces，小数位数
	 * @return，结果
	 */
	public static double round(double number, int decimalPlaces) {
		return Math.round(number * 100d) / 100d;
	}

	/**
	 * 计算数学表达式的值（只支持加减乘除）
	 * 
	 * @param expression
	 *            ，数学表达式
	 * @return，结果
	 */
	public static double eval(String expression) {
		ScriptEngineManager scriptEngineManager = new ScriptEngineManager();
		ScriptEngine scriptEngine = scriptEngineManager
				.getEngineByName("JavaScript");
		try {
			return (double) (scriptEngine.eval(expression));
		} catch (Exception err) {
			return 0;
		}
	}

	/**
	 * 求质因数
	 * 
	 * @param number
	 *            ，待求质因数的数字，必须大于0。且是整数
	 * @return，质因数列表
	 */
	@SuppressWarnings("unchecked")
	public static <T extends Number> ArrayList<T> getPrimeDivisors(T number) {
		ArrayList<T> list = new ArrayList<T>();

		for (T i = (T) SmartConvert.to(2, number.getClass()); SmartGeneric
				.lessThanOrEquals(i, number); i = SmartGeneric.increase(i)) {
			while (SmartGeneric.notEquals(number, i)) {
				T divideRemainder = SmartGeneric.divideRemainder(number, i);
				if (SmartGeneric.equals(divideRemainder, 0)) {
					list.add(i);
					number = SmartGeneric.divide(number, i);
				} else {
					break;
				}
			}
		}
		list.add(number);

		return list;
	}

	/**
	 * 求最大公约数，如果没有，则返回1
	 * 
	 * @param numbers
	 *            ，待求的数字列表
	 * @return，最大公约数
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public static <T extends Number> T getMaxDivisor(ArrayList<T> numbers) {
		ArrayList<T> numberList = new ArrayList<T>(numbers);
		ArrayList<SimpleEntry<T, Integer>> commonPrimeDivisors = new ArrayList<SimpleEntry<T, Integer>>();
		boolean isFirst = true;
		for (T number : numberList) {
			ArrayList<SimpleEntry<T, Integer>> list = new ArrayList<SimpleEntry<T, Integer>>();
			ArrayList<T> primeDivisors = getPrimeDivisors(number);
			for (T primeDivisor : primeDivisors) {
				int i = 0;
				while (list.contains(new SimpleEntry<T, Integer>(primeDivisor,
						i))) {
					i++;
				}
				list.add(new SimpleEntry<T, Integer>(primeDivisor, i));
			}
			if (isFirst) {
				isFirst = false;
				commonPrimeDivisors.addAll(list);
			} else {
				commonPrimeDivisors = SmartArray.intersect(list,
						commonPrimeDivisors);
			}
		}
		Class type = numbers.get(0).getClass();
		// 所有公共质因数的乘积就是最大公约数
		T result = (T) SmartConvert.to(1, type);
		for (SimpleEntry<T, Integer> item : commonPrimeDivisors) {
			result = SmartGeneric.multiply(result, item.getKey());
		}
		return result;
	}

	/**
	 * 二进制转换为十进制
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换的结果
	 */
	public static int binaryToDecimal(String input) {
		return Integer.valueOf(input, 10);
	}

	/**
	 * 八进制转换为十进制
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换的结果
	 */
	public static int octalToDecimal(String input) {
		return Integer.valueOf(input, 8);
	}

	/**
	 * 十六进制转换为十进制
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换的结果
	 */
	public static int hexToDecimal(String input) {
		return Integer.valueOf(input, 16);
	}

	/**
	 * 十进制转换为二进制
	 * 
	 * @param input
	 *            ，待转换的数字
	 * @return，转换的结果
	 */
	public static String decimalToBinary(int input) {
		return Integer.toString(input, 2);
	}

	/**
	 * 十进制转换为八进制
	 * 
	 * @param input
	 *            ，待转换的数字
	 * @return，转换的结果
	 */
	public static String decimalToOctal(int input) {
		return Integer.toString(input, 8);
	}

	/**
	 * 十进制转换为十六进制
	 * 
	 * @param input
	 *            ，待转换的数字
	 * @return，转换的结果
	 */
	public static String decimalToHex(int input) {
		return Integer.toString(input, 16);
	}

	/**
	 * 角度转换为弧度
	 * 
	 * @param input
	 *            ，待转换的角度值
	 * @return，弧度表示
	 */
	public static double angleToRadian(double input) {
		return (Math.PI * input) / 180d;
	}

	/**
	 * 弧度转换为角度
	 * 
	 * @param input
	 *            ，待转换的弧度值
	 * @return，角度表示
	 */
	public static double radianToAngle(double input) {
		return input * 180d / Math.PI;
	}

	/**
	 * 计算利息
	 * 
	 * @param principalMoney
	 *            ，本金
	 * @param year
	 *            ，年数
	 * @param rate
	 *            ，年利率
	 * @param isCompoundInterest
	 *            ，是否复利
	 * @return，本利和
	 */
	public static double calculateInterest(double principalMoney, double year,
			double rate, boolean isCompoundInterest) {
		if (isCompoundInterest) {
			return Math.pow(1 + rate, year) * principalMoney;
		}
		return (1 + rate * year) * principalMoney;
	}

	/**
	 * 计算利息
	 * 
	 * @param principalMoney
	 *            ，本金
	 * @param year
	 *            ，年数
	 * @param rate
	 *            ，年利率
	 * @return，本利和
	 */
	public static double calculateInterest(double principalMoney, double year,
			double rate) {
		return calculateInterest(principalMoney, year, rate, true);
	}

	/**
	 * 通过角度计算偏移
	 * 
	 * @param angle
	 *            ，角度
	 * @param distance
	 *            ，距离
	 * @return，结果
	 */
	public static Point getOffsetFromAngleAndDistance(double angle,
			double distance) {
		double x = Math.cos(angleToRadian(angle)) * distance;
		double y = Math.tan(angleToRadian(angle)) * x;
		return new Point((int) x, (int) y);
	}

	/**
	 * 通过偏移计算角度
	 * 
	 * @param offset
	 *            ，偏移
	 * @return，结果
	 */
	public static double getAngleFromOffset(Point offset) {
		double opposite = Math.abs(offset.getY());
		double adjacent = Math.abs(offset.getX());

		if (offset.getY() < 0) {
			opposite = -opposite;
		}

		double angle = radianToAngle(Math.atan(opposite / adjacent));
		if (Double.isNaN(angle)) {
			return 0.0;
		}

		if (offset.getX() < 0) {
			angle = 90 + (90 - angle);
		}

		return angle;
	}
}
