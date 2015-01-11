/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.io.*;

/**
 * FTP客户端配置实体
 *
 */
public class SmartFtpClientConfig implements Serializable {
	private static final long serialVersionUID = 1L;

	/**
	 * 公有构造函数
	 */
	public SmartFtpClientConfig() {
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 * @param username
	 *            ，登录Ftp服务器的用户名
	 * @param password
	 *            ，登录Ftp服务器的密码
	 * @param port
	 *            ，Ftp服务器端口
	 */
	public SmartFtpClientConfig(String host, String username, String password,
			int port) {
		this.setHost(host);
		this.setPort(port);
		this.setUsername(username);
		this.setPassword(password);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 * @param username
	 *            ，登录Ftp服务器的用户名
	 * @param password
	 *            ，登录Ftp服务器的密码
	 */
	public SmartFtpClientConfig(String host, String username, String password) {
		this.setHost(host);
		this.setPort(21);
		this.setUsername(username);
		this.setPassword(password);
	}

	private String host;

	private int port;

	private String username;

	private String password;

	/**
	 * 获取Ftp服务器地址
	 * 
	 * @return，Ftp服务器地址
	 */
	public String getHost() {
		return host;
	}

	/**
	 * 设置Ftp服务器地址
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 */
	public void setHost(String host) {
		this.host = host;
	}

	/**
	 * 获取Ftp服务器端口
	 * 
	 * @return，Ftp服务器端口
	 */
	public int getPort() {
		return port;
	}

	/**
	 * 设置Ftp服务器端口
	 * 
	 * @param port
	 *            ，Ftp服务器端口
	 */
	public void setPort(int port) {
		this.port = port;
	}

	/**
	 * 获取登录Ftp服务器的用户名
	 * 
	 * @return，登录Ftp服务器的用户名
	 */
	public String getUsername() {
		return username;
	}

	/**
	 * 设置登录Ftp服务器的用户名
	 * 
	 * @param username
	 *            ，登录Ftp服务器的用户名
	 */
	public void setUsername(String username) {
		this.username = username;
	}

	/**
	 * 获取登录Ftp服务器的密码
	 * 
	 * @return，登录Ftp服务器的密码
	 */
	public String getPassword() {
		return password;
	}

	/**
	 * 设置登录Ftp服务器的密码
	 * 
	 * @param password
	 *            ，登录Ftp服务器的密码
	 */
	public void setPassword(String password) {
		this.password = password;
	}
}
