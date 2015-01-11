/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.io.*;

/**
 * 邮件Smtp客户端的配置实体
 *
 */
public class SmartSmtpClientConfig implements Serializable {
	private static final long serialVersionUID = 1L;

	/**
	 * 构造函数
	 */
	public SmartSmtpClientConfig() {
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Smtp服务器地址
	 * @param senderEmail
	 *            ，发送者邮箱
	 * @param senderUsername
	 *            ，发送者用户名
	 * @param senderPassword
	 *            ，发送者密码
	 * @param port
	 *            ，Smtp服务器端口
	 * @param timeout
	 *            ，发送超时时间
	 */
	public SmartSmtpClientConfig(String host, String senderEmail,
			String senderUsername, String senderPassword, int port, int timeout) {
		this.setHost(host);
		this.setPort(port);
		this.setSenderEmail(senderEmail);
		this.setSenderPassword(senderPassword);
		this.setSenderUsername(senderUsername);
		this.setTimeout(timeout);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Smtp服务器地址
	 * @param senderEmail
	 *            ，发送者邮箱
	 * @param senderUsername
	 *            ，发送者用户名
	 * @param senderPassword
	 *            ，发送者密码
	 * @param port
	 *            ，Smtp服务器端口
	 */
	public SmartSmtpClientConfig(String host, String senderEmail,
			String senderUsername, String senderPassword, int port) {
		this.setHost(host);
		this.setPort(port);
		this.setSenderEmail(senderEmail);
		this.setSenderPassword(senderPassword);
		this.setSenderUsername(senderUsername);
		this.setTimeout(30000);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Smtp服务器地址
	 * @param senderEmail
	 *            ，发送者邮箱
	 * @param senderUsername
	 *            ，发送者用户名
	 * @param senderPassword
	 *            ，发送者密码
	 */
	public SmartSmtpClientConfig(String host, String senderEmail,
			String senderUsername, String senderPassword) {
		this.setHost(host);
		this.setPort(25);
		this.setSenderEmail(senderEmail);
		this.setSenderPassword(senderPassword);
		this.setSenderUsername(senderUsername);
		this.setTimeout(30000);
	}

	private String host;

	private int port;

	private String senderEmail;

	private String senderUsername;

	private String senderPassword;

	private int timeout;

	/**
	 * 获取Smtp服务器地址
	 * 
	 * @return，Smtp服务器地址
	 */
	public String getHost() {
		return host;
	}

	/**
	 * 设置Smtp服务器地址
	 * 
	 * @param host
	 *            ，Smtp服务器地址
	 */
	public void setHost(String host) {
		this.host = host;
	}

	/**
	 * 获取Smtp服务器端口
	 * 
	 * @return，Smtp服务器端口
	 */
	public int getPort() {
		return port;
	}

	/**
	 * 设置Smtp服务器端口
	 * 
	 * @param port
	 *            ，Smtp服务器端口
	 */
	public void setPort(int port) {
		this.port = port;
	}

	/**
	 * 获取发送者邮箱
	 * 
	 * @return，发送者邮箱
	 */
	public String getSenderEmail() {
		return senderEmail;
	}

	/**
	 * 设置发送者邮箱
	 * 
	 * @param senderEmail
	 *            ，发送者邮箱
	 */
	public void setSenderEmail(String senderEmail) {
		this.senderEmail = senderEmail;
	}

	/**
	 * 获取发送者用户名
	 * 
	 * @return，发送者用户名
	 */
	public String getSenderUsername() {
		return senderUsername;
	}

	/**
	 * 设置发送者用户名
	 * 
	 * @param senderUsername
	 *            ，发送者用户名
	 */
	public void setSenderUsername(String senderUsername) {
		this.senderUsername = senderUsername;
	}

	/**
	 * 获取发送者密码
	 * 
	 * @return，发送者密码
	 */
	public String getSenderPassword() {
		return senderPassword;
	}

	/**
	 * 设置发送者密码
	 * 
	 * @param senderPassword
	 *            ，发送者密码
	 */
	public void setSenderPassword(String senderPassword) {
		this.senderPassword = senderPassword;
	}

	/**
	 * 获取发送超时时间
	 * 
	 * @return，发送超时时间
	 */
	public int getTimeout() {
		return timeout;
	}

	/**
	 * 设置发送超时时间
	 * 
	 * @param timeout
	 *            ，发送超时时间
	 */
	public void setTimeout(int timeout) {
		this.timeout = timeout;
	}
}
