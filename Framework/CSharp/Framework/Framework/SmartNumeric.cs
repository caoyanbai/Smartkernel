/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System;
using System.Numerics;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 数字类型相关
	/// </summary>
	public static class SmartNumeric
	{
		/// <summary>
		/// 是否是0
		/// </summary>
		/// <param name="input">待检查的数字</param>
		/// <param name="compareValue">比较的值</param>
		/// <returns>结果</returns>
		public static bool IsZero(double input, double compareValue = 2.2204460492503131E-15)
		{
			return Math.Abs(input) < compareValue;
		}

		/// <summary>
		/// 是否是0
		/// </summary>
		/// <param name="input">待检查的数字</param>
		/// <param name="compareValue">比较的值</param>
		/// <returns>结果</returns>
		public static bool IsZero(float input, float compareValue = 2.2204460492503131E-15f)
		{
			return Math.Abs(input) < compareValue;
		}

		/// <summary>
		/// 是否是0
		/// </summary>
		/// <param name="input">待检查的数字</param>
		/// <param name="compareValue">比较的值</param>
		/// <returns>结果</returns>
		public static bool IsZero(decimal input, decimal compareValue = 2.2204460492503131E-15m)
		{
			return Math.Abs(input) < compareValue;
		}

		/// <summary>
		/// 是否是0
		/// </summary>
		/// <param name="input">待检查的数字</param>
		/// <returns>结果</returns>
		public static bool IsZero(int input)
		{
			return input == 0;
		}

		/// <summary>
		/// 是否是0
		/// </summary>
		/// <param name="input">待检查的数字</param>
		/// <returns>结果</returns>
		public static bool IsZero(long input)
		{
			return input == 0;
		}

		/// <summary>
		/// 是否是0
		/// </summary>
		/// <param name="input">待检查的数字</param>
		/// <returns>结果</returns>
		public static bool IsZero(BigInteger input)
		{
			return input == 0;
		}

		/// <summary>
		/// 近似相等
		/// </summary>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <param name="compareValue">比较的值</param>
		/// <returns>是否相等</returns>
		public static bool NearEquals(double left, double right, double compareValue = 2.2204460492503131E-16)
		{
			if (left == right)
			{
				return true;
			}
			double a = (Math.Abs(left) + Math.Abs(right) + 10.0) * compareValue;
			double b = left - right;
			return (-a < b) && (a > b);
		}

		/// <summary>
		/// 近似相等
		/// </summary>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <param name="compareValue">比较的值</param>
		/// <returns>是否相等</returns>
		public static bool NearEquals(float left, float right, float compareValue = 2.2204460492503131E-16f)
		{
			if (left == right)
			{
				return true;
			}
			double a = (Math.Abs(left) + Math.Abs(right) + 10.0) * compareValue;
			double b = left - right;
			return (-a < b) && (a > b);
		}

		/// <summary>
		/// 近似相等
		/// </summary>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <param name="compareValue">比较的值</param>
		/// <returns>是否相等</returns>
		public static bool NearEquals(decimal left, decimal right, decimal compareValue = 2.2204460492503131E-16m)
		{
			if (left == right)
			{
				return true;
			}
			decimal a = (Math.Abs(left) + Math.Abs(right) + 10.0m) * compareValue;
			decimal b = left - right;
			return (-a < b) && (a > b);
		}

		/// <summary>
		/// 近似相等
		/// </summary>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>是否相等</returns>
		public static bool NearEquals(int left, int right)
		{
			return left == right;
		}

		/// <summary>
		/// 近似相等
		/// </summary>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>是否相等</returns>
		public static bool NearEquals(long left, long right)
		{
			return left == right;
		}

		/// <summary>
		/// 近似相等
		/// </summary>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>是否相等</returns>
		public static bool NearEquals(BigInteger left, BigInteger right)
		{
			return left == right;
		}

		/// <summary>
		/// 是否在两个数字之间
		/// </summary>
		/// <param name="number">要比较的数字</param>
		/// <param name="from">开始</param>
		/// <param name="to">结束</param>
		/// <param name="isLimitFrom">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <param name="isLimitTo">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <returns>结果</returns>
		public static bool Between(double number, double from, double to, bool isLimitFrom = false, bool isLimitTo = false)
		{
			if (from == to)
			{
				return number == from;
			}

			if (from > to)
			{
				throw new Exception("左侧边界不能大于右侧边界！");
			}

			if (isLimitFrom && isLimitTo)
			{
				return from <= number && number <= to;
			}
			else if (isLimitFrom && !isLimitTo)
			{
				return from <= number && number < to;
			}
			else if (!isLimitFrom && isLimitTo)
			{
				return from < number && number <= to;
			}
			else
			{
				return from < number && number < to;
			}
		}

		/// <summary>
		/// 是否在两个数字之间
		/// </summary>
		/// <param name="number">要比较的数字</param>
		/// <param name="from">开始</param>
		/// <param name="to">结束</param>
		/// <param name="isLimitFrom">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <param name="isLimitTo">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <returns>结果</returns>
		public static bool Between(float number, float from, float to, bool isLimitFrom = false, bool isLimitTo = false)
		{
			if (from == to)
			{
				return number == from;
			}

			if (from > to)
			{
				throw new Exception("左侧边界不能大于右侧边界！");
			}

			if (isLimitFrom && isLimitTo)
			{
				return from <= number && number <= to;
			}
			else if (isLimitFrom && !isLimitTo)
			{
				return from <= number && number < to;
			}
			else if (!isLimitFrom && isLimitTo)
			{
				return from < number && number <= to;
			}
			else
			{
				return from < number && number < to;
			}
		}

		/// <summary>
		/// 是否在两个数字之间
		/// </summary>
		/// <param name="number">要比较的数字</param>
		/// <param name="from">开始</param>
		/// <param name="to">结束</param>
		/// <param name="isLimitFrom">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <param name="isLimitTo">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <returns>结果</returns>
		public static bool Between(decimal number, decimal from, decimal to, bool isLimitFrom = false, bool isLimitTo = false)
		{
			if (from == to)
			{
				return number == from;
			}

			if (from > to)
			{
				throw new Exception("左侧边界不能大于右侧边界！");
			}

			if (isLimitFrom && isLimitTo)
			{
				return from <= number && number <= to;
			}
			else if (isLimitFrom && !isLimitTo)
			{
				return from <= number && number < to;
			}
			else if (!isLimitFrom && isLimitTo)
			{
				return from < number && number <= to;
			}
			else
			{
				return from < number && number < to;
			}
		}

		/// <summary>
		/// 是否在两个数字之间
		/// </summary>
		/// <param name="number">要比较的数字</param>
		/// <param name="from">开始</param>
		/// <param name="to">结束</param>
		/// <param name="isLimitFrom">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <param name="isLimitTo">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <returns>结果</returns>
		public static bool Between(int number, int from, int to, bool isLimitFrom = false, bool isLimitTo = false)
		{
			if (from == to)
			{
				return number == from;
			}

			if (from > to)
			{
				throw new Exception("左侧边界不能大于右侧边界！");
			}

			if (isLimitFrom && isLimitTo)
			{
				return from <= number && number <= to;
			}
			else if (isLimitFrom && !isLimitTo)
			{
				return from <= number && number < to;
			}
			else if (!isLimitFrom && isLimitTo)
			{
				return from < number && number <= to;
			}
			else
			{
				return from < number && number < to;
			}
		}

		/// <summary>
		/// 是否在两个数字之间
		/// </summary>
		/// <param name="number">要比较的数字</param>
		/// <param name="from">开始</param>
		/// <param name="to">结束</param>
		/// <param name="isLimitFrom">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <param name="isLimitTo">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <returns>结果</returns>
		public static bool Between(long number, long from, long to, bool isLimitFrom = false, bool isLimitTo = false)
		{
			if (from == to)
			{
				return number == from;
			}

			if (from > to)
			{
				throw new Exception("左侧边界不能大于右侧边界！");
			}

			if (isLimitFrom && isLimitTo)
			{
				return from <= number && number <= to;
			}
			else if (isLimitFrom && !isLimitTo)
			{
				return from <= number && number < to;
			}
			else if (!isLimitFrom && isLimitTo)
			{
				return from < number && number <= to;
			}
			else
			{
				return from < number && number < to;
			}
		}

		/// <summary>
		/// 是否在两个数字之间
		/// </summary>
		/// <param name="number">要比较的数字</param>
		/// <param name="from">开始</param>
		/// <param name="to">结束</param>
		/// <param name="isLimitFrom">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <param name="isLimitTo">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
		/// <returns>结果</returns>
		public static bool Between(BigInteger number, BigInteger from, BigInteger to, bool isLimitFrom = false, bool isLimitTo = false)
		{
			if (from == to)
			{
				return number == from;
			}

			if (from > to)
			{
				throw new Exception("左侧边界不能大于右侧边界！");
			}

			if (isLimitFrom && isLimitTo)
			{
				return from <= number && number <= to;
			}
			else if (isLimitFrom && !isLimitTo)
			{
				return from <= number && number < to;
			}
			else if (!isLimitFrom && isLimitTo)
			{
				return from < number && number <= to;
			}
			else
			{
				return from < number && number < to;
			}
		}

		/// <summary>
		/// 验证是不是Double类型的数字：25，1.23，-10等都是合法的数字
		/// </summary>
		/// <param name="input">待检查的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsDouble(string input)
		{
			double number;
			return double.TryParse(input, out number);
		}

		/// <summary>
		/// 验证是不是正整数：大于0的整数（2.0，+32.0,3.也判断为正整数）
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsPositiveInteger(string input)
		{
			const string pattern1 = @"^[+]?[0-9]+[.]?[0]*$";
			const string pattern2 = @"^[+-]?[0]+[.]?[0]*$";
			return IsDouble(input) && Convert.ToDouble(input) > 0 && (SmartRegex.IsMatch(input, pattern1) || SmartRegex.IsMatch(input, pattern2));
		}

		/// <summary>
		/// 验证是不是整数：可以为正也可以为负（0.0，2.0，+32.0，-123.00000，3.也判断为整数）
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsInteger(string input)
		{
			const string pattern = @"^[+-]?[0-9]+[.]?[0]*$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是数字
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsNumberic(string input)
		{
			decimal result;
			return Decimal.TryParse(input, out result);
		}

		/// <summary>
		/// 验证小数位数是不是在指定的范围内
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <param name="start">起始边界</param>
		/// <param name="end">结束边界</param>
		/// <returns>验证的结果</returns>
		public static bool IsDecimalDigitsBetween(string input, int start, int end)
		{
			var pattern = string.Format(@"^[+-]?[0-9]+(.[0-9]{{{0},{1}}})$", start, end);
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证小数位数是不是指定的长度
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <param name="length">指定的长度</param>
		/// <returns>验证的结果</returns>
		public static bool IsDecimalDigits(string input, int length = 2)
		{
			var pattern = string.Format(@"^[+-]?[0-9]+(.[0-9]{{{0}}})$", length);
			return SmartRegex.IsMatch(input, pattern);
		}
	}
}
