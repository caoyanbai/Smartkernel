/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.net.*;
import java.util.*;

/**
 * 网络操作相关功能
 *
 */
public class SmartNet {
	/**
	 * 通过主机名获得IP地址
	 * 
	 * @param hostName
	 *            ，主机名，例如：localhost,www.caoyanbai.com
	 * @return，IP地址列表
	 */
	public static ArrayList<String> getIPAddress(String hostName) {
		try {
			InetAddress[] items = InetAddress.getAllByName(hostName);

			ArrayList<String> result = new ArrayList<String>();

			for (InetAddress item : items) {
				result.add(item.getHostAddress());
			}

			return result;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 通过主机名获得IP地址
	 * 
	 * @return，IP地址列表
	 */
	public static ArrayList<String> getIPAddress() {
		return getIPAddress("localhost");
	}

	/**
	 * 检查端口状态，是否启用TCP监听
	 * 
	 * @param ip
	 *            ，IP地址
	 * @param port
	 *            ，端口
	 * @return，状态
	 */
	public static boolean checkPort(String ip, int port) {
		InetSocketAddress ipEndPoint = new InetSocketAddress(ip, port);
		boolean isListening = false;
		try (Socket socket = new Socket()) {
			socket.connect(ipEndPoint);
			isListening = true;
		} catch (Exception err) {

		}
		return isListening;
	}

	/**
	 * 检查网址是否可以访问
	 * 
	 * @param uri
	 *            ，测试的网址地址：例如，http://www.caoyanbai.com
	 * @param timeOut
	 *            ，设置超时时间，在指定的时间内无响应的认为是无法访问，单位为毫秒
	 * @return，是否可以访问
	 */
	public static boolean isCanVisit(String uri, int timeOut) {
		boolean isCanVisit = false;
		try {
			URL url = new URL(uri);
			HttpURLConnection httpURLConnection = (HttpURLConnection) url
					.openConnection();
			httpURLConnection.setInstanceFollowRedirects(false);
			httpURLConnection.setRequestMethod("HEAD");
			httpURLConnection.setConnectTimeout(timeOut);
			httpURLConnection.connect();

			if (HttpURLConnection.HTTP_OK == httpURLConnection
					.getResponseCode()) {
				isCanVisit = true;
			}

		} catch (Exception err) {

		}
		return isCanVisit;
	}

	/**
	 * 检查网址是否可以访问
	 * 
	 * @param uri
	 *            ，测试的网址地址：例如，http://www.caoyanbai.com
	 * @return，是否可以访问
	 */
	public static boolean isCanVisit(String uri) {
		return isCanVisit(uri, 6000);
	}
}
