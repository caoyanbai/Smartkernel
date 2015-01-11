/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.International.Converters.PinYinConverter;

namespace Smartkernel.Framework.Text
{
    /// <summary>
    /// 文本
    /// </summary>
    public static class SmartText
    {
        /// <summary> 
        /// 汉字转化为拼音
        /// </summary> 
        /// <param name="input">汉字</param> 
        /// <returns>全拼</returns> 
        public static string GetPinyin(string input)
        {
            string result = string.Empty;
            foreach (char obj in input)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string temp = chineseChar.Pinyins[0].ToString();
                    result += temp.Substring(0, temp.Length - 1);
                }
                catch
                {
                    result += obj.ToString();
                }
            }
            return result;
        }

        /// <summary> 
        /// 汉字转化为拼音首字母
        /// </summary> 
        /// <param name="input">汉字</param> 
        /// <returns>首字母</returns> 
        public static string GetInitialPinyin(string input)
        {
            string result = string.Empty;
            foreach (char obj in input)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string temp = chineseChar.Pinyins[0].ToString();
                    result += temp.Substring(0, 1);
                }
                catch
                {
                    result += obj.ToString();
                }
            }
            return result;
        }  

        /// <summary>
        /// 转换为半角格式（英文标点格式）
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <returns>转换之后的结果</returns>
        public static string ToDbc(string input)
        {
            // 转半角(DBC case)
            // 全角空格为12288，半角空格为32
            // 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
            var chars = input.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] == 12290)
                {
                    chars[i] = (char)46;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                {
                    chars[i] = (char)(chars[i] - 65248);
                }
            }
            var result = new string(chars);
            result = result.Replace("。", ".");
            return result;
        }

        /// <summary>
        /// 转换为全角格式（中文标点格式）
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <returns>转换之后的结果</returns>
        public static string ToSbc(string input)
        {
            // 转全角(SBC case)
            // 全角空格为12288，半角空格为32
            // 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
            var chars = input.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 32)
                {
                    chars[i] = (char)12288;
                    continue;
                }
                if (chars[i] == 46)
                {
                    chars[i] = (char)12290;
                    continue;
                }
                if (chars[i] < 127)
                {
                    chars[i] = (char)(chars[i] + 65248);
                }
            }
            var result = new string(chars);
            result = result.Replace(".", "。");
            return result;
        }

        /// <summary>
        /// 把多行文档转换为多行列表
        /// </summary>
        /// <param name="input">输入项</param>
        /// <returns>转换的结果</returns>
        public static IList<string> ToLines(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            StringReader reader = new StringReader(input);
            string currentLine = reader.ReadLine();
            IList<string> lines = new List<string>();
            while (currentLine != null)
            {
                lines.Add(currentLine);
                currentLine = reader.ReadLine();
            }
            return lines;
        }

        /// <summary>
        /// 获得单词的重复数量
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="word">单词</param>
        /// <param name="regexOptions">匹配选项</param>
        /// <returns>重复数量</returns>
        public static int GetWordRepeatCount(string input, string word, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.Matches(input, @"\b(" + word + @")\b", regexOptions).Count;
        }

        /// <summary>
        /// 获得字符串的重复数量
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="str">字符串</param>
        /// <param name="regexOptions">匹配选项</param>
        /// <returns>重复数量</returns>
        public static int GetStringRepeatCount(string input, string str, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.Matches(input, @"(" + str + @")", regexOptions).Count;
        }

        /// <summary>
        /// 获得字符串中重复的单词
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="regexOptions">匹配选项</param>
        /// <returns>重复字符串的列表（并带有每个字符串的数量）</returns>
        public static Dictionary<string, int> GetRepeatWords(string input, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            var list = new List<string>();
            var dictionary = new Dictionary<string, int>();
            var matchCollection = Regex.Matches(input, @"('\w+)|(\w+'\w+)|(\w+')|(\w+)", regexOptions);
            if (matchCollection.Count != 0)
            {
                foreach (Match match in matchCollection)
                {
                    var word = match.Groups[0].Value;

                    if (regexOptions.HasFlag(RegexOptions.IgnoreCase))
                    {
                        word = word.ToLower();
                    }

                    if (!list.Contains(word))
                    {
                        list.Add(word);
                    }
                }
                var enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var key = enumerator.Current;
                    var value = GetWordRepeatCount(input, key, regexOptions);
                    dictionary.Add(key, value);
                }
            }
            return dictionary;
        }
    }
}
