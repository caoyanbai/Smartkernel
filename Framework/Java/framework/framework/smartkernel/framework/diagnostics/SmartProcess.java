/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.diagnostics;

import java.io.*;

import smartkernel.framework.computer.*;
import smartkernel.framework.text.*;

/**
 * 进程
 * 
 */
public class SmartProcess {
	/**
	 * 执行命令行
	 * 
	 * @param command
	 *            ，命令
	 * @param encoding
	 *            ，编码
	 * @return，结果
	 */
	public static String executeCommand(String command, String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try (InputStream inputStream = Runtime.getRuntime().exec(command)
				.getInputStream();
				InputStreamReader inputStreamReader = new InputStreamReader(
						inputStream, encoding);
				BufferedReader bufferedReader = new BufferedReader(
						inputStreamReader)) {
			String line = null;
			StringBuilder stringBuilder = new StringBuilder();
			while ((line = bufferedReader.readLine()) != null) {
				stringBuilder.append(line);
				stringBuilder.append(SmartComputer.LineSeparator);
			}
			return stringBuilder.toString();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 执行命令行
	 * 
	 * @param command
	 *            ，命令
	 * @return，结果
	 */
	public static String executeCommand(String command) {
		return executeCommand(command, null);
	}

	/**
	 * 启动程序
	 * 
	 * @param filePath
	 *            ，待启动的程序路径
	 * @param args
	 *            ，参数
	 */
	public static void start(String filePath, String[] args) {
		try {
			Runtime.getRuntime().exec(filePath, args);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 启动程序
	 * 
	 * @param filePath
	 *            ，待启动的程序路径
	 */
	public static void start(String filePath) {
		start(filePath, null);
	}
}
