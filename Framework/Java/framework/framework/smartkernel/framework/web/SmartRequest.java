/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.web;

import java.io.*;
import java.net.*;
import java.util.zip.*;

import smartkernel.framework.computer.*;
import smartkernel.framework.text.*;

/**
 * 请求
 *
 */
public class SmartRequest {
	/**
	 * 下载字符串
	 * 
	 * @param uri
	 *            ，地址
	 * @param encoding
	 *            ，编码
	 * @param timeout
	 *            ，超时
	 * @param httpActionType
	 *            ，请求类型
	 * @param postParameter
	 *            ，参数
	 * @return，结果
	 */
	public static String downloadString(String uri, String encoding,
			int timeout, SmartHttpActionType httpActionType,
			String postParameter) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			URL url = new URL(uri);
			HttpURLConnection httpURLConnection = (HttpURLConnection) url
					.openConnection();
			httpURLConnection.setConnectTimeout(timeout);
			httpURLConnection.setReadTimeout(timeout);
			httpURLConnection.setInstanceFollowRedirects(true);

			if (httpActionType == SmartHttpActionType.Get) {
				httpURLConnection.setRequestMethod("GET");
				httpURLConnection.connect();
			} else {
				httpURLConnection.setDoInput(true);
				httpURLConnection.setDoOutput(true);
				httpURLConnection.setRequestMethod("POST");
				httpURLConnection.addRequestProperty("Content-type",
						"application/x-www-form-urlencoded");

				if (postParameter != null) {
					try (PrintWriter printWriter = new PrintWriter(
							httpURLConnection.getOutputStream())) {
						printWriter.print(postParameter);
						printWriter.flush();
					}
				}
			}
			BufferedReader bufferedReader = null;
			String type = httpURLConnection.getContentEncoding();
			if (type != null) {
				type = type.toLowerCase();
			}
			if ("gzip".equals(type)) {
				bufferedReader = new BufferedReader(
						new InputStreamReader(new GZIPInputStream(
								httpURLConnection.getInputStream()), encoding));
			} else if ("deflate".equals(type)) {
				bufferedReader = new BufferedReader(new InputStreamReader(
						new DeflaterInputStream(
								httpURLConnection.getInputStream()), encoding));
			} else {
				bufferedReader = new BufferedReader(new InputStreamReader(
						httpURLConnection.getInputStream(), encoding));
			}

			String line = null;
			StringBuilder stringBuilder = new StringBuilder();
			try (BufferedReader b = bufferedReader;) {
				while ((line = b.readLine()) != null) {
					stringBuilder.append(line + SmartComputer.LineSeparator);
				}
			}
			httpURLConnection.disconnect();
			return stringBuilder.toString();

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 下载字符串
	 * 
	 * @param uri
	 *            ，地址
	 * @param encoding
	 *            ，编码
	 * @param timeout
	 *            ，超时
	 * @param httpActionType
	 *            ，请求类型
	 * @return，结果
	 */
	public static String downloadString(String uri, String encoding,
			int timeout, SmartHttpActionType httpActionType) {
		return downloadString(uri, encoding, timeout, httpActionType, null);
	}

	/**
	 * 下载字符串
	 * 
	 * @param uri
	 *            ，地址
	 * @param encoding
	 *            ，编码
	 * @param timeout
	 *            ，超时
	 * @return，结果
	 */
	public static String downloadString(String uri, String encoding, int timeout) {
		return downloadString(uri, encoding, timeout, SmartHttpActionType.Get,
				null);
	}

	/**
	 * 下载字符串
	 * 
	 * @param uri
	 *            ，地址
	 * @param encoding
	 *            ，编码
	 * @return，结果
	 */
	public static String downloadString(String uri, String encoding) {
		return downloadString(uri, encoding, 10000, SmartHttpActionType.Get,
				null);
	}

	/**
	 * 下载字符串
	 * 
	 * @param uri
	 *            ，地址
	 * @return，结果
	 */
	public static String downloadString(String uri) {
		return downloadString(uri, null, 10000, SmartHttpActionType.Get, null);
	}
}
