/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 邮件Pop3客户端的配置实体
    /// </summary>
    [Serializable]
    public class SmartPop3ClientConfig
    {
        /// <summary>
        /// 私有构造函数
        /// </summary>
        public SmartPop3ClientConfig() {}

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">Pop3服务器地址</param>
        /// <param name="username">接收者用户名</param>
        /// <param name="password">接收者密码</param>
        /// <param name="port">Pop3服务器端口</param>
        public SmartPop3ClientConfig(string host, string username, string password, int port = 110)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }

        /// <summary>
        /// 获取或设置Pop3服务器地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 获取或设置Pop3服务器端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 获取或设置接收者用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置接收者密码
        /// </summary>
        public string Password { get; set; }
    }
}