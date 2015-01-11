/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Smartkernel.Framework.Text;

namespace Smartkernel.Framework.Net
{
	/// <summary>
	/// Ftp客户端类
	/// </summary>
	public class SmartFtpClient
	{
		private readonly SmartFtpClientConfig ftpClientConfig;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="ftpClientConfig">配置实体</param>
		public SmartFtpClient(SmartFtpClientConfig ftpClientConfig)
		{
			this.ftpClientConfig = ftpClientConfig;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="host">Ftp服务器地址</param>
		/// <param name="username">用户名</param>
		/// <param name="password">密码</param>
		/// <param name="port">Ftp的端口号</param>
		public SmartFtpClient(string host, string username = null, string password = null, int port = 21)
		{
			ftpClientConfig = new SmartFtpClientConfig(host, username, password, port);
		}

		/// <summary>
		/// 上传文件到Ftp服务器的指定目录
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器的文件路径（注意，不能包含盘符部分）</param>
		/// <param name="localFilePath">本地文件路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		public void UploadFile(string ftpFilePath, string localFilePath, Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			var targetPath = new StringBuilder();
			targetPath.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			targetPath.Append(ftpFilePath.TrimStart('/'));

			var uri = new Uri(targetPath.ToString());

			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(uri);
			ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
			ftpWebRequest.UseBinary = useBinary;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}

			using (var ftpStream = ftpWebRequest.GetRequestStream())
			{
				using (var fileStream = new FileStream(localFilePath, FileMode.Open))
				{
					const int bufferSize = 2048 * 3;
					var length = fileStream.Length;
					var pos = 0;
					while (pos < length)
					{
						var buffer = new byte[bufferSize];
						var offSet = fileStream.Read(buffer, 0, bufferSize);
						ftpStream.Write(buffer, 0, offSet);
						pos += offSet;
					}
				}
			}
		}

		/// <summary>
		/// 获得Ftp服务器指定目录的文件列表
		/// </summary>
		/// <param name="ftpFolder">Ftp服务器目录</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		/// <returns>文件列表</returns>
		public List<string> GetFiles(string ftpFolder, Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;

			var list = new List<string>();
			var targetFolder = new StringBuilder();
			targetFolder.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			if (!string.IsNullOrEmpty(ftpFolder))
			{
				targetFolder.Append(ftpFolder.TrimStart('/').TrimEnd('/') + "/");
			}
			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFolder.ToString()));
			ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
			ftpWebRequest.UseBinary = useBinary;
			ftpWebRequest.KeepAlive = keepAlive;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}
			var filePaths = new StringBuilder();
			using (var webResponse = ftpWebRequest.GetResponse())
			{
				try
				{
					using (var streamReader = new StreamReader(webResponse.GetResponseStream(), encoding))
					{
						var line = streamReader.ReadLine();
						while (line != null)
						{
							filePaths.Append(line);
							filePaths.Append("\n");
							line = streamReader.ReadLine();
						}
					}
				}
				catch
				{
				}
			}
			if (filePaths.Length > 0)
			{
				filePaths.Remove(filePaths.ToString().LastIndexOf('\n'), 1);
				list.AddRange(filePaths.ToString().Split('\n'));
			}
			return list;
		}

		/// <summary>
		/// 判断指定目录中是否存在指定的文件，不区分大小写
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器文件路径</param>
		/// <param name="encoding">编码</param>
		/// <returns>是否存在</returns>
		public bool FileExists(string ftpFilePath, Encoding encoding = null)
		{
			var ftpFolder = Path.GetDirectoryName(ftpFilePath).Replace("\\", "/").Replace("//", "/");
			var targetFileName = Path.GetFileName(ftpFilePath);
			var list = GetFiles(ftpFolder, encoding);
			var linq = from file in list
			           where file.ToLower().Trim() == targetFileName.ToLower().Trim()
			           select file;
			return linq.Count() > 0;
		}

		/// <summary>
		/// 删除指定目录中的指定文件
		/// </summary>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		/// <param name="ftpFilePath">Ftp服务器文件路径</param>
		public void DeleteFile(string ftpFilePath, Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;

			if (FileExists(ftpFilePath))
			{
				var targetFilePath = new StringBuilder();
				targetFilePath.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
				targetFilePath.Append(ftpFilePath.TrimStart('/'));
				var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFilePath.ToString()));
				ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
				ftpWebRequest.UseBinary = useBinary;
				ftpWebRequest.KeepAlive = keepAlive;
				if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
				{
					ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
				}
				using (var ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
				{
					using (var datastream = ftpWebResponse.GetResponseStream())
					{
						using (var streamReader = new StreamReader(datastream, encoding))
						{
							streamReader.ReadToEnd();
						}
					}
				}
			}
		}

		/// <summary>
		/// 从指定Ftp服务器目录下载指定文件
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器的文件路径（注意，不能包含盘符部分）</param>
		/// <param name="localFilePath">本地文件路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		public void DownloadFile(string ftpFilePath, string localFilePath, Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			var targetFile = new StringBuilder();
			targetFile.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			targetFile.Append(ftpFilePath.TrimStart('/'));
			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFile.ToString()));
			ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
			ftpWebRequest.UseBinary = useBinary;
			ftpWebRequest.KeepAlive = keepAlive;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}
			using (var ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
			{
				using (var ftpStream = ftpWebResponse.GetResponseStream())
				{
					const int bufferSize = 2048;
					var buffer = new byte[bufferSize];
					var readCount = ftpStream.Read(buffer, 0, bufferSize);
					using (var outputStream = new FileStream(localFilePath, FileMode.Create))
					{
						while (readCount > 0)
						{
							outputStream.Write(buffer, 0, readCount);
							readCount = ftpStream.Read(buffer, 0, bufferSize);
						}
					}
				}
			}
		}

		/// <summary>
		/// 在Ftp服务器上创建目录
		/// </summary>
		/// <param name="ftpFolder">Ftp服务器目录</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		public void CreateDirectory(string ftpFolder,Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			var targetFolder = new StringBuilder();
			targetFolder.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			if (!string.IsNullOrEmpty(ftpFolder))
			{
				targetFolder.Append(ftpFolder.TrimStart('/') + "/");
			}
			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFolder.ToString()));
			ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
			ftpWebRequest.UseBinary = useBinary;
			ftpWebRequest.KeepAlive = keepAlive;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}
			using (ftpWebRequest.GetResponse())
			{
			}
		}

		/// <summary>
		/// 在Ftp服务器上删除目录
		/// </summary>
		/// <param name="ftpFolder">Ftp服务器目录</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		public void DeleteDirectory(string ftpFolder,Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			var targetFolder = new StringBuilder();
			targetFolder.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			if (!string.IsNullOrEmpty(ftpFolder))
			{
				targetFolder.Append(ftpFolder.TrimStart('/') + "/");
			}
			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFolder.ToString()));
			ftpWebRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
			ftpWebRequest.UseBinary = useBinary;
			ftpWebRequest.KeepAlive = keepAlive;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}
			using (ftpWebRequest.GetResponse())
			{
			}
		}

		/// <summary>
		/// 获得Ftp上指定文件的大小
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器上的文件路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		/// <returns>文件的大小</returns>
		public long GetFileSize(string ftpFilePath, Encoding encoding = null,bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			using (var ftpWebResponse = GetFtpWebResponse(ftpFilePath, WebRequestMethods.Ftp.GetFileSize, useBinary, keepAlive))
			{
				return ftpWebResponse.ContentLength;
			}
		}

		/// <summary>
		/// 修改制定文件的名称
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器上的文件路径</param>
		/// <param name="newFileName">新的文件名</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		public void Rename(string ftpFilePath,string newFileName, Encoding encoding = null, bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			var targetFolder = new StringBuilder();
			targetFolder.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			if (!string.IsNullOrEmpty(ftpFilePath))
			{
				targetFolder.Append(ftpFilePath.TrimStart('/').TrimEnd('/'));
			}
			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFolder.ToString()));
			ftpWebRequest.Method = WebRequestMethods.Ftp.Rename;
			ftpWebRequest.RenameTo = newFileName;
			ftpWebRequest.UseBinary = useBinary;
			ftpWebRequest.KeepAlive = keepAlive;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}
			using (ftpWebRequest.GetResponse())
			{
			}
		}

		/// <summary>
		/// 获得Ftp上指定文件的最后修改时间
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器上的文件路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		/// <returns>文件的最后修改时间</returns>
		public DateTime GetFileLastModifyTime(string ftpFilePath, Encoding encoding = null,bool useBinary = true, bool keepAlive = false)
		{
			encoding = encoding ?? SmartEncoding.Default;
			
			using (var ftpWebResponse = GetFtpWebResponse(ftpFilePath, WebRequestMethods.Ftp.GetDateTimestamp, useBinary, keepAlive))
			{
				return ftpWebResponse.LastModified;
			}
		}

		/// <summary>
		/// 获得Ftp的请求对象
		/// </summary>
		/// <param name="ftpFilePath">Ftp服务器上的文件路径</param>
		/// <param name="webRequestMethods">Ftp的请求方法</param>
		/// <param name="useBinary">是否使用二进制格式</param>
		/// <param name="keepAlive">是否保持活动</param>
		/// <returns>请求对象</returns>
		private FtpWebResponse GetFtpWebResponse(string ftpFilePath, string webRequestMethods, bool useBinary = true, bool keepAlive = false)
		{
			var targetFolder = new StringBuilder();
			targetFolder.AppendFormat("ftp://{0}:{1}/", ftpClientConfig.Host.Replace("ftp://", ""), ftpClientConfig.Port);
			if (!string.IsNullOrEmpty(ftpFilePath))
			{
				targetFolder.Append(ftpFilePath.TrimStart('/').TrimEnd('/'));
			}
			var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(targetFolder.ToString()));
			ftpWebRequest.Method = webRequestMethods;
			ftpWebRequest.UseBinary = useBinary;
			ftpWebRequest.KeepAlive = keepAlive;
			if (!string.IsNullOrEmpty(ftpClientConfig.Username) && !string.IsNullOrEmpty(ftpClientConfig.Password))
			{
				ftpWebRequest.Credentials = new NetworkCredential(ftpClientConfig.Username, ftpClientConfig.Password);
			}
			var webResponse = ftpWebRequest.GetResponse();
			return ((FtpWebResponse)webResponse);
		}
	}
}