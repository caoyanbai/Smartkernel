/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 随机数类，提供多种产生随机数的方式，不光可以产生随机数字，还可以产生随机字符串等任何格式的字符
	/// </summary>
	public static class SmartRandom
	{
		private static readonly Random random = new Random(DateTime.Now.Ticks.GetHashCode());

		private static readonly RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();

		/// <summary>
		/// 产生指定范围的随机数，随机数可以取开始和结束两个边界值
		/// </summary>
		/// <param name="start">开始边界</param>
		/// <param name="end">结束边界</param>
		/// <returns>随机数</returns>
		public static int NextInt(int start, int end)
		{
			return random.Next(start, end + 1);
		}

		/// <summary>
		/// 产生指定范围的随机数，随机数可以取开始和结束两个边界值
		/// </summary>
		/// <param name="start">开始边界</param>
		/// <param name="end">结束边界</param>
		/// <returns>随机数</returns>
		public static double NextDouble(double start, double end)
		{
			double offset = 0;

			if (start < 0)
			{
				offset = -start + 1;
			}

			start = start + offset;
			end = end + offset;

			var scaleStart = GetMaxScaleupMultiple(start);
			var scaleEnd = GetMaxScaleupMultiple(end);

			var list = new List<int> { scaleStart, scaleEnd };

			var scaleMin = list.Min();

			var startInt = Convert.ToInt32(start * scaleMin);
			var endInt = Convert.ToInt32(end * scaleMin);

			var result = random.Next(startInt, endInt + 1);

			return Convert.ToDouble(result) / Convert.ToDouble(scaleMin) - offset;
		}

		/// <summary>
		/// 获得放大为无小数的整数所需的放大倍数
		/// </summary>
		/// <param name="number">浮点数</param>
		/// <returns>放大倍数</returns>
		private static int GetMaxScaleupMultiple(double number)
		{
			var i = 1;
			try
			{
				checked
				{
					while (number * i < int.MaxValue)
					{
						i = i * 10;
					}
				}
			}
			catch
			{
			}
			i = i / 10;
			return i;
		}

		/// <summary>
		/// 产生指定范围和指定长度的随机字符串，随机字符串的长度不受范围长度的限制
		/// </summary>
		/// <param name="scope">随机字符串的范围，可以取任何字符串</param>
		/// <param name="length">需要返回的随机字符串的长度</param>
		/// <returns>随机字符串</returns>
		public static string NextString(string scope, int length)
		{
			char[] chars = scope.ToCharArray();
			var datas = new byte[1];

			rngCryptoServiceProvider.GetBytes(datas);
			datas = new byte[length];
			rngCryptoServiceProvider.GetBytes(datas);

			var result = new StringBuilder(length);
			foreach (var data in datas)
			{
				result.Append(chars[data % chars.Length]);
			}
			return result.ToString();
		}

		/// <summary>
		/// 获得随机大写字符串，字符串范围ABCDEFGHIJKLMNOPQRSTUVWXYZ
		/// </summary>
		/// <param name="length">字符串长度</param>
		/// <returns>随机字符串</returns>
		public static string NextCapitalString(int length)
		{
			const string scope = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return NextString(scope, length);
		}

		/// <summary>
		/// 生成一个随机数学表达式
		/// </summary>
		/// <param name="start">表达式中使用数字的左边界，不应该包括0</param>
		/// <param name="end">表达式中使用数字的右边界，不应该包括0</param>
		/// <param name="result">表达式的计算结果</param>
		/// <returns>生成的随机表达式</returns>
		public static string NextMathExpression(int start, int end, out double result)
		{
			var expression = string.Format("{0} {1} {2}", NextInt(start, end), NextString("+-*", 1), NextInt(start, end));
			result = SmartMath.Eval(expression);
			return expression;
		}

		/// <summary>
		/// 生成一个随机数学表达式
		/// </summary>
		/// <param name="start">表达式中使用数字的左边界，不应该包括0</param>
		/// <param name="end">表达式中使用数字的右边界，不应该包括0</param>
		/// <returns>生成的随机表达式</returns>
		public static string NextMathExpression(int start, int end)
		{
			double result = 0;
			return NextMathExpression(start, end, out result);
		}

		/// <summary>
		/// 从列表中获得随机对象
		/// </summary>
		/// <typeparam name="T">列表中对象的类型</typeparam>
		/// <param name="list">对象列表</param>
		/// <returns>随机对象</returns>
		public static T NextObject<T>(IEnumerable<T> list)
		{
			var array = list.ToArray();
			return array[NextInt(0, array.Length - 1)];
		}

		/// <summary>
		/// 获得随机布尔值
		/// </summary>
		/// <returns>随机布尔值</returns>
		public static bool NextBool()
		{
			var list = new List<bool> { true, false };
			return NextObject(list);
		}
	}
}
