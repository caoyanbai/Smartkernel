/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 字符串
	/// </summary>
	public static class SmartString
	{
		/// <summary>
		/// 截取字符串左侧指定长度的字符，如果不足指定的长度，则取整个字符串
		/// </summary>
		/// <param name="input">待截取的字符串</param>
		/// <param name="length">截取的长度</param>
		/// <param name="ellipsis">如果发生截取，则使用的结尾符号</param>
		/// <returns>截取的结果</returns>
		public static string Left(string input, int length, string ellipsis = "")
		{
			return input.Length <= length ? input : input.Substring(0, length) + ellipsis;
		}

		/// <summary>
		/// 截取字符串右侧指定长度的字符，如果不足指定的长度，则取整个字符串
		/// </summary>
		/// <param name="input">待截取的字符串</param>
		/// <param name="length">截取的长度</param>
		/// <param name="ellipsis">如果发生截取，则使用的开始符号</param>
		/// <returns>截取的结果</returns>
		public static string Right(string input, int length, string ellipsis = "")
		{
			return input.Length <= length ? input : ellipsis + input.Substring(input.Length - length, length);
		}

		/// <summary>
		/// 是否全为空（只要有一个不为空，则返回false）
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>结果</returns>
		public static bool IsNullOrEmptyAll(params string[] input)
		{
			foreach (var one in input)
			{
				if (!string.IsNullOrEmpty(one))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 是否有一个为空（只要有一个为空，则返回true）
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>结果</returns>
		public static bool IsNullOrEmptyAny(params string[] input)
		{
			foreach (var one in input)
			{
				if (string.IsNullOrEmpty(one))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 是否全为空（只要有一个不为空，则返回false）
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>结果</returns>
		public static bool IsNullOrWhiteSpaceAll(params string[] input)
		{
			foreach (var one in input)
			{
				if (!string.IsNullOrWhiteSpace(one))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 是否有一个为空（只要有一个为空，则返回true）
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>结果</returns>
		public static bool IsNullOrWhiteSpaceAny(params string[] input)
		{
			foreach (var one in input)
			{
				if (string.IsNullOrWhiteSpace(one))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 获得重复字符组成的字符串
		/// </summary>
		/// <param name="input">字符</param>
		/// <param name="count">重复次数</param>
		/// <returns>字符串</returns>
		public static string Repeat(string input, int count)
		{
			var result = string.Empty;
			for (var i = 0; i < count; i++)
			{
				result = result + input;
			}
			return result;
		}

		/// <summary>
		/// 翻转字符串
		/// </summary>
		/// <param name="input">输入的字符串</param>
		/// <returns>翻转的结果</returns>
		public static string Reverse(string input)
		{
			var chars = input.ToCharArray();
			Array.Reverse(chars);
			return new string(chars);
		}

		/// <summary>
		/// 进行不区分大小写的比较
		/// </summary>
		/// <param name="input">原字符串</param>
		/// <param name="other">待比较的字符串</param>
		/// <returns>比较结果</returns>
		public static bool CompareIgnoreCase(string input, string other)
		{
			return string.Compare(input, other, true) == 0;
		}


		/// <summary>
		/// 验证是不是邮箱地址
		/// </summary>
		/// <param name="input">待检查的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsEmail(string input)
		{
			const string pattern = @"^([a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是包含小写字符串，包含非字母符号不影响结果
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool ContainsLow(string input)
		{
			const string pattern = @"[a-z]";
			return SmartRegex.Contains(input, pattern, RegexOptions.None);
		}

		/// <summary>
		/// 验证是不是包含大写字符串，包含非字母符号不影响结果
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool ContainsUp(string input)
		{
			const string pattern = @"[A-Z]";
			return SmartRegex.Contains(input, pattern, RegexOptions.None);
		}

		/// <summary>
		/// 验证是不是字母字符串，空格也认为是非字母
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsAlphabetic(string input)
		{
			const string pattern = @"^[a-zA-Z]+$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是包含字母
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool ContainsAlphabetic(string input)
		{
			const string pattern = @"[a-zA-Z]";
			return SmartRegex.Contains(input, pattern);
		}

		/// <summary>
		/// 验证是不是包含数字
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool ContainsNumberic(string input)
		{
			const string pattern = @"[0-9]";
			return SmartRegex.Contains(input, pattern);
		}

		/// <summary>
		/// 验证是不是中文字符，空格也认为是非中文
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsChinese(string input)
		{
			const string pattern = @"^[\u4e00-\u9fa5]+$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是包含中文字符
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool ContainsChinese(string input)
		{
			const string pattern = @"[\u4e00-\u9fa5]";
			return SmartRegex.Contains(input, pattern);
		}

		/// <summary>
		/// 验证是不是字母和数字组合
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsAlphabeticNumberic(string input)
		{
			const string pattern = @"^[A-Za-z0-9]+$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是字符、数字或者下划线
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsAlphabeticNumbericUnderline(string input)
		{
			const string pattern = @"^[a-zA-Z0-9_]+$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是手机号码
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsChineseMobilePhone(string input)
		{
			const string pattern = @"^[1]{1}[0-9]{10}$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证长度是不是在指定的范围内
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <param name="start">起始边界</param>
		/// <param name="end">结束边界</param>
		/// <returns>验证的结果</returns>
		public static bool IsLengthBetween(string input, int start, int end)
		{
			var pattern = string.Format(@"^.{{{0},{1}}}$", start, end);
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 设置单词首字母大写
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <returns>处理的结果</returns>
		public static string ToTitleCase(string input)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
		}

		/// <summary>
		/// 设置单词首字母小写
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <returns>处理的结果</returns>
		public static string ToCamelCase(string input)
		{
			return Left(input, 1).ToLower() + Right(input, input.Length - 1);
		}

		/// <summary>
		/// 验证是不是电话号码，匹配010-1234567、010-12345678、0316-1234567、0316-12345678、1234567、12345678。
		/// 以及所有前面的号码加“-”、“转”、“#”之后加分机号码。
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsChinesePhone(string input)
		{
			return SmartRegex.IsMatch(input, @"^\d{7,8}$") || SmartRegex.IsMatch(input, @"^\d{7,8}[-转#]\d{1,6}$") || SmartRegex.IsMatch(input, @"^\d{3,4}-\d{7,8}$") || SmartRegex.IsMatch(input, @"^\d{3,4}-\d{7,8}[-转#]\d{1,6}$");
		}

		/// <summary>
		/// 删除所有空格
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <returns>处理的结果</returns>
		public static string TrimAll(string input)
		{
			return input.Replace(" ", "");
		}

		/// <summary>
		/// 替换指定的字符串列表
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="oldValues">旧的字符串</param>
		/// <param name="newValue">新的字符串</param>
		/// <returns>处理的结果</returns>
		public static string Replace(string input, IEnumerable<string> oldValues, string newValue = "")
		{
			var enumerator = oldValues.GetEnumerator();
			while (enumerator.MoveNext())
			{
				input = input.Replace(enumerator.Current, newValue);
			}
			return input;
		}

		/// <summary>
		/// 多次反复替换直到完全不包含指定的字符为止
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="oldValue">旧的字符串</param>
		/// <param name="newValue">新的字符串</param>
		/// <returns>处理的结果</returns>
		public static string RepeatReplace(string input, string oldValue, string newValue = "")
		{
			while (input.Contains(oldValue))
			{
				input = input.Replace(oldValue, newValue);
			}
			return input;
		}

		/// <summary>
		/// 多次反复删除开始的字符直到完全不包含指定的字符为止
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="value">移除的字符串</param>
		/// <returns>处理的结果</returns>
		public static string RepeatTrimStart(string input, string value)
		{
			while (input.StartsWith(value))
			{
				input = TrimStart(input, value);
			}
			return input;
		}

		/// <summary>
		/// 多次反复删除结束的字符直到完全不包含指定的字符为止
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="value">移除的字符串</param>
		/// <returns>处理的结果</returns>
		public static string RepeatTrimEnd(string input, string value)
		{
			while (input.EndsWith(value))
			{
				input = TrimEnd(input, value);
			}
			return input;
		}

		/// <summary>
		/// 删除开头的字符串
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="value">移除的字符串</param>
		/// <returns>处理的结果</returns>
		public static string TrimStart(string input, string value)
		{
			if (Left(input, value.Length) == value)
			{
				for (int i = 0; i < value.Length; i++)
				{
					input = input.TrimStart(value[i]);
				}
				return input;
			}
			return input;
		}

		/// <summary>
		/// 删除结尾的字符串
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="value">移除的字符串</param>
		/// <returns>处理的结果</returns>
		public static string TrimEnd(string input, string value)
		{
			if (Right(input, value.Length) == value)
			{
				for (int i = 0; i < value.Length; i++)
				{
					input = input.TrimEnd(value[value.Length - 1 - i]);
				}
				return input;
			}
			return input;
		}

		/// <summary>
		/// 验证是不是邮编
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsChineseZipCode(string input)
		{
			const string pattern = @"^\d{6}$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 根据片段的长度拆分字符串获得字符串数组
		/// </summary>
		/// <param name="input">待处理的字符串</param>
		/// <param name="segmentSize">片段的长度</param>
		/// <returns>处理的结果</returns>
		public static string[] SplitBySegment(string input, int segmentSize = 1)
		{
			if (string.IsNullOrEmpty(input))
			{
				return new[] { "" };
			}
			var totalSegments = (int)Math.Ceiling(input.Length / (double)segmentSize);

			var segments = new string[totalSegments];

			for (var i = 0; i < segments.Length; i++)
			{
				if (i * segmentSize + segmentSize >= input.Length)
				{
					segments[i] = input.Substring(i * segmentSize);
				}
				else
				{
					segments[i] = input.Substring(i * segmentSize, segmentSize);
				}
			}
			return segments;
		}

		/// <summary>
		/// 截取字符串（通过范围，不包括范围标记）
		/// </summary>
		/// <param name="input">待截取的字符串</param>
		/// <param name="left">左边界</param>
		/// <param name="right">右边界</param>
		/// <returns>结果</returns>
		public static string SubStringByScope(string input, string left, string right)
		{
			var leftIndex = input.IndexOf(left) + left.Length;
			var rightIndex = input.IndexOf(right);

			return input.Substring(leftIndex, rightIndex - leftIndex);
		}

		/// <summary>
		/// 截取字符串（通过范围，包括范围标记）
		/// </summary>
		/// <param name="input">待截取的字符串</param>
		/// <param name="leftIndex">左边界</param>
		/// <param name="rightIndex">右边界</param>
		/// <returns>结果</returns>
		public static string SubStringByScope(string input, int leftIndex, int rightIndex)
		{
			return input.Substring(leftIndex, rightIndex - leftIndex + 1);
		}
	}
}
