/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

import java.util.regex.*;

import org.jsoup.*;
import org.jsoup.safety.*;

/**
 * Xss攻击防御
 * 
 */
public class SmartAntiXss {
	/**
	 * 获得安全的Html片段（不会自动补全Html标签）
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String getSafeHtmlFragment(String input) {
		return Jsoup.clean(input, Whitelist.basic());
	}

	private static Pattern getSafeTextRegex = Pattern.compile("<[^>]*>");

	/**
	 * 获得安全的Text
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String getSafeText(String input) {
		return getSafeTextRegex.matcher(input).replaceAll("");
	}
}
