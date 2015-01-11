/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.util.*;

import org.apache.commons.mail.*;

import smartkernel.framework.*;
import smartkernel.framework.text.*;

/**
 * 邮件Smtp客户端类
 *
 */
public class SmartSmtpClient {
	private SmartSmtpClientConfig smtpClientConfig;

	/**
	 * 构造函数
	 * 
	 * @param smtpClientConfig
	 *            ，Smtp配置实体
	 */
	public SmartSmtpClient(SmartSmtpClientConfig smtpClientConfig) {
		this.smtpClientConfig = smtpClientConfig;
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
	public SmartSmtpClient(String host, String senderEmail,
			String senderUsername, String senderPassword, int port, int timeout) {
		smtpClientConfig = new SmartSmtpClientConfig(host, senderEmail,
				senderUsername, senderPassword, port, timeout);
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
	public SmartSmtpClient(String host, String senderEmail,
			String senderUsername, String senderPassword, int port) {
		smtpClientConfig = new SmartSmtpClientConfig(host, senderEmail,
				senderUsername, senderPassword, port);
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
	public SmartSmtpClient(String host, String senderEmail,
			String senderUsername, String senderPassword) {
		smtpClientConfig = new SmartSmtpClientConfig(host, senderEmail,
				senderUsername, senderPassword);
	}

	/**
	 * 发送邮件
	 * 
	 * @param to
	 *            ，接收者，多个接收者以逗号分隔，例如：test1@126.com,test2@126.com
	 * @param subject
	 *            ，邮件标题
	 * @param body
	 *            ，邮件正文
	 * @param attachments
	 *            ，邮件附件
	 * @param encoding
	 *            ，编码方式
	 * @param isBodyHtml
	 *            ，是否Html格式
	 */
	public void send(String to, String subject, String body,
			ArrayList<EmailAttachment> attachments, String encoding,
			boolean isBodyHtml) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			MultiPartEmail email = isBodyHtml ? new HtmlEmail()
					: new MultiPartEmail();
			if (!SmartString
					.isNullOrEmpty(smtpClientConfig.getSenderUsername())
					&& !SmartString.isNullOrEmpty(smtpClientConfig
							.getSenderPassword())) {
				email.setAuthentication(
						this.smtpClientConfig.getSenderUsername(),
						this.smtpClientConfig.getSenderPassword());
			}
			email.setHostName(this.smtpClientConfig.getHost());
			String[] tos = to.split("\\,");
			for (String one : tos) {
				email.addTo(one);
			}
			email.setFrom(this.smtpClientConfig.getSenderEmail());
			email.setSubject(subject);
			email.setMsg(body);
			email.setCharset(encoding);
			email.setSmtpPort(this.smtpClientConfig.getPort());
			email.setSocketConnectionTimeout(this.smtpClientConfig.getTimeout());
			email.setSocketTimeout(this.smtpClientConfig.getTimeout());

			if (attachments != null) {
				for (EmailAttachment attachment : attachments) {
					email.attach(attachment);
				}
			}

			email.send();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 发送邮件
	 * 
	 * @param to
	 *            ，接收者，多个接收者以逗号分隔，例如：test1@126.com,test2@126.com
	 * @param subject
	 *            ，邮件标题
	 * @param body
	 *            ，邮件正文
	 * @param attachments
	 *            ，邮件附件
	 * @param encoding
	 *            ，编码方式
	 */
	public void send(String to, String subject, String body,
			ArrayList<EmailAttachment> attachments, String encoding) {
		send(to, subject, body, attachments, encoding, true);
	}

	/**
	 * 发送邮件
	 * 
	 * @param to
	 *            ，接收者，多个接收者以逗号分隔，例如：test1@126.com,test2@126.com
	 * @param subject
	 *            ，邮件标题
	 * @param body
	 *            ，邮件正文
	 * @param attachments
	 *            ，邮件附件
	 */
	public void send(String to, String subject, String body,
			ArrayList<EmailAttachment> attachments) {
		send(to, subject, body, attachments, null, true);
	}

	/**
	 * 发送邮件
	 * 
	 * @param to
	 *            ，接收者，多个接收者以逗号分隔，例如：test1@126.com,test2@126.com
	 * @param subject
	 *            ，邮件标题
	 * @param body
	 *            ，邮件正文
	 */
	public void send(String to, String subject, String body) {
		send(to, subject, body, null, null, true);
	}
}
