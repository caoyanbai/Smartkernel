/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

import java.net.*;

import org.apache.commons.lang3.*;

import smartkernel.framework.text.*;

/**
 * HttpUtility
 * 
 */
public class SmartHttpUtility {
	/**
	 * Html编码
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String htmlEncode(String input) {
		return StringEscapeUtils.escapeHtml4(input);
	}

	/**
	 * Html解码
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String htmlDecode(String input) {
		return StringEscapeUtils.unescapeHtml4(input);
	}

	/**
	 * Url编码
	 * 
	 * @param input
	 *            ，输入
	 * @param encoding
	 *            ，编码
	 * @return，结果
	 */
	public static String urlEncode(String input, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;
			return URLEncoder.encode(input, encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * Url编码
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String urlEncode(String input) {
		return urlEncode(input, null);
	}

	/**
	 * Url解码
	 * 
	 * @param input
	 *            ，输入
	 * @param encoding
	 *            ，编码
	 * @return，结果
	 */
	public static String urlDecode(String input, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;
			return URLDecoder.decode(input, encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * Url解码
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String urlDecode(String input) {
		return urlEncode(input, null);
	}
}
