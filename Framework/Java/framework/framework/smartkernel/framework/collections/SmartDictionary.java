/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.collections;

import java.util.*;
import java.util.Map.*;

import net.sf.json.*;

import org.w3c.dom.*;

import smartkernel.framework.*;
import smartkernel.framework.web.*;
import smartkernel.framework.xml.SmartXml;

/**
 * 字典
 * 
 */
public class SmartDictionary {
	/**
	 * 过滤
	 * 
	 * @param hashMap
	 *            ，字典
	 * @param where
	 *            ，过滤条件
	 * @return，结果
	 */
	public static <K, V> HashMap<K, V> where(HashMap<K, V> hashMap,
			ISmartInvokeWithEntryReturnBooleanFunc<K, V> where) {
		HashMap<K, V> result = new HashMap<K, V>();
		Set<Entry<K, V>> set = hashMap.entrySet();
		for (Entry<K, V> kv : set) {
			if (where.invoke(kv)) {
				result.put(kv.getKey(), kv.getValue());
			}
		}
		return result;
	}

	/*
	 * 
	 * 
	 * @param array $array，字典
	 * 
	 * @param function $action，函数
	 */

	/**
	 * 循环处理
	 * 
	 * @param hashMap
	 *            ，字典
	 * @param action
	 *            ，函数
	 */
	public static <K, V> void forEach(HashMap<K, V> hashMap,
			ISmartInvokeWithEntryFunc<K, V> action) {
		Set<Entry<K, V>> set = hashMap.entrySet();
		for (Entry<K, V> kv : set) {
			action.invoke(kv);
		}
	}

	/**
	 * 对象映射为Xml
	 * 
	 * @param item
	 *            ，对象
	 * @param rootName
	 *            ，根元素的名称
	 * @return，xml文档
	 */
	public static String toXml(HashMap<String, String> item, String rootName) {
		StringBuilder result = new StringBuilder();
		result.append(SmartString.format("<{0}>", rootName));
		Set<String> set = item.keySet();
		for (String key : set) {
			String value = item.get(key);
			result.append(SmartString.format("<{0}>{1}</{0}>", key, value));
		}
		result.append(SmartString.format("</{0}>", rootName));
		return result.toString();
	}

	/**
	 * 从Xml解析
	 * 
	 * @param xml
	 *            ，Xml
	 * @return，结果
	 */
	public static HashMap<String, String> fromXml(String xml) {
		HashMap<String, String> result = new HashMap<String, String>();

		Document document = SmartXml.load(xml);

		NodeList items = document.getFirstChild().getChildNodes();
		for (int i = 0; i < items.getLength(); i++) {
			Node item = items.item(i);
			String key = item.getNodeName();
			String value = item.getFirstChild().getNodeValue();
			result.put(key, value);
		}

		return result;
	}

	/**
	 * 对象映射为Json
	 * 
	 * @param item
	 *            ，对象
	 * @return，xml文档
	 */
	public static String toJson(HashMap<String, String> item) {
		return SmartJson.toJson(item);
	}

	/**
	 * 从Json解析
	 * 
	 * @param xml
	 *            ，Json
	 * @return，结果
	 */
	public static HashMap<String, String> fromJson(String json) {
		try {
			HashMap<String, String> result = new HashMap<String, String>();
			JSONObject jsonObject = JSONObject.fromObject(json);
			Iterator<?> keys = jsonObject.keys();

			while (keys.hasNext()) {
				String key = (String) keys.next();
				String value = jsonObject.getString(key);
				result.put(key, value);
			}

			return result;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}

	}
}
