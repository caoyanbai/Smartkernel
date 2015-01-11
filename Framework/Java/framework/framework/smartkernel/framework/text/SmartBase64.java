/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.text;

import org.apache.commons.codec.binary.*;

/**
 * Base64
 * 
 */
public class SmartBase64 {
	/**
	 * 转换为Base64
	 * 
	 * @param input
	 *            ，待转换的字节数组
	 * @return，转换的结果
	 */
	public static String toBase64WithArray(byte[] input) {
		try {
			return new String(Base64.encodeBase64(input), SmartEncoding.Ascii);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换为Base64
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @param encoding
	 *            ，编码方式
	 * @return，转换的结果
	 */
	public static String toBase64(String input, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;
			return new String(Base64.encodeBase64(input.getBytes(encoding)),
					encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换为Base64
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换的结果
	 */
	public static String toBase64(String input) {
		return toBase64(input, null);
	}

	/**
	 * 转换回原形式
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，原形式
	 */
	public static byte[] fromBase64WithArray(String input) {
		try {
			return Base64.decodeBase64(input);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换回原形式
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @param encoding
	 *            ，编码方式
	 * @return，原形式
	 */
	public static String fromBase64(String input, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;
			return new String(Base64.decodeBase64(input.getBytes(encoding)),
					encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换回原形式
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，原形式
	 */
	public static String fromBase64(String input) {
		return fromBase64(input, null);
	}

	/**
	 * 检查是不是合法的64位编码格式的字符串
	 * 
	 * @param input
	 *            ，待检查的字符串。空字符串和空格都是合法的64位编码
	 * @param encoding
	 *            ，编码方式
	 * @return，是否是64位编码
	 */
	public static boolean isBase64(String input, String encoding) {
		boolean isBase64 = true;
		try {
			fromBase64(input, encoding);
		} catch (Exception err) {
			isBase64 = false;
		}
		return isBase64;
	}

	/**
	 * 检查是不是合法的64位编码格式的字符串
	 * 
	 * @param input
	 *            ，待检查的字符串。空字符串和空格都是合法的64位编码
	 * @return，是否是64位编码
	 */
	public static boolean isBase64(String input) {
		return isBase64(input, null);
	}
}
