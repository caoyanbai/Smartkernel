/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Diagnostics;
using System.Text;

namespace Smartkernel.Framework.Data
{
	/// <summary>
	/// 用于执行sql脚本
	/// </summary>
	public class SmartSqlServerCommand
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="server">数据库服务地址（如果有实例名需要包含实例名）</param>
		/// <param name="username">用户名</param>
		/// <param name="password">密码</param>
		public SmartSqlServerCommand(string server, string username, string password)
		{
			this.Server = server;
			this.Username = username;
			this.Password = password;
			this.IsTrust = false;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="server">数据库服务地址（如果有实例名需要包含实例名）</param>
		public SmartSqlServerCommand(string server)
		{
			this.Server = server;
			this.IsTrust = true;
		}

		/// <summary>
		/// 获取数据库服务地址（如果有实例名需要包含实例名）
		/// </summary>
		public string Server { get; private set; }

		/// <summary>
		/// 获取用户名
		/// </summary>
		public string Username { get; private set; }

		/// <summary>
		/// 获取密码
		/// </summary>
		public string Password { get; private set; }

		/// <summary>
		/// 获取是否信任连接
		/// </summary>
		public bool IsTrust { get; private set; }

		/// <summary>
		/// 执行脚本文件
		/// </summary>
		/// <param name="sqlFilePath">sql脚本文件的路径</param>
		/// <param name="encoding">编码</param>
		/// <returns>执行的消息</returns>
		public string Execute(string sqlFilePath, Encoding encoding = null)
		{
			string sqlcmd;
			if (IsTrust)
			{
				sqlcmd = string.Format("sqlcmd -E -S {0} -H SmartSqlServerCommand -i {1}", Server, sqlFilePath);
			}
			else
			{
				sqlcmd = string.Format("sqlcmd -U {0} -P {1} -S {2} -H SmartSqlServerCommand -i {3}", Username, Password, Server, sqlFilePath);
			}

			return SmartProcess.ExecuteCommand(sqlcmd, encoding);
		}
	}
}
