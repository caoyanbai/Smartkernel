/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

import java.util.regex.*;

/**
 * Html
 * 
 */
public class SmartHtml {
	/**
	 * 去除Html标记
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，模式
	 * @param regexOptions
	 *            ，正则表达式选项
	 * @return，处理的结果
	 */
	public static String clear(String input, String regex, int regexOptions) {
		Pattern pattern = Pattern.compile(regex, regexOptions);
		return pattern.matcher(input).replaceAll("");
	}

	/**
	 * 去除Html标记
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param regex
	 *            ，模式
	 * @return，处理的结果
	 */
	public static String clear(String input, String regex) {
		return clear(input, regex, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 去除Html标记
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @return，处理的结果
	 */
	public static String clear(String input) {
		return clear(input, "\\<.*?>", Pattern.CASE_INSENSITIVE);
	}
}
