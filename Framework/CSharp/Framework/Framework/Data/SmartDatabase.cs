/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Web;

namespace Smartkernel.Framework.Data
{
	/// <summary>
	/// 数据库操作
	/// </summary>
	public static class SmartDatabase
	{
		private const string sqlCommandKeywords = "and|exec|execute|insert|select|delete|update|count|chr|mid|master|" +
		                                                "char|declare|sitename|net user|xp_cmdshell|or|create|drop|table|from|grant|use|group_concat|column_name|" +
		                                                "information_schema.columns|table_schema|union|where|select|delete|update|orderhaving|having|by|count|*|truncate|like";

		private const string sqlSeparatKeywords = "'|;|,|--|\'|\"|/*|%|#";

		private static readonly List<string> sqlKeywordsArray = new List<string>();

		/// <summary>
		/// 静态构造函数
		/// </summary>
		static SmartDatabase()
		{
			sqlKeywordsArray.AddRange(sqlSeparatKeywords.Split('|'));
			sqlKeywordsArray.AddRange(Array.ConvertAll<string, string>(sqlCommandKeywords.Split('|'), h => h = h + " "));
			sqlKeywordsArray.AddRange(Array.ConvertAll<string, string>(sqlCommandKeywords.Split('|'), h => h = " " + h));
		}

		/// <summary>
		/// 是否安全
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>返回</returns>
		public static bool IsSafetySql(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return true;
			}
			input = (HttpUtility.UrlDecode(input)).ToLower();

			foreach (var sqlKeyword in sqlKeywordsArray)
			{
				if (input.IndexOf(sqlKeyword) >= 0)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 返回安全字符串
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>返回</returns>
		public static string GetSafetySql(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			input = (HttpUtility.UrlDecode(input)).ToLower();

			foreach (var sqlKeyword in sqlKeywordsArray)
			{
				if (input.IndexOf(sqlKeyword) >= 0)
				{
					input = input.Replace(sqlKeyword, string.Empty);
				}
			}
			return input;
		}
	}
}
