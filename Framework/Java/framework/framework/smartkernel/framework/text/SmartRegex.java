/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.text;

import java.util.*;
import java.util.regex.*;

import smartkernel.framework.*;

/**
 * Regex
 * 
 */
public class SmartRegex {
	/**
	 * 正则表达式验证方法
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @param regex
	 *            ，正则表达式模式
	 * @param regexOptions
	 *            ，匹配选择项
	 * @return，验证的结果
	 */
	public static boolean isMatch(String input, String regex, int regexOptions) {
		Pattern pattern = Pattern.compile(regex, regexOptions);
		return pattern.matcher(input).matches();
	}

	/**
	 * 正则表达式验证方法
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @param pattern
	 *            ，正则表达式模式
	 * @return，验证的结果
	 */
	public static boolean isMatch(String input, String regex) {
		return isMatch(input, regex, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 去除指定模式的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，按匹配的模式删除
	 * @param regexOptions
	 *            ，正则表达式选项
	 * @return，处理的结果
	 */
	public static String remove(String input, String regex, int regexOptions) {
		Pattern pattern = Pattern.compile(regex, regexOptions);
		return pattern.matcher(input).replaceAll("");
	}

	/**
	 * 去除指定模式的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，按匹配的模式删除
	 * @return，处理的结果
	 */
	public static String remove(String input, String regex) {
		return remove(input, regex, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 替换指定模式的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，匹配的模式
	 * @param replace
	 *            ，替换的字符串
	 * @param regexOptions
	 *            ，正则表达式选项
	 * @return，处理的结果
	 */
	public static String replace(String input, String regex, String replace,
			int regexOptions) {
		Pattern pattern = Pattern.compile(regex, regexOptions);
		return pattern.matcher(input).replaceAll(replace);
	}

	/**
	 * 替换指定模式的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，匹配的模式
	 * @param replace
	 *            ，替换的字符串
	 * @param regexOptions
	 *            ，正则表达式选项
	 * @return，处理的结果
	 */
	public static String replace(String input, String regex, String replace) {
		return replace(input, regex, replace, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 通过正则表达式查找匹配的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，模式
	 * @param regexOptions
	 *            ，正则表达式选项
	 * @return，查找到的结果列表
	 */
	public static ArrayList<String> find(String input, String regex,
			int regexOptions) {
		Pattern pattern = Pattern.compile(regex, regexOptions);
		Matcher matcher = pattern.matcher(input);
		ArrayList<String> result = new ArrayList<String>();
		while (matcher.find()) {
			result.add(matcher.group(0));
		}
		return result;
	}

	/**
	 * 通过正则表达式查找匹配的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，模式
	 * @return，查找到的结果列表
	 */
	public static ArrayList<String> find(String input, String regex) {
		return find(input, regex, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 是否包含指定模式的字符串
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param pattern
	 *            ，匹配的模式
	 * @param regexOptions
	 *            ，正则表达式选项
	 * @return，处理的结果
	 */
	public static boolean contains(String input, String pattern,
			int regexOptions) {
		return find(input, pattern, regexOptions).size() > 0;
	}

	/**
	 * 通过正则表达式拆分字符串
	 * 
	 * @param input
	 *            ，输入字符串
	 * @param regex
	 *            ，验证模式
	 * @param regexOptions
	 *            ，匹配选项
	 * @return，拆分的结果
	 */
	public static ArrayList<String> split(String input, String regex,
			int regexOptions) {
		Pattern pattern = Pattern.compile(regex, regexOptions);
		String[] array = pattern.split(input);
		ArrayList<String> result = new ArrayList<String>();
		for (int i = 0; i < array.length; i++) {
			if (!SmartString.isNullOrWhiteSpace(array[i])
					&& !SmartString.isNullOrEmpty(array[i])) {
				result.add(array[i]);
			}
		}
		return result;
	}

	/**
	 * 通过正则表达式拆分字符串
	 * 
	 * @param input
	 *            ，输入字符串
	 * @param regex
	 *            ，验证模式
	 * @return，拆分的结果
	 */
	public static ArrayList<String> split(String input, String regex) {
		return split(input, regex, Pattern.CASE_INSENSITIVE);
	}
}
