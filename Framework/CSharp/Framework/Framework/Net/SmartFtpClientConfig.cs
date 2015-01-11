/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// FTP客户端配置实体
    /// </summary>
    [Serializable]
    public class SmartFtpClientConfig
    {
        /// <summary>
        /// 公有构造函数
        /// </summary>
        public SmartFtpClientConfig() {}

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">Ftp服务器地址</param>
        /// <param name="username">登录Ftp服务器的用户名</param>
        /// <param name="password">登录Ftp服务器的密码</param>
        /// <param name="port">Ftp服务器端口</param>
        public SmartFtpClientConfig(string host, string username = null, string password = null, int port = 21)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }

        /// <summary>
        /// 获取或设置Ftp服务器地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 获取或设置Ftp服务器端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 获取或设置登录Ftp服务器的用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置登录Ftp服务器的密码
        /// </summary>
        public string Password { get; set; }
    }
}