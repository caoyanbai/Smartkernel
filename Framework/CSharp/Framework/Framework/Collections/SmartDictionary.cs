/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Web;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Smartkernel.Framework.Collections
{
	/// <summary>
	/// 字典
	/// </summary>
	public class SmartDictionary
	{
		/// <summary>
		/// 对象映射为Xml
		/// </summary>
		/// <param name="item">对象</param>
		/// <param name="rootName">根元素的名称</param>
		/// <returns>xml文档</returns>
		public static string ToXml(Dictionary<string, string> item, string rootName)
		{
			StringBuilder result = new StringBuilder();
			result.Append(string.Format("<{0}>", rootName));
			foreach (var one in item)
			{
				string value = one.Value;
				result.Append(string.Format("<{0}>{1}</{0}>", one.Key, value));
			}
			result.Append(string.Format("</{0}>", rootName));
			return result.ToString();
		}

		/// <summary>
		/// 从Xml解析
		/// </summary>
		/// <param name="xml">Xml</param>
		/// <returns>结果</returns>
		public static Dictionary<string, string> FromXml(string xml)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			var nodes = XElement.Parse(xml).Nodes();

			foreach (var node in nodes)
			{
				var nodeXml = node.ToString();
				var element = XElement.Parse(nodeXml);
				result.Add(element.Name.ToString(), element.Value);
			}

			return result;
		}

		/// <summary>
		/// 对象映射为Json
		/// </summary>
		/// <param name="item">对象</param>
		/// <returns>xml文档</returns>
		public static string ToJson(Dictionary<string, string> item)
		{
			return SmartJson.ToJson(item);
		}

		/// <summary>
		/// 从Json解析
		/// </summary>
		/// <param name="json">Json</param>
		/// <returns>结果</returns>
		public static Dictionary<string, string> FromJson(string json)
		{
			return SmartJson.FromJson<Dictionary<string, string>>(json);
		}
	}
}
