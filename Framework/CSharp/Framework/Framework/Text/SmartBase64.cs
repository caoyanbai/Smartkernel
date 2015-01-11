/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Text;

namespace Smartkernel.Framework.Text
{
    /// <summary>
    /// Base64
    /// </summary>
    public static class SmartBase64
    {
        /// <summary>
        /// 转换为Base64
        /// </summary>
        /// <param name="input">待转换的字节数组</param>
        /// <returns>转换的结果</returns>
        public static string ToBase64WithArray(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        /// <summary>
        /// 转换为Base64
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>转换的结果</returns>
        public static string ToBase64(string input, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;
            byte[] bytes = encoding.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 转换回原形式
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <returns>原形式</returns>
        public static byte[] FromBase64WithArray(string input)
        {
            byte[] outputb = Convert.FromBase64String(input);
            return outputb;
        }

        /// <summary>
        /// 转换回原形式
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>原形式</returns>
        public static string FromBase64(string input, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;
            byte[] outputb = Convert.FromBase64String(input);
            return encoding.GetString(outputb);
        }

        /// <summary>
        /// 检查是不是合法的64位编码格式的字符串
        /// </summary>
        /// <param name="input">待检查的字符串。空字符串和空格都是合法的64位编码</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>是否是64位编码</returns>
        public static bool IsBase64(string input, Encoding encoding = null)
        {
            var isBase64 = true;
            try
            {
                encoding = encoding ?? SmartEncoding.Default;
                FromBase64(input, encoding);
            }
            catch (FormatException)
            {
                isBase64 = false;
            }
            return isBase64;
        }
    }
}
