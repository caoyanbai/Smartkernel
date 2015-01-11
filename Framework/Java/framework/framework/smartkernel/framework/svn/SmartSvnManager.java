/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.svn;

import java.util.*;

import org.w3c.dom.*;

import smartkernel.framework.*;
import smartkernel.framework.diagnostics.*;
import smartkernel.framework.threading.*;
import smartkernel.framework.xml.SmartXml;

/**
 * Svn管理器
 * 
 */
public class SmartSvnManager {
	private String remotePath;

	private String username;

	private String password;

	/**
	 * 获取远程路径
	 * 
	 * @return，结果
	 */
	public String getRemotePath() {
		return remotePath;
	}

	/**
	 * 
	 * 设置远程路径
	 * 
	 * @param remotePath
	 *            ，远程路径
	 */
	public void setRemotePath(String remotePath) {
		this.remotePath = remotePath;
	}

	/**
	 * 获取用户名
	 * 
	 * @return，结果
	 */
	public String getUsername() {
		return username;
	}

	/**
	 * 设置用户名
	 * 
	 * @param username
	 *            ，用户名
	 */
	public void setUsername(String username) {
		this.username = username;
	}

	/**
	 * 获取密码
	 * 
	 * @return，结果
	 */
	public String getPassword() {
		return password;
	}

	/**
	 * 设置密码
	 * 
	 * @param password
	 *            ，密码
	 */
	public void setPassword(String password) {
		this.password = password;
	}

	/**
	 * 构造函数
	 * 
	 * @param remotePath
	 *            ，远程路径
	 * @param username
	 *            ，用户名
	 * @param password
	 *            ，密码
	 */
	public SmartSvnManager(String remotePath, String username, String password) {
		this.remotePath = remotePath;
		this.username = username;
		this.password = password;
	}

	/**
	 * 获得列表
	 * 
	 * @param dateTime
	 *            ，时间（这个时间之后的修改会列出）
	 * @param sleepSecond
	 *            ，休眠时间以使svn log命令能执行完
	 * @param encoding
	 *            ，编码
	 * @return，结果
	 */
	public ArrayList<SmartSvnItem> getItems(Date dateTime, int sleepSecond,
			String encoding) {
		ArrayList<SmartSvnItem> items = new ArrayList<SmartSvnItem>();

		String xml = SmartProcess.executeCommand(SmartString.format(
				"svn log {0} --username {1} --password {2} -v --xml",
				remotePath, username, password), encoding);

		int start = xml.indexOf("<?xml");
		int end = xml.lastIndexOf("</log>") + 6;

		xml = xml.substring(start, end);

		SmartThread.sleep(1000 * sleepSecond);

		Document document = SmartXml.load(xml);

		NodeList items1 = document.getFirstChild().getChildNodes();
		for (int i = 0; i < items1.getLength(); i++) {
			Node item1 = items1.item(i);
			NodeList items2 = item1.getChildNodes();
			String author = "";
			Date date = null;
			for (int j = 0; j < items2.getLength(); j++) {
				Node item2 = items2.item(j);

				if (item2.getNodeName().equals("paths")) {
					NodeList items3 = item2.getChildNodes();

					for (int k = 0; k < Math.min(items3.getLength(), 100); k++) {
						Node item3 = items3.item(k);

						String path = item3.getTextContent();
						if (!SmartString.isNullOrWhiteSpace(path)) {
							if (date.after(dateTime)) {
								SmartSvnItem svnItem = new SmartSvnItem();
								svnItem.setLastModifyUser(author);
								svnItem.setLastModifyTime(date);
								svnItem.setPath(path);
								items.add(svnItem);
							}
						}
					}
				} else if (item2.getNodeName().equals("author")) {
					author = item2.getFirstChild().getNodeValue();
				} else if (item2.getNodeName().equals("date")) {
					date = SmartDateTime.parse(item2.getFirstChild()
							.getNodeValue(), "yyyy-MM-dd'T'HH:mm:ss");
					date = new Date(date.getTime() + 8 * 60 * 60 * 1000);
				}
			}
		}

		return items;
	}

	/**
	 * 获得列表
	 * 
	 * @param dateTime
	 *            ，时间（这个时间之后的修改会列出）
	 * @return，结果
	 */
	public ArrayList<SmartSvnItem> getItems(Date dateTime) {
		return getItems(dateTime, 30, null);
	}

	/**
	 * 获得列表
	 * 
	 * @param dateTime
	 *            ，时间（这个时间之后的修改会列出）
	 * @param sleepSecond
	 *            ，休眠时间以使svn log命令能执行完
	 * @return，结果
	 */
	public ArrayList<SmartSvnItem> getItems(Date dateTime, int sleepSecond) {
		return getItems(dateTime, sleepSecond, null);
	}
}
