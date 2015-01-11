/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Collections;
using Smartkernel.Framework.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Smartkernel.Framework.Net
{
	/// <summary>
	/// 邮件Smtp客户端类
	/// </summary>
	public class SmartSmtpClient
	{
		private readonly SmartSmtpClientConfig smtpClientConfig;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="smtpClientConfig">Smtp配置实体</param>
		public SmartSmtpClient(SmartSmtpClientConfig smtpClientConfig)
		{
			this.smtpClientConfig = smtpClientConfig;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="host">Smtp服务器地址</param>
		/// <param name="senderEmail">发送者邮箱</param>
		/// <param name="senderUsername">发送者用户名</param>
		/// <param name="senderPassword">发送者密码</param>
		/// <param name="port">Smtp服务器端口</param>
		/// <param name="timeout">发送超时时间</param>
		public SmartSmtpClient(string host, string senderEmail, string senderUsername, string senderPassword, int port = 25, int timeout = 30000)
		{
			smtpClientConfig = new SmartSmtpClientConfig(host, senderEmail, senderUsername, senderPassword, port, timeout);
		}

		/// <summary>
		/// 发送邮件
		/// </summary>
		/// <param name="to">接收者，多个接收者以逗号分隔，例如：test1@126.com,test2@126.com</param>
		/// <param name="subject">邮件标题</param>
		/// <param name="body">邮件正文</param>
		/// <param name="attachments">邮件附件</param>
		/// <param name="encoding">编码方式</param>
		/// <param name="isBodyHtml">是否Html格式</param>
		public void Send(string to, string subject, string body, List<Attachment> attachments = null, Encoding encoding = null, bool isBodyHtml = true)
		{
			encoding = encoding ?? SmartEncoding.Default;
			using (var mailMessage = new MailMessage())
			{
				mailMessage.To.Add(to);
				mailMessage.Subject = subject;
				mailMessage.Body = body;
				mailMessage.IsBodyHtml = isBodyHtml;
				mailMessage.From = new MailAddress(smtpClientConfig.SenderEmail);
				mailMessage.Priority = MailPriority.High;
				mailMessage.BodyEncoding = encoding;

				if (!SmartCollection.IsNullOrEmpty(attachments))
				{
					attachments.ForEach(attachment => mailMessage.Attachments.Add(attachment));
				}

				var smtpClient = new SmtpClient(smtpClientConfig.Host, smtpClientConfig.Port);
				if(smtpClientConfig.SenderUsername != null && smtpClientConfig.SenderPassword != null)
				{
					NetworkCredential networkCredential = null;
					networkCredential = new NetworkCredential(smtpClientConfig.SenderUsername, smtpClientConfig.SenderPassword);
					smtpClient.Credentials = networkCredential;
				}
				smtpClient.Timeout = smtpClientConfig.Timeout;
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtpClient.Send(mailMessage);
			}
		}
	}
}