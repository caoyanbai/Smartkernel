/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 比较
	/// </summary>
	public static class SmartCompare
	{
		/// <summary>
		/// 判断一个值是否在一个值范围内
		/// </summary>
		/// <param name="input">输入</param>
		/// <param name="start">开始</param>
		/// <param name="end">结束</param>
		/// <returns>结果</returns>
		public static bool InScope<T>(T input, T start, T end) where T :IComparable
		{
			return input.CompareTo(start) >= 0 && input.CompareTo(end) <= 0;
		}

		/// <summary>
		/// 判断一个值是否不在一个值范围内
		/// </summary>
		/// <param name="input">输入</param>
		/// <param name="start">开始</param>
		/// <param name="end">结束</param>
		/// <returns>结果</returns>
		public static bool NotInScope<T>(T input, T start, T end) where T : IComparable
		{
			return !InScope(input, start, end);
		}

		/// <summary>
		/// 判断一个值是否在一个值范围内（有一个在其范围内即为真）
		/// </summary>
		/// <param name="inputs">输入</param>
		/// <param name="start">开始</param>
		/// <param name="end">结束</param>
		/// <returns>结果</returns>
		public static bool AnyInScope<T>(List<T> inputs, T start, T end) where T : IComparable
		{
			foreach (var input in inputs)
			{
				if (InScope<T>(input,start,end))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 判断一个值是否不在一个值范围内（有一个在其范围内即为假）
		/// </summary>
		/// <param name="inputs">输入</param>
		/// <param name="start">开始</param>
		/// <param name="end">结束</param>
		/// <returns>结果</returns>
		public static bool NotAnyInScope<T>(List<T> inputs, T start, T end) where T : IComparable
		{
			return !AnyInScope(inputs, start, end);
		}
		
		/// <summary>
		/// 判断一个值是否在一个值范围内（有一个在其范围内即为真）
		/// </summary>
		/// <param name="inputs">输入</param>
		/// <param name="start">开始</param>
		/// <param name="end">结束</param>
		/// <returns>结果</returns>
		public static bool AllInScope<T>(List<T> inputs, T start, T end) where T : IComparable
		{
			foreach (var input in inputs)
			{
				if (!InScope<T>(input,start,end))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 判断一个值是否不在一个值范围内（有一个在其范围内即为假）
		/// </summary>
		/// <param name="inputs">输入</param>
		/// <param name="start">开始</param>
		/// <param name="end">结束</param>
		/// <returns>结果</returns>
		public static bool NotAllInScope<T>(List<T> inputs, T start, T end) where T : IComparable
		{
			return !AllInScope(inputs, start, end);
		}
	}
}
