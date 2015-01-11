/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Text;

namespace Smartkernel.Framework.Text
{
    /// <summary>
    /// 编码
    /// </summary>
    public static class SmartEncoding
    {
        /// <summary>
        /// 默认
        /// </summary>
        public static readonly Encoding Default = Encoding.UTF8;

        /// <summary>
        /// 判断是否全部为Ascii编码的字符
        /// </summary>
        /// <param name="input">待检查的输入</param>
        /// <returns>结果</returns>
        public static bool IsAsciiEncoding(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] > 127)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 计算字符串的长度，一个中文算两个字符长度
        /// </summary>
        /// <param name="input">需要检查的字符串</param>
        /// <returns>长度</returns>
        public static int GetAsciiLength(string input)
        {
            Encoding encoding = new ASCIIEncoding();

            var datas = encoding.GetBytes(input);
            var result = 0;
            for (var i = 0; i < datas.Length; i++)
            {
                if (datas[i] == 63)
                {
                    result++;
                }
                result++;
            }
            return result;
        }
    }
}
