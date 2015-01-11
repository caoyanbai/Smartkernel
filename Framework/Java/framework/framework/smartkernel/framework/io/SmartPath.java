/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.File;

import smartkernel.framework.*;
import smartkernel.framework.computer.*;

/**
 * 路径
 * 
 */
public class SmartPath {
	/**
	 * 获得扩展名
	 * 
	 * @param filePath
	 *            ，路径
	 * @return，结果
	 */
	public static String getExtension(String filePath) {
		filePath = SmartFile.getFormatFilePath(filePath);
		String[] filePathParts = filePath.split("\\"
				+ SmartComputer.DirectorySeparator);
		String filename = filePathParts[filePathParts.length - 1];
		String[] nameSplit = filename.split("[.]");
		return nameSplit[nameSplit.length - 1];
	}

	/**
	 * 获得文件名（不包含扩展名）
	 * 
	 * @param filePath
	 *            ，路径
	 * @return，结果
	 */
	public static String getFileNameWithoutExtension(String filePath) {
		filePath = SmartFile.getFormatFilePath(filePath);
		String[] filePathParts = filePath.split("\\"
				+ SmartComputer.DirectorySeparator);
		String filename = filePathParts[filePathParts.length - 1];
		String[] nameSplit = filename.split("[.]");
		return SmartString.trimEnd(filename, "."
				+ nameSplit[nameSplit.length - 1]);
	}

	/**
	 * 获得文件名
	 * 
	 * @param filePath
	 *            ，路径
	 * @return，结果
	 */
	public static String getFileName(String filePath) {
		filePath = SmartFile.getFormatFilePath(filePath);
		String[] filePathParts = filePath.split("\\"
				+ SmartComputer.DirectorySeparator);
		String filename = filePathParts[filePathParts.length - 1];
		return filename;
	}

	/**
	 * 获得文件夹路径（有结尾分隔符号）
	 * 
	 * @param filePath
	 *            ，文件路径
	 * @return，结果
	 */
	public static String getDirectoryName(String filePath) {
		filePath = SmartFile.getFormatFilePath(filePath);
		String parent = new File(filePath).getParent();
		parent = parent == null ? "" : parent;
		return parent + SmartComputer.DirectorySeparator;
	}
}
