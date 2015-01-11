/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 是否Uri
	/// </summary>
	public static class SmartUri
	{
		/// <summary>
		/// 验证是不是Uri地址。注意，必须有http等协议开头的前缀，www.smartkernel.com是不能验证通过的
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsUri(string input)
		{
			const string pattern = @"^((http|https|ftp):\/\/[\w\-_]+(\.[\w\-_]+)+([a-z])+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)$";
			return SmartRegex.IsMatch(input, pattern);
		}

		/// <summary>
		/// 验证是不是Uri地址。注意，不需要有前缀
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsUriWithoutProtocol(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return false;
			}

			if (!input.ToLower().StartsWith("http://") && !input.ToLower().StartsWith("https://") && !input.ToLower().StartsWith("ftp://"))
			{
				input = string.Concat("http://", input);
			}
			return IsUri(input);
		}
	}
}
