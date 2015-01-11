/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Smartkernel.Framework.Text
{
    /// <summary>
    /// Regex
    /// </summary>
    public static class SmartRegex
    {
        /// <summary>
        /// 去除指定模式的字符串
        /// </summary>
        /// <param name="input">待处理的字符串</param>
        /// <param name="pattern">按匹配的模式删除</param>
        /// <param name="regexOptions">正则表达式选项</param>
        /// <returns>处理的结果</returns>
        public static string Remove(string input, string pattern, RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline)
        {
            return Regex.Replace(input, pattern, string.Empty, regexOptions);
        }

        /// <summary>
        /// 是否包含指定模式的字符串
        /// </summary>
        /// <param name="input">待处理的字符串</param>
        /// <param name="pattern">匹配的模式</param>
        /// <param name="regexOptions">正则表达式选项</param>
        /// <returns>处理的结果</returns>
        public static bool Contains(string input, string pattern, RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline)
        {
            return Find(input, pattern, regexOptions).Count > 0;
        }

        /// <summary>
        /// 替换指定模式的字符串
        /// </summary>
        /// <param name="input">待处理的字符串</param>
        /// <param name="pattern">匹配的模式</param>
        /// <param name="replace">替换的字符串</param>
        /// <param name="regexOptions">正则表达式选项</param>
        /// <returns>处理的结果</returns>
        public static string Replace(string input, string pattern, string replace, RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline)
        {
            return Regex.Replace(input, pattern, replace, regexOptions);
        }

        /// <summary>
        /// 通过正则表达式查找匹配的字符串
        /// </summary>
        /// <param name="input">待处理的字符串</param>
        /// <param name="pattern">模式</param>
        /// <param name="regexOptions">正则表达式选项</param>
        /// <returns>查找到的结果列表</returns>
        public static List<string> Find(string input, string pattern, RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline)
        {
            var matchs = Regex.Matches(input, pattern, regexOptions);
            return (from Match match in matchs select match.Value).ToList();
        }

        /// <summary>
        /// 正则表达式验证方法
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <param name="pattern">正则表达式模式</param>
        /// <param name="regexOptions">匹配选择项</param>
        /// <returns>验证的结果</returns>
        public static bool IsMatch(string input, string pattern, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, pattern, regexOptions);
        }

        /// <summary>
        /// 通过正则表达式拆分字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">验证模式</param>
        /// <param name="regexOptions">匹配选项</param>
        /// <returns>拆分的结果</returns>
        public static List<string> Split(string input, string pattern, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            var array = Regex.Split(input, pattern, regexOptions);
            var result = new List<string>();
            for (var i = 0; i < array.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(array[i]) && !string.IsNullOrEmpty(array[i]))
                {
                    result.Add(array[i]);
                }
            }
            return result;
        }
    }
}
