/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.util.*;

import javax.mail.*;
import javax.mail.internet.*;

/**
 * 邮件服务器Pop3客户端类
 *
 */
public class SmartPop3Client {
	private ArrayList<Integer> list = new ArrayList<Integer>();

	private SmartPop3ClientConfig pop3ClientConfig;

	/**
	 * 构造函数
	 * 
	 * @param pop3ClientConfig
	 *            ，配置实体
	 */
	public SmartPop3Client(SmartPop3ClientConfig pop3ClientConfig) {
		this.pop3ClientConfig = pop3ClientConfig;
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Pop3服务器地址
	 * @param username
	 *            ，接收者用户名
	 * @param password
	 *            ，接收者密码
	 * @param port
	 *            ，Pop3服务器端口
	 */
	public SmartPop3Client(String host, String username, String password,
			int port) {
		pop3ClientConfig = new SmartPop3ClientConfig();
		pop3ClientConfig.setHost(host);
		pop3ClientConfig.setPort(port);
		pop3ClientConfig.setUsername(username);
		pop3ClientConfig.setPassword(password);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Pop3服务器地址
	 * @param username
	 *            ，接收者用户名
	 * @param password
	 *            ，接收者密码
	 */
	public SmartPop3Client(String host, String username, String password) {
		pop3ClientConfig = new SmartPop3ClientConfig();
		pop3ClientConfig.setHost(host);
		pop3ClientConfig.setPort(110);
		pop3ClientConfig.setUsername(username);
		pop3ClientConfig.setPassword(password);
	}

	/**
	 * 获取已经获取的列表
	 * 
	 * @return，结果
	 */
	public ArrayList<Integer> getAlreadyMimes() {
		return list;
	};

	/**
	 * 获得邮件列表（已经获取过的，不会再获取）
	 * 
	 * @return，获取的列表
	 */
	public ArrayList<SmartMailInfo> getMimes() {
		ArrayList<SmartMailInfo> smartMimes = new ArrayList<SmartMailInfo>();

		try {
			Properties props = new Properties();
			props.setProperty("mail.store.protocol", "pop3");
			props.setProperty("mail.pop3.port",
					String.valueOf(this.pop3ClientConfig.getPort()));
			props.setProperty("mail.pop3.host", this.pop3ClientConfig.getHost());

			Session session = Session.getInstance(props);
			Store store = session.getStore("pop3");
			store.connect(this.pop3ClientConfig.getUsername(),
					this.pop3ClientConfig.getPassword());

			Folder folder = store.getFolder("INBOX");

			folder.open(Folder.READ_WRITE);

			Message[] messages = folder.getMessages();

			for (int i = 0; i < messages.length; i++) {
				try {
					MimeMessage message = (MimeMessage) messages[i];

					if (!list.contains(message.getMessageNumber())) {
						list.add(message.getMessageNumber());
						SmartMailInfo smartMime = new SmartMailInfo();
						smartMime.setSubject(MimeUtility.decodeText(message
								.getSubject()));

						{
							String from = "";
							Address[] froms = message.getFrom();

							InternetAddress address = (InternetAddress) froms[0];
							String person = address.getPersonal();
							if (person != null) {
								person = MimeUtility.decodeText(person) + " ";
							} else {
								person = "";
							}
							from = person + "<" + address.getAddress() + ">";

							smartMime.setFrom(from);
						}

						smartMime.setDate(message.getSentDate());

						StringBuffer body = new StringBuffer();

						getMailTextContent(message, body);

						smartMime.setHtmlBody(body.toString());
						smartMimes.add(smartMime);
					}
				} catch (Exception err) {

				}

			}

			folder.close(true);
			store.close();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
		return smartMimes;
	}

	private static void getMailTextContent(Part part, StringBuffer content) {
		try {
			boolean isContainTextAttach = part.getContentType().indexOf("name") > 0;
			if (part.isMimeType("text/*") && !isContainTextAttach) {
				content.append(part.getContent().toString());
			} else if (part.isMimeType("message/rfc822")) {
				getMailTextContent((Part) part.getContent(), content);
			} else if (part.isMimeType("multipart/*")) {
				Multipart multipart = (Multipart) part.getContent();
				int partCount = multipart.getCount();
				for (int i = 0; i < partCount; i++) {
					BodyPart bodyPart = multipart.getBodyPart(i);
					getMailTextContent(bodyPart, content);
				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}

	}
}
