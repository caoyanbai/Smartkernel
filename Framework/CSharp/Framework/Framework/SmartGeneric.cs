/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 泛型相关
	/// </summary>
	public static class SmartGeneric
	{
		/// <summary>
		/// 加号（+），将返回为左操作数类型的结果
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>相加的和</returns>
		public static TLeft Add<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return (TLeft)(dynamicLeft + dynamicRight);
		}

		/// <summary>
		/// 减号（-），将返回为左操作数类型的结果
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>相减的差</returns>
		public static TLeft Subtract<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return (TLeft)(dynamicLeft - dynamicRight);
		}

		/// <summary>
		/// 乘号（×），将返回为左操作数类型的结果
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>相乘的积</returns>
		public static TLeft Multiply<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return (TLeft)(dynamicLeft * dynamicRight);
		}

		/// <summary>
		/// 除号（／），将返回为左操作数类型的结果
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>相除的商</returns>
		public static TLeft Divide<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return (TLeft)(dynamicLeft / dynamicRight);
		}

		/// <summary>
		/// 大于号（＞），左操作数是否大于右操作数
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>比较的结果</returns>
		public static bool MoreThan<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return dynamicLeft > dynamicRight;
		}

		/// <summary>
		/// 小于号（＜），左操作数是否小于右操作数
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>比较的结果</returns>
		public static bool LessThan<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return dynamicLeft < dynamicRight;
		}

		/// <summary>
		/// 大于等于号（≥），左操作数是否大于等于右操作数
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>比较的结果</returns>
		public static bool MoreThanOrEquals<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return dynamicLeft >= dynamicRight;
		}

		/// <summary>
		/// 小于等于号（≤），左操作数是否小于等于右操作数
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>比较的结果</returns>
		public static bool LessThanOrEquals<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return dynamicLeft <= dynamicRight;
		}

		/// <summary>
		/// 等于号（＝＝），左操作数是否等于右操作数
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>比较的结果</returns>
		public static bool Equals<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return dynamicLeft == dynamicRight;
		}

		/// <summary>
		/// 不等于号（!＝），左操作数是否不等于右操作数
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>比较的结果</returns>
		public static bool NotEquals<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			return !Equals(left, right);
		}

		/// <summary>
		/// 求余数（%），将返回为左操作数类型的结果
		/// </summary>
		/// <typeparam name="TLeft">左操作数的类型</typeparam>
		/// <typeparam name="TRight">右操作数的类型</typeparam>
		/// <param name="left">左操作数</param>
		/// <param name="right">右操作数</param>
		/// <returns>相除的余数</returns>
		public static TLeft DivideRemainder<TLeft, TRight>(TLeft left, TRight right)
            where TLeft : IComparable
            where TRight : IComparable
		{
			dynamic dynamicLeft = left;
			dynamic dynamicRight = SmartGeneric.ToGeneral<TLeft>(right);
			return (TLeft)(dynamicLeft % dynamicRight);
		}

		/// <summary>
		/// 递增（++）
		/// </summary>
		/// <typeparam name="T">数据类型</typeparam>
		/// <param name="number">操作数</param>
		/// <returns>递增的结果</returns>
		public static T Increase<T>(T number) where T : IComparable
		{
			dynamic dynamicNumber = number;
			dynamicNumber++;
			return (T)dynamicNumber;
		}

		/// <summary>
		/// 递减（--）
		/// </summary>
		/// <typeparam name="T">数据类型</typeparam>
		/// <param name="number">操作数</param>
		/// <returns>递减的结果</returns>
		public static T Decrease<T>(T number) where T : IComparable
		{
			dynamic dynamicNumber = number;
			dynamicNumber--;
			return (T)dynamicNumber;
		}

		/// <summary>
		/// 取反（-）
		/// </summary>
		/// <typeparam name="T">数据类型</typeparam>
		/// <param name="number">操作数</param>
		/// <returns>取反的结果</returns>
		public static T Reverse<T>(T number) where T : IComparable
		{
			dynamic dynamicNumber = number;
			return (T)(-dynamicNumber);
		}

		/// <summary>
		/// 将源类型转换为目标类型，适用于两种泛型间的转换
		/// </summary>
		/// <typeparam name="T">目标类型</typeparam>
		/// <param name="source">源</param>
		/// <returns>转换的结果</returns>
		public static T ToGeneral<T>(object source)
		{
			dynamic dynamicSource = source;
			return (T)dynamicSource;
		}
	}
}
