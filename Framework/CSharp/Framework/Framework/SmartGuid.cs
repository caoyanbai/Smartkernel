/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework
{
	/// <summary>
	/// Guid
	/// </summary>
	public static class SmartGuid
	{
		/// <summary>
		/// 判断是否是Guid
		/// </summary>
		/// <param name="guid">guid的字符串表示形式</param>
		/// <returns>判断的结果</returns>
		public static bool IsGuid(string guid)
		{
			Guid result;
			return Guid.TryParse(guid, out result);
		}

		/// <summary>
		/// 产生Guid
		/// </summary>
		/// <returns>结果</returns>
		public static string NewGuid()
		{
			return Guid.NewGuid().ToString("N").ToLower();
		}
	}
}
