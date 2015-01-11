/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Smartkernel.Framework.Xml
{
	/// <summary>
	/// Xml
	/// </summary>
	public static class SmartXml
	{
		/// <summary>
		/// 通过XML文件获得实体，实体必须提供了公有构造函数
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="xmlPath">XML文件地址，XML文件必须遵守特定格式</param>
		/// <param name="xmlMappingType">映射的类型</param>
		/// <returns>已经初始化并赋值的实体</returns>
		public static T ToObjectFromFile<T>(string xmlPath, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			var entity = Activator.CreateInstance<T>();
			ToObject(XElement.Load(xmlPath), xmlMappingType, ref entity);
			return entity;
		}

		/// <summary>
		/// 通过XML字符串获得实体，实体必须提供了公有构造函数
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="xml">XML字符串</param>
		/// <param name="xmlMappingType">映射的类型</param>
		/// <returns>已经初始化并赋值的实体</returns>
		public static T ToObject<T>(string xml, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			var entity = Activator.CreateInstance<T>();
			ToObject(XElement.Parse(xml), xmlMappingType, ref entity);
			return entity;
		}

		/// <summary>
		/// 通过XML元素获得实体，实体必须提供了公有构造函数
		/// </summary>
		/// <param name="xml">XML元素</param>
		/// <param name="xmkMappingType">映射的类型</param>
		/// <param name="entity">实体对象</param>
		private static void ToObject<T>(XElement xml, SmartXmlMappingType xmkMappingType, ref T entity)
		{
			var type = entity.GetType();
			var xelements = xml.Descendants();

			switch (xmkMappingType) {
				case SmartXmlMappingType.Auto:
					{
						try {
							#region 根据字段映射

							foreach (var fieldInfo in SmartType.GetFields(type)) {
								string source = null;
								if (QueryNode(xelements, fieldInfo.Name, out source)) {
									var value = SmartConvert.To(source, fieldInfo.FieldType);
									fieldInfo.SetValue(entity, value);
								}
							}

							#endregion
						} catch {
						}

						try {
							#region 根据属性映射

							foreach (var propertyInfo in SmartType.GetProperties(type)) {
								string source = null;
								if (QueryNode(xelements, propertyInfo.Name, out source)) {
									var value = SmartConvert.To(source, propertyInfo.PropertyType);
									propertyInfo.SetValue(entity, value, null);
								}
							}

							#endregion
						} catch {
						}

						try {
							#region 根据特性标识映射

							foreach (var propertyInfo in SmartType.GetPropertiesWithAttribute<SmartNodeMappingAttribute>(type)) {
								var attribute = (SmartNodeMappingAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(SmartNodeMappingAttribute), false);
								string source = null;
								if (QueryNode(xelements, attribute.NodeName, out source)) {
									var value = SmartConvert.To(source, propertyInfo.PropertyType);
									propertyInfo.SetValue(entity, value, null);
								} else {
									if (attribute.DefaultValue != null) {
										propertyInfo.SetValue(entity, attribute.DefaultValue, null);
									}
								}
							}
							foreach (var fieldInfo in SmartType.GetFieldsWithAttribute<SmartNodeMappingAttribute>(type)) {
								var attribute = (SmartNodeMappingAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(SmartNodeMappingAttribute), false);
								string source = null;
								if (QueryNode(xelements, attribute.NodeName, out source)) {
									var value = SmartConvert.To(source, fieldInfo.FieldType);
									fieldInfo.SetValue(entity, value);
								} else {
									if (attribute.DefaultValue != null) {
										fieldInfo.SetValue(entity, attribute.DefaultValue);
									}
								}
							}

							#endregion
						} catch {
						}
					}
					break;
				case SmartXmlMappingType.Attribute:
					{
						#region 根据特性标识映射

						foreach (var propertyInfo in SmartType.GetPropertiesWithAttribute<SmartNodeMappingAttribute>(type)) {
							var attribute = (SmartNodeMappingAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(SmartNodeMappingAttribute), false);
							string source = null;
							if (QueryNode(xelements, attribute.NodeName, out source)) {
								var value = SmartConvert.To(source, propertyInfo.PropertyType);
								propertyInfo.SetValue(entity, value, null);
							} else {
								if (attribute.DefaultValue != null) {
									propertyInfo.SetValue(entity, attribute.DefaultValue, null);
								}
							}
						}
						foreach (var fieldInfo in SmartType.GetFieldsWithAttribute<SmartNodeMappingAttribute>(type)) {
							var attribute = (SmartNodeMappingAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(SmartNodeMappingAttribute), false);
							string source;
							if (QueryNode(xelements, attribute.NodeName, out source)) {
								var value = SmartConvert.To(source, fieldInfo.FieldType);
								fieldInfo.SetValue(entity, value);
							} else {
								if (attribute.DefaultValue != null) {
									fieldInfo.SetValue(entity, attribute.DefaultValue);
								}
							}
						}

						#endregion
					}
					break;
				case SmartXmlMappingType.Property:
					{
						#region 根据属性映射

						foreach (var propertyInfo in SmartType.GetProperties(type)) {
							string source;
							if (QueryNode(xelements, propertyInfo.Name, out source)) {
								var value = SmartConvert.To(source, propertyInfo.PropertyType);
								propertyInfo.SetValue(entity, value, null);
							}
						}

						#endregion
					}
					break;
				case SmartXmlMappingType.Field:
					{
						#region 根据字段映射

						foreach (var fieldInfo in SmartType.GetFields(type)) {
							string source = null;
							if (QueryNode(xelements, fieldInfo.Name, out source)) {
								var value = SmartConvert.To(source, fieldInfo.FieldType);
								fieldInfo.SetValue(entity, value);
							}
						}

						#endregion
					}
					break;
			}
		}

		/// <summary>
		/// 通过XML文件获得实体，实体必须提供了公有构造函数
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="xmlPath">XML文件地址，XML文件必须遵守特定格式</param>
		/// <param name="xmlMappingType">映射的类型</param>
		/// <returns>已经初始化并赋值的实体列表</returns>
		public static List<T> ToObjectsFromFile<T>(string xmlPath, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			String xml = File.ReadAllText(xmlPath);
			return ToObjects<T>(xml, xmlMappingType);
		}

		/// <summary>
		/// 通过XML字符串获得实体，实体必须提供了公有构造函数
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="xml">XML字符串</param>
		/// <param name="xmlMappingType">映射的类型</param>
		/// <returns>已经初始化并赋值的实体列表</returns>
		public static List<T> ToObjects<T>(string xml, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			var xmls = XElement.Parse(xml);
			var xelements = xmls.Descendants();
			var entityList = new List<T>(xelements.Count());
			var xelementList = xelements.ToList();
			xelementList.ForEach(delegate(XElement xe) {
				var entity = Activator.CreateInstance<T>();
				
				ToObject(xe, xmlMappingType, ref entity);
				
				entityList.Add(entity);
			});
			return entityList;
		}

		/// <summary>
		/// 判断指定的节点在文件中是否存在，节点没有值的也认为是不存在
		/// </summary>
		/// <param name="xelements">文件的LINQ查询集合</param>
		/// <param name="node">节点名称</param>
		/// <param name="value">如果存在，则返回节点的值</param>
		/// <returns>是否存在，true表示存在，false表示不存在</returns>
		private static bool QueryNode(IEnumerable<XElement> xelements, string node, out string value)
		{
			var values = from v in xelements
			             where v.Name.ToString().ToLower() == node.ToLower() && v.Value.Trim().Length > 0
			             select v;
			if (values.Count() > 1) {
				throw new Exception();
			}
			if (values.Count() == 1) {
				value = values.First().Value.Trim();
				return true;
			}
			value = string.Empty;
			return false;
		}

		/// <summary>
		/// 对象列表映射为Xml
		/// </summary>
		/// <typeparam name="T">对象类型</typeparam>
		/// <param name="list">列表</param>
		/// <param name="rootName">根元素的名称</param>
		/// <param name="xmlMappingType">映射类型</param>
		/// <returns>xml文档</returns>
		public static string ToXmls<T>(List<T> list, string rootName, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			var xml = new StringBuilder();
			list.ForEach(item => xml.AppendLine(ToXml(item, rootName, xmlMappingType)));
			return xml.ToString();
		}

		private static XElement[] CreateXElements<T>(T item, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			var list = new List<XElement>();
			var datas = new Dictionary<string, object>();
			switch (xmlMappingType) {
				case SmartXmlMappingType.Auto:
					{
						try {
							datas = SmartType.GetFieldsDictionary(item);
						} catch {
						}

						try {
							datas = SmartType.GetPropertiesDictionary(item);
						} catch {
						}

						try {
							var fields = SmartType.GetFieldsWithAttribute<SmartNodeMappingAttribute>(typeof(T));
							foreach (var field in fields) {
								var key = field.Name;
								var temp = SmartType.GetFieldValue(item, key);
								var value = temp == null ? string.Empty : temp.ToString();
								if (!datas.ContainsKey(key)) {
									datas.Add(key, value);
								}
							}
							var properties = SmartType.GetPropertiesWithAttribute<SmartNodeMappingAttribute>(typeof(T));
							foreach (var property in properties) {
								var key = property.Name;
								var temp = SmartType.GetPropertyValue(item, key);
								var value = temp == null ? string.Empty : temp.ToString();
								if (!datas.ContainsKey(key)) {
									datas.Add(key, value);
								}
							}
						} catch {
						}
					}
					break;
				case SmartXmlMappingType.Attribute:
					{
						var fields = SmartType.GetFieldsWithAttribute<SmartNodeMappingAttribute>(typeof(T));
						foreach (var field in fields) {
							var key = field.Name;
							var temp = SmartType.GetFieldValue(item, key);
							var value = temp == null ? string.Empty : temp.ToString();
							if (!datas.ContainsKey(key)) {
								datas.Add(key, value);
							}
						}
						var properties = SmartType.GetPropertiesWithAttribute<SmartNodeMappingAttribute>(typeof(T));
						foreach (var property in properties) {
							var key = property.Name;
							var temp = SmartType.GetPropertyValue(item, key);
							var value = temp == null ? string.Empty : temp.ToString();
							if (!datas.ContainsKey(key)) {
								datas.Add(key, value);
							}
						}
					}
					break;
				case SmartXmlMappingType.Property:
					{
						datas = SmartType.GetPropertiesDictionary(item);
					}
					break;
				case SmartXmlMappingType.Field:
					{
						datas = SmartType.GetFieldsDictionary(item);
					}
					break;
			}

			var enumerator = datas.GetEnumerator();
			while (enumerator.MoveNext()) {
				list.Add(new XElement(enumerator.Current.Key, enumerator.Current.Value));
			}

			return list.ToArray();
		}

		/// <summary>
		/// 对象映射为Xml
		/// </summary>
		/// <typeparam name="T">对象类型</typeparam>
		/// <param name="item">对象</param>
		/// <param name="rootName">根元素的名称</param>
		/// <param name="xmlMappingType">映射类型</param>
		/// <returns>xml文档</returns>
		public static string ToXml<T>(T item, string rootName, SmartXmlMappingType xmlMappingType = SmartXmlMappingType.Property)
		{
			var xml = new XDocument(new XElement(rootName, CreateXElements(item, xmlMappingType)));
			return xml.ToString();
		}

		/// <summary>
		/// 根据xsl转换xml文档
		/// </summary>
		/// <param name="xml">xml文档的内容</param>
		/// <param name="xslFilePath">xsl文件的位置</param>
		/// <returns>转换的结果</returns>
		public static string Transform(string xml, string xslFilePath)
		{
			if (xml == null || xml.Length == 0 || !File.Exists(xslFilePath)) {
				return "";
			}

			string result = "";
			try {
				using (TextReader styleSheetTextReader = new StreamReader(new FileStream(xslFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))) {
					TextReader xmlTextReader = new StringReader(xml);
					TextWriter xmlTextWriter = new StringWriter();
					Transform(xmlTextReader, styleSheetTextReader, xmlTextWriter);
					result = xmlTextWriter.ToString();
				}
			} catch {
				result = "";
			}
			return result;
		}

		private static TextWriter Transform(TextReader xmlTextReader, TextReader styleSheetTextReader, TextWriter xmlTextWriter)
		{
			if (null == xmlTextReader || null == styleSheetTextReader) {
				return xmlTextWriter;
			}

			XslCompiledTransform xslt = new XslCompiledTransform();
			XsltSettings settings = new XsltSettings(false, false);
			using (XmlReader sheetReader = XmlReader.Create(styleSheetTextReader)) {
				xslt.Load(sheetReader, settings, null);
			}

			using (XmlReader inReader = XmlReader.Create(xmlTextReader)) {
				xslt.Transform(inReader, null, xmlTextWriter);
			}
			return xmlTextWriter;
		}

		/// <summary>
		/// 序列化对象为xml文档
		/// </summary>
		/// <typeparam name="T">对象类型</typeparam>
		/// <param name="item">对象</param>
		/// <returns>序列化的结果</returns>
		public static string Serialize<T>(T item)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringBuilder stringBuilder = new StringBuilder();
			using (StringWriter stringWriter = new StringWriter(stringBuilder)) {
				xmlSerializer.Serialize(stringWriter, item);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// 序列化对象为xml文档
		/// </summary>
		/// <param name="item">对象</param>
		/// <returns>序列化的结果</returns>
		public static string Serialize(object item)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());
			StringBuilder stringBuilder = new StringBuilder();
			using (StringWriter stringWriter = new StringWriter(stringBuilder)) {
				xmlSerializer.Serialize(stringWriter, item);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// xml文档串行化为对象
		/// </summary>
		/// <typeparam name="T">对象类型</typeparam>
		/// <param name="xml">xml文档</param>
		/// <returns>串行化的结果</returns>
		public static T Deserialize<T>(string xml)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (TextReader textReader = new StringReader(xml)) {
				return (T)xmlSerializer.Deserialize(textReader);
			}
		}

		/// <summary>
		/// xml文档串行化为对象
		/// </summary>
		/// <param name="xml">xml文档</param>
		/// <param name="type">类型</param>
		/// <returns>串行化的结果</returns>
		public static object Deserialize(string xml, Type type)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			using (TextReader textReader = new StringReader(xml)) {
				return xmlSerializer.Deserialize(textReader);
			}
		}
	}
}
