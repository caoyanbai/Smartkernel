/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.security;

import java.io.*;
import java.nio.file.*;

import javax.crypto.*;
import javax.crypto.spec.*;

import smartkernel.framework.text.*;

/**
 * Aes
 * 
 */
public class SmartAes {
	/**
	 * 加密方法
	 * 
	 * @param input
	 *            ，待加密的字节数组
	 * @param password
	 *            ，加密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @return，加密之后的字节数组
	 */
	public static byte[] encrypt(byte[] input, byte[] password, byte[] iv) {
		try {
			IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
			SecretKeySpec aesKeySpec = new SecretKeySpec(password, "AES");
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cipher.init(Cipher.ENCRYPT_MODE, aesKeySpec, ivParameterSpec);
			byte[] output = cipher.doFinal(input);
			return output;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 加密方法
	 * 
	 * @param input
	 *            ，待加密的字符串
	 * @param password
	 *            ，加密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @param encoding
	 *            ，编码
	 * @return，加密之后的字符串
	 */
	public static String encryptToHexString(String input, String password,
			String iv, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;

			byte[] output = encrypt(input.getBytes(encoding),
					password.getBytes(SmartEncoding.Default),
					iv.getBytes(SmartEncoding.Default));

			return new String(SmartHex.toHex(output), SmartEncoding.Default);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 加密方法
	 * 
	 * @param input
	 *            ，待加密的字符串
	 * @param password
	 *            ，加密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @return，加密之后的字符串
	 */
	public static String encryptToHexString(String input, String password,
			String iv) {
		return encryptToHexString(input, password, iv, null);
	}

	/**
	 * 解密方法
	 * 
	 * @param input
	 *            ，待解密的字节数组
	 * @param password
	 *            ，加密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @return，解密之后的字节数组
	 */
	public static byte[] decrypt(byte[] input, byte[] password, byte[] iv) {
		try {
			IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
			SecretKeySpec aesKeySpec = new SecretKeySpec(password, "AES");
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cipher.init(Cipher.DECRYPT_MODE, aesKeySpec, ivParameterSpec);
			byte[] output = cipher.doFinal(input);
			return output;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解密方法
	 * 
	 * @param input
	 *            ，待解密的字符串
	 * @param password
	 *            ，解密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @param encoding
	 *            ，编码
	 * @return，解密之后的字符串
	 */
	public static String decryptFromHexString(String input, String password,
			String iv, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;

			byte[] output = decrypt(
					SmartHex.fromHex(input.getBytes(SmartEncoding.Default)),
					password.getBytes(SmartEncoding.Default),
					iv.getBytes(SmartEncoding.Default));

			return new String(output, encoding);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解密方法
	 * 
	 * @param input
	 *            ，待解密的字符串
	 * @param password
	 *            ，解密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @return，解密之后的字符串
	 */
	public static String decryptFromHexString(String input, String password,
			String iv) {
		return decryptFromHexString(input, password, iv, null);
	}

	/**
	 * 加密文件的方法
	 * 
	 * @param sourceFilePath
	 *            ，待加密的文件路径
	 * @param encryptFilePath
	 *            ，加密之后的文件路径
	 * @param password
	 *            ，加密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 */
	public static void encryptFile(String sourceFilePath,
			String encryptFilePath, byte[] password, byte[] iv) {
		try {
			IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
			SecretKeySpec aesKeySpec = new SecretKeySpec(password, "AES");
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cipher.init(Cipher.ENCRYPT_MODE, aesKeySpec, ivParameterSpec);

			try (InputStream inputStream = Files.newInputStream(Paths
					.get(sourceFilePath));
					OutputStream outputStream = Files.newOutputStream(
							Paths.get(encryptFilePath),
							StandardOpenOption.CREATE_NEW);
					CipherOutputStream cipherOutputStream = new CipherOutputStream(
							outputStream, cipher)) {
				int legth = -1;
				byte[] data = new byte[1024];
				while ((legth = inputStream.read(data)) > 0) {
					cipherOutputStream.write(data, 0, legth);
				}
			}

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 加密流的方法
	 * 
	 * @param sourceFilePath
	 *            ，待加密的流
	 * @param password
	 *            ，加密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @return，加密之后的流
	 */
	@SuppressWarnings("resource")
	public static ByteArrayOutputStream encryptStream(String sourceFilePath,
			byte[] password, byte[] iv) {
		try {
			IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
			SecretKeySpec aesKeySpec = new SecretKeySpec(password, "AES");
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cipher.init(Cipher.ENCRYPT_MODE, aesKeySpec, ivParameterSpec);

			try (InputStream inputStream = Files.newInputStream(Paths
					.get(sourceFilePath))) {
				ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
				CipherOutputStream cipherOutputStream = new CipherOutputStream(
						outputStream, cipher);
				int legth = -1;
				byte[] data = new byte[1024];
				while ((legth = inputStream.read(data)) > 0) {
					cipherOutputStream.write(data, 0, legth);
				}
				return outputStream;
			}

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解密文件的方法
	 * 
	 * @param encryptFilePath
	 *            ，待解密的文件路径
	 * @param decryptFilePath
	 *            ，解密之后的文件路径
	 * @param password
	 *            ，解密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 */
	public static void decryptFile(String encryptFilePath,
			String decryptFilePath, byte[] password, byte[] iv) {
		try {
			IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
			SecretKeySpec aesKeySpec = new SecretKeySpec(password, "AES");
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cipher.init(Cipher.DECRYPT_MODE, aesKeySpec, ivParameterSpec);

			try (InputStream inputStream = Files.newInputStream(Paths
					.get(encryptFilePath));
					OutputStream outputStream = Files.newOutputStream(
							Paths.get(decryptFilePath),
							StandardOpenOption.CREATE_NEW);
					CipherInputStream cipherInputStream = new CipherInputStream(
							inputStream, cipher)) {
				int legth = -1;
				byte[] data = new byte[1024];
				while ((legth = cipherInputStream.read(data)) > 0) {
					outputStream.write(data, 0, legth);
				}
			}

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解密流的方法
	 * 
	 * @param encryptFilePath
	 *            ，待解密的流
	 * @param password
	 *            ，解密的密码（只能为16位长）
	 * @param iv
	 *            ，偏移
	 * @return，解密之后的流
	 */
	@SuppressWarnings("resource")
	public static ByteArrayOutputStream decryptStream(String encryptFilePath,
			byte[] password, byte[] iv) {
		try {
			IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
			SecretKeySpec aesKeySpec = new SecretKeySpec(password, "AES");
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cipher.init(Cipher.DECRYPT_MODE, aesKeySpec, ivParameterSpec);

			try (InputStream inputStream = Files.newInputStream(Paths
					.get(encryptFilePath))) {
				ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
				CipherInputStream cipherInputStream = new CipherInputStream(
						inputStream, cipher);
				int legth = -1;
				byte[] data = new byte[1024];
				while ((legth = cipherInputStream.read(data)) > 0) {
					outputStream.write(data, 0, legth);
				}
				return outputStream;
			}

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
