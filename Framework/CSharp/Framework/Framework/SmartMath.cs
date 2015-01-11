/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.XPath;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 数学辅助类
	/// </summary>
	public static class SmartMath
	{
		/// <summary>
		/// 求质因数
		/// </summary>
		/// <typeparam name="T">数字类型</typeparam>
		/// <param name="number">待求质因数的数字，必须大于0。且是整数</param>
		/// <returns>质因数列表</returns>
		public static List<T> GetPrimeDivisors<T>(T number) where T : IComparable
		{
			var list = new List<T>();

			for (var i = SmartGeneric.ToGeneral<T>(2); SmartGeneric.LessThanOrEquals(i, number); i = SmartGeneric.Increase(i))
			{
				while (SmartGeneric.NotEquals(number, i))
				{
					var divideRemainder = SmartGeneric.DivideRemainder(number, i);
					if (SmartGeneric.Equals(divideRemainder, SmartGeneric.ToGeneral<T>(0)))
					{
						list.Add(i);
						number = SmartGeneric.Divide(number, i);
					}
					else
					{
						break;
					}
				}
			}
			list.Add(number);

			return list;
		}

		/// <summary>
		/// 求最大公约数，如果没有，则返回1
		/// </summary>
		/// <typeparam name="T">数字类型</typeparam>
		/// <param name="numbers">待求的数字列表</param>
		/// <returns>最大公约数</returns>
		public static T GetMaxDivisor<T>(IEnumerable<T> numbers) where T : IComparable
		{
			var numberList = new List<T>(numbers);
			var commonPrimeDivisors = new List<KeyValuePair<T, int>>();
			bool isFirst = true;
			numberList.ForEach(number =>
				{
					var list = new List<KeyValuePair<T, int>>();
					GetPrimeDivisors(number).ForEach(primeDivisor =>
						{
							int i = 0;
							while (list.Contains(new KeyValuePair<T, int>(primeDivisor, i)))
							{
								i++;
							}
							list.Add(new KeyValuePair<T, int>(primeDivisor, i));
						});
					if (isFirst)
					{
						isFirst = false;
						commonPrimeDivisors.AddRange(list);
					}
					else
					{
						commonPrimeDivisors = commonPrimeDivisors.Intersect(list).ToList();
					}
				});

			//所有公共质因数的乘积就是最大公约数
			var result = SmartGeneric.ToGeneral<T>(1);
			commonPrimeDivisors.ForEach(item =>
				{
					result = SmartGeneric.Multiply(result, item.Key);
				});
			return result;
		}

		/// <summary>
		/// 二进制转换为十进制
		/// </summary>
		/// <param name="input">待转换的字符串</param>
		/// <returns>转换的结果</returns>
		public static int BinaryToDecimal(string input)
		{
			return Convert.ToInt32(input, 2);
		}

		/// <summary>
		/// 八进制转换为十进制
		/// </summary>
		/// <param name="input">待转换的字符串</param>
		/// <returns>转换的结果</returns>
		public static int OctalToDecimal(string input)
		{
			return Convert.ToInt32(input, 8);
		}

		/// <summary>
		/// 十六进制转换为十进制
		/// </summary>
		/// <param name="input">待转换的字符串</param>
		/// <returns>转换的结果</returns>
		public static int HexToDecimal(string input)
		{
			return Convert.ToInt32(input, 16);
		}

		/// <summary>
		/// 十进制转换为二进制
		/// </summary>
		/// <param name="input">待转换的数字</param>
		/// <returns>转换的结果</returns>
		public static string DecimalToBinary(int input)
		{
			return Convert.ToString(input, 2);
		}

		/// <summary>
		/// 十进制转换为八进制
		/// </summary>
		/// <param name="input">待转换的数字</param>
		/// <returns>转换的结果</returns>
		public static string DecimalToOctal(int input)
		{
			return Convert.ToString(input, 8);
		}

		/// <summary>
		/// 十进制转换为十六进制
		/// </summary>
		/// <param name="input">待转换的数字</param>
		/// <returns>转换的结果</returns>
		public static string DecimalToHex(int input)
		{
			return Convert.ToString(input, 16);
		}

		/// <summary>
		/// 角度转换为弧度
		/// </summary>
		/// <param name="input">待转换的角度值</param>
		/// <returns>弧度表示</returns>
		public static decimal AngleToRadian(decimal input)
		{
			return (Convert.ToDecimal(Math.PI) * input) / 180m;
		}

		/// <summary>
		/// 弧度转换为角度
		/// </summary>
		/// <param name="input">待转换的弧度值</param>
		/// <returns>角度表示</returns>
		public static decimal RadianToAngle(decimal input)
		{
			return input * 180m / Convert.ToDecimal(Math.PI);
		}

		/// <summary>
		/// 角度转换为弧度
		/// </summary>
		/// <param name="input">待转换的角度值</param>
		/// <returns>弧度表示</returns>
		public static double AngleToRadian(double input)
		{
			return (Math.PI * input) / 180d;
		}

		/// <summary>
		/// 弧度转换为角度
		/// </summary>
		/// <param name="input">待转换的弧度值</param>
		/// <returns>角度表示</returns>
		public static double RadianToAngle(double input)
		{
			return input * 180d / Math.PI;
		}

		/// <summary>
		/// 计算利息
		/// </summary>
		/// <param name="principalMoney">本金</param>
		/// <param name="year">年数</param>
		/// <param name="rate">年利率</param>
		/// <param name="isCompoundInterest">是否复利</param>
		/// <returns>本利和</returns>
		public static double CalculateInterest(double principalMoney, double year, double rate, bool isCompoundInterest = true)
		{
			if (isCompoundInterest)
			{
				return Math.Pow(1 + rate, year) * principalMoney;
			}
			return (1 + rate * year) * principalMoney;
		}

		/// <summary>
		/// 计算数学表达式的值（只支持加减乘除）
		/// </summary>
		/// <param name="expression">数学表达式</param>
		/// <returns>结果</returns>
		public static double Eval(string expression)
		{
			var xpath = string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(expression, " ${1} ").Replace("/", " div ").Replace("%", " mod "));

			return (double)new XPathDocument(new System.IO.StringReader("<r/>")).CreateNavigator().Evaluate(xpath);
		}

		/// <summary>
		/// 通过角度计算偏移
		/// </summary>
		/// <param name="angle">角度</param>
		/// <param name="distance">距离</param>
		/// <returns>结果</returns>
		public static Point GetOffsetFromAngleAndDistance(double angle, double distance)
		{
			double x = Math.Cos(AngleToRadian(angle)) * distance;
			double y = Math.Tan(AngleToRadian(angle)) * x;
			return new Point(x, y);
		}

		/// <summary>
		/// 通过偏移计算角度
		/// </summary>
		/// <param name="offset">偏移</param>
		/// <returns>结果</returns>
		public static double GetAngleFromOffset(Point offset)
		{
			double opposite = Math.Abs(offset.Y);
			double adjacent = Math.Abs(offset.X);

			if (offset.Y < 0)
			{
				opposite = -opposite;
			}

			double angle = RadianToAngle(Math.Atan(opposite / adjacent));
			if (double.IsNaN(angle))
			{
				return 0.0;
			}

			if (offset.X < 0)
			{
				angle = 90 + (90 - angle);
			}

			return angle;
		}
	}
}
