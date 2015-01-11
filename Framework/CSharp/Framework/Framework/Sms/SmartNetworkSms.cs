/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Net.Sockets;
using System.Text;

namespace Smartkernel.Framework.Sms
{
    /// <summary>
    /// 网络接口的短信猫
    /// </summary>
    public class SmartNetworkSms
    {
        /// <summary>
        /// 同步对象
        /// </summary>
        private readonly object syncRoot = new object();

        /// <summary>
        /// IP地址（出厂默认是192.168.1.24）
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口号（出厂默认是1234）
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        public SmartNetworkSms(string ip = "192.168.1.24", int port = 1234)
        {
            IP = ip;
            Port = port;
        }

        /// <summary>
        /// 发送短信消息
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <param name="message">短信消息（长度应该在70个长度以内）</param>
        /// <returns>发送是否成功</returns>
        public bool Send(string phone, string message)
        {
            lock (syncRoot)
            {
                using (var tcpClient = new TcpClient(IP, Port))
                {
                    using (var networkStream = tcpClient.GetStream())
                    {
                        byte[] byteTime = Encoding.Unicode.GetBytes("011" + phone + message);
                        networkStream.Write(byteTime, 0, byteTime.Length);
                        byte[] bytes = new byte[1024];
                        int count = networkStream.Read(bytes, 0, bytes.Length);
                        string info = Encoding.Unicode.GetString(bytes, 0, count);
                        if (info.ToLower().Contains("error!") || info.ToLower().Contains("long!"))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
    }
}
