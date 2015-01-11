/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System.Collections.Generic;
using System.Text;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// UrlParameter
    /// </summary>
    public static class SmartUrlParameter
    {
        /// <summary>
        /// 编码参数对
        /// </summary>
        /// <param name="parameters">参数对列表</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>编码结果</returns>
        public static string ToOne(Dictionary<string, string> parameters, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;
            var result = "";
            var enumerator = parameters.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var kv = enumerator.Current;
                result += SmartHex.ToHex(kv.Key.ToLower(), encoding) + "=" + SmartHex.ToHex(kv.Value.ToLower(), encoding) + "|";
            }

            return SmartHex.ToHex(result.TrimEnd(new[] { '|' }), encoding);
        }

        /// <summary>
        /// 解码Url参数
        /// </summary>
        /// <param name="data">编码的参数</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>结果之后的键值对</returns>
        public static Dictionary<string, string> ToAll(string data, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;
            var parameters = new Dictionary<string, string>();
            var output = SmartHex.FromHex(data, encoding);
            var kvs = output.Split(new[] { '|' });
            for (var i = 0; i < kvs.Length; i++)
            {
                var kv = kvs[i].Split(new[] { '=' });
                parameters.Add(SmartHex.FromHex(kv[0], encoding), SmartHex.FromHex(kv[1], encoding));
            }
            return parameters;
        }

        /// <summary>
        /// 查询一个参数（不存在则返回null）
        /// </summary>
        /// <param name="data">编码的数据</param>
        /// <param name="key">键</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>值</returns>
        public static string Query(string data, string key, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;
            try
            {
                var parameters = ToAll(data, encoding);

                string value = null;

                foreach(var kv in parameters)
                {
                    if (kv.Key.ToLower().ToString() == key.ToLower())
                    {
                        value = kv.Value;
			break;
                    }
                }
                return value;
            }
            catch
            {
                return null;
            }
        }
    }
}
