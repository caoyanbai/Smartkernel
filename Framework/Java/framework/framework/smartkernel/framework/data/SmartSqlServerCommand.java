/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

import smartkernel.framework.*;
import smartkernel.framework.diagnostics.*;

/**
 * 用于执行sql脚本
 * 
 */
public class SmartSqlServerCommand {
	/**
	 * 构造函数
	 * 
	 * @param server
	 *            ，数据库服务地址（如果有实例名需要包含实例名）
	 * @param username
	 *            ，用户名
	 * @param password
	 *            ，密码
	 */
	public SmartSqlServerCommand(String server, String username, String password) {
		this.server = server;
		this.username = username;
		this.password = password;
		this.isTrust = false;
	}

	private String server;
	private String username;
	private String password;
	private boolean isTrust;

	/**
	 * 构造函数
	 * 
	 * @param server
	 *            ，数据库服务地址（如果有实例名需要包含实例名）
	 */
	public SmartSqlServerCommand(String server) {
		this.server = server;
		this.isTrust = true;
	}

	/**
	 * 获取数据库服务地址（如果有实例名需要包含实例名）
	 * 
	 * @return，结果
	 */
	public String getServer() {
		return this.server;
	}

	/**
	 * 获取用户名
	 * 
	 * @return，结果
	 */
	public String getUsername() {
		return this.username;
	}

	/**
	 * 获取密码
	 * 
	 * @return，结果
	 */
	public String getPassword() {
		return this.password;
	}

	/**
	 * 获取是否信任连接
	 * 
	 * @return，结果
	 */
	public boolean getIsTrust() {
		return this.isTrust;
	}

	/**
	 * 执行脚本文件
	 * 
	 * @param sqlFilePath
	 *            ，sql脚本文件的路径
	 * @return，执行的消息
	 */
	public String execute(String sqlFilePath) {
		String sqlcmd;
		if (isTrust) {
			sqlcmd = SmartString.format(
					"sqlcmd -E -S {0} -H SmartSqlServerCommand -i {1}", server,
					sqlFilePath);
		} else {
			sqlcmd = SmartString
					.format("sqlcmd -U {0} -P {1} -S {2} -H SmartSqlServerCommand -i {3}",
							username, password, server, sqlFilePath);
		}

		return SmartProcess.executeCommand(sqlcmd);
	}
}
