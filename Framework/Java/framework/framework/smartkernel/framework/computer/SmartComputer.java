/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.computer;

import java.awt.*;
import java.net.*;

import smartkernel.framework.diagnostics.*;

/**
 * 本地计算机功能相关
 * 
 */
public class SmartComputer {
	/**
	 * 获取是否是64位操作系统
	 * 
	 * @return，结果
	 */
	public static boolean is64BitOperatingSystem() {
		return System.getProperty("os.arch").contains("64");
	}

	/**
	 * 获取当前进程是不是64位进程
	 * 
	 * @return，结果
	 */
	public static boolean is64BitProcess() {
		return Integer.valueOf(System.getProperty("sun.arch.data.model")) == 64;
	}

	/**
	 * 发出蜂鸣声
	 */
	public static void beep() {
		Toolkit.getDefaultToolkit().beep();
	}

	/**
	 * 获取本地计算机名称
	 * 
	 * @return，结果
	 */
	public static String getMachineName() {
		try {
			return InetAddress.getLocalHost().getHostName();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获取当前已登录到操作系统的人员的用户名
	 * 
	 * @return，结果
	 */
	public static String getUserName() {
		return System.getProperty("user.name");
	}

	/**
	 * 获取处理器数量（多核也认为是多个处理器）
	 * 
	 * @return，结果
	 */
	public static int getProcessorCount() {
		return Runtime.getRuntime().availableProcessors();
	}

	/**
	 * 获取一个 Version 对象，该对象描述公共语言运行库的主版本、次版本、内部版本和修订号
	 * 
	 * @return，结果
	 */
	public static String getJavaVersion() {
		return System.getProperty("java.version");
	}

	/**
	 * 获得操作系统类型
	 * 
	 * @return，结果
	 */
	public static SmartOSType getOSType() {
		SmartOSType osType = null;
		String OS = System.getProperty("os.name", "generic").toLowerCase();
		if (OS.indexOf("win") >= 0) {
			osType = SmartOSType.Windows;
		} else if ((OS.indexOf("mac") >= 0) || (OS.indexOf("darwin") >= 0)) {
			osType = SmartOSType.MacOS;
		} else if (OS.indexOf("nux") >= 0) {
			osType = SmartOSType.Linux;
		} else {
			osType = SmartOSType.Other;
		}
		return osType;
	}

	/**
	 * 换行符号
	 */
	public static final String LineSeparator = System
			.getProperty("line.separator");

	/**
	 * 目录分隔符号
	 */
	public static final String DirectorySeparator = System
			.getProperty("file.separator");

	/**
	 * 立即关机
	 */
	public static void close() {
		if (getOSType().equals(SmartOSType.Windows)) {
			SmartProcess.executeCommand("shutdown -s -f -t 00");
		} else {
			SmartProcess.executeCommand("shutdown -h now");
		}
	}

	/**
	 * 立即重启
	 */
	public static void restart() {
		if (getOSType().equals(SmartOSType.Windows)) {
			SmartProcess.executeCommand("shutdown -r");
		} else {
			SmartProcess.executeCommand("shutdown -r now");
		}
	}
}
