/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.codedom;

import java.net.*;

import javax.tools.*;

/**
 * SmartSimpleJavaFileObject
 * 
 */
public class SmartSimpleJavaFileObject extends SimpleJavaFileObject {
	final String code;

	/**
	 * 构造函数
	 * 
	 * @param className
	 *            ，名称
	 * @param classCode
	 *            ，代码
	 */
	public SmartSimpleJavaFileObject(String className, String classCode) {
		super(URI.create("string:///" + className.replace('.', '/')
				+ Kind.SOURCE.extension), Kind.SOURCE);
		this.code = classCode;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.SimpleJavaFileObject#getCharContent(boolean)
	 */
	public CharSequence getCharContent(boolean ignoreEncodingErrors) {
		return code;
	}
}
