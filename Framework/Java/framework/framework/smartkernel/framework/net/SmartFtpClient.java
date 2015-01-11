/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.io.*;
import java.util.*;

import org.apache.commons.net.ftp.*;

import smartkernel.framework.*;
import smartkernel.framework.io.*;
import smartkernel.framework.text.*;

/**
 * Ftp客户端类
 *
 */
public class SmartFtpClient {
	private SmartFtpClientConfig ftpClientConfig;

	/**
	 * 构造函数
	 * 
	 * @param ftpClientConfig
	 *            ，配置实体
	 */
	public SmartFtpClient(SmartFtpClientConfig ftpClientConfig) {
		this.ftpClientConfig = ftpClientConfig;
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 * @param username
	 *            ，用户名
	 * @param password
	 *            ，密码
	 * @param port
	 *            ，Ftp的端口号
	 */
	public SmartFtpClient(String host, String username, String password,
			int port) {
		this.ftpClientConfig = new SmartFtpClientConfig(host, username,
				password, port);
	}
	
	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 * @param username
	 *            ，用户名
	 * @param password
	 *            ，密码
	 */
	public SmartFtpClient(String host, String username, String password) {
		this(host, username, password, 21);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 * @param username
	 *            ，用户名
	 */
	public SmartFtpClient(String host, String username) {
		this(host, username, null, 21);
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，Ftp服务器地址
	 */
	public SmartFtpClient(String host) {
		this(host, null, null, 21);
	}

	/**
	 * 上传文件到Ftp服务器的指定目录
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 */
	public void uploadFile(String ftpFilePath, String localFilePath,
			String encoding, boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);
			try (FileInputStream fileInputStream = new FileInputStream(
					localFilePath)) {
				ftp.storeFile(ftpFilePath, fileInputStream);
			}
			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 上传文件到Ftp服务器的指定目录
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 */
	public void uploadFile(String ftpFilePath, String localFilePath,
			String encoding, boolean useBinary) {
		uploadFile(ftpFilePath, localFilePath, encoding, useBinary, false);
	}

	/**
	 * 上传文件到Ftp服务器的指定目录
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 * @param encoding
	 *            ，编码
	 */
	public void uploadFile(String ftpFilePath, String localFilePath,
			String encoding) {
		uploadFile(ftpFilePath, localFilePath, encoding, true, false);
	}

	/**
	 * 上传文件到Ftp服务器的指定目录
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 */
	public void uploadFile(String ftpFilePath, String localFilePath) {
		uploadFile(ftpFilePath, localFilePath, null, true, false);
	}

	/**
	 * 获得Ftp服务器指定目录的文件列表
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 * @return，文件列表
	 */
	public ArrayList<String> getFiles(String ftpFolder, String encoding,
			boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		ArrayList<String> result = new ArrayList<String>();
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);
			FTPFile[] files = ftp.listFiles(ftpFolder);

			for (FTPFile file : files) {
				result.add(file.getName());
			}

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}

		return result;
	}

	/**
	 * 获得Ftp服务器指定目录的文件列表
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @return，文件列表
	 */
	public ArrayList<String> getFiles(String ftpFolder, String encoding,
			boolean useBinary) {
		return getFiles(ftpFolder, encoding, useBinary, false);
	}

	/**
	 * 获得Ftp服务器指定目录的文件列表
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @return，文件列表
	 */
	public ArrayList<String> getFiles(String ftpFolder, String encoding) {
		return getFiles(ftpFolder, encoding, true, false);
	}

	/**
	 * 获得Ftp服务器指定目录的文件列表
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @return，文件列表
	 */
	public ArrayList<String> getFiles(String ftpFolder) {
		return getFiles(ftpFolder, null, true, false);
	}

	/**
	 * 判断指定目录中是否存在指定的文件，不区分大小写
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器文件路径
	 * @param encoding
	 *            ，编码
	 * @return，是否存在
	 */
	public boolean fileExists(String ftpFilePath, String encoding) {
		String ftpFolder = SmartPath.getDirectoryName(ftpFilePath)
				.replace("\\", "/").replace("//", "/");

		String targetFileName = SmartPath.getFileName(ftpFilePath);
		ArrayList<String> files = getFiles(ftpFolder, encoding);

		for (String file : files) {
			if (file.toLowerCase().trim()
					.equals(targetFileName.toLowerCase().trim())) {
				return true;
			}
		}

		return false;
	}

	/**
	 * 判断指定目录中是否存在指定的文件，不区分大小写
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器文件路径
	 * @return，是否存在
	 */
	public boolean fileExists(String ftpFilePath) {
		return fileExists(ftpFilePath, null);
	}

	/**
	 * 删除指定目录中的指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 */
	public void deleteFile(String ftpFilePath, String encoding,
			boolean useBinary, boolean keepAlive) {
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			ftp.deleteFile(ftpFilePath);

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 删除指定目录中的指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 */
	public void deleteFile(String ftpFilePath, String encoding,
			boolean useBinary) {
		deleteFile(ftpFilePath, encoding, useBinary, false);
	}

	/**
	 * 删除指定目录中的指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器文件路径
	 * @param encoding
	 *            ，编码
	 */
	public void deleteFile(String ftpFilePath, String encoding) {
		deleteFile(ftpFilePath, encoding, true, false);
	}

	/**
	 * 删除指定目录中的指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器文件路径
	 */
	public void deleteFile(String ftpFilePath) {
		deleteFile(ftpFilePath, null, true, false);
	}

	/**
	 * 从指定Ftp服务器目录下载指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 */
	public void downloadFile(String ftpFilePath, String localFilePath,
			String encoding, boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			try (FileOutputStream fileOutputStream = new FileOutputStream(
					localFilePath)) {
				ftp.retrieveFile(ftpFilePath, fileOutputStream);
			}
			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 从指定Ftp服务器目录下载指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 */
	public void downloadFile(String ftpFilePath, String localFilePath,
			String encoding, boolean useBinary) {
		downloadFile(ftpFilePath, localFilePath, encoding, useBinary, false);
	}

	/**
	 * 从指定Ftp服务器目录下载指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 * @param encoding
	 *            ，编码
	 */
	public void downloadFile(String ftpFilePath, String localFilePath,
			String encoding) {
		downloadFile(ftpFilePath, localFilePath, encoding, true, false);
	}

	/**
	 * 从指定Ftp服务器目录下载指定文件
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param localFilePath
	 *            ，本地文件路径
	 */
	public void downloadFile(String ftpFilePath, String localFilePath) {
		downloadFile(ftpFilePath, localFilePath, null, true, false);
	}

	/**
	 * 在Ftp服务器上创建目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 */
	public void createDirectory(String ftpFolder, String encoding,
			boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			ftp.mkd(ftpFolder);

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 在Ftp服务器上创建目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 */
	public void createDirectory(String ftpFolder, String encoding,
			boolean useBinary) {
		createDirectory(ftpFolder, encoding, useBinary, false);
	}

	/**
	 * 在Ftp服务器上创建目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 */
	public void createDirectory(String ftpFolder, String encoding) {
		createDirectory(ftpFolder, encoding, true, false);
	}

	/**
	 * 在Ftp服务器上创建目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 */
	public void createDirectory(String ftpFolder) {
		createDirectory(ftpFolder, null, true, false);
	}

	/**
	 * 在Ftp服务器上删除目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 */
	public void deleteDirectory(String ftpFolder, String encoding,
			boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			ftp.removeDirectory(ftpFolder);

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 在Ftp服务器上删除目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 */
	public void deleteDirectory(String ftpFolder, String encoding,
			boolean useBinary) {
		deleteDirectory(ftpFolder, encoding, useBinary, false);
	}

	/**
	 * 在Ftp服务器上删除目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 * @param encoding
	 *            ，编码
	 */
	public void deleteDirectory(String ftpFolder, String encoding) {
		deleteDirectory(ftpFolder, encoding, true, false);
	}

	/**
	 * 在Ftp服务器上删除目录
	 * 
	 * @param ftpFolder
	 *            ，Ftp服务器目录
	 */
	public void deleteDirectory(String ftpFolder) {
		deleteDirectory(ftpFolder, null, true, false);
	}

	/**
	 * 获得Ftp上指定文件的大小
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 * @return，文件的大小
	 */
	public long getFileSize(String ftpFilePath, String encoding,
			boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			FTPFile[] files = ftp.listFiles(SmartPath
					.getDirectoryName(ftpFilePath));

			for (FTPFile file : files) {
				if (ftpFilePath.toLowerCase().trim()
						.endsWith(file.getName().toLowerCase().trim())) {
					return file.getSize();
				}
			}

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();

			return -1;

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得Ftp上指定文件的大小
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @return，文件的大小
	 */
	public long getFileSize(String ftpFilePath, String encoding,
			boolean useBinary) {
		return getFileSize(ftpFilePath, encoding, useBinary, false);
	}

	/**
	 * 获得Ftp上指定文件的大小
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @param encoding
	 *            ，编码
	 * @return，文件的大小
	 */
	public long getFileSize(String ftpFilePath, String encoding) {
		return getFileSize(ftpFilePath, encoding, true, false);
	}

	/**
	 * 获得Ftp上指定文件的大小
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @return，文件的大小
	 */
	public long getFileSize(String ftpFilePath) {
		return getFileSize(ftpFilePath, null, true, false);
	}

	/**
	 * 获得Ftp上指定文件的最后修改时间
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 * @return，文件的最后修改时间
	 */
	public Date getLastModifyTime(String ftpFilePath, String encoding,
			boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			FTPFile[] files = ftp.listFiles(SmartPath
					.getDirectoryName(ftpFilePath));

			for (FTPFile file : files) {
				if (ftpFilePath.toLowerCase().trim()
						.endsWith(file.getName().toLowerCase().trim())) {
					return file.getTimestamp().getTime();
				}
			}

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();

			return null;

		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得Ftp上指定文件的最后修改时间
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @return，文件的最后修改时间
	 */
	public Date getLastModifyTime(String ftpFilePath, String encoding,
			boolean useBinary) {
		return getLastModifyTime(ftpFilePath, encoding, useBinary, false);
	}

	/**
	 * 获得Ftp上指定文件的最后修改时间
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @param encoding
	 *            ，编码
	 * @return，文件的最后修改时间
	 */
	public Date getLastModifyTime(String ftpFilePath, String encoding) {
		return getLastModifyTime(ftpFilePath, encoding, true, false);
	}

	/**
	 * 获得Ftp上指定文件的最后修改时间
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器上的文件路径
	 * @return，文件的最后修改时间
	 */
	public Date getLastModifyTime(String ftpFilePath) {
		return getLastModifyTime(ftpFilePath, null, true, false);
	}

	/**
	 * 修改制定文件的名称
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param newFileName
	 *            ，新文件名
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 */
	public void rename(String ftpFilePath, String newFileName, String encoding,
			boolean useBinary, boolean keepAlive) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;
		try {
			FTPClient ftp = getFTPClient(encoding, useBinary, keepAlive);

			ftp.rename(ftpFilePath, newFileName);

			int replyCode = ftp.getReplyCode();
			if (replyCode > 299 || replyCode < 200) {
				throw new RuntimeException(ftp.getReplyString());
			}
			ftp.logout();
			ftp.disconnect();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 修改制定文件的名称
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param newFileName
	 *            ，新文件名
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 */
	public void rename(String ftpFilePath, String newFileName, String encoding,
			boolean useBinary) {
		rename(ftpFilePath, newFileName, encoding, useBinary, false);
	}

	/**
	 * 修改制定文件的名称
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param newFileName
	 *            ，新文件名
	 * @param encoding
	 *            ，编码
	 */
	public void rename(String ftpFilePath, String newFileName, String encoding) {
		rename(ftpFilePath, newFileName, encoding, true, false);
	}

	/**
	 * 修改制定文件的名称
	 * 
	 * @param ftpFilePath
	 *            ，Ftp服务器的文件路径（注意，不能包含盘符部分）
	 * @param newFileName
	 *            ，新文件名
	 */
	public void rename(String ftpFilePath, String newFileName) {
		rename(ftpFilePath, newFileName, null, true, false);
	}

	/**
	 * 获得Ftp的请求对象
	 * 
	 * @param encoding
	 *            ，编码
	 * @param useBinary
	 *            ，是否使用二进制格式
	 * @param keepAlive
	 *            ，是否保持活动
	 * @return，请求对象
	 */
	private FTPClient getFTPClient(String encoding, boolean useBinary,
			boolean keepAlive) {
		try {
			FTPClient ftp = new FTPClient();
			ftp.setAutodetectUTF8(true);
			ftp.setControlEncoding(encoding);
			ftp.connect(this.ftpClientConfig.getHost(),
					this.ftpClientConfig.getPort());
			if (!SmartString.isNullOrEmpty(ftpClientConfig.getUsername())
					&& !SmartString
							.isNullOrEmpty(ftpClientConfig.getPassword())) {
				ftp.login(this.ftpClientConfig.getUsername(),
						this.ftpClientConfig.getPassword());
			}
			if (useBinary) {
				ftp.setFileType(FTP.BINARY_FILE_TYPE);
				ftp.setFileTransferMode(FTP.BINARY_FILE_TYPE);
				ftp.enterLocalPassiveMode();
			}
			ftp.setKeepAlive(keepAlive);

			return ftp;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
