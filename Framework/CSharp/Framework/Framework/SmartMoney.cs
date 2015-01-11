/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 金钱
	/// </summary>
	public static class SmartMoney
	{
		private static readonly SmartEnglishConverter englishConverter = new SmartEnglishConverter();

		/// <summary>
		/// 金额转换为中文大写形式
		/// </summary>
		/// <param name="money">金额</param>
		/// <param name="isFixLength">是否固定长度，如果为false，将删除无效的零</param>
		/// <returns>中文大写形式</returns>
		public static string ToChinese(decimal money, bool isFixLength = true)
		{
			string result = "{17}仟{16}佰{15}拾{14}万{13}仟{12}佰{11}拾{10}億{9}仟{8}佰{7}拾{6}萬{5}仟{4}佰{3}拾{2}元{1}角{0}分";
			var format = money.ToString("#.00").Replace(".", "");
			result = string.Format(result, SplitToChinese(format, 0), SplitToChinese(format, 1), SplitToChinese(format, 2), SplitToChinese(format, 3), SplitToChinese(format, 4), SplitToChinese(format, 5), SplitToChinese(format, 6), SplitToChinese(format, 7), SplitToChinese(format, 8), SplitToChinese(format, 9), SplitToChinese(format, 10), SplitToChinese(format, 11), SplitToChinese(format, 12), SplitToChinese(format, 13), SplitToChinese(format, 14), SplitToChinese(format, 15), SplitToChinese(format, 16), SplitToChinese(format, 17));
			if (!isFixLength)
			{
				result = SmartString.Replace(result, new[] { "零角", "零分" }, "");
				result = SmartString.Replace(result, new[] { "零拾", "零佰", "零仟", "零万" }, "零").Replace("零萬", "萬").Replace("零億", "億");
				result = SmartString.RepeatReplace(result, "零元", "元");
				result = SmartString.RepeatReplace(result, "零萬", "萬");
				result = SmartString.RepeatReplace(result, "零億", "億");
				result = SmartString.RepeatReplace(result, "零零", "零");
				result = result.Replace("億萬", "億零");
				result = result.TrimStart('億').Replace("万", "萬");
				result = SmartString.RepeatTrimStart(result, "零");
				return result;
			}
			return result.Replace("万", "萬");
		}

		private static string SplitToChinese(string input, int index)
		{
			var result = new[] { '零', '壹', '贰', '叁', '肆', '伍', '陆', '染', '捌', '玖' };
			if (index > input.Length - 1)
			{
				return "零";
			}
			return result[Convert.ToInt32(input[input.Length - 1 - index].ToString())].ToString();
		}

		/// <summary>
		/// 数值转换为英文形式
		/// </summary>
		/// <param name="money">数量</param>
		/// <returns>英文形式</returns>
		public static string ToEnglish(decimal money)
		{
			return englishConverter.Convert(money);
		}
	}

	/// <summary>
	/// 英文转换器
	/// </summary>
	internal class SmartEnglishConverter
	{
		private readonly string[] figs = new string[19];

		private readonly string[] tens = new string[9];

		private readonly string[] units = new string[8];

		/// <summary>
		/// 转换
		/// </summary>
		/// <param name="number">数字</param>
		/// <returns>转换的结果</returns>
		public string Convert(decimal number)
		{
			string left;
			string right;
			string temp;
			Init();
			string result = System.Convert.ToString(Math.Round(number, 2));
			if (result.IndexOf(".") == -1)
			{
				left = result;
				right = "";
			}
			else
			{
				left = result.Substring(0, result.IndexOf("."));
				right = result.Substring(result.IndexOf(".") + 1, result.Length - result.IndexOf(".") - 1);
			}
			if (left.Length > 12)
			{
				return null;
			}
			result = "";
			while (left.Length > 0)
			{
				int length = Len(left);
				string current;
				if (length % 3 == 0)
				{
					current = Left(left, 3);
					left = Right(left, length - 3);
				}
				else
				{
					current = Left(left, (length % 3));
					left = Right(left, length - (length % 3));
				}
				int nbit = Len(left) / 3;
				temp = DecodeHundred(current);
				if ((left == Len(left).ToString() || nbit == 0) && Len(current) == 3)
				{
					if (System.Convert.ToInt32(Left(current, 1)) != 0 & System.Convert.ToInt32(Right(current, 2)) != 0)
					{
						temp = Left(temp, temp.IndexOf(units[3]) + Len(units[3])) + units[7] + " " + Right(temp, Len(temp) - (temp.IndexOf(units[3]) + Len(units[3])));
					}
					else
					{
						temp = units[7] + " " + temp;
					}
				}
				if (nbit == 0)
				{
					result = System.Convert.ToString(result + " " + temp).Trim();
				}
				else
				{
					result = System.Convert.ToString(result + " " + temp + " " + units[nbit - 1]).Trim();
				}
				if (Left(result, 3) == units[7])
				{
					result = System.Convert.ToString(Right(result, Len(result) - 3)).Trim();
				}
				if (left == Len(left).ToString())
				{
					return "";
				}
			}
			left = result;
			if (Len(right) > 0)
			{
				right = units[5] + " " + DecodeHundred(right) + " " + units[6];
			}
			else
			{
				right = units[4];
			}
			return (left + " " + right).ToUpper();
		}

		private void Init()
		{
			if (figs[0] != "One")
			{
				figs[0] = "One";
				figs[1] = "Two";
				figs[2] = "Three";
				figs[3] = "Four";
				figs[4] = "Five";
				figs[5] = "Six";
				figs[6] = "Seven";
				figs[7] = "Eight";
				figs[8] = "Nine";
				figs[9] = "Ten";
				figs[10] = "Eleven";
				figs[11] = "Twelve";
				figs[12] = "Thirteen";
				figs[13] = "Fourteen";
				figs[14] = "Fifteen";
				figs[15] = "Sixteen";
				figs[16] = "Seventeen";
				figs[17] = "Eighteen";
				figs[18] = "Nineteen";
				tens[0] = "Ten";
				tens[1] = "Twenty";
				tens[2] = "Thirty";
				tens[3] = "Forty";
				tens[4] = "Fifty";
				tens[5] = "Sixty";
				tens[6] = "Seventy";
				tens[7] = "Eighty";
				tens[8] = "Ninety";
				units[0] = "Thousand";
				units[1] = "Million";
				units[2] = "Billion";
				units[3] = "Hundred";
				units[4] = "Only";
				units[5] = "Dollars and";
				units[6] = "Cent";
				units[7] = "";
			}
		}

		private string DecodeHundred(string hundredString)
		{
			var rtn = "";
			if (Len(hundredString) > 0 && Len(hundredString) <= 3)
			{
				int tmp;
				switch (Len(hundredString))
				{
					case 1:
						tmp = System.Convert.ToInt32(hundredString);
						if (tmp != 0)
						{
							rtn = figs[tmp - 1];
						}
						break;
					case 2:
						tmp = System.Convert.ToInt32(hundredString);
						if (tmp != 0)
						{
							if ((tmp < 20))
							{
								rtn = figs[tmp - 1];
							}
							else
							{
								rtn = System.Convert.ToInt32(Right(hundredString, 1)) == 0 ? tens[System.Convert.ToInt32(tmp / 10) - 1] : System.Convert.ToString(tens[System.Convert.ToInt32(tmp / 10) - 1] + " " + figs[System.Convert.ToInt32(Right(hundredString, 1)) - 1]);
							}
						}
						break;
					case 3:
						rtn = System.Convert.ToInt32(Left(hundredString, 1)) != 0 ? System.Convert.ToString(figs[System.Convert.ToInt32(Left(hundredString, 1)) - 1] + " " + units[3] + "AND " + DecodeHundred(Right(hundredString, 2))) : DecodeHundred(Right(hundredString, 2));
						break;
					default:
						break;
				}
			}
			return rtn;
		}

		private static string Left(string str, int n)
		{
			return str.Substring(0, n);
		}

		private static string Right(string str, int n)
		{
			return str.Substring(str.Length - n, n);
		}

		private static int Len(string str)
		{
			return str.Length;
		}
	}
}
