/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.security;

import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.*;

import smartkernel.framework.text.*;

/**
 * 哈希密码
 * 
 */
public class SmartHashAlgorithm {
	/**
	 * 获得哈希密码
	 * 
	 * @param input
	 *            ，待处理的字节数组
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，哈希密码
	 */
	public static byte[] computeHash(byte[] input,
			SmartHashAlgorithmType hashAlgorithmType) {
		try {
			MessageDigest messageDigest = createHashAlgorithm(hashAlgorithmType);
			byte[] hash = messageDigest.digest(input);
			return hash;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得哈希密码
	 * 
	 * @param input
	 *            ，待处理的字节数组
	 * @return，哈希密码
	 */
	public static byte[] computeHash(byte[] input) {
		return computeHash(input, SmartHashAlgorithmType.Md5);
	}

	/**
	 * 获得哈希密码
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @param encoding
	 *            ，编码
	 * @return，哈希密码
	 */
	public static String computeHashToHexString(String input,
			SmartHashAlgorithmType hashAlgorithmType, String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			MessageDigest messageDigest = createHashAlgorithm(hashAlgorithmType);
			byte[] hash = messageDigest.digest(input.getBytes(encoding));
			return new String(SmartHex.toHex(hash), encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得哈希密码
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，哈希密码
	 */
	public static String computeHashToHexString(String input,
			SmartHashAlgorithmType hashAlgorithmType) {
		return computeHashToHexString(input, hashAlgorithmType, null);
	}

	/**
	 * 获得哈希密码
	 * 
	 * @param input
	 *            ，待处理的字符串
	 * @return，哈希密码
	 */
	public static String computeHashToHexString(String input) {
		return computeHashToHexString(input, SmartHashAlgorithmType.Md5, null);
	}

	/**
	 * 产生哈希算法
	 * 
	 * @param hashAlgorithmType
	 *            ，哈希算法的类型
	 * @return，哈希算法
	 */
	private static MessageDigest createHashAlgorithm(
			SmartHashAlgorithmType hashAlgorithmType) {
		try {
			String hashAlgorithmString = "";
			switch (hashAlgorithmType) {
			case Md5:
				hashAlgorithmString = "MD5";
				break;
			case Sha1:
				hashAlgorithmString = "SHA1";
				break;
			}

			return MessageDigest.getInstance(hashAlgorithmString);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 计算文件的哈希密码
	 * 
	 * @param filePath
	 *            ，文件的路径
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，编码了的哈希码
	 */
	public static byte[] computeFileHash(String filePath,
			SmartHashAlgorithmType hashAlgorithmType) {
		try {
			MessageDigest messageDigest = createHashAlgorithm(hashAlgorithmType);

			try (InputStream inputStream = Files.newInputStream(Paths
					.get(filePath))) {
				DigestInputStream digestInputStream = new DigestInputStream(
						inputStream, messageDigest);
				while (digestInputStream.read() > 0) {
				}
			}

			byte[] hash = messageDigest.digest();
			return hash;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 
	 * 
	 * @param filePath
	 *            ，文件的路径
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，编码了的哈希码
	 */
	public static byte[] computeFileHash(String filePath) {
		return computeFileHash(filePath, SmartHashAlgorithmType.Md5);
	}

	/**
	 * 计算流的哈希密码
	 * 
	 * @param stream
	 *            ，流
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，编码了的哈希码
	 */
	public static byte[] computeStreamHash(InputStream stream,
			SmartHashAlgorithmType hashAlgorithmType) {
		try {
			MessageDigest messageDigest = createHashAlgorithm(hashAlgorithmType);

			DigestInputStream digestInputStream = new DigestInputStream(stream,
					messageDigest);
			while (digestInputStream.read() > 0) {
			}

			byte[] hash = messageDigest.digest();
			return hash;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 计算流的哈希密码
	 * 
	 * @param stream
	 *            ，流
	 * @return，编码了的哈希码
	 */
	public static byte[] computeStreamHash(InputStream stream) {
		return computeStreamHash(stream, SmartHashAlgorithmType.Md5);
	}
}
