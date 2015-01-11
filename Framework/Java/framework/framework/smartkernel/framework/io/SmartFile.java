/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.*;
import java.nio.file.*;
import java.util.*;
import java.util.zip.*;

import smartkernel.framework.*;
import smartkernel.framework.computer.*;
import smartkernel.framework.text.*;

/**
 * 文件
 * 
 */
public class SmartFile {
	/**
	 * 读取全部文本
	 * 
	 * @param path
	 *            ，路径
	 * @return，结果
	 */
	public static String readAllText(String path) {
		StringBuilder result = new StringBuilder();
		try (BufferedReader bufferedReader = getStreamReader(path)) {
			String line = null;
			while ((line = bufferedReader.readLine()) != null) {
				result.append(line + SmartComputer.LineSeparator);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
		return result.toString();
	}

	/**
	 * 获得格式化的文件路径（格式化为符合操作系统的分隔符号）
	 * 
	 * @param filePath
	 *            ，文件的路径
	 * @return，结果
	 */
	public static String getFormatFilePath(String filePath) {
		filePath = filePath.replace("\\", SmartComputer.DirectorySeparator);
		filePath = filePath.replace("/", SmartComputer.DirectorySeparator);
		filePath = filePath.replace(SmartComputer.DirectorySeparator
				+ SmartComputer.DirectorySeparator,
				SmartComputer.DirectorySeparator);
		return filePath;
	}

	/**
	 * 判断文件是否存在
	 * 
	 * @param path
	 *            ，路径
	 * @return，结果
	 */
	public static boolean exists(String path) {
		path = getFormatFilePath(path);
		return new File(path).exists();
	}

	/**
	 * 删除文件
	 * 
	 * @param path
	 *            ，路径
	 */
	public static void delete(String path) {
		new File(path).delete();
	}

	/**
	 * 复制文件
	 * 
	 * @param sourceFilePath
	 *            ，源文件
	 * @param targetFilePath
	 *            ，目标文件
	 * @param overwrite
	 *            ，是否覆盖
	 */
	public static void copy(String sourceFilePath, String targetFilePath,
			boolean overwrite) {
		sourceFilePath = getFormatFilePath(sourceFilePath);
		targetFilePath = getFormatFilePath(targetFilePath);
		File targetFile = new File(targetFilePath);

		File directory = targetFile.getParentFile();

		if (!directory.exists()) {
			directory.mkdirs();
		}

		if (!exists(sourceFilePath)) {
			return;
		}
		if (targetFile.exists() && overwrite) {
			targetFile.delete();
		}
		if (!targetFile.exists()) {
			try {
				Files.copy(new File(sourceFilePath).toPath(),
						targetFile.toPath(),
						StandardCopyOption.REPLACE_EXISTING);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 复制文件
	 * 
	 * @param sourceFilePath
	 *            ，源文件
	 * @param targetFilePath
	 *            ，目标文件
	 */
	public static void copy(String sourceFilePath, String targetFilePath) {
		copy(sourceFilePath, targetFilePath, true);
	}

	/**
	 * 写入日志
	 * 
	 * @param filePath
	 *            ，文件路径，文件不存在时会自动创建，存在时则追加信息
	 * @param message
	 *            ，写入内容
	 * @param isNewline
	 *            ，是否自动换行
	 * @param encoding
	 *            ，编码方式
	 */
	public static void write(String filePath, String message,
			boolean isNewline, String encoding) {
		filePath = getFormatFilePath(filePath);
		encoding = encoding == null ? SmartEncoding.Default : encoding;

		try {
			File directory = new File(filePath).getParentFile();
			if (!directory.exists()) {
				directory.mkdirs();
			}
		} catch (Exception err) {
		}

		try (OutputStream outputStream = new FileOutputStream(filePath, true);
				OutputStreamWriter streamWriter = new OutputStreamWriter(
						outputStream, encoding)) {
			if (isNewline) {
				streamWriter.write(message + SmartComputer.LineSeparator);
			} else {
				streamWriter.write(message);
			}
			streamWriter.flush();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 写入日志
	 * 
	 * @param filePath
	 *            ，文件路径，文件不存在时会自动创建，存在时则追加信息
	 * @param message
	 *            ，写入内容
	 * @param isNewline
	 *            ，是否自动换行
	 */
	public static void write(String filePath, String message, boolean isNewline) {
		write(filePath, message, isNewline, null);
	}

	/**
	 * 写入日志
	 * 
	 * @param filePath
	 *            ，文件路径，文件不存在时会自动创建，存在时则追加信息
	 * @param message
	 *            ，写入内容
	 */
	public static void write(String filePath, String message) {
		write(filePath, message, true, null);
	}

	/**
	 * 获得读取流
	 * 
	 * @param path
	 *            ，路径
	 * @param fileType
	 *            ，文件类型
	 * @param fileEncoding
	 *            ，文件编码
	 * @return，结果
	 */
	public static BufferedReader getStreamReader(String path,
			SmartFileType fileType, String fileEncoding) {
		path = getFormatFilePath(path);
		if (fileEncoding == null) {
			fileEncoding = SmartEncoding.Default;
		}
		try {
			InputStream inputStream = new FileInputStream(path);

			if (fileType == SmartFileType.GZip) {
				GZIPInputStream gzipInputStream = new GZIPInputStream(
						inputStream);
				InputStreamReader inputStreamReader = new InputStreamReader(
						gzipInputStream, fileEncoding);
				return new BufferedReader(inputStreamReader);
			} else {
				InputStreamReader inputStreamReader = new InputStreamReader(
						inputStream, fileEncoding);
				return new BufferedReader(inputStreamReader);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得读取流
	 * 
	 * @param path
	 *            ，路径
	 * @param fileType
	 *            ，文件类型
	 * @return，结果
	 */
	public static BufferedReader getStreamReader(String path,
			SmartFileType fileType) {
		return getStreamReader(path, fileType, null);
	}

	/**
	 * 获得读取流
	 * 
	 * @param path
	 *            ，路径
	 * @return，结果
	 */
	public static BufferedReader getStreamReader(String path) {
		return getStreamReader(path, SmartFileType.Text, null);
	}

	/**
	 * 获得写入流
	 * 
	 * @param path
	 *            ，路径
	 * @param fileType
	 *            ，文件类型
	 * @param fileEncoding
	 *            ，文件编码
	 * @return，结果
	 */
	public static BufferedWriter getStreamWriter(String path,
			SmartFileType fileType, String fileEncoding) {
		path = getFormatFilePath(path);
		if (fileEncoding == null) {
			fileEncoding = SmartEncoding.Default;
		}
		try {
			OutputStream outputStream = new FileOutputStream(path);

			if (fileType == SmartFileType.GZip) {
				GZIPOutputStream gzipOutputStream = new GZIPOutputStream(
						outputStream);
				OutputStreamWriter outputStreamWriter = new OutputStreamWriter(
						gzipOutputStream, fileEncoding);
				return new BufferedWriter(outputStreamWriter);
			} else {
				OutputStreamWriter outputStreamWriter = new OutputStreamWriter(
						outputStream, fileEncoding);
				return new BufferedWriter(outputStreamWriter);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得写入流
	 * 
	 * @param path
	 *            ，路径
	 * @param fileType
	 *            ，文件类型
	 * @return，结果
	 */
	public static BufferedWriter getStreamWriter(String path,
			SmartFileType fileType) {
		return getStreamWriter(path, fileType, null);
	}

	/**
	 * 获得写入流
	 * 
	 * @param path
	 *            ，路径
	 * @return，结果
	 */
	public static BufferedWriter getStreamWriter(String path) {
		return getStreamWriter(path, SmartFileType.Text, null);
	}

	/**
	 * 拆分文件
	 * 
	 * @param filePath
	 *            ，源文件路径
	 * @param splitFilePath
	 *            ，目标文件路径
	 * @param quantity
	 *            ，数量
	 * @param postfix
	 *            ，拆分的文件后缀
	 */
	public static void split(String filePath, String splitFilePath,
			int quantity, String postfix) {
		filePath = getFormatFilePath(filePath);
		splitFilePath = SmartDirectory.getFormatDirectoryPath(splitFilePath);
		String fileName = SmartPath.getFileNameWithoutExtension(filePath);

		try (FileInputStream sourceFileStream = new FileInputStream(filePath)) {
			int fileSize = (int) (Math.ceil((double) sourceFileStream
					.getChannel().size() / (double) quantity));
			for (int i = 0; i < quantity; i++) {
				String name = SmartNumeric.toString(i, SmartString.repeat("0",
						String.valueOf(quantity).length()));
				try (FileOutputStream targetFileStream = new FileOutputStream(
						(SmartString.format("{0}{1}_{2}{3}", splitFilePath,
								fileName, name, postfix)))) {
					int count = 0;
					byte[] buffer = new byte[fileSize];
					count = sourceFileStream.read(buffer, 0, fileSize);
					if (count > 0) {
						targetFileStream.write(buffer, 0, count);
					}
				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 拆分文件
	 * 
	 * @param filePath
	 *            ，源文件路径
	 * @param splitFilePath
	 *            ，目标文件路径
	 * @param quantity
	 *            ，数量
	 */
	public static void split(String filePath, String splitFilePath, int quantity) {
		split(filePath, splitFilePath, quantity, ".split");
	}

	/**
	 * 拆分文件
	 * 
	 * @param filePath
	 *            ，源文件路径
	 * @param splitFilePath
	 *            ，目标文件路径
	 */
	public static void split(String filePath, String splitFilePath) {
		split(filePath, splitFilePath, 10, ".split");
	}

	/**
	 * 合并文件
	 * 
	 * @param directoryPath
	 *            ，拆分文件所在文件夹
	 * @param uniteFilePath
	 *            ，合并文件路径
	 */
	public static void unite(String directoryPath, String uniteFilePath) {
		ArrayList<String> splitFilePaths = SmartDirectory
				.getFiles(directoryPath);
		uniteFilePath = getFormatFilePath(uniteFilePath);
		directoryPath = SmartDirectory.getFormatDirectoryPath(directoryPath);
		try (FileOutputStream targetFileStream = new FileOutputStream(
				uniteFilePath)) {
			Collections.sort(splitFilePaths);

			for (String filePath : splitFilePaths) {
				try (FileInputStream sourceFileStream = new FileInputStream(
						(filePath))) {
					int count;
					byte[] buffer = new byte[1024];
					while ((count = sourceFileStream.read(buffer, 0, 1024)) > 0) {
						targetFileStream.write(buffer, 0, count);
					}
				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 在一个文件夹内递归查找文件，判断文件是否存在
	 * 
	 * @param fileName
	 *            ，待查找的文件名，必须有扩展名
	 * @param directoryPath
	 *            ，查找范围的文件夹
	 * @param filePathList
	 *            ，找到的文件的路径
	 * @param searchOption
	 *            ，搜索的范围，是不是包含子目录
	 * @return，是否存在
	 */
	public static boolean exists(String fileName, String directoryPath,
			ArrayList<String> filePathList, SmartSearchOptionType searchOption) {
		directoryPath = SmartDirectory.getFormatDirectoryPath(directoryPath);
		ArrayList<String> files = SmartDirectory.getFiles(directoryPath,
				searchOption);

		for (String file : files) {
			String temp = SmartPath.getFileName(file);
			if (temp.toLowerCase().equals(fileName.toLowerCase())) {
				filePathList.add(file);
			}
		}

		return filePathList.size() > 0;
	}

	/**
	 * 在一个文件夹内递归查找文件，判断文件是否存在
	 * 
	 * @param fileName
	 *            ，待查找的文件名，必须有扩展名
	 * @param directoryPath
	 *            ，查找范围的文件夹
	 * @param filePathList
	 *            ，找到的文件的路径
	 * @return，是否存在
	 */
	public static boolean exists(String fileName, String directoryPath,
			ArrayList<String> filePathList) {
		return exists(fileName, directoryPath, filePathList,
				SmartSearchOptionType.AllDirectories);
	}

	/**
	 * 通过文件的字节数获得文件的易理解大小，如1.5GB
	 * 
	 * @param fileSize
	 *            ，字节大小
	 * @param rounded
	 *            ，是否取整
	 * @return，文件大小的易理解形式
	 */
	public static String formatSize(long fileSize, boolean rounded) {
		final double kb = 1024.0;
		final double mb = 1048576.0;
		final double gb = 1000000000.0;
		final double tb = 1000000000000.0;
		double dValue;
		String result;

		String format = rounded ? "0" : "0.##";

		if (fileSize >= kb && fileSize <= mb) {
			dValue = (fileSize / kb);
			result = SmartString.format("{0} KBs",
					SmartNumeric.toString(dValue, format));
		} else if (fileSize >= mb && fileSize <= gb) {
			dValue = (fileSize / mb);
			result = SmartString.format("{0} MBs",
					SmartNumeric.toString(dValue, format));
		} else if (fileSize >= gb && fileSize <= tb) {
			dValue = (fileSize / gb);
			result = SmartString.format("{0} GBs",
					SmartNumeric.toString(dValue, format));
		} else if (fileSize >= tb) {
			dValue = (fileSize / tb);
			result = SmartString.format("{0} TBs",
					SmartNumeric.toString(dValue, format));
		} else {
			result = SmartString.format("{0} bytes", fileSize);
		}
		return result;
	}

	/**
	 * 通过文件的字节数获得文件的易理解大小，如1.5GB
	 * 
	 * @param fileSize
	 *            ，字节大小
	 * @return，文件大小的易理解形式
	 */
	public static String formatSize(long fileSize) {
		return formatSize(fileSize, false);
	}

	/**
	 * 修改文件名称
	 * 
	 * @param filePath
	 *            ，文件路径
	 * @param newName
	 *            ，新的文件名
	 * @param overWriteFile
	 *            ，是否覆盖文件
	 */
	public static void changeName(String filePath, String newName,
			boolean overWriteFile) {
		filePath = getFormatFilePath(filePath);
		File file = new File(filePath);
		File targetFile = new File(SmartDirectory.getFormatDirectoryPath(file
				.getParent()) + newName);
		try {
			if (targetFile.exists() && overWriteFile) {
				targetFile.delete();
			}
			Files.move(file.toPath(), targetFile.toPath(),
					StandardCopyOption.REPLACE_EXISTING);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 修改文件名称
	 * 
	 * @param filePath
	 *            ，文件路径
	 * @param newName
	 *            ，新的文件名
	 */
	public static void changeName(String filePath, String newName) {
		changeName(filePath, newName, true);
	}

	/**
	 * 将对象转成二进制文件存储到对应的目录
	 * 
	 * @param obj
	 *            ，对象
	 * @param path
	 *            ，文件地址
	 * @param fileType
	 *            ，文件类型
	 */
	public static void binaryWrite(Object obj, String path,
			SmartFileType fileType) {
		try (FileOutputStream fileStream = new FileOutputStream(path)) {
			if (fileType == SmartFileType.Text) {
				try (ObjectOutputStream objectOutputStream = new ObjectOutputStream(
						fileStream)) {
					objectOutputStream.writeObject(obj);
				}
			} else {
				try (GZIPOutputStream gzipOutputStream = new GZIPOutputStream(
						fileStream);
						ObjectOutputStream objectOutputStream = new ObjectOutputStream(
								gzipOutputStream)) {
					objectOutputStream.writeObject(obj);
				}
			}

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 将对象转成二进制文件存储到对应的目录
	 * 
	 * @param obj
	 *            ，对象
	 * @param path
	 *            ，文件地址
	 */
	public static void binaryWrite(Object obj, String path) {
		binaryWrite(obj, path, SmartFileType.Text);
	}

	/**
	 * 将二进制文件转成对象并返回
	 * 
	 * @param path
	 *            ，文件地址
	 * @param fileType
	 *            ，文件类型
	 */
	@SuppressWarnings("unchecked")
	public static <T> T binaryRead(String path, SmartFileType fileType) {
		try (FileInputStream fileStream = new FileInputStream(path)) {
			if (fileType == SmartFileType.Text) {
				try (ObjectInputStream objectInputStream = new ObjectInputStream(
						fileStream)) {
					return (T) objectInputStream.readObject();
				}
			} else {
				try (GZIPInputStream gzipInputStream = new GZIPInputStream(
						fileStream);
						ObjectInputStream objectInputStream = new ObjectInputStream(
								gzipInputStream)) {
					return (T) objectInputStream.readObject();
				}
			}

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 将二进制文件转成对象并返回
	 * 
	 * @param path
	 *            ，文件地址
	 */
	public static <T> T binaryRead(String path) {
		return binaryRead(path, SmartFileType.Text);
	}
}
