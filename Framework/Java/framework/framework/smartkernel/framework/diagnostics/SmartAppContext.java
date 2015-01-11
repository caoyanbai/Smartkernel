/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.diagnostics;

import java.util.*;

import smartkernel.framework.*;
import smartkernel.framework.computer.*;
import smartkernel.framework.io.*;

/**
 * App上下文
 * 
 */
public class SmartAppContext {
	/**
	 * 启动时间
	 */
	public static final Date StartupTime = new Date();

	/**
	 * 程序所在目录（有斜线结尾）
	 */
	public static String Directory;

	static {
		String temp = System.getProperty("java.class.path").split("\\;")[0];

		if (temp.endsWith(".jar")) {
			Directory = SmartPath.getDirectoryName(temp);
		} else {
			Directory = temp + SmartComputer.DirectorySeparator;
		}
	}

	/**
	 * 程序名称
	 */
	public static final String Name = getName();

	private static String getName() {
		String name = System.getProperty("sun.java.command");
		String[] parts = name.split("\\.");
		String result = "";
		for (int i = 0; i < parts.length - 1; i++) {
			result += "." + parts[i];
		}
		return SmartString.trimStart(result, ".");
	}
}
