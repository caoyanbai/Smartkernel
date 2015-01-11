/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.security;

import java.math.*;
import java.security.*;
import java.security.spec.*;

import javax.crypto.*;

import org.w3c.dom.*;

import smartkernel.framework.text.*;
import smartkernel.framework.xml.SmartXml;

/**
 * 非对称加密（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证），非对称加密的性能开销很大，使用时需要注意
 * 
 */
public class SmartRsa {
	/**
	 * 创建密钥对，每次调用都会创建新的密钥对
	 * 
	 * @return，密钥对实体
	 */
	public static SmartRsaKey createKey() {
		return new SmartRsaKey();
	}

	private static String parse(String xml, String nodeName) {
		Document document = SmartXml.load(xml);
		NodeList nodeList = document.getElementsByTagName(nodeName);

		return ((Element) nodeList.item(0)).getChildNodes().item(0)
				.getNodeValue();
	}

	/**
	 * 加密方法
	 * 
	 * @param input
	 *            ，待加密的字节数组
	 * @param privateKeyOrPubliclKey
	 *            ，加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，加密之后的字节数组
	 */
	public static byte[] encrypt(byte[] input, String privateKeyOrPubliclKey) {
		try {
			byte[] modulusBytes = SmartBase64.fromBase64WithArray(parse(
					privateKeyOrPubliclKey, "Modulus"));
			byte[] exponentBytes = SmartBase64.fromBase64WithArray(parse(
					privateKeyOrPubliclKey, "Exponent"));

			BigInteger modulus = new BigInteger(1, modulusBytes);
			BigInteger exponent = new BigInteger(1, exponentBytes);
			RSAPublicKeySpec rsaPublicKeySpec = new RSAPublicKeySpec(modulus,
					exponent);
			KeyFactory keyFactory = KeyFactory.getInstance("RSA");
			PublicKey publicKey = keyFactory.generatePublic(rsaPublicKeySpec);
			Cipher cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");
			cipher.init(Cipher.ENCRYPT_MODE, publicKey);
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
	 * @param privateKeyOrPubliclKey
	 *            ，加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param encoding
	 *            ，编码
	 * @return，加密之后的字符串
	 */
	public static String encryptToHexString(String input,
			String privateKeyOrPubliclKey, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;

			byte[] output = encrypt(input.getBytes(encoding),
					privateKeyOrPubliclKey);

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
	 * @param privateKeyOrPubliclKey
	 *            ，加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，加密之后的字符串
	 */
	public static String encryptToHexString(String input,
			String privateKeyOrPubliclKey) {
		return encryptToHexString(input, privateKeyOrPubliclKey, null);
	}

	/**
	 * 解密方法
	 * 
	 * @param input
	 *            ，待解密的字节数组
	 * @param privateKey
	 *            ，加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，解密之后的字节数组
	 */
	public static byte[] decrypt(byte[] input, String privateKey) {
		try {
			byte[] modulusBytes = SmartBase64.fromBase64WithArray(parse(
					privateKey, "Modulus"));
			byte[] exponentBytes = SmartBase64.fromBase64WithArray(parse(
					privateKey, "D"));

			BigInteger modulus = new BigInteger(1, modulusBytes);
			BigInteger exponent = new BigInteger(1, exponentBytes);
			RSAPrivateKeySpec rsaPrivateKeySpec = new RSAPrivateKeySpec(
					modulus, exponent);
			KeyFactory keyFactory = KeyFactory.getInstance("RSA");
			PrivateKey pk = keyFactory.generatePrivate(rsaPrivateKeySpec);
			Cipher cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");
			cipher.init(Cipher.DECRYPT_MODE, pk);
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
	 * @param privateKey
	 *            ，加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param encoding
	 *            ，编码
	 * @return，解密之后的字符串
	 */
	public static String decryptFromHexString(String input, String privateKey,
			String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;

			byte[] output = decrypt(
					SmartHex.fromHex(input.getBytes(SmartEncoding.Default)),
					privateKey);

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
	 * @param privateKey
	 *            ，加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，解密之后的字符串
	 */
	public static String decryptFromHexString(String input, String privateKey) {
		return decryptFromHexString(input, privateKey, null);
	}

	/**
	 * 产生哈希算法
	 * 
	 * @param hashAlgorithmType
	 *            ，哈希算法的类型
	 * @return，哈希算法
	 */
	private static String createHashAlgorithm(
			SmartHashAlgorithmType hashAlgorithmType) {
		String hashAlgorithmString = "";
		switch (hashAlgorithmType) {
		case Md5:
			hashAlgorithmString = "MD5WithRSA";
			break;
		case Sha1:
			hashAlgorithmString = "SHA1WithRSA";
			break;
		}

		return hashAlgorithmString;
	}

	/**
	 * 私钥签名
	 * 
	 * @param input
	 *            ，待签名的字节数组
	 * @param privateKey
	 *            ，签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，签名之后的字节数组
	 */
	public static byte[] signData(byte[] input, String privateKey,
			SmartHashAlgorithmType hashAlgorithmType) {
		try {
			byte[] modulusBytes = SmartBase64.fromBase64WithArray(parse(
					privateKey, "Modulus"));
			byte[] exponentBytes = SmartBase64.fromBase64WithArray(parse(
					privateKey, "D"));

			BigInteger modulus = new BigInteger(1, modulusBytes);
			BigInteger exponent = new BigInteger(1, exponentBytes);
			RSAPrivateKeySpec rsaPrivateKeySpec = new RSAPrivateKeySpec(
					modulus, exponent);
			KeyFactory keyFactory = KeyFactory.getInstance("RSA");
			PrivateKey pk = keyFactory.generatePrivate(rsaPrivateKeySpec);

			Signature signature = Signature
					.getInstance(createHashAlgorithm(hashAlgorithmType));
			signature.initSign(pk);

			signature.update(input);
			return signature.sign();

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 私钥签名
	 * 
	 * @param input
	 *            ，待签名的字节数组
	 * @param privateKey
	 *            ，签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，签名之后的字节数组
	 */
	public static byte[] signData(byte[] input, String privateKey) {
		return signData(input, privateKey, SmartHashAlgorithmType.Sha1);
	}

	/**
	 * 私钥签名
	 * 
	 * @param input
	 *            ，待签名的字符串
	 * @param privateKey
	 *            ，签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @param encoding
	 *            ，编码
	 * @return，签名之后的字节数组
	 */
	public static String signDataToHexString(String input, String privateKey,
			SmartHashAlgorithmType hashAlgorithmType, String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;

			byte[] output = signData(input.getBytes(encoding), privateKey,
					hashAlgorithmType);

			return new String(SmartHex.toHex(output), SmartEncoding.Default);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 私钥签名
	 * 
	 * @param input
	 *            ，待签名的字符串
	 * @param privateKey
	 *            ，签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，签名之后的字节数组
	 */
	public static String signDataToHexString(String input, String privateKey,
			SmartHashAlgorithmType hashAlgorithmType) {
		return signDataToHexString(input, privateKey, hashAlgorithmType, null);
	}

	/**
	 * 私钥签名
	 * 
	 * @param input
	 *            ，待签名的字符串
	 * @param privateKey
	 *            ，签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，签名之后的字节数组
	 */
	public static String signDataToHexString(String input, String privateKey) {
		return signDataToHexString(input, privateKey,
				SmartHashAlgorithmType.Sha1, null);
	}

	/**
	 * 公钥验证签名
	 * 
	 * @param input
	 *            ，待签名验证的字节数组
	 * @param signInput
	 *            ，验证字节数组
	 * @param publicKey
	 *            ，签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，是否验证通过
	 */
	public static boolean verifyData(byte[] input, byte[] signInput,
			String publicKey, SmartHashAlgorithmType hashAlgorithmType) {
		try {
			byte[] modulusBytes = SmartBase64.fromBase64WithArray(parse(
					publicKey, "Modulus"));
			byte[] exponentBytes = SmartBase64.fromBase64WithArray(parse(
					publicKey, "Exponent"));

			BigInteger modulus = new BigInteger(1, modulusBytes);
			BigInteger exponent = new BigInteger(1, exponentBytes);
			RSAPublicKeySpec rsaPublicKeySpec = new RSAPublicKeySpec(modulus,
					exponent);
			KeyFactory keyFactory = KeyFactory.getInstance("RSA");
			PublicKey pk = keyFactory.generatePublic(rsaPublicKeySpec);
			Signature signature = Signature
					.getInstance(createHashAlgorithm(hashAlgorithmType));
			signature.initVerify(pk);
			signature.update(input);
			return signature.verify(signInput);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 公钥验证签名
	 * 
	 * @param input
	 *            ，待签名验证的字节数组
	 * @param signInput
	 *            ，验证字节数组
	 * @param publicKey
	 *            ，签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，是否验证通过
	 */
	public static boolean verifyData(byte[] input, byte[] signInput,
			String publicKey) {
		return verifyData(input, signInput, publicKey,
				SmartHashAlgorithmType.Sha1);
	}

	/**
	 * 公钥验证签名
	 * 
	 * @param input
	 *            ，待签名验证的字符串
	 * @param signInput
	 *            ，验证字符串
	 * @param publicKey
	 *            ，签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @param encoding
	 *            ，编码
	 * @return，是否验证通过
	 */
	public static boolean verifyDataFromHex(String input, String signInput,
			String publicKey, SmartHashAlgorithmType hashAlgorithmType,
			String encoding) {
		try {
			encoding = encoding == null ? SmartEncoding.Default : encoding;

			return verifyData(
					input.getBytes(encoding),
					SmartHex.fromHex(signInput.getBytes(SmartEncoding.Default)),
					publicKey, hashAlgorithmType);

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 公钥验证签名
	 * 
	 * @param input
	 *            ，待签名验证的字符串
	 * @param signInput
	 *            ，验证字符串
	 * @param publicKey
	 *            ，签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @param hashAlgorithmType
	 *            ，算法类型
	 * @return，是否验证通过
	 */
	public static boolean verifyDataFromHex(String input, String signInput,
			String publicKey, SmartHashAlgorithmType hashAlgorithmType) {
		return verifyDataFromHex(input, signInput, publicKey,
				hashAlgorithmType, null);
	}

	/**
	 * 公钥验证签名
	 * 
	 * @param input
	 *            ，待签名验证的字符串
	 * @param signInput
	 *            ，验证字符串
	 * @param publicKey
	 *            ，签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * @return，是否验证通过
	 */
	public static boolean verifyDataFromHex(String input, String signInput,
			String publicKey) {
		return verifyDataFromHex(input, signInput, publicKey,
				SmartHashAlgorithmType.Sha1, null);
	}
}