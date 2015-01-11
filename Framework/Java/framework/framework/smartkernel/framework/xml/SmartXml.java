/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.xml;

import java.io.*;
import java.lang.reflect.*;
import java.util.*;

import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;

import org.w3c.dom.*;
import org.xml.sax.*;

import smartkernel.framework.*;
import smartkernel.framework.computer.*;
import smartkernel.framework.io.*;
import smartkernel.framework.text.*;

import com.thoughtworks.xstream.*;
import com.thoughtworks.xstream.io.xml.*;

/**
 * Xml
 * 
 */
public class SmartXml {
	/**
	 * 序列化对象为xml文档
	 * 
	 * @param item
	 *            ，对象
	 * @return，序列化的结果
	 */
	public static String serialize(Object item) {
		XStream xstream = new XStream(new StaxDriver());
		xstream.alias(item.getClass().getSimpleName(), item.getClass());
		return xstream.toXML(item);
	}

	/**
	 * xml文档串行化为对象
	 * 
	 * @param xml
	 *            ，xml文档
	 * @param type
	 *            ，类型
	 * @return，串行化的结果
	 */
	@SuppressWarnings("unchecked")
	public static <T> T deserialize(String xml, Class<?> type) {
		XStream xstream = new XStream(new StaxDriver());
		xstream.alias(type.getSimpleName(), type);
		return (T) SmartConvert.to(xstream.fromXML(xml), type);
	}

	/**
	 * 根据xsl转换xml文档
	 * 
	 * @param xml
	 *            ，xml文档的内容
	 * @param xslFilePath
	 *            ，xsl文件的位置
	 * @return，转换的结果
	 */
	public static String transform(String xml, String xslFilePath) {
		if (xml == null || xml.length() == 0 || !SmartFile.exists(xslFilePath)) {
			return "";
		}
		String result = "";
		try (StringReader reader = new StringReader(xml);
				StringWriter writer = new StringWriter()) {
			TransformerFactory factory = TransformerFactory.newInstance();
			Source xslt = new StreamSource(new File(xslFilePath));
			Transformer transformer = factory.newTransformer(xslt);

			Source text = new StreamSource(reader);
			transformer.transform(text, new StreamResult(writer));
			result = writer.toString();

		} catch (Exception err) {
			result = "";
		}
		return result;
	}

	/**
	 * 对象映射为Xml
	 * 
	 * @param item
	 *            ，对象
	 * @param rootName
	 *            ，根元素的名称
	 * @param xmlMappingType
	 *            ，映射类型
	 * @return，xml文档
	 */
	public static String toXml(Object item, String rootName,
			SmartXmlMappingType xmlMappingType) {
		HashMap<String, Object> datas = createDatas(item, xmlMappingType);
		StringBuilder result = new StringBuilder();
		result.append(SmartString.format("<{0}>", rootName));
		Set<String> set = datas.keySet();
		for (String key : set) {
			String value = datas.get(key).toString();
			result.append(SmartString.format("<{0}>{1}</{0}>", key, value));
		}
		result.append(SmartString.format("</{0}>", rootName));
		return result.toString();
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
	public static String toXml(Object item, String rootName) {
		return toXml(item, rootName, SmartXmlMappingType.Field);
	}

	private static HashMap<String, Object> createDatas(Object item,
			SmartXmlMappingType xmlMappingType) {
		HashMap<String, Object> datas = new HashMap<String, Object>();
		switch (xmlMappingType) {
		case Auto: {
			try {
				datas = SmartType.getFieldsDictionary(item);
			} catch (Exception err) {
			}

			try {
				Field[] fields = SmartType.getFieldsWithAttribute(
						item.getClass(), SmartNodeMappingAttribute.class);
				for (Field field : fields) {
					String key = field.getName();
					Object temp = SmartType.getFieldValue(item, key);
					String value = temp == null ? "" : temp.toString();
					if (!datas.containsKey(key)) {
						datas.put(key, value);
					}
				}
			} catch (Exception err) {
			}
		}
			break;
		case Attribute: {
			try {
				Field[] fields = SmartType.getFieldsWithAttribute(
						item.getClass(), SmartNodeMappingAttribute.class);
				for (Field field : fields) {
					String key = field.getName();
					Object temp = SmartType.getFieldValue(item, key);
					String value = temp == null ? "" : temp.toString();
					if (!datas.containsKey(key)) {
						datas.put(key, value);
					}
				}
			} catch (Exception err) {
			}
		}
			break;
		case Field: {
			try {
				datas = SmartType.getFieldsDictionary(item);
			} catch (Exception err) {
			}
		}
			break;
		}

		return datas;
	}

	/**
	 * 对象列表映射为Xml
	 * 
	 * @param list
	 *            ，列表
	 * @param rootName
	 *            ，根元素的名称
	 * @param xmlMappingType
	 *            ，映射类型
	 * @return，xml文档
	 */
	public static String toXmls(ArrayList<Object> list, String rootName,
			SmartXmlMappingType xmlMappingType) {
		StringBuilder xml = new StringBuilder();
		for (Object item : list) {
			xml.append(toXml(item, rootName, xmlMappingType)
					+ SmartComputer.LineSeparator);
		}
		return xml.toString();
	}

	/**
	 * 对象列表映射为Xml
	 * 
	 * @param list
	 *            ，列表
	 * @param rootName
	 *            ，根元素的名称
	 * @return，xml文档
	 */
	public static String toXmls(ArrayList<Object> list, String rootName) {
		return toXmls(list, rootName, SmartXmlMappingType.Field);
	}

	/**
	 * 判断指定的节点在文件中是否存在，节点没有值的也认为是不存在
	 * 
	 * @param xelements
	 *            ，文件的LINQ查询集合
	 * @param node
	 *            ，节点名称
	 * @param value
	 *            ，如果存在，则返回节点的值
	 * @return，是否存在，true表示存在，false表示不存在
	 */
	private static boolean queryNode(NodeList xelements, String node,
			SmartRef<String> value) {
		for (int i = 0; i < xelements.getLength(); i++) {
			Node item = xelements.item(i);
			String key = item.getNodeName();
			if (key.toLowerCase().equals(node.toLowerCase())) {
				value.setValue(item.getFirstChild().getNodeValue());
				return true;
			}
		}

		return false;
	}

	/**
	 * 通过XML元素获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，类型
	 * @param xml
	 *            ，XML元素
	 * @param xmkMappingType
	 *            ，映射的类型
	 * @param entity
	 *            ，实体对象
	 */
	private static <T> void toObject(Class<T> c, Node xml,
			SmartXmlMappingType xmkMappingType, SmartRef<T> entity) {
		NodeList xelements = xml.getFirstChild().getChildNodes();
		switch (xmkMappingType) {
		case Auto: {
			try {
				// 根据字段映射
				Field[] fields = SmartType.getFields(c);

				T temp = entity.getValue();

				for (Field fieldInfo : fields) {
					SmartRef<String> source = new SmartRef<String>();
					if (queryNode(xelements, fieldInfo.getName(), source)) {
						Object value = SmartConvert.to(source.getValue(),
								fieldInfo.getType());
						SmartType.setFieldValue(temp, fieldInfo.getName(),
								value);
					}
				}
			} catch (Exception err) {
			}
			try {
				// 根据特性映射
				Field[] fields = SmartType.getFieldsWithAttribute(c,
						SmartNodeMappingAttribute.class);
				T temp = entity.getValue();

				for (Field fieldInfo : fields) {
					SmartRef<String> source = new SmartRef<String>();
					if (queryNode(xelements, fieldInfo.getName(), source)) {
						Object value = SmartConvert.to(source.getValue(),
								fieldInfo.getType());
						SmartType.setFieldValue(temp, fieldInfo.getName(),
								value);
					}
				}
			} catch (Exception err) {
			}
		}
			break;
		case Attribute: {
			try {
				// 根据特性映射
				Field[] fields = SmartType.getFieldsWithAttribute(c,
						SmartNodeMappingAttribute.class);
				T temp = entity.getValue();

				for (Field fieldInfo : fields) {
					SmartRef<String> source = new SmartRef<String>();
					if (queryNode(xelements, fieldInfo.getName(), source)) {
						Object value = SmartConvert.to(source.getValue(),
								fieldInfo.getType());
						SmartType.setFieldValue(temp, fieldInfo.getName(),
								value);
					}
				}
			} catch (Exception err) {
			}
		}
			break;
		case Field: {
			try {
				// 根据字段映射
				Field[] fields = SmartType.getFields(c);

				T temp = entity.getValue();

				for (Field fieldInfo : fields) {
					SmartRef<String> source = new SmartRef<String>();
					if (queryNode(xelements, fieldInfo.getName(), source)) {
						Object value = SmartConvert.to(source.getValue(),
								fieldInfo.getType());
						SmartType.setFieldValue(temp, fieldInfo.getName(),
								value);
					}
				}
			} catch (Exception err) {
			}
		}
			break;
		default:
			break;
		}
	}

	/**
	 * 通过XML字符串获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xml
	 *            ，XML字符串
	 * @param xmlMappingType
	 *            ，映射的类型
	 * @return，已经初始化并赋值的实体
	 */
	public static <T> T toObject(Class<T> c, String xml,
			SmartXmlMappingType xmlMappingType) {
		SmartRef<T> entity = new SmartRef<T>();

		entity.setValue(SmartType.createInstance(c));

		Document document = load(xml);

		toObject(c, document, xmlMappingType, entity);
		return entity.getValue();
	}

	/**
	 * 通过XML字符串获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xml
	 *            ，XML字符串
	 * @return，已经初始化并赋值的实体
	 */
	public static <T> T toObject(Class<T> c, String xml) {
		return toObject(c, xml, SmartXmlMappingType.Field);
	}

	/**
	 * 通过XML文件获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xmlPath
	 *            ，XML文件地址，XML文件必须遵守特定格式
	 * @param xmlMappingType
	 *            ，映射的类型
	 * @return，已经初始化并赋值的实体
	 */
	public static <T> T toObjectFromFile(Class<T> c, String xmlPath,
			SmartXmlMappingType xmlMappingType) {
		String xml = SmartFile.readAllText(xmlPath);
		return toObject(c, xml, xmlMappingType);
	}

	/**
	 * 通过XML文件获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xmlPath
	 *            ，XML文件地址，XML文件必须遵守特定格式
	 * @return，已经初始化并赋值的实体
	 */
	public static <T> T toObjectFromFile(Class<T> c, String xmlPath) {
		return toObjectFromFile(c, xmlPath, SmartXmlMappingType.Field);
	}

	/**
	 * 通过XML字符串获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xml
	 *            ，XML字符串
	 * @param xmlMappingType
	 *            ，映射的类型
	 * @return，已经初始化并赋值的实体列表
	 */
	public static <T> ArrayList<T> toObjects(Class<T> c, String xml,
			SmartXmlMappingType xmlMappingType) {
		Document document = load(xml);

		NodeList items = document.getFirstChild().getChildNodes();
		ArrayList<T> results = new ArrayList<T>();
		for (int i = 0; i < items.getLength(); i++) {
			Node item = items.item(i);
			if (item.getNodeType() == Node.ELEMENT_NODE) {
				results.add(toObject(c, toString(item), xmlMappingType));
			}
		}
		return results;
	}

	/**
	 * 通过XML字符串获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xml
	 *            ，XML字符串
	 * @return，已经初始化并赋值的实体列表
	 */
	public static <T> ArrayList<T> toObjects(Class<T> c, String xml) {
		return toObjects(c, xml, SmartXmlMappingType.Field);
	}

	/**
	 * 通过XML文件获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xmlPath
	 *            ，XML文件地址，XML文件必须遵守特定格式
	 * @param xmlMappingType
	 *            ，映射的类型
	 * @return，已经初始化并赋值的实体列表
	 */
	public static <T> ArrayList<T> toObjectsFromFile(Class<T> c,
			String xmlPath, SmartXmlMappingType xmlMappingType) {
		String xml = SmartFile.readAllText(xmlPath);

		return toObjects(c, xml, xmlMappingType);
	}

	/**
	 * 通过XML文件获得实体，实体必须提供了公有构造函数
	 * 
	 * @param c
	 *            ，实体类型
	 * @param xmlPath
	 *            ，XML文件地址，XML文件必须遵守特定格式
	 * @return，已经初始化并赋值的实体列表
	 */
	public static <T> ArrayList<T> toObjectsFromFile(Class<T> c, String xmlPath) {
		return toObjectsFromFile(c, xmlPath, SmartXmlMappingType.Field);
	}

	/**
	 * 节点转换为字符串
	 * 
	 * @param node
	 *            ，节点
	 * @return，结果
	 */
	public static String toString(Node node) {
		try {
			StringWriter writer = new StringWriter();
			Transformer transformer = TransformerFactory.newInstance()
					.newTransformer();
			transformer
					.transform(new DOMSource(node), new StreamResult(writer));
			String temp = writer.toString();

			return temp;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 加载xml文档
	 * 
	 * @param xml
	 *            ，xml
	 * @return，结果
	 */
	public static Document load(String xml) {
		try {
			DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory
					.newInstance();
			DocumentBuilder documentBuilder = documentBuilderFactory
					.newDocumentBuilder();
			Document document = documentBuilder.parse(new InputSource(
					new ByteArrayInputStream(xml
							.getBytes(SmartEncoding.Default))));
			return document;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
