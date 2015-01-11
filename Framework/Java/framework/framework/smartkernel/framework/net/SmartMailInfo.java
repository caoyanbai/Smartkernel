/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.util.*;

/**
 * 邮件内容实体类
 *
 */
public class SmartMailInfo {
	private String htmlBody;

	private String from;

	private Date date;

	private String subject;

	/**
	 * 获取邮件正文
	 * 
	 * @return，邮件正文
	 */
	public String getHtmlBody() {
		return htmlBody;
	}

	/**
	 * 设置邮件正文
	 * 
	 * @param htmlBody
	 *            ，邮件正文
	 */
	public void setHtmlBody(String htmlBody) {
		this.htmlBody = htmlBody;
	}

	/**
	 * 获取邮件来源地址
	 * 
	 * @return，邮件来源地址
	 */
	public String getFrom() {
		return from;
	}

	/**
	 * 设置邮件来源地址
	 * 
	 * @param from
	 *            ，邮件来源地址
	 */
	public void setFrom(String from) {
		this.from = from;
	}

	/**
	 * 获取邮件发送时间
	 * 
	 * @return，邮件发送时间
	 */
	public Date getDate() {
		return date;
	}

	/**
	 * 设置邮件发送时间
	 * 
	 * @param date
	 *            ，邮件发送时间
	 */
	public void setDate(Date date) {
		this.date = date;
	}

	/**
	 * 获取邮件标题
	 * 
	 * @return，邮件标题
	 */
	public String getSubject() {
		return subject;
	}

	/**
	 * 设置邮件标题
	 * 
	 * @param subject
	 *            ，邮件标题
	 */
	public void setSubject(String subject) {
		this.subject = subject;
	}
}
