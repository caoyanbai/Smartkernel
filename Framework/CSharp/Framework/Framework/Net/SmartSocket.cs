/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 套接字
    /// </summary>
    public static class SmartSocket
    {
        /// <summary>
        /// 获得远程IP
        /// </summary>
        /// <param name="socket">套接字</param>
        /// <returns>结果</returns>
        public static string GetRemoteEndPointIP(Socket socket)
        {
            SocketAddress socketAddress = socket.RemoteEndPoint.Serialize();

            return socketAddress[4].ToString() + "." + socketAddress[5].ToString() + "." + socketAddress[6].ToString() + "." + socketAddress[7].ToString();
        }

        /// <summary>
        /// 获得远程端口
        /// </summary>
        /// <param name="socket">套接字</param>
        /// <returns>结果</returns>
        public static int GetRemoteEndPointPort(Socket socket)
        {
            SocketAddress socketAddress = socket.RemoteEndPoint.Serialize();

            return socketAddress[2] * 256 + socketAddress[3];
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="ipEndPoint">端点</param>
        /// <param name="requestText">消息</param>
        /// <param name="flgReceive">是否接受消息</param>
        /// <param name="encoding">数据编码方式</param>
        /// <returns>结果</returns>
        public static string Send(IPEndPoint ipEndPoint, string requestText, bool flgReceive = true, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            var responseText = "";

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Connect(ipEndPoint);

                socket.Send(encoding.GetBytes(requestText));
                socket.Shutdown(SocketShutdown.Send);

                if (flgReceive)
                {
                    using (MemoryStream bufferedReader = new MemoryStream())
                    {
                        int length = -1;
                        byte[] bytes = new byte[1024];
                        while ((length = socket.Receive(bytes)) > 0)
                        {
                            bufferedReader.Write(bytes, 0, length);
                        }
                        var array = bufferedReader.ToArray();
                        responseText = encoding.GetString(array, 0, array.Length);
                        socket.Shutdown(SocketShutdown.Receive);
                    }
                }
            }

            return responseText;
        }

        /// <summary>
        /// 监听信息
        /// </summary>
        /// <param name="ipEndPoint">端点</param>
        /// <param name="interact">交互处理</param>
        /// <param name="listenQueueLimit">监听队列限制</param>
        /// <param name="encoding">数据编码方式</param>
        /// <returns>结果</returns>
        public static void Listen(IPEndPoint ipEndPoint, Func<string, string> interact, int listenQueueLimit = 100, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(listenQueueLimit);
                while (true)
                {
                    Socket socket = serverSocket.Accept();

                    new Task(delegate
                    {
                        using (MemoryStream bufferedReader = new MemoryStream())
                        {
                            int length = -1;
                            byte[] bytes = new byte[1024];
                            while ((length = socket.Receive(bytes)) > 0)
                            {
                                bufferedReader.Write(bytes, 0, length);
                            }
                            var array = bufferedReader.ToArray();
                            var requestText = encoding.GetString(array, 0, array.Length);
                            socket.Shutdown(SocketShutdown.Receive);
                            var responseText = interact(requestText);
                            if (!string.IsNullOrWhiteSpace(responseText))
                            {
                                socket.Send(encoding.GetBytes(responseText));
                                socket.Shutdown(SocketShutdown.Send);
                            }
                        }
                    }).Start();
                }
            }
        }
    }
}
