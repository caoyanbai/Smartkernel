/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.codedom;

/**
 * SmartByteArrayClassLoader
 * 
 */
public class SmartByteArrayClassLoader extends ClassLoader {
	/*
	 * (non-Javadoc)
	 * 
	 * @see java.lang.ClassLoader#findClass(java.lang.String)
	 */
	public Class<?> findClass(String name) {
		byte[] bytes = SmartMemoryJavaFileObject.OutputStream.toByteArray();
		return super.defineClass(name, bytes, 0, bytes.length);
	}
}
