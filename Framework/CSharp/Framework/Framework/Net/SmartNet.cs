/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 网络操作相关功能
    /// </summary>
    public class SmartNet
    {
        /// <summary>
        /// 通过主机名获得IP地址
        /// </summary>
        /// <param name="hostName">主机名，例如：localhost,www.caoyanbai.com</param>
        /// <returns>IP地址列表</returns>
        public static List<string> GetIPAddress(string hostName = "localhost")
        {
            var ips = new List<string>();
            var ipHostEntry = Dns.GetHostEntry(hostName.Replace("http://", ""));
            if (ipHostEntry.AddressList.Length > 0)
            {
                ips.AddRange(ipHostEntry.AddressList.Select((t, i) => (ipHostEntry.AddressList)[i].ToString()));
            }
            return ips;
        }

        /// <summary>
        /// 检查端口状态，是否启用TCP监听
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <returns>状态</returns>
        public static bool CheckPort(string ip, int port)
        {
            var ipAddress = IPAddress.Parse(ip);
            var ipEndPoint = new IPEndPoint(ipAddress, port);
            var isListening = false;
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Connect(ipEndPoint);
                    socket.Close();
                    isListening = true;
                }
                catch { }
                return isListening;
            }
        }

        /// <summary>
        /// Ping目标计算机
        /// </summary>
        /// <param name="host">目标计算机的IP（211.66.4.102）或者主机名（SmartKernel-PC）</param>
        /// <returns>IPStatus枚举</returns>
        public static IPStatus Ping(string host)
        {
            var ip = Dns.GetHostEntry(host).AddressList[0];
            var options = new PingOptions(128, true);
            using (var ping = new Ping())
            {
                var data = new byte[32];
                var reply = ping.Send(ip, 1000, data, options);
                return reply != null ? reply.Status : IPStatus.Unknown;
            }
        }

        /// <summary>
        ///  检查网址是否可以访问
        /// </summary>
        /// <param name="uri">测试的网址地址：例如，http://www.caoyanbai.com</param>
        /// <param name="timeOut">设置超时时间，在指定的时间内无响应的认为是无法访问，单位为毫秒</param>
        /// <returns>是否可以访问</returns>
        public static bool IsCanVisit(string uri, int timeOut = 6000)
        {
            uri = string.Format("http://{0}", uri.Replace("http://", ""));
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Timeout = timeOut;
                httpWebRequest.Proxy = null;
                httpWebRequest.Method = "HEAD";
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                try
                {
                    return httpWebResponse.StatusCode == HttpStatusCode.OK;
                }
                finally
                {
                    httpWebResponse.Close();
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
