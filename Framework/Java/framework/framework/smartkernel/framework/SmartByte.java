/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.io.*;
import java.util.*;
import java.util.Base64.*;

/**
 * 字节类（Java的字节类值范围是-127~127，而C#是0~255，Java没有无符号整数，都是有符号的）
 * 
 */
public class SmartByte {
	/**
	 * 高性能拷贝字节数组的一部分
	 * 
	 * @param source
	 *            ，源
	 * @param startIndex
	 *            ，开始的索引
	 * @param length
	 *            ，长度
	 * @return，拷贝的结果
	 */
	public static byte[] blockCopy(byte[] source, int startIndex, int length) {
		byte[] bytes = new byte[source.length - startIndex < length ? source.length
				- startIndex
				: length];
		System.arraycopy(source, startIndex, bytes, 0, bytes.length);
		return bytes;
	}

	/**
	 * 合并两个字节数组
	 * 
	 * @param source
	 *            ，源
	 * @param other
	 *            ，另外一个字节数组
	 * @return，合并的结果
	 */
	private static byte[] combine(byte[] source, byte[] other) {
		byte[] bytes = new byte[source.length + other.length];
		System.arraycopy(source, 0, bytes, 0, source.length);
		System.arraycopy(other, 0, bytes, source.length, other.length);
		return bytes;
	}

	/**
	 * 合并多个字节数组
	 * 
	 * @param source
	 *            ，源
	 * @param others
	 *            ，待合并的字节数组
	 * @return，合并的结果
	 */
	public static byte[] combine(byte[] source, byte[]... others) {
		for (int i = 0; i < others.length; i++) {
			source = combine(source, others[i]);
		}
		return source;
	}

	/**
	 * 合并二维字节数组为一维字节数组
	 * 
	 * @param twoDimensionsBytes
	 *            ，二维字节数组
	 * @return，合并的结果
	 */
	public static byte[] combine(byte[][] twoDimensionsBytes) {
		try (ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream()) {
			for (int i = 0; i < twoDimensionsBytes.length; i++) {
				byteArrayOutputStream.write(twoDimensionsBytes[i], 0,
						twoDimensionsBytes[i].length);
			}
			return byteArrayOutputStream.toByteArray();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 比较两个字节数组是否相等
	 * 
	 * @param source
	 *            ，源
	 * @param other
	 *            ，目标
	 * @return，比较的结果
	 */
	public static int compareTo(byte[] source, byte[] other) {
		if (source == null && other == null) {
			return 0;
		}
		if (source == null) {
			return 1;
		}
		if (other == null) {
			return -1;
		}
		int sourceLength = source.length;
		int otherLength = other.length;

		if (sourceLength == otherLength) {
			int comparision = 0;
			for (int i = 0; i < sourceLength; i++) {
				comparision = ((Byte) source[i]).compareTo((Byte) other[i]);
				if (comparision != 0) {
					break;
				}
			}
			return comparision;
		}
		return ((Integer) sourceLength).compareTo((Integer) otherLength);
	}

	/**
	 * 转换为字符串（64位编码）
	 * 
	 * @param source
	 *            ，字节数组
	 * @return，转换的结果
	 */
	public static String toBase64(byte[] source) {
		Encoder base64Encoder = Base64.getEncoder();
		return base64Encoder.encodeToString(source);
	}

	/**
	 * 转换为字符串（十六进制）
	 * 
	 * @param source
	 *            ，字节数组
	 * @return，转换的结果
	 */
	public static String toHex(byte[] source) {
		StringBuilder stringBuilder = new StringBuilder();
		for (byte item : source) {
			stringBuilder.append(String.format("%2X", item));
		}
		return stringBuilder.toString();
	}

	/**
	 * 转换为内存流
	 * 
	 * @param source
	 *            ，字节数组
	 * @return，转换的结果
	 */
	public static ByteArrayInputStream toMemoryStream(byte[] source) {
		return new ByteArrayInputStream(source);
	}

	/**
	 * 转换回字节数组
	 * 
	 * @param input
	 *            ，字符串
	 * @return，转换的结果
	 */
	public static byte[] fromBase64(String input) {
		try {
			Decoder base64Decoder = Base64.getDecoder();
			return base64Decoder.decode(input);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换回字节数组
	 * 
	 * @param input
	 *            ，字符串
	 * @return，转换的结果
	 */
	public static byte[] fromHex(String input) {
		if (input.length() == 0 || input.length() % 2 != 0) {
			return new byte[0];
		}
		byte[] bytes = new byte[input.length() / 2];
		char c;
		for (int byteIndex = 0, stringIndex = 0; byteIndex < bytes.length; ++byteIndex, ++stringIndex) {
			// 转换前半部分
			c = input.charAt(stringIndex);
			bytes[byteIndex] = (byte) ((c > '9' ? (c > 'Z' ? (c - 'a' + 10)
					: (c - 'A' + 10)) : (c - '0')) << 4);
			// 转换后半部分
			c = input.charAt(++stringIndex);
			bytes[byteIndex] |= (byte) (c > '9' ? (c > 'Z' ? (c - 'a' + 10)
					: (c - 'A' + 10)) : (c - '0'));
		}
		return bytes;
	}

	/**
	 * 转换回字节数组
	 * 
	 * @param input
	 *            ，内存流
	 * @return，转换的结果
	 */
	public static byte[] fromMemoryStream(ByteArrayInputStream input) {
		byte[] buffer = new byte[input.available()];
		input.reset();
		input.read(buffer, 0, buffer.length);
		return buffer;
	}
}
