/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Text.RegularExpressions;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// Html
    /// </summary>
    public static class SmartHtml
    {
        /// <summary>
        /// 去除Html标记
        /// </summary>
        /// <param name="input">待处理的字符串</param>
        /// <param name="pattern">模式</param>
        /// <param name="regexOptions">正则表达式选项</param>
        /// <returns>处理的结果</returns>
        public static string Clear(string input, string pattern = @"\<.*?>", RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline)
        {
            var regex = new Regex(pattern, regexOptions);
            return regex.Replace(input, string.Empty);
        }
    }
}
