/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.io.*;
import java.net.*;
import java.util.*;
import java.util.zip.*;

/**
 * Jar处理
 * 
 */
public class SmartJar {
	/**
	 * 获得所有类定义
	 * 
	 * @param path
	 *            ，路径
	 * @return，结果
	 */
	public static ArrayList<Class<?>> getAllClasses(String path) {
		ArrayList<Class<?>> cs = new ArrayList<Class<?>>();
		File file = new File(path);
		try (ZipInputStream zipInputStream = new ZipInputStream(
				new FileInputStream(path))) {
			try (URLClassLoader loader = new URLClassLoader(new URL[] { file
					.toURI().toURL() }, ClassLoader.getSystemClassLoader())) {
				for (ZipEntry entry = zipInputStream.getNextEntry(); entry != null; entry = zipInputStream
						.getNextEntry())
					if (entry.getName().endsWith(".class")
							&& !entry.isDirectory()) {
						StringBuilder className = new StringBuilder();
						String[] parts = entry.getName().split("/");
						for (String part : parts) {
							if (className.length() != 0)
								className.append(".");
							className.append(part);
							if (part.endsWith(".class"))
								className.setLength(className.length()
										- ".class".length());
						}
						cs.add(loader.loadClass(className.toString()));
					}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
		return cs;
	}
}
