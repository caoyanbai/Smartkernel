/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// Cookie操作类
    /// </summary>
    public static class SmartCookie
    {
        private static readonly HttpCookieCollection requestCookies = HttpContext.Current.Request.Cookies;

        private static readonly HttpCookieCollection responseCookies = HttpContext.Current.Response.Cookies;

        /// <summary>
        /// 增加存储的数据
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="keyValues">存储的键值对</param>
        /// <param name="timeOut">超时时间，默认是30天</param>
        /// <param name="path">路径</param>
        /// <param name="domain">域名</param>
        /// <param name="secure">SSL</param>
        /// <param name="httponly">httponly</param>
        public static void Add(string category, Dictionary<string, string> keyValues, TimeSpan timeOut = default(TimeSpan), string path = null, string domain = null,bool secure = false, bool httponly = true)
        {
            if (timeOut == default(TimeSpan))
            {
                timeOut = TimeSpan.FromDays(30);
            }

            var httpCookie = new HttpCookie(category);
            var enumerator = keyValues.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var keyValue = enumerator.Current;
                httpCookie[keyValue.Key] = keyValue.Value;
            }
            httpCookie.Expires = DateTime.Now.Add(timeOut);
            if (!string.IsNullOrWhiteSpace(path))
            {
                httpCookie.Path = path;
            }
            if (!string.IsNullOrWhiteSpace(domain))
            {
                httpCookie.Domain = domain;
            }
            httpCookie.Secure = secure;
            httpCookie.HttpOnly = httponly;

            responseCookies.Add(httpCookie);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="category">分类名称</param>
        public static void Remove(string category)
        {
            responseCookies[category].Expires = DateTime.Now.AddYears(-1);
        }

        /// <summary>
        /// 是否包含这个分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>是否包含</returns>
        public static bool Contains(string category)
        {
            return responseCookies[category] != null;
        }

        /// <summary>
        /// 获得值
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string category, string key)
        {
            return requestCookies[category][key];
        }

        /// <summary>
        /// 获得键值
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>键值</returns>
        public static Dictionary<string,string> GetKeyValues(string category)
        {
            var keyValues = new Dictionary<string, string>();

            var getEnumerator = requestCookies[category].Values.GetEnumerator();
            while (getEnumerator.MoveNext())
            {
                var key = getEnumerator.Current.ToString();
                var value = requestCookies[category][key];
                keyValues.Add(key, value);
            }

            return keyValues;
        }

        /// <summary>
        /// 获取响应中的Cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>Cookie</returns>
        public static HttpCookie GetResponseCookie(string key)
        {
            var cookies = responseCookies;
            return GetCookie(cookies, key);
        }

        /// <summary>
        /// 获取请求中的Cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>Cookie</returns>
        public static HttpCookie GetRequestCookie(string key)
        {
            var cookies = requestCookies;
            return GetCookie(cookies, key);
        }

        /// <summary>
        /// 获得指定的Cookie
        /// </summary>
        /// <param name="cookies">要查找的集合</param>
        /// <param name="key">键</param>
        /// <returns>Cookie</returns>
        public static HttpCookie GetCookie(HttpCookieCollection cookies, string key)
        {
            var count = cookies.Count;

            for (var i = 0; i < count; i++)
            {
                if (String.Compare(cookies[i].Name, key, true, CultureInfo.InvariantCulture) == 0)
                {
                    return cookies[i];
                }
            }
            return null;
        }
    }
}
