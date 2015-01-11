/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 邮件Smtp客户端的配置实体
    /// </summary>
    [Serializable]
    public class SmartSmtpClientConfig
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SmartSmtpClientConfig() {}

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">Smtp服务器地址</param>
        /// <param name="senderEmail">发送者邮箱</param>
        /// <param name="senderUsername">发送者用户名</param>
        /// <param name="senderPassword">发送者密码</param>
        /// <param name="port">Smtp服务器端口</param>
        /// <param name="timeout">发送超时时间</param>
        public SmartSmtpClientConfig(string host, string senderEmail, string senderUsername, string senderPassword, int port = 25, int timeout = 30000)
        {
            Host = host;
            Port = port;
            SenderEmail = senderEmail;
            SenderUsername = senderUsername;
            SenderPassword = senderPassword;
            Timeout = timeout;
        }

        /// <summary>
        /// Smtp服务器地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Smtp服务器端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 发送者邮箱
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// 发送者用户名
        /// </summary>
        public string SenderUsername { get; set; }

        /// <summary>
        /// 发送者密码
        /// </summary>
        public string SenderPassword { get; set; }

        /// <summary>
        /// 发送超时时间
        /// </summary>
        public int Timeout { get; set; }
    }
}