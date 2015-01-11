/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

import java.util.*;

import smartkernel.framework.*;
import smartkernel.framework.text.*;

/**
 * UrlParameter
 * 
 */
public class SmartUrlParameter {
	/**
	 * 编码参数对
	 * 
	 * @param parameters
	 *            ，参数对列表
	 * @param encoding
	 *            ，字符编码
	 * @return，编码结果
	 */
	public static String toOne(HashMap<String, String> parameters,
			String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		String result = "";
		Iterator<String> iterator = parameters.keySet().iterator();

		while (iterator.hasNext()) {
			String key = iterator.next();
			String value = parameters.get(key);

			result += SmartHex.toHex(key.toLowerCase(), encoding) + "="
					+ SmartHex.toHex(value.toLowerCase(), encoding) + "|";
		}

		return SmartHex.toHex(SmartString.trimEnd(result, "|"), encoding);
	}

	/**
	 * 编码参数对
	 * 
	 * @param parameters
	 *            ，参数对列表
	 * @return，编码结果
	 */
	public static String toOne(HashMap<String, String> parameters) {
		return toOne(parameters, null);
	}

	/**
	 * 解码Url参数
	 * 
	 * @param data
	 *            ，编码的参数
	 * @param encoding
	 *            ，字符编码
	 * @return，结果之后的键值对
	 */
	public static HashMap<String, String> toAll(String data, String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		HashMap<String, String> parameters = new HashMap<String, String>();
		String output = SmartHex.fromHex(data, encoding);
		String[] kvs = output.split("\\|");
		for (int i = 0; i < kvs.length; i++) {
			String[] kv = kvs[i].split("\\=");
			parameters.put(SmartHex.fromHex(kv[0], encoding),
					SmartHex.fromHex(kv[1], encoding));
		}
		return parameters;
	}

	/**
	 * 解码Url参数
	 * 
	 * @param data
	 *            ，编码的参数
	 * @return，结果之后的键值对
	 */
	public static HashMap<String, String> toAll(String data) {
		return toAll(data, null);
	}

	/**
	 * 查询一个参数（不存在则返回null）
	 * 
	 * @param data
	 *            ，编码的数据
	 * @param key
	 *            ，键
	 * @param encoding
	 *            ，字符编码
	 * @return，值
	 */
	public static String query(String data, String key, String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			HashMap<String, String> parameters = toAll(data, encoding);

			String value = null;

			Iterator<String> iterator = parameters.keySet().iterator();
			while (iterator.hasNext()) {
				String keyCurrent = iterator.next();
				if (keyCurrent.toLowerCase().equals(key.toLowerCase())) {
					value = parameters.get(keyCurrent.toLowerCase());
					break;
				}
			}
			return value;
		} catch (Exception err) {
			return null;
		}
	}

	/**
	 * 查询一个参数（不存在则返回null）
	 * 
	 * @param data
	 *            ，编码的数据
	 * @param key
	 *            ，键
	 * @return，值
	 */
	public static String query(String data, String key) {
		return query(data, key, null);
	}
}
