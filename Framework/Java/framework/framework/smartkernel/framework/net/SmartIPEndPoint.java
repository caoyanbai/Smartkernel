/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.net.*;

/**
 * 端点
 *
 */
public class SmartIPEndPoint {
	/**
	 * 解析
	 * @param text，文本（127.0.0.1:9000或9000格式）
	 * @return，结果
	 */
	public static InetSocketAddress parse(String text) {
		String[] parts = text.split("\\:");
		if (parts.length == 2) {
			return new InetSocketAddress(parts[0], Integer.valueOf(parts[1]));
		}
		if (parts.length == 1) {
			return new InetSocketAddress(Integer.valueOf(parts[1]));
		}

		return null;
	}
}
