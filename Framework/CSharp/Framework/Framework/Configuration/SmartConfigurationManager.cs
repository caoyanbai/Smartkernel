/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Smartkernel.Framework.Configuration
{
	/// <summary>
	/// 配置管理类
	/// </summary>
	public static class SmartConfigurationManager
	{
		/// <summary>
		/// 获得值
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="key">键（不区分大小写）</param>
		/// <param name="isDecode">是否解码</param>
		/// <returns>结果</returns>
		public static T GetValue<T>(string key, bool isDecode = true)
		{
			var value = ConfigurationManager.AppSettings[key];
			var type = typeof(T);
			if (type == typeof(string) && isDecode)
			{
				value = HttpUtility.HtmlDecode(value);
			}
			if (type.IsEnum)
			{
				return (T)Enum.Parse(type, value, true);
			}
			else
			{
				return (T)Convert.ChangeType(value, typeof(T));
			}
		}

		/// <summary>
		/// 获得值
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="key">键（不区分大小写）</param>
		/// <param name="split">分割符</param>
		/// <param name="isDecode">是否解码</param>
		/// <returns>结果</returns>
		public static T[] GetValues<T>(string key, char split = '|', bool isDecode = true)
		{
			var value = ConfigurationManager.AppSettings[key];
			var type = typeof(T);
			if (type == typeof(string) && isDecode)
			{
				value = HttpUtility.HtmlDecode(value);
			}
			return SmartArray.Parse<T>(value, split);
		}

		/// <summary>
		/// 刷新配置
		/// </summary>
		public static void Refresh()
		{
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
}
