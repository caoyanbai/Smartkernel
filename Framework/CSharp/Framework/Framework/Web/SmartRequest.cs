/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Net;
using Smartkernel.Framework.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// 请求
    /// </summary>
    public static class SmartRequest
    {
        /// <summary>
        /// 获得操作系统名称（出现新的操作系统时，这个方法需要更新）
        /// </summary>
        public static string UserHostOS
        {
            get
            {
                var current = HttpContext.Current;
                var userAgent = current.Request.UserAgent;

                string os = "Other OS";

                if (userAgent.Contains("NT 6.1"))
                {
                    os = "Windows 7/Server 2008 R2";
                }
                else if (userAgent.Contains("NT 6.0"))
                {
                    os = "Windows Vista/Server 2008";
                }
                else if (userAgent.Contains("NT 5.2"))
                {
                    os = "Windows Server 2003";
                }
                else if (userAgent.Contains("NT 5.1"))
                {
                    os = "Windows XP";
                }
                else if (userAgent.Contains("NT 5"))
                {
                    os = "Windows 2000";
                }
                else if (userAgent.Contains("NT 4"))
                {
                    os = "Windows NT4";
                }
                else if (userAgent.Contains("Me"))
                {
                    os = "Windows Me";
                }
                else if (userAgent.Contains("98"))
                {
                    os = "Windows 98";
                }
                else if (userAgent.Contains("95"))
                {
                    os = "Windows 95";
                }
                else if (userAgent.Contains("NT"))
                {
                    os = "Windows NT";
                }
                else if (userAgent.Contains("Mac"))
                {
                    os = "Mac";
                }
                else if (userAgent.Contains("Unix"))
                {
                    os = "UNIX";
                }
                else if (userAgent.Contains("Linux"))
                {
                    os = "Linux";
                }
                else if (userAgent.Contains("SunOS"))
                {
                    os = "SunOS";
                }
                return os;
            }
        }

        private static List<string> mobiles = (new string[]
                {
                    "iphone", "android", "symbian", "windows phone", "windows ce", "blackberry"
                }).ToList();

        /// <summary>
        /// 获得移动设备信息（出现新的移动设备品牌时，这个方法需要更新）
        /// </summary>
        public static string UserHostMobile
        {
            get
            {
                //如果是移动设备，则默认命名为Other
                string mobile = HttpContext.Current.Request.Browser.IsMobileDevice ? "Other Mobile" : null;
                foreach(var item in mobiles)
                {
                    if (HttpContext.Current.Request.UserAgent.ToLower().Contains(item))
                    {
                        mobile = item;
                        break;
                    }
                }
                return mobile;
            }
        }

        private static List<string> crawlers = (new string[]
                    {
                        "Baiduspider",
                        "msnbot",
                        "Googlebot",
                        "Scooter",
                        "Mercator",
                        "Slurp",
                        "Gulliver",
                        "ArchitextSpider",
                        "Lycos_Spider",
                        "Ask Jeeves",
                        "FAST-WebCrawler",
                        "crawler",
                    }).ToList();

        /// <summary>
        /// 获得爬虫信息（出现新的爬虫时，这个方法需要更新）
        /// </summary>
        public static string UserHostCrawler
        {
            get
            {
                string crawler = HttpContext.Current.Request.Browser.Crawler ? "Other Crawler" : null;
                foreach (var item in crawlers)
                {
                    if (HttpContext.Current.Request.UserAgent.ToLower().Contains(item))
                    {
                        crawler = item;
                        break;
                    }
                }
                return crawler;
            }
        }

        /// <summary>
        /// 客户端IP地址（已经考虑了使用代理服务器的情况）
        /// </summary>
        public static string UserHostAddress
        {
            get
            {
                string ip = string.Empty;

                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (ip != null && ip != String.Empty)
                {
                    //可能有代理 
                    if (ip.IndexOf(".") == -1)
                    {
                        //没有“.”肯定是非IPv4格式 
                        ip = null;
                    }
                    else
                    {
                        if (ip.IndexOf(",") != -1)
                        {
                            //有“,”，估计多个代理。取第一个不是内网的IP。 
                            ip = ip.Replace(" ", "").Replace("'", "");
                            string[] ips = ip.Split(",;".ToCharArray());
                            for (int i = 0; i < ips.Length; i++)
                            {
                                if (SmartIPAddress.IsIPAddress(ips[i]) && ips[i].Substring(0, 3) != "10." && ips[i].Substring(0, 7) != "192.168" && ips[i].Substring(0, 7) != "172.16.")
                                {
                                    //找到不是内网的地址 
                                    return ips[i];
                                }
                            }
                        }
                        else if (SmartIPAddress.IsIPAddress(ip))
                        {
                            //代理即是IP格式 
                            return ip;
                        }
                        else
                        {
                            //代理中的内容 非IP，取IP 
                            ip = null;
                        }
                    }
                }

                if (null == ip || ip == String.Empty)
                {
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (ip == null || ip == String.Empty)
                {
                    ip = HttpContext.Current.Request.UserHostAddress;
                }

                return ip;
            }
        }

        /// <summary>
        /// 请求是否来自于自己的主机
        /// </summary>
        /// <returns>是否相同的主机</returns>
        public static bool IsFromSelfHost
        {
            get
            {
                HttpRequest httpRequest = HttpContext.Current.Request;

                if (httpRequest.UrlReferrer != null && httpRequest.UrlReferrer.Host.Length > 0)
                {
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(httpRequest.Url.Host, httpRequest.UrlReferrer.Host, CompareOptions.IgnoreCase) == 0;
                }
                return true;
            }
        }

        /// <summary>
        /// 用户端口号
        /// </summary>
        public static string UserHostPort
        {
            get
            {
                string port = HttpContext.Current.Request.ServerVariables["HTTP_REMOTE_PORT"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_PORT"];
                return string.IsNullOrEmpty(port) ? string.Empty : port;
            }
        }

        /// <summary>
        /// 下载字符串
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encoding">编码</param>
        /// <param name="timeout">超时</param>
        /// <param name="httpActionType">请求类型</param>
        /// <param name="postParameter">参数</param>
        /// <returns>结果</returns>
        public static string DownloadString(string url, Encoding encoding = null, int timeout = 10000, SmartHttpActionType httpActionType = SmartHttpActionType.Get, string postParameter = "")
        {
            if (encoding == null)
            {
                encoding = SmartEncoding.Default;
            }
            var request = HttpWebRequest.Create(url);
            request.Proxy = null;
            request.Timeout = timeout;

            if (httpActionType == SmartHttpActionType.Post)
            {
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                if (!string.IsNullOrEmpty(postParameter))
                {
                    var postData = encoding.GetBytes(postParameter);

                    request.ContentLength = postData.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(postData, 0, postData.Length);
                    }
                }
            }
            else
            {
                request.Method = "GET";
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream responseStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (var streamReader = new StreamReader(responseStream, encoding))
                        {
                            var content = streamReader.ReadToEnd();
                            return content;
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream responseStream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (var streamReader = new StreamReader(responseStream, encoding))
                        {
                            var content = streamReader.ReadToEnd();
                            return content;
                        }
                    }
                }
                else
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var streamReader = new StreamReader(responseStream, encoding))
                        {
                            var content = streamReader.ReadToEnd();
                            return content;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 下载网页并保存成.mht格式的文件
        /// </summary>
        /// <param name="uri">网页地址：例如，http://www.smartkernel.com</param>
        /// <param name="localFilePath">存放的路径：例如，D:\index.mht</param>
        public static void DownloadMht(string uri, string localFilePath)
        {
            var message = new CDO.Message();
            message.CreateMHTMLBody(uri, CDO.CdoMHTMLFlags.cdoSuppressAll, "", "");
            ADODB.Stream stream = null;
            try
            {
                stream = message.GetStream();
                stream.SaveToFile(localFilePath, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
