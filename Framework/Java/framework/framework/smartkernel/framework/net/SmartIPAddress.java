/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.net.*;

import smartkernel.framework.*;

/**
 * IP地址
 * 
 */
public class SmartIPAddress {
	/**
	 * 验证是不是IP地址
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isIPAddress(String input) {
		String pattern = "^\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}$";
		if (input.matches(pattern)) {
			try {
				Inet4Address.getByName(input);
				return true;
			} catch (Exception err) {
				return false;
			}
		}
		return false;
	}

	/**
	 * IP转换为数字
	 * 
	 * @param ip
	 *            ，IP地址
	 * @return，结果
	 */
	public static long toNumber(String ip) {
		try {
			String[] ips = ip.split("\\.");
			return Long.parseLong(ips[0]) * 256 * 256 * 256
					+ Long.parseLong(ips[1]) * 256 * 256
					+ Long.parseLong(ips[2]) * 256 + Long.parseLong(ips[3]);
		} catch (Exception err) {
			return -1;
		}
	}

	/**
	 * 数字转换为IPAddress
	 * 
	 * @param ipValue
	 *            ，ipValue
	 * @return，结果
	 */
	public static String toIPAddress(long ipValue) {
		try {
			String ip = "";

			for (int i = 4; i > 0; i--) {
				ip = String.valueOf(ipValue % 256) + "." + ip;
				ipValue = ipValue / 256;
			}

			return SmartString.trimEnd(ip, ".");
		} catch (Exception err) {
			return "";
		}
	}

	/**
	 * 比较IP地址的大小
	 * 
	 * @param left
	 *            ，第一个IP
	 * @param right
	 *            ，第二个IP
	 * @return，如果第一个大于第二个返回-1，如果第一个小于第二个返回1
	 */
	public static int compare(String left, String right) {
		long numberLeft = toNumber(left);
		long numberRight = toNumber(right);
		if (numberLeft > numberRight) {
			return -1;
		}
		if (numberLeft < numberRight) {
			return 1;
		}
		return 0;
	}

	/**
	 * 是否是私有IP
	 * 
	 * @param ip
	 *            ，IP地址
	 * @return，是否是私有IP
	 */
	public static boolean isPrivate(String ip) {
		InetAddress ipAddress = null;
		try {
			ipAddress = Inet4Address.getByName(ip);
		} catch (Exception err) {

		}
		byte[] ipBytes = ipAddress.getAddress();
		if (ipBytes[0] == (byte) 192 && ipBytes[1] == (byte) 168) {
			return true;
		}
		if (ipBytes[0] == (byte) 172 && ipBytes[1] >= (byte) 16
				&& ipBytes[1] <= (byte) 31) {
			return true;
		}
		if (ipBytes[0] == (byte) 10) {
			return true;
		}
		if (ipBytes[0] == (byte) 169 && ipBytes[1] == (byte) 254) {
			return true;
		}
		if (ipBytes[0] == (byte) 127) {
			return true;
		}

		return false;
	}
}
