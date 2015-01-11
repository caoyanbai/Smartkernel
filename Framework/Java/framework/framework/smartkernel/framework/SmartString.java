/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.text.*;
import java.util.*;

/**
 * String
 * 
 */
public class SmartString {
	/**
	 * 格式化字符串
	 * 
	 * @param format
	 *            ，格式
	 * @param args
	 *            ，参数
	 * @return，结果
	 */
	public static String format(String format, Object... args) {
		return MessageFormat.format(format, args);
	}

	/**
	 * 
	 * 判断字符串是否为null或空
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean isNullOrEmpty(String input) {
		return input == null || input.isEmpty();
	}

	/**
	 * 
	 * 判断字符串是否为null、空或空白
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean isNullOrWhiteSpace(String input) {
		return input == null || input.isEmpty() || input.trim().isEmpty();
	}

	/**
	 * 截取字符串左侧指定长度的字符，如果不足指定的长度，则取整个字符串
	 * 
	 * @param input
	 *            ，待截取的字符串
	 * @param length
	 *            ，截取的长度
	 * @param ellipsis
	 *            ，如果发生截取，则使用的结尾符号
	 * @return，截取的结果
	 */
	public static String left(String input, int length, String ellipsis) {
		return input.length() <= length ? input : input.substring(0, length)
				+ ellipsis;
	}

	/**
	 * 截取字符串左侧指定长度的字符，如果不足指定的长度，则取整个字符串
	 * 
	 * @param input
	 *            ，待截取的字符串
	 * @param length
	 *            ，截取的长度
	 * @return，截取的结果
	 */
	public static String left(String input, int length) {
		return left(input, length, "");
	}

	/**
	 * 截取字符串右侧指定长度的字符，如果不足指定的长度，则取整个字符串
	 * 
	 * @param input
	 *            ，待截取的字符串
	 * @param length
	 *            ，截取的长度
	 * @param ellipsis
	 *            ，如果发生截取，则使用的开始符号
	 * @return，截取的结果
	 */
	public static String right(String input, int length, String ellipsis) {
		int startIndex = input.length() - length;
		return input.length() <= length ? input : ellipsis
				+ input.substring(startIndex, startIndex + length);
	}

	/**
	 * 截取字符串右侧指定长度的字符，如果不足指定的长度，则取整个字符串
	 * 
	 * @param input
	 *            ，待截取的字符串
	 * @param length
	 *            ，截取的长度
	 * @return，截取的结果
	 */
	public static String right(String input, int length) {
		return right(input, length, "");
	}

	/**
	 * 是否全为空（只要有一个不为空，则返回false）
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean isNullOrEmptyAll(String... input) {
		for (String one : input) {
			if (!isNullOrEmpty(one)) {
				return false;
			}
		}
		return true;
	}

	/**
	 * 是否有一个为空（只要有一个为空，则返回true）
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean isNullOrEmptyAny(String... input) {
		for (String one : input) {
			if (isNullOrEmpty(one)) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 是否全为空（只要有一个不为空，则返回false）
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean isNullOrWhiteSpaceAll(String... input) {
		for (String one : input) {
			if (!isNullOrWhiteSpace(one)) {
				return false;
			}
		}
		return true;
	}

	/**
	 * 是否有一个为空（只要有一个为空，则返回true）
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static boolean isNullOrWhiteSpaceAny(String... input) {
		for (String one : input) {
			if (isNullOrWhiteSpace(one)) {
				return true;
			}
		}

		return false;
	}

	/**
	 * 获得重复字符组成的字符串
	 * 
	 * @param input
	 *            ，字符
	 * @param count
	 *            ，重复次数
	 * @return，字符串
	 */
	public static String repeat(String input, int count) {
		String result = "";
		for (int i = 0; i < count; i++) {
			result = result + input;
		}
		return result;
	}

	/**
	 * 翻转字符串
	 * 
	 * @param input
	 *            ，输入的字符串
	 * @return，翻转的结果
	 */
	public static String reverse(String input) {
		return new StringBuilder(input).reverse().toString();
	}

	/**
	 * 进行不区分大小写的比较
	 * 
	 * @param input
	 *            ，原字符串
	 * @param other
	 *            ，待比较的字符串
	 * @return，比较结果
	 */
	public static boolean compareIgnoreCase(String input, String other) {
		return input.equalsIgnoreCase(other);
	}

	/**
	 * 设置单词首字母小写
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @return，处理的结果
	 */
	public static String toCamelCase(String input) {
		return left(input, 1).toLowerCase() + right(input, input.length() - 1);
	}

	/**
	 * 删除所有空格
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @return，处理的结果
	 */
	public static String trimAll(String input) {
		return input.replace(" ", "");
	}

	/**
	 * 替换指定的字符串列表
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param oldValues
	 *            ，旧的字符串
	 * @param newValue
	 *            ，新的字符串
	 * @return，处理的结果
	 */
	public static String replace(String input, Iterable<String> oldValues,
			String newValue) {
		Iterator<String> iterator = oldValues.iterator();
		while (iterator.hasNext()) {
			input = input.replace(iterator.next(), newValue);
		}
		return input;
	}

	/**
	 * 替换指定的字符串列表
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param oldValues
	 *            ，旧的字符串
	 * @param newValue
	 *            ，新的字符串
	 * @return，处理的结果
	 */
	public static String replace(String input, String[] oldValues,
			String newValue) {
		ArrayList<String> list = new ArrayList<String>();
		for (int i = 0; i < oldValues.length; i++) {
			list.add(oldValues[i]);
		}
		return replace(input, list, newValue);
	}

	/**
	 * 多次反复替换直到完全不包含指定的字符为止
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param oldValue
	 *            ，旧的字符串
	 * @param newValue
	 *            ，新的字符串
	 * @return，处理的结果
	 */
	public static String repeatReplace(String input, String oldValue,
			String newValue) {
		while (input.contains(oldValue)) {
			input = input.replace(oldValue, newValue);
		}
		return input;
	}

	/**
	 * 多次反复替换直到完全不包含指定的字符为止
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param oldValue
	 *            ，旧的字符串
	 * @param newValue
	 *            ，新的字符串
	 * @return，处理的结果
	 */
	public static String repeatReplace(String input, String oldValue) {
		return repeatReplace(input, oldValue, "");
	}

	/**
	 * 删除开头的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param value
	 *            ，移除的字符串
	 * @return，处理的结果
	 */
	public static String trimStart(String input, String value) {
		if (left(input, value.length()).equals(value)) {
			input = input.substring(value.length());
		}
		return input;
	}

	/**
	 * 多次反复删除开始的字符直到完全不包含指定的字符为止
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param value
	 *            ，移除的字符串
	 * @return，处理的结果
	 */
	public static String repeatTrimStart(String input, String value) {
		while (input.startsWith(value)) {
			input = trimStart(input, value);
		}
		return input;
	}

	/**
	 * 删除结尾的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param value
	 *            ，移除的字符串
	 * @return，处理的结果
	 */
	public static String trimEnd(String input, String value) {
		if (right(input, value.length()).equals(value)) {
			return input.substring(0, input.length() - value.length());
		}
		return input;
	}

	/**
	 * 多次反复删除结束的字符直到完全不包含指定的字符为止
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param value
	 *            ，移除的字符串
	 * @return，处理的结果
	 */
	public static String repeatTrimEnd(String input, String value) {
		while (input.endsWith(value)) {
			input = trimEnd(input, value);
		}
		return input;
	}

	/**
	 * 根据片段的长度拆分字符串获得字符串数组
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param segmentSize
	 *            ，片段的长度
	 * @return，处理的结果
	 */
	public static String[] splitBySegment(String input, int segmentSize) {
		if (isNullOrEmpty(input)) {
			return new String[] { "" };
		}
		int totalSegments = (int) Math.ceil(input.length()
				/ (double) segmentSize);

		String[] segments = new String[totalSegments];

		for (int i = 0; i < segments.length; i++) {
			if (i * segmentSize + segmentSize >= input.length()) {
				segments[i] = input.substring(i * segmentSize);
			} else {
				segments[i] = input.substring(i * segmentSize, i * segmentSize
						+ segmentSize);
			}
		}
		return segments;
	}

	/**
	 * 根据片段的长度拆分字符串获得字符串数组
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @return，处理的结果
	 */
	public static String[] splitBySegment(String input) {
		return splitBySegment(input, 1);
	}

	/**
	 * 截取字符串（通过范围，不包括范围标记）
	 * 
	 * @param input
	 *            ，待截取的字符串
	 * @param left
	 *            ，左边界
	 * @param right
	 *            ，右边界
	 * @return，结果
	 */
	public static String subStringByScope(String input, String left,
			String right) {
		int leftIndex = input.indexOf(left) + left.length();
		int rightIndex = input.indexOf(right);

		return input.substring(leftIndex, rightIndex);
	}

	/**
	 * 截取字符串（通过范围，包括范围标记）
	 * 
	 * @param input
	 *            ，待截取的字符串
	 * @param leftIndex
	 *            ，左边界
	 * @param rightIndex
	 *            ，右边界
	 * @return，结果
	 */
	public static String subStringByScope(String input, int leftIndex,
			int rightIndex) {
		return input.substring(leftIndex, rightIndex + 1);
	}

	/**
	 * 验证是不是邮箱地址
	 * 
	 * @param input
	 *            ，待检查的字符串
	 * @return，验证的结果
	 */
	public static boolean isEmail(String input) {
		String pattern = "^([a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是包含小写字符串，包含非字母符号不影响结果
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean containsLow(String input) {
		String pattern = "[a-z]";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是包含大写字符串，包含非字母符号不影响结果
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean containsUp(String input) {
		String pattern = "[A-Z]";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是字母字符串，空格也认为是非字母
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isAlphabetic(String input) {
		String pattern = "^[a-zA-Z]+$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是包含字母
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean containsAlphabetic(String input) {
		String pattern = "[a-zA-Z]";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是包含数字
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean containsNumberic(String input) {
		String pattern = "[0-9]";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是中文字符，空格也认为是非中文
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isChinese(String input) {
		String pattern = "^[\u4e00-\u9fa5]+$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是包含中文字符
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean containsChinese(String input) {
		String pattern = "[\u4e00-\u9fa5]";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是字母和数字组合
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isAlphabeticNumberic(String input) {
		String pattern = "^[A-Za-z0-9]+$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是字符、数字或者下划线
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isAlphabeticNumbericUnderline(String input) {
		String pattern = "^[a-zA-Z0-9_]+$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是手机号码
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isChineseMobilePhone(String input) {
		String pattern = "^[1]{1}[0-9]{10}$";
		return input.matches(pattern);
	}

	/**
	 * 验证长度是不是在指定的范围内
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @param start
	 *            ，起始边界
	 * @param end
	 *            ，结束边界
	 * @return，验证的结果
	 */
	public static boolean isLengthBetween(String input, int start, int end) {
		String pattern = "^.{" + start + "," + end + "}$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是邮编
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isChineseZipCode(String input) {
		String pattern = "^\\d{6}$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是电话号码，匹配010-1234567、010-12345678、0316-1234567、0316-12345678、1234567、
	 * 12345678。 以及所有前面的号码加“-”、“转”、“#”之后加分机号码。
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isChinesePhone(String input) {
		return input.matches("^\\d{7,8}$")
				|| input.matches("^\\d{7,8}[-转#]\\d{1,6}$")
				|| input.matches("^\\d{3,4}-\\d{7,8}$")
				|| input.matches("^\\d{3,4}-\\d{7,8}[-转#]\\d{1,6}$");
	}

	/**
	 * 设置单词首字母大写
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @return，处理的结果
	 */
	public static String toTitleCase(String input) {
		StringBuilder titleCase = new StringBuilder();
		boolean nextTitleCase = true;

		char[] cArray = input.toCharArray();
		
		for (char c : cArray) {
			if (Character.isSpaceChar(c)) {
				nextTitleCase = true;
			} else if (nextTitleCase) {
				c = Character.toTitleCase(c);
				nextTitleCase = false;
			}

			titleCase.append(c);
		}

		return titleCase.toString();
	}

	/**
	 * 通过长度截取
	 * 
	 * @param input，输入
	 * @param startIndex，开始索引
	 * @param length，长度
	 * @return，结果
	 */
	public static String substringByLength(String input, int startIndex, int length) {
		return input.substring(startIndex, startIndex + length);
	}
}
