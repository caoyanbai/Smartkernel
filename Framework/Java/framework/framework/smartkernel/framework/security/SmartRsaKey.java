/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.security;

import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;

import smartkernel.framework.text.*;

/**
 * 密钥对
 * 
 */
public class SmartRsaKey {
	private String privateKey;

	private String publicKey;

	/**
	 * 构造函数
	 */
	public SmartRsaKey() {
		try {
			KeyPairGenerator keyPairGenerator = KeyPairGenerator
					.getInstance("RSA");
			keyPairGenerator.initialize(1024);
			KeyPair keyPair = keyPairGenerator.genKeyPair();

			byte[] encodedPrivateKey = keyPair.getPrivate().getEncoded();
			PKCS8EncodedKeySpec pkcs8EncodedKeySpec = new PKCS8EncodedKeySpec(
					encodedPrivateKey);
			KeyFactory keyFactory = KeyFactory.getInstance("RSA");
			RSAPrivateCrtKey rsaPrivateCrtKey = (RSAPrivateCrtKey) keyFactory
					.generatePrivate(pkcs8EncodedKeySpec);

			this.privateKey = formatPrivateKey(rsaPrivateCrtKey);
			this.publicKey = formatPublicKey(rsaPrivateCrtKey);

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	private static String formatPrivateKey(RSAPrivateCrtKey rsaPrivateCrtKey) {
		try {
			StringBuffer stringBuffer = new StringBuffer();

			stringBuffer.append("<RSAKeyValue>");
			stringBuffer.append("<Modulus>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getModulus().toByteArray())) + "</Modulus>");
			stringBuffer.append("<Exponent>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPublicExponent().toByteArray()))
					+ "</Exponent>");
			stringBuffer.append("<P>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPrimeP().toByteArray())) + "</P>");
			stringBuffer.append("<Q>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPrimeQ().toByteArray())) + "</Q>");
			stringBuffer.append("<DP>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPrimeExponentP().toByteArray())) + "</DP>");
			stringBuffer.append("<DQ>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPrimeExponentQ().toByteArray())) + "</DQ>");
			stringBuffer.append("<InverseQ>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getCrtCoefficient().toByteArray()))
					+ "</InverseQ>");
			stringBuffer.append("<D>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPrivateExponent().toByteArray())) + "</D>");
			stringBuffer.append("</RSAKeyValue>");
			return stringBuffer.toString().replaceAll("[ \t\n\r]", "");
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	private static String formatPublicKey(RSAPrivateCrtKey rsaPrivateCrtKey) {
		try {
			StringBuffer stringBuffer = new StringBuffer();
			stringBuffer.append("<RSAKeyValue>");
			stringBuffer.append("<Modulus>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getModulus().toByteArray())) + "</Modulus>");
			stringBuffer.append("<Exponent>"
					+ SmartBase64.toBase64WithArray(removeZero(rsaPrivateCrtKey
							.getPublicExponent().toByteArray()))
					+ "</Exponent>");
			stringBuffer.append("</RSAKeyValue>");
			return stringBuffer.toString().replaceAll("[ \t\n\r]", "");
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	private static byte[] removeZero(byte[] data) {
		try {
			// 我们得到的modulus是257个字节，需要去掉首字节的0，用剩下的256个字节实例化BigInteger。
			byte[] data1;
			int len = data.length;
			if (data[0] == 0) {
				data1 = new byte[data.length - 1];
				System.arraycopy(data, 1, data1, 0, len - 1);
			} else {
				data1 = data;
			}
			return data1;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 密钥对的公钥（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * 
	 * @return，结果
	 */
	public String getPublicKey() {
		return this.publicKey;
	}

	/**
	 * 密钥对的私钥（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
	 * 
	 * @return，结果
	 */
	public String getPrivateKey() {
		return this.privateKey;
	}
}
