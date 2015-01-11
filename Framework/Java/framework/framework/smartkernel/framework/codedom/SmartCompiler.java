/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.codedom;

import java.util.*;

import javax.tools.*;

/**
 * 编译器
 * 
 */
public class SmartCompiler {
	/**
	 * 编译
	 * 
	 * @param simpleJavaFileObjects
	 *            ，代码对象
	 * @param options
	 *            ，选项
	 * @return，类加载器
	 */
	public static ClassLoader compile(
			ArrayList<SmartSimpleJavaFileObject> simpleJavaFileObjects,
			ArrayList<String> options) {

		JavaCompiler javaCompiler = ToolProvider.getSystemJavaCompiler();

		JavaFileManager javaFileManager = javaCompiler.getStandardFileManager(
				null, null, null);
		SmartMemoryJavaFileManager memoryJavaFileManager = new SmartMemoryJavaFileManager(
				javaFileManager);

		javaCompiler.getTask(null, memoryJavaFileManager, null, options, null,
				simpleJavaFileObjects).call();

		return new SmartByteArrayClassLoader();
	}

	/**
	 * 编译
	 * 
	 * @param simpleJavaFileObjects
	 *            ，代码对象
	 * @return，类加载器
	 */
	public static ClassLoader compile(
			ArrayList<SmartSimpleJavaFileObject> simpleJavaFileObjects) {
		return compile(simpleJavaFileObjects, null);
	}

	/**
	 * 编译到文件
	 * 
	 * @param simpleJavaFileObjects
	 *            ，代码对象
	 * @param options
	 *            ，选项
	 */
	public static void compileToFile(
			ArrayList<SmartSimpleJavaFileObject> simpleJavaFileObjects,
			ArrayList<String> options) {
		JavaCompiler javaCompiler = ToolProvider.getSystemJavaCompiler();
		DiagnosticCollector<JavaFileObject> diagnostics = new DiagnosticCollector<JavaFileObject>();
		javaCompiler.getTask(null, null, diagnostics, options, null,
				simpleJavaFileObjects).call();
	}

	/**
	 * 编译到文件
	 * 
	 * @param simpleJavaFileObjects
	 *            ，代码对象
	 */
	public static void compileToFile(
			ArrayList<SmartSimpleJavaFileObject> simpleJavaFileObjects) {
		compileToFile(simpleJavaFileObjects, null);
	}
}
