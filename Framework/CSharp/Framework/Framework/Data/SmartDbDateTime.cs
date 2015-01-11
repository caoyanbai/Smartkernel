/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.Data
{
	/// <summary>
	/// Db时间类型
	/// </summary>
	public static class SmartDbDateTime
	{
		/// <summary>
		/// 默认
		/// </summary>
		public static readonly DateTime Default = DateTime.Parse("1900-01-01 00:00:00");

		/// <summary>
		/// 开始时间
		/// </summary>
		public static readonly DateTime MinTime = DateTime.Parse("1753-01-01 00:00:00");

		/// <summary>
		/// 结束时间
		/// </summary>
		public static readonly DateTime MaxTime = DateTime.Parse("9999-12-31 23:59:59.997");

		/// <summary>
		/// 开始日期
		/// </summary>
		public static readonly DateTime MinDate = DateTime.Parse("1753-01-01 00:00:00");

		/// <summary>
		/// 结束日期
		/// </summary>
		public static readonly DateTime MaxDate = DateTime.Parse("9999-12-31 00:00:00");

		/// <summary>
		/// 是否合法的时间
		/// </summary>
		/// <param name="dateTime">时间</param>
		/// <returns>结果</returns>
		public static bool IsLegalDateTime(DateTime dateTime)
		{
			if (dateTime < MinTime || dateTime > MaxTime)
			{
				return false;
			}

			return true;
		}
	}
}
