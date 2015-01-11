/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.Scanner;

/**
 * Console
 * 
 */
public class SmartConsole {
	/**
	 * 输出消息
	 * 
	 * @param message
	 *            ，消息
	 */
	public static void write(Object message) {
		System.out.print(message);
	}

	/**
	 * 输出消息
	 * 
	 * @param message
	 *            ，消息
	 */
	public static void writeLine(Object message) {
		System.out.println(message);
	}

	/**
	 * 输入消息
	 * 
	 * @return，消息
	 */
	public static String read() {
		try (Scanner scanner = new Scanner(System.in)) {
			return scanner.next();
		}
	}

	/**
	 * 输入消息
	 * 
	 * @return，消息
	 */
	public static String readLine() {
		try (Scanner scanner = new Scanner(System.in)) {
			return scanner.nextLine();
		}
	}
}
