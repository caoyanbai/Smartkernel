/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.*;

/**
 * 流的处理
 * 
 */
public class SmartStream {
	/**
	 * 输入流转输出流
	 * 
	 * @param inputStream
	 *            ，输入流
	 * @return，结果
	 */
	public static ByteArrayOutputStream convert(ByteArrayInputStream inputStream) {
		ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
		byte[] buffer = new byte[1024];
		int count = inputStream.read(buffer, 0, 1024);
		while (count > 0) {
			outputStream.write(buffer, 0, count);
			count = inputStream.read(buffer, 0, 1024);
		}
		return outputStream;
	}

	/**
	 * 输出流转输入流
	 * 
	 * @param outputStream
	 *            ，输出流
	 * @return，结果
	 */
	public static ByteArrayInputStream convert(
			ByteArrayOutputStream outputStream) {
		return new ByteArrayInputStream(outputStream.toByteArray());
	}
}
