/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.*;
import java.util.*;

import smartkernel.framework.*;
import smartkernel.framework.text.*;
import net.lingala.zip4j.core.*;
import net.lingala.zip4j.model.*;
import net.lingala.zip4j.util.*;

/**
 * Zip文件的格式的压缩解压处理（只能处理zip格式，rar格式无法处理）
 *
 */
public class SmartZip {
	/**
	 * 压缩文件列表
	 * 
	 * @param sourceFilePaths
	 *            ，文件列表
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 * @param password
	 *            ，解压密码
	 */
	public static void compressFiles(ArrayList<String> sourceFilePaths,
			String zipFilePath, String encoding, String password) {

		encoding = encoding == null ? SmartEncoding.Default : encoding;

		try {
			ZipParameters parameters = new ZipParameters();
			parameters.setCompressionMethod(Zip4jConstants.COMP_DEFLATE);
			parameters.setCompressionLevel(Zip4jConstants.DEFLATE_LEVEL_NORMAL);
			ZipFile zip = new ZipFile(zipFilePath);
			zip.setFileNameCharset(encoding);
			if (!SmartString.isNullOrEmpty(password)) {
				zip.setPassword(password);
			}
			zip.addFiles(sourceFilePaths, parameters);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 压缩文件列表
	 * 
	 * @param sourceFilePaths
	 *            ，文件列表
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 */
	public static void compressFiles(ArrayList<String> sourceFilePaths,
			String zipFilePath, String encoding) {
		compressFiles(sourceFilePaths, zipFilePath, encoding, null);
	}

	/**
	 * 压缩文件列表
	 * 
	 * @param sourceFilePaths
	 *            ，文件列表
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 */
	public static void compressFiles(ArrayList<String> sourceFilePaths,
			String zipFilePath) {
		compressFiles(sourceFilePaths, zipFilePath, null, null);
	}

	/**
	 * 压缩文件
	 * 
	 * @param sourceFilePath
	 *            ，文件
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 * @param password
	 *            ，解压密码
	 */
	public static void compressFile(String sourceFilePath, String zipFilePath,
			String encoding, String password) {

		encoding = encoding == null ? SmartEncoding.Default : encoding;

		try {
			ZipParameters parameters = new ZipParameters();
			parameters.setCompressionMethod(Zip4jConstants.COMP_DEFLATE);
			parameters.setCompressionLevel(Zip4jConstants.DEFLATE_LEVEL_NORMAL);
			ZipFile zip = new ZipFile(zipFilePath);
			zip.setFileNameCharset(encoding);
			if (!SmartString.isNullOrEmpty(password)) {
				zip.setPassword(password);
			}
			zip.addFile(new File(sourceFilePath), parameters);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 压缩文件
	 * 
	 * @param sourceFilePath
	 *            ，文件
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 */
	public static void compressFile(String sourceFilePath, String zipFilePath,
			String encoding) {
		compressFile(sourceFilePath, zipFilePath, encoding, null);
	}

	/**
	 * 压缩文件
	 * 
	 * @param sourceFilePath
	 *            ，文件
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 */
	public static void compressFile(String sourceFilePath, String zipFilePath) {
		compressFile(sourceFilePath, zipFilePath, null, null);
	}

	/**
	 * 压缩文件列表
	 * 
	 * @param sourceDirectoryPaths
	 *            ，文件夹列表
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 * @param password
	 *            ，解压密码
	 */
	public static void compressDirectories(
			ArrayList<String> sourceDirectoryPaths, String zipFilePath,
			String encoding, String password) {

		encoding = encoding == null ? SmartEncoding.Default : encoding;

		try {
			ZipParameters parameters = new ZipParameters();
			parameters.setCompressionMethod(Zip4jConstants.COMP_DEFLATE);
			parameters.setCompressionLevel(Zip4jConstants.DEFLATE_LEVEL_NORMAL);
			ZipFile zip = new ZipFile(zipFilePath);
			zip.setFileNameCharset(encoding);
			if (!SmartString.isNullOrEmpty(password)) {
				zip.setPassword(password);
			}
			for (String sourceDirectoryPath : sourceDirectoryPaths) {
				zip.addFolder(sourceDirectoryPath, parameters);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 压缩文件列表
	 * 
	 * @param sourceDirectoryPaths
	 *            ，文件夹列表
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 */
	public static void compressDirectories(
			ArrayList<String> sourceDirectoryPaths, String zipFilePath,
			String encoding) {
		compressDirectories(sourceDirectoryPaths, zipFilePath, encoding, null);
	}

	/**
	 * 压缩文件列表
	 * 
	 * @param sourceDirectoryPaths
	 *            ，文件夹列表
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 */
	public static void compressDirectories(
			ArrayList<String> sourceDirectoryPaths, String zipFilePath) {
		compressDirectories(sourceDirectoryPaths, zipFilePath, null, null);
	}

	/**
	 * 压缩文件
	 * 
	 * @param sourceDirectoryPath
	 *            ，文件夹
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 * @param password
	 *            ，解压密码
	 */
	public static void compressDirectory(String sourceDirectoryPath,
			String zipFilePath, String encoding, String password) {

		encoding = encoding == null ? SmartEncoding.Default : encoding;

		try {
			ZipParameters parameters = new ZipParameters();
			parameters.setCompressionMethod(Zip4jConstants.COMP_DEFLATE);
			parameters.setCompressionLevel(Zip4jConstants.DEFLATE_LEVEL_NORMAL);
			ZipFile zip = new ZipFile(zipFilePath);
			zip.setFileNameCharset(encoding);
			if (!SmartString.isNullOrEmpty(password)) {
				zip.setPassword(password);
			}
			zip.addFolder(new File(sourceDirectoryPath), parameters);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 压缩文件
	 * 
	 * @param sourceDirectoryPath
	 *            ，文件夹
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 * @param encoding
	 *            ，编码
	 */
	public static void compressDirectory(String sourceDirectoryPath,
			String zipFilePath, String encoding) {
		compressDirectory(sourceDirectoryPath, zipFilePath, encoding, null);
	}

	/**
	 * 压缩文件
	 * 
	 * @param sourceDirectoryPath
	 *            ，文件夹
	 * @param zipFilePath
	 *            ，压缩文件保存的路径
	 */
	public static void compressDirectory(String sourceDirectoryPath,
			String zipFilePath) {
		compressDirectory(sourceDirectoryPath, zipFilePath, null, null);
	}

	/**
	 * 解压文件
	 * 
	 * @param zipFilePath
	 *            ，压缩文件所在的路径
	 * @param sourceDirectoryPath
	 *            ，解压到的文件夹路径
	 * @param encoding
	 *            ，编码
	 * @param password
	 *            ，解压密码
	 */
	public static void decompress(String zipFilePath,
			String sourceDirectoryPath, String encoding, String password) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;

		sourceDirectoryPath = SmartDirectory
				.getFormatDirectoryPath(sourceDirectoryPath);

		try {
			ZipParameters parameters = new ZipParameters();
			parameters.setCompressionMethod(Zip4jConstants.COMP_DEFLATE);
			parameters.setCompressionLevel(Zip4jConstants.DEFLATE_LEVEL_NORMAL);
			ZipFile zip = new ZipFile(zipFilePath);
			zip.setFileNameCharset(encoding);
			if (!SmartString.isNullOrEmpty(password)) {
				zip.setPassword(password);
			}
			zip.extractAll(sourceDirectoryPath);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解压文件
	 * 
	 * @param zipFilePath
	 *            ，压缩文件所在的路径
	 * @param sourceDirectoryPath
	 *            ，解压到的文件夹路径
	 * @param encoding
	 *            ，编码
	 */
	public static void decompress(String zipFilePath,
			String sourceDirectoryPath, String encoding) {
		decompress(zipFilePath, sourceDirectoryPath, encoding, null);
	}

	/**
	 * 解压文件
	 * 
	 * @param zipFilePath
	 *            ，压缩文件所在的路径
	 * @param sourceDirectoryPath
	 *            ，解压到的文件夹路径
	 */
	public static void decompress(String zipFilePath, String sourceDirectoryPath) {
		decompress(zipFilePath, sourceDirectoryPath, null, null);
	}
}
