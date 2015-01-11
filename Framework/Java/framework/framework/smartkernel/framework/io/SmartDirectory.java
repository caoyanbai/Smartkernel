/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.*;
import java.util.*;

import smartkernel.framework.*;
import smartkernel.framework.computer.*;

/**
 * 文件夹操作类
 * 
 */
public class SmartDirectory {
	/**
	 * 计算指定文件夹的总大小，包含所有子目录中的文件
	 * 
	 * @param directoryPath
	 *            ，文件夹的路径
	 * @return，总大小
	 */
	public static long getTotalSize(String directoryPath) {
		directoryPath = getFormatDirectoryPath(directoryPath);
		File directory = new File(directoryPath);
		File[] files = directory.listFiles();
		long size = 0;
		for (File file : files) {
			if (file.isFile()) {
				size += file.length();
			} else if (file.isDirectory()) {
				size += getTotalSize(file.getAbsolutePath());
			}
		}
		return size;
	}

	/**
	 * 获得格式化的目录路径（格式化为符合操作系统的分隔符号和包含结尾分隔符号）
	 * 
	 * @param directoryPath
	 *            ，目录的路径
	 * @return，结果
	 */
	public static String getFormatDirectoryPath(String directoryPath) {
		directoryPath = directoryPath.replace("\\",
				SmartComputer.DirectorySeparator);
		directoryPath = directoryPath.replace("/",
				SmartComputer.DirectorySeparator);
		directoryPath = directoryPath.replace(SmartComputer.DirectorySeparator
				+ SmartComputer.DirectorySeparator,
				SmartComputer.DirectorySeparator);
		directoryPath = SmartString.trimEnd(directoryPath,
				SmartComputer.DirectorySeparator);
		return directoryPath + SmartComputer.DirectorySeparator;
	}

	/**
	 * 获得目录下的子目录列表
	 * 
	 * @param directoryPath
	 *            ，目录的路径
	 * @param searchOptionType
	 *            ，搜索选项类型
	 * @return，结果
	 */
	public static ArrayList<String> getDirectories(String directoryPath,
			SmartSearchOptionType searchOptionType) {
		directoryPath = getFormatDirectoryPath(directoryPath);
		if (searchOptionType == SmartSearchOptionType.TopDirectoryOnly) {
			ArrayList<String> result = new ArrayList<String>();
			File[] files = new File(directoryPath).listFiles();
			for (File file : files) {
				if (file.isDirectory()) {
					result.add(file.getAbsolutePath());
				}
			}
			return result;
		} else {
			ArrayList<String> result = getDirectories(directoryPath,
					SmartSearchOptionType.TopDirectoryOnly);

			ArrayList<String> subDirectories = getDirectories(directoryPath);

			for (String subDirectorie : subDirectories) {
				ArrayList<String> resultTemp = getDirectories(subDirectorie,
						SmartSearchOptionType.AllDirectories);
				result.addAll(resultTemp);
			}

			return result;
		}
	}

	/**
	 * 获得目录下的子目录列表
	 * 
	 * @param directoryPath
	 *            ，目录的路径
	 * @return，结果
	 */
	public static ArrayList<String> getDirectories(String directoryPath) {
		return getDirectories(directoryPath,
				SmartSearchOptionType.TopDirectoryOnly);
	}

	/**
	 * 获得目录下的文件列表
	 * 
	 * @param directoryPath
	 *            ，目录的路径
	 * @param searchOptionType
	 *            ，搜索选项类型
	 * @return，结果
	 */
	public static ArrayList<String> getFiles(String directoryPath,
			SmartSearchOptionType searchOptionType) {
		directoryPath = getFormatDirectoryPath(directoryPath);
		if (searchOptionType == SmartSearchOptionType.TopDirectoryOnly) {
			ArrayList<String> result = new ArrayList<String>();
			File[] files = new File(directoryPath).listFiles();
			for (File file : files) {
				if (file.isFile()) {
					result.add(file.getAbsolutePath());
				}
			}
			return result;
		} else {

			ArrayList<String> result = getFiles(directoryPath,
					SmartSearchOptionType.TopDirectoryOnly);

			ArrayList<String> subDirectories = getDirectories(directoryPath);

			for (String subDirectorie : subDirectories) {
				ArrayList<String> resultTemp = getFiles(subDirectorie,
						SmartSearchOptionType.AllDirectories);
				result.addAll(resultTemp);
			}

			return result;
		}
	}

	/**
	 * 获得目录下的文件列表
	 * 
	 * @param directoryPath
	 *            ，目录的路径
	 * @return，结果
	 */
	public static ArrayList<String> getFiles(String directoryPath) {
		return getFiles(directoryPath, SmartSearchOptionType.TopDirectoryOnly);
	}

	/**
	 * 获得指定文件夹下的文件扩展名类型
	 * 
	 * @param directoryPath
	 *            ，文件夹路径
	 * @param searchOptionType
	 *            ，搜索的范围，是不是包含子目录
	 * @return，查找的结果
	 */
	public static ArrayList<String> getExtensionTypes(String directoryPath,
			SmartSearchOptionType searchOptionType) {
		directoryPath = getFormatDirectoryPath(directoryPath);
		ArrayList<String> files = getFiles(directoryPath, searchOptionType);

		ArrayList<String> extensionTypes = new ArrayList<String>();
		HashSet<String> hashSet = new HashSet<String>();

		for (String file : files) {
			String extensionType = SmartPath.getExtension(file);

			if (!hashSet.contains(extensionType)) {
				hashSet.add(extensionType);
				extensionTypes.add(extensionType);
			}
		}

		return extensionTypes;
	}

	/**
	 * 获得指定文件夹下的文件扩展名类型
	 * 
	 * @param directoryPath
	 *            ，文件夹路径
	 * @return，查找的结果
	 */
	public static ArrayList<String> getExtensionTypes(String directoryPath) {
		return getExtensionTypes(directoryPath,
				SmartSearchOptionType.AllDirectories);
	}

	/**
	 * 判断文件夹是否存在
	 * 
	 * @param path
	 *            ，路径
	 * @return，结果
	 */
	public static boolean exists(String path) {
		path = getFormatDirectoryPath(path);
		return new File(path).exists();
	}

	/**
	 * 递归复制文件夹及所有文件
	 * 
	 * @param sourceDirectoryPath
	 *            ，源文件夹
	 * @param targetDirectoryPath
	 *            ，目标文件夹
	 * @param overwrite
	 *            ，是否覆盖
	 */
	public static void copy(String sourceDirectoryPath,
			String targetDirectoryPath, boolean overwrite) {
		sourceDirectoryPath = getFormatDirectoryPath(sourceDirectoryPath);
		targetDirectoryPath = getFormatDirectoryPath(targetDirectoryPath);
		if (!exists(targetDirectoryPath)) {
			new File(targetDirectoryPath).mkdirs();
		}

		if (!exists(sourceDirectoryPath)) {
			return;
		}

		ArrayList<String> directories = getDirectories(sourceDirectoryPath,
				SmartSearchOptionType.TopDirectoryOnly);

		if (directories.size() > 0) {
			for (String directory : directories) {
				copy(directory,
						targetDirectoryPath
								+ directory.substring(directory
										.lastIndexOf("\\")), overwrite);
			}
		}

		ArrayList<String> files = getFiles(sourceDirectoryPath);

		if (files.size() > 0) {
			for (String file : files) {
				String targerFile = targetDirectoryPath
						+ file.substring(file.lastIndexOf("\\"));
				SmartFile.copy(file, targerFile, overwrite);
			}
		}
	}

	/**
	 * 递归复制文件夹及所有文件
	 * 
	 * @param sourceDirectoryPath
	 *            ，源文件夹
	 * @param targetDirectoryPath
	 *            ，目标文件夹
	 */
	public static void copy(String sourceDirectoryPath,
			String targetDirectoryPath) {
		copy(sourceDirectoryPath, targetDirectoryPath, true);
	}

	/**
	 * 创建多层目录
	 * 
	 * @param directoryName，目录路径
	 */
	public static void createDirectory(String directoryName) {
		if (!exists(directoryName)) {
			new File(directoryName).mkdirs();
		}
	}
}
