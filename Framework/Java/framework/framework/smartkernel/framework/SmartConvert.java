/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.lang.reflect.*;
import java.util.*;

/**
 * 转换
 * 
 */
public class SmartConvert {
	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Int32类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static int tryToInt32(Object input, int defaultValue) {
		try {
			return Integer.parseInt(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Int32类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static int tryToInt32(Object input) {
		return tryToInt32(input, 0);
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Int16类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static short tryToInt16(Object input, short defaultValue) {
		try {
			return Short.parseShort(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Int16类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static short tryToInt16(Object input) {
		return tryToInt16(input, (short) 0);
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Int64类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static long tryToInt64(Object input, long defaultValue) {
		try {
			return Long.parseLong(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Int64类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static long tryToInt64(Object input) {
		return tryToInt64(input, (long) 0);
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Double类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static double tryToDouble(Object input, double defaultValue) {
		try {
			return Double.parseDouble(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Double类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static double tryToDouble(Object input) {
		return tryToDouble(input, 0.0);
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Float类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static float tryToFloat(Object input, float defaultValue) {
		try {
			return Float.parseFloat(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为Float类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static float tryToFloat(Object input) {
		return tryToFloat(input, (float) 0.0);
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 String 类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static String tryToString(Object input, String defaultValue) {
		try {
			return String.valueOf(input);
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 String 类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String tryToString(Object input) {
		return tryToString(input, "");
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 Char 类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static char tryToChar(Object input, char defaultValue) {
		try {
			return input.toString().charAt(0);
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 Char 类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static char tryToChar(Object input) {
		return tryToChar(input, ' ');
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 DateTime类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static Date tryToDateTime(Object input, Date defaultValue) {
		try {
			return SmartDateTime.parse(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 DateTime类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static Date tryToDateTime(Object input) {
		return tryToDateTime(input, SmartDateTime.parse("1900-01-01"));
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 bool 类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static boolean tryToBool(Object input, boolean defaultValue) {
		try {
			return Boolean.parseBoolean(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 bool 类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean tryToBool(Object input) {
		return tryToBool(input, false);
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 byte 类型
	 * 
	 * @param input
	 *            ，输入
	 * @param defaultValue
	 *            ，默认值
	 * @return，结果
	 */
	public static byte tryToByte(Object input, byte defaultValue) {
		try {
			return Byte.parseByte(input.toString());
		} catch (Exception err) {
			return defaultValue;
		}
	}

	/**
	 * 尝试转换（失败则返回默认值）-- 转换为 byte 类型
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static byte tryToByte(Object input) {
		return tryToByte(input, (byte) 0);
	}

	/**
	 * 从源类型转换为目标类型
	 * 
	 * @param source
	 *            ，源
	 * @param type
	 *            ，目标类型（可以是枚举、TimeSpan、DateTime、List[string]、Color、其他基本类型等）
	 * @return，转换之后的对象
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public static Object to(Object source, Class type) {
		Object result = source;

		if (source == null) {
			return null;
		}
		Class sourceType = source.getClass();
		String sourceString = source == null ? null : source.toString();

		if (sourceType.equals(type)) {
			return source;
		} else if (type.isEnum()) {
			// 目标类型为枚举类型
			result = SmartEnum.parse(type, sourceString);
		} else if (sourceType.isEnum() && type.equals(Integer.class)) {
			// 源为枚举类型，目标为整形
			result = Enum.valueOf(sourceType, sourceString).ordinal();
		} else if (sourceType.equals(Integer.class) && type.isEnum()) {
			// 源为整形，目标为枚举类型
			Iterator iterator = EnumSet.allOf(type).iterator();
			while (iterator.hasNext()) {
				Object current = iterator.next();

				String currentString = iterator.next().toString();
				int target = Enum.valueOf(type, currentString).ordinal();
				if ((int) source == target) {
					result = current;
				}
			}
		} else if (type.equals(Date.class)) {
			// 目标类型为时间类型
			result = SmartDateTime.parse(sourceString);
		} else if ((sourceType.equals(Boolean.class) || sourceType
				.equals(boolean.class)) && type.equals(String.class)) {
			// 如果源是布尔值，目标是字符串
			result = sourceString.toLowerCase();
		} else if ((type.equals(Boolean.class) || type.equals(boolean.class))
				&& sourceType.equals(String.class)) {
			// 如果源是字符串，目标是布尔值
			result = Boolean.valueOf(sourceString);
		} else if (SmartType.isNumbericType(sourceType)
				&& type.equals(String.class)) {
			// 如果源是数字类型，目标是字符串类型
			result = sourceString.toLowerCase();
		} else if (SmartType.isNumbericType(type)
				&& sourceType.equals(String.class)) {
			// 如果源是字符串类型，目标是数字类型
			if (type.equals(Integer.class) || type.equals(int.class)) {
				result = Integer.valueOf(sourceString.toLowerCase());
			} else if (type.equals(Long.class) || type.equals(long.class)) {
				result = Long.valueOf(sourceString.toLowerCase());
			} else if (type.equals(Float.class) || type.equals(float.class)) {
				result = Float.valueOf(sourceString.toLowerCase());
			} else if (type.equals(Double.class) || type.equals(double.class)) {
				result = Double.valueOf(sourceString.toLowerCase());
			} else if (type.equals(Short.class) || type.equals(short.class)) {
				result = Short.valueOf(sourceString.toLowerCase());
			} else if (type.equals(Byte.class) || type.equals(byte.class)) {
				result = Byte.valueOf(sourceString.toLowerCase());
			}
		} else if (sourceType.equals(String.class)
				&& (type.equals(Character.class) || type.equals(char.class))) {
			// 源为字符串，目标为字符
			return sourceString.charAt(0);
		} else if (type.equals(String.class)
				&& (sourceType.equals(Character.class) || sourceType
						.equals(char.class))) {
			// 源为字符，目标为字符串
			return String.valueOf(sourceString);
		} else {
			try {
				Constructor constructor = type.getConstructor(sourceType);
				result = constructor.newInstance(source);
			} catch (Exception err) {
			}
		}

		return result;
	}
}
