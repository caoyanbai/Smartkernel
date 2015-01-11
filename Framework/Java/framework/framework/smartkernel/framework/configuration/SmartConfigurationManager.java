/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.configuration;

import java.io.*;
import java.util.*;

import org.apache.commons.configuration.*;

import smartkernel.framework.*;
import smartkernel.framework.diagnostics.*;
import smartkernel.framework.web.*;

/**
 * 配置管理类
 * 
 */
public class SmartConfigurationManager {

	private static HashMap<String, String> appSettings = new HashMap<String, String>();

	/**
	 * 静态构造函数
	 * 
	 */
	static {
		refresh();
	}

	/**
	 * 刷新配置
	 */
	public static void refresh() {
		appSettings.clear();

		try {
			XMLConfiguration xmlConfiguration = null;
			if (new File(SmartAppContext.Directory + "web.config").exists()) {
				xmlConfiguration = new XMLConfiguration(
						SmartAppContext.Directory + "web.config");
			}
			if (new File(SmartAppContext.Directory + "app.config").exists()) {
				xmlConfiguration = new XMLConfiguration(
						SmartAppContext.Directory + "app.config");
			}
			List<HierarchicalConfiguration> adds = xmlConfiguration
					.configurationsAt("appSettings.add");
			for (HierarchicalConfiguration add : adds) {
				String k = add.getString("[@key]");
				String v = add.getString("[@value]");
				appSettings.put(k.toLowerCase(), v);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	private static String getString(String key) {
		return appSettings.get(key.toLowerCase());
	}

	/**
	 * 获得值
	 * 
	 * @param type
	 *            ，类型
	 * @param key
	 *            ，键（不区分大小写）
	 * @param isDecode
	 *            ，是否解码
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public static <T> T getValue(Class<T> type, String key, boolean isDecode) {
		String value = getString(key);
		if (type == String.class && isDecode) {
			value = SmartHttpUtility.htmlDecode(value);
		}

		return (T) SmartConvert.to(value, type);
	}

	/**
	 * 获得值
	 * 
	 * @param type
	 *            ，类型
	 * @param key
	 *            ，键（不区分大小写）
	 * @return
	 */
	public static <T> T getValue(Class<T> type, String key) {
		return getValue(type, key, true);
	}

	/**
	 * 获得值
	 * 
	 * @param type
	 *            ，类型
	 * @param key
	 *            ，键（不区分大小写）
	 * @param split
	 *            ，分割符
	 * @param isDecode
	 *            ，是否解码
	 * @return，结果
	 */
	public static <T> T[] getValues(Class<T> type, String key, String split,
			boolean isDecode) {
		String value = getString(key);
		if (type == String.class && isDecode) {
			value = SmartHttpUtility.htmlDecode(value);
		}

		return SmartArray.parse(type, value, split);
	}

	/**
	 * 获得值
	 * 
	 * @param type
	 *            ，类型
	 * @param key
	 *            ，键（不区分大小写）
	 * @param split
	 *            ，分割符
	 * @return，结果
	 */
	public static <T> T[] getValues(Class<T> type, String key, String split) {
		return getValues(type, key, split, true);
	}

	/**
	 * 获得值
	 * 
	 * @param type
	 *            ，类型
	 * @param key
	 *            ，键（不区分大小写）
	 * @return，结果
	 */
	public static <T> T[] getValues(Class<T> type, String key) {
		return getValues(type, key, "\\|", true);
	}
}
