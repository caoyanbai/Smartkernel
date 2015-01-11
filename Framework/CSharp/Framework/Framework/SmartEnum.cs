/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 枚举辅助操作类
	/// </summary>
	public static class SmartEnum
	{
		/// <summary>
		/// 将字符串表示形式的枚举解析成枚举类型
		/// </summary>
		/// <typeparam name="T">枚举类型</typeparam>
		/// <param name="value">字符串表示形式</param>
		/// <returns>解析的结果</returns>
		public static T Parse<T>(string value)
		{
			var type = typeof(T);
			return (T)Enum.Parse(type, value, true);
		}

		/// <summary>
		/// 获得某种枚举类型下的所有枚举值
		/// </summary>
		/// <typeparam name="T">枚举类型</typeparam>
		/// <returns>所有值</returns>
		public static List<T> GetAll<T>()
		{
			var enumType = typeof(T);

			var values = new List<T>();

			var fields = from field in enumType.GetFields()
			                      where field.IsLiteral
			                      select field;

			foreach (var field in fields)
			{
				var value = field.GetValue(enumType);
				values.Add((T)value);
			}
			return values.ToList();
		}
	}
}
