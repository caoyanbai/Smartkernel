/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.text;

import java.io.*;

/**
 * 十六进制转换（输入项是区分大小写的，结果不区分。也就是输入项大小写不同时，结果不同。但是结果大小写不同，输入相同）
 * 
 */
public class SmartHex {
	/**
	 * 转换为十六进制
	 * 
	 * @param datas
	 *            ，数据
	 * @return，转换的结果
	 */
	public static byte[] toHex(byte[] datas) {
		char[] hexChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7',
				'8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

		try (ByteArrayOutputStream memoryStream = new ByteArrayOutputStream()) {
			for (byte data : datas) {
				byte[] hexByte = new byte[2];
				hexByte[0] = (byte) hexChars[(data & 0xF0) >> 4];
				hexByte[1] = (byte) hexChars[data & 0x0F];
				memoryStream.write(hexByte, 0, 2);
			}

			return memoryStream.toByteArray();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换为十六进制
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @param encoding
	 *            ，编码方式
	 * @return，转换的结果
	 */
	public static String toHex(String input, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;
			byte[] data = input.getBytes(encoding);
			byte[] hexData = toHex(data);
			return new String(hexData, encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换为十六进制
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换的结果
	 */
	public static String toHex(String input) {
		return toHex(input, null);
	}

	/**
	 * 由十六进制数据转换为原形式
	 * 
	 * @param hexData
	 *            ，十六进制数据
	 * @return，原形式
	 */
	public static byte[] fromHex(byte[] hexData) {
		try (ByteArrayOutputStream memoryStream = new ByteArrayOutputStream()) {
			for (int i = 0; i < hexData.length; i += 2) {
				byte[] hexPairInDecimal = new byte[2];
				for (int h = 0; h < 2; h++) {
					char temp = (char) hexData[i + h];
					if (temp == '0') {
						hexPairInDecimal[h] = 0;
					} else if (temp == '1') {
						hexPairInDecimal[h] = 1;
					} else if (temp == '2') {
						hexPairInDecimal[h] = 2;
					} else if (temp == '3') {
						hexPairInDecimal[h] = 3;
					} else if (temp == '4') {
						hexPairInDecimal[h] = 4;
					} else if (temp == '5') {
						hexPairInDecimal[h] = 5;
					} else if (temp == '6') {
						hexPairInDecimal[h] = 6;
					} else if (temp == '7') {
						hexPairInDecimal[h] = 7;
					} else if (temp == '8') {
						hexPairInDecimal[h] = 8;
					} else if (temp == '9') {
						hexPairInDecimal[h] = 9;
					} else if (temp == 'A' || temp == 'a') {
						hexPairInDecimal[h] = 10;
					} else if (temp == 'B' || temp == 'b') {
						hexPairInDecimal[h] = 11;
					} else if (temp == 'C' || temp == 'c') {
						hexPairInDecimal[h] = 12;
					} else if (temp == 'D' || temp == 'd') {
						hexPairInDecimal[h] = 13;
					} else if (temp == 'E' || temp == 'e') {
						hexPairInDecimal[h] = 14;
					} else if (temp == 'F' || temp == 'f') {
						hexPairInDecimal[h] = 15;
					}
				}

				memoryStream
						.write((byte) ((hexPairInDecimal[0] << 4) | hexPairInDecimal[1]));
			}

			return memoryStream.toByteArray();
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
	public static String fromHex(String input, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;
			byte[] hexData = input.getBytes(encoding);
			byte[] data = fromHex(hexData);
			return new String(data, encoding);
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
	public static String fromHex(String input) {
		return fromHex(input, null);
	}
}
