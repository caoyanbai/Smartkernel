/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Net;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 端点
    /// </summary>
    public class SmartIPEndPoint
    {
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="text">文本（127.0.0.1:9000或9000格式）</param>
        /// <returns>结果</returns>
        public static IPEndPoint Parse(string text)
        {
            string[] parts = text.Split(':');
            if (parts.Length == 2)
            {
                return new IPEndPoint(IPAddress.Parse(parts[0]), Convert.ToInt32(parts[1]));
            }
            if (parts.Length == 1)
            {
                return new IPEndPoint(IPAddress.None,Convert.ToInt32(parts[1]));
            }

            return null;
        }
    }
}
