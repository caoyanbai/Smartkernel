/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.*;
import java.util.zip.*;

import smartkernel.framework.*;
import smartkernel.framework.text.*;

/**
 * GZip
 * 
 */
public class SmartGZip {
	/**
	 * 压缩流
	 * 
	 * @param inputStream
	 *            ，需要被压缩的流
	 * @param bufferSize
	 *            ，缓存大小
	 * @return，压缩之后的流
	 */
	public static ByteArrayOutputStream compress(InputStream inputStream,
			int bufferSize) {
		ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
		try (GZIPOutputStream gzipStream = new GZIPOutputStream(outputStream)) {
			byte[] buffer = new byte[bufferSize];
			int count = inputStream.read(buffer, 0, bufferSize);
			while (count > 0) {
				gzipStream.write(buffer, 0, count);
				count = inputStream.read(buffer, 0, bufferSize);
			}
			gzipStream.flush();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
		return outputStream;
	}

	/**
	 * 压缩流
	 * 
	 * @param inputStream
	 *            ，需要被压缩的流
	 * @return，压缩之后的流
	 */
	public static ByteArrayOutputStream compress(InputStream inputStream) {
		return compress(inputStream, 1024 * 8);
	}

	/**
	 * 解压流
	 * 
	 * @param inputStream
	 *            ，需要被解压的流
	 * @param bufferSize
	 *            ，缓存大小
	 * @return，解压之后的流
	 */
	public static ByteArrayOutputStream decompress(InputStream inputStream,
			int bufferSize) {
		ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
		try (GZIPInputStream gzipStream = new GZIPInputStream(inputStream)) {
			byte[] buffer = new byte[bufferSize];
			int count = gzipStream.read(buffer, 0, bufferSize);
			while (count > 0) {
				outputStream.write(buffer, 0, count);
				count = gzipStream.read(buffer, 0, bufferSize);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
		return outputStream;
	}

	/**
	 * 解压流
	 * 
	 * @param inputStream
	 *            ，需要被解压的流
	 * @return，解压之后的流
	 */
	public static ByteArrayOutputStream decompress(InputStream inputStream) {
		return decompress(inputStream, 1024 * 8);
	}

	/**
	 * 压缩文件：被压缩的文件必须存在
	 * 
	 * @param sourceFilePath
	 *            ，需要被压缩的文件
	 * @param zipFilePath
	 *            ，压缩之后保存的文件路径
	 */
	public static void compress(String sourceFilePath, String zipFilePath) {
		try (FileInputStream input = new FileInputStream(sourceFilePath);
				ByteArrayOutputStream output = compress(input);
				FileOutputStream fileStream = new FileOutputStream(zipFilePath)) {
			byte[] data = output.toByteArray();
			fileStream.write(data, 0, data.length);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解压缩文件：被解压缩的文件必须存在
	 * 
	 * @param zipFilePath
	 *            ，需要被解压的文件
	 * @param targetFilePath
	 *            ，解压之后保存的文件路径
	 */
	public static void decompress(String zipFilePath, String targetFilePath) {
		try (FileInputStream input = new FileInputStream(zipFilePath);
				ByteArrayOutputStream output = decompress(input);
				FileOutputStream fileStream = new FileOutputStream(
						targetFilePath)) {
			byte[] data = output.toByteArray();
			fileStream.write(data, 0, data.length);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 压缩
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String compress(String input) {
		String result = "";
		if (!SmartString.isNullOrEmpty(input)) {
			try {
				byte[] source = input.getBytes(SmartEncoding.Default);
				ByteArrayInputStream byteArrayInputStream = SmartByte
						.toMemoryStream(source);
				ByteArrayOutputStream byteArrayOutputStream = compress(byteArrayInputStream);
				return SmartBase64.toBase64WithArray(byteArrayOutputStream
						.toByteArray());
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}

		return result;
	}

	/**
	 * 解压
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static String decompress(String input) {
		String result = "";
		if (!SmartString.isNullOrEmpty(input)) {
			try {
				byte[] source = SmartBase64.fromBase64WithArray(input);
				ByteArrayInputStream byteArrayInputStream = SmartByte
						.toMemoryStream(source);
				ByteArrayOutputStream byteArrayOutputStream = decompress(byteArrayInputStream);
				return new String(byteArrayOutputStream.toByteArray(),
						SmartEncoding.Default);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}

		return result;
	}
}
