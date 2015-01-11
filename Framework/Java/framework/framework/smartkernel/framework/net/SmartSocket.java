/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.io.*;
import java.net.*;

import smartkernel.framework.*;
import smartkernel.framework.text.*;

/**
 * 套接字
 * 
 */
public class SmartSocket {
	/**
	 * 获得远程IP
	 * 
	 * @param socket
	 *            ，套接字
	 * @return，结果
	 */
	public static String getRemoteEndPointIP(Socket socket) {
		return socket.getInetAddress().getHostAddress();
	}

	/**
	 * 获得远程端口
	 * 
	 * @param socket
	 *            ，套接字
	 * @return，结果
	 */
	public static int getRemoteEndPointPort(Socket socket) {
		return socket.getPort();
	}

	/**
	 * 发送信息
	 * 
	 * @param ipEndPoint
	 *            ，端点
	 * @param requestText
	 *            ，消息
	 * @param flgReceive
	 *            ，是否接受消息
	 * @param encoding
	 *            ，数据编码方式
	 * @return，结果
	 */
	public static String send(InetSocketAddress ipEndPoint, String requestText,
			boolean flgReceive, String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;

		String responseText = "";

		try (Socket socket = new Socket()) {
			socket.connect(ipEndPoint);
			try (BufferedWriter bufferedWriter = new BufferedWriter(
					new OutputStreamWriter(socket.getOutputStream(), encoding))) {
				bufferedWriter.write(requestText);
				bufferedWriter.flush();
				socket.shutdownOutput();

				if (flgReceive) {
					try (BufferedReader bufferedReader = new BufferedReader(
							new InputStreamReader(socket.getInputStream(),
									encoding))) {
						String message = null;
						while ((message = bufferedReader.readLine()) != null) {
							responseText += message;
						}
					}
				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}

		return responseText;
	}

	/**
	 * 发送信息
	 * 
	 * @param ipEndPoint
	 *            ，端点
	 * @param requestText
	 *            ，消息
	 * @param flgReceive
	 *            ，是否接受消息
	 * @return，结果
	 */
	public static String send(InetSocketAddress ipEndPoint, String requestText,
			boolean flgReceive) {
		return send(ipEndPoint, requestText, flgReceive, null);
	}

	/**
	 * 发送信息
	 * 
	 * @param ipEndPoint
	 *            ，端点
	 * @param requestText
	 *            ，消息
	 * @return，结果
	 */
	public static String send(InetSocketAddress ipEndPoint, String requestText) {
		return send(ipEndPoint, requestText, true, null);
	}

	/**
	 * 监听信息
	 * 
	 * @param ipEndPoint
	 *            ，端点
	 * @param interact
	 *            ，交互处理
	 * @param encoding
	 *            ，数据编码方式
	 */
	public static void listen(InetSocketAddress ipEndPoint,
			final ISmartInvokeWithStringReturnStringFunc interact,
			String encoding) {
		final String encodingTrue = encoding == null ? SmartEncoding.Default
				: encoding;

		try (ServerSocket serverSocket = new ServerSocket()) {
			serverSocket.bind(ipEndPoint);
			while (true) {
				final Socket socket = serverSocket.accept();
				new Thread() {
					public void run() {
						try {
							try (BufferedReader bufferedReader = new BufferedReader(
									new InputStreamReader(
											socket.getInputStream(),
											encodingTrue))) {
								String requestText = "";
								String message = null;
								while ((message = bufferedReader.readLine()) != null) {
									requestText += message;
								}
								socket.shutdownInput();

								try (BufferedWriter bufferedWriter = new BufferedWriter(
										new OutputStreamWriter(
												socket.getOutputStream(),
												encodingTrue))) {
									String responseText = interact
											.invoke(requestText);
									bufferedWriter.write(responseText);
								}
							}
						} catch (Exception err) {
							throw new RuntimeException(err);
						}
					}
				}.start();

			}
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
	}

	/**
	 * 监听信息
	 * 
	 * @param ipEndPoint
	 *            ，端点
	 * @param interact
	 *            ，交互处理
	 */
	public static void listen(InetSocketAddress ipEndPoint,
			final ISmartInvokeWithStringReturnStringFunc interact) {
		listen(ipEndPoint, interact, null);
	}
}
