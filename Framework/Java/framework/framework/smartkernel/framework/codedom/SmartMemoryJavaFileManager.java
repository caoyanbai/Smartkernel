/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.codedom;

import java.io.*;
import java.util.*;

import javax.tools.*;
import javax.tools.JavaFileObject.*;

import smartkernel.framework.*;

/**
 * SmartMemoryJavaFileManager
 * 
 */
public class SmartMemoryJavaFileManager implements JavaFileManager {
	protected JavaFileManager parent;

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#getJavaFileForOutput(javax.tools.JavaFileManager
	 * .Location, java.lang.String, javax.tools.JavaFileObject.Kind,
	 * javax.tools.FileObject)
	 */
	public JavaFileObject getJavaFileForOutput(
			JavaFileManager.Location location, String className,
			JavaFileObject.Kind kind, FileObject sibling) throws IOException {
		return new SmartMemoryJavaFileObject("file:///SmartCompiler_"
				+ SmartGuid.newGuid() + ".class", kind);
	}

	/**
	 * @param parent
	 */
	public SmartMemoryJavaFileManager(JavaFileManager parent) {
		this.parent = parent;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.JavaFileManager#close()
	 */
	public void close() throws IOException {
		parent.close();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.JavaFileManager#flush()
	 */
	public void flush() throws IOException {
		parent.flush();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#getClassLoader(javax.tools.JavaFileManager
	 * .Location)
	 */
	public ClassLoader getClassLoader(JavaFileManager.Location location) {
		return parent.getClassLoader(location);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#getFileForInput(javax.tools.JavaFileManager
	 * .Location, java.lang.String, java.lang.String)
	 */
	public FileObject getFileForInput(JavaFileManager.Location location,
			String packageName, String relName) throws IOException {
		return parent.getFileForInput(location, packageName, relName);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#getFileForOutput(javax.tools.JavaFileManager
	 * .Location, java.lang.String, java.lang.String, javax.tools.FileObject)
	 */
	public FileObject getFileForOutput(JavaFileManager.Location location,
			String packageName, String relName, FileObject sibling)
			throws IOException {
		return parent.getFileForOutput(location, packageName, relName, sibling);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#getJavaFileForInput(javax.tools.JavaFileManager
	 * .Location, java.lang.String, javax.tools.JavaFileObject.Kind)
	 */
	public JavaFileObject getJavaFileForInput(
			JavaFileManager.Location location, String className,
			JavaFileObject.Kind kind) throws IOException {
		return parent.getJavaFileForInput(location, className, kind);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.JavaFileManager#handleOption(java.lang.String,
	 * java.util.Iterator)
	 */
	public boolean handleOption(String current, Iterator<String> remaining) {
		return parent.handleOption(current, remaining);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#hasLocation(javax.tools.JavaFileManager.Location
	 * )
	 */
	public boolean hasLocation(JavaFileManager.Location location) {
		return parent.hasLocation(location);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#inferBinaryName(javax.tools.JavaFileManager
	 * .Location, javax.tools.JavaFileObject)
	 */
	public String inferBinaryName(JavaFileManager.Location location,
			JavaFileObject file) {
		return parent.inferBinaryName(location, file);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.JavaFileManager#isSameFile(javax.tools.FileObject,
	 * javax.tools.FileObject)
	 */
	public boolean isSameFile(FileObject a, FileObject b) {
		return parent.isSameFile(a, b);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see javax.tools.OptionChecker#isSupportedOption(java.lang.String)
	 */
	public int isSupportedOption(String option) {
		return parent.isSupportedOption(option);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * javax.tools.JavaFileManager#list(javax.tools.JavaFileManager.Location,
	 * java.lang.String, java.util.Set, boolean)
	 */
	public Iterable<JavaFileObject> list(Location location, String packageName,
			Set<Kind> kinds, boolean recurse) throws IOException {
		return parent.list(location, packageName, kinds, recurse);
	}
}
