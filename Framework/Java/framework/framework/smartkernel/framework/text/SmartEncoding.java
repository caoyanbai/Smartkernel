/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.text;

import smartkernel.framework.*;

/**
 * 编码
 * 
 */
public class SmartEncoding {
	/**
	 * 默认
	 */
	public static final String Default = "UTF-8";

	/**
	 * Ascii
	 */
	public static final String Ascii = "iso-8859-1";

	/**
	 * 判断是否全部为Ascii编码的字符
	 * 
	 * @param input
	 *            ，待检查的输入
	 * @return，结果
	 */
	public static boolean isAsciiEncoding(String input) {
		try {
			if (SmartString.isNullOrEmpty(input))
				return true;
			byte[] bytes = input.getBytes("UTF-8");
			for (int i = 0; i < bytes.length; i++) {
				if (bytes[i] > 127 || bytes[i] < 0) {
					return false;
				}
			}
			return true;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 计算字符串的长度，一个中文算两个字符长度
	 * 
	 * @param input
	 *            ，需要检查的字符串
	 * @return，长度
	 */
	public static int getAsciiLength(String input) {
		try {
			byte[] datas = input.getBytes(Ascii);
			int result = 0;
			for (int i = 0; i < datas.length; i++) {
				if (datas[i] == 63) {
					result++;
				}
				result++;
			}
			return result;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
