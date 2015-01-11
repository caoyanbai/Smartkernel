/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.codedom;

import java.io.*;
import java.net.*;

import javax.tools.*;

/**
 * SmartMemoryJavaFileObject
 * 
 */
public class SmartMemoryJavaFileObject extends SimpleJavaFileObject {
	/**
	 * OutputStream
	 */
	public static ByteArrayOutputStream OutputStream = new ByteArrayOutputStream();

	/**
	 * 构造函数
	 * 
	 * @param uri
	 *            ，地址
	 * @param kind
	 *            ，类型
	 */
	public SmartMemoryJavaFileObject(String uri, JavaFileObject.Kind kind) {
		super(URI.create(uri), kind);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.SimpleJavaFileObject#openOutputStream()
	 */
	public OutputStream openOutputStream() {
		return OutputStream;
	}
}
