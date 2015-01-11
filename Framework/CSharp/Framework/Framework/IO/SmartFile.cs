/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using Smartkernel.Framework.Text;
using Smartkernel.Framework.Computer;

namespace Smartkernel.Framework.IO
{
	/// <summary>
	/// 文件
	/// </summary>
	public static class SmartFile
	{
		/// <summary>
		/// 获得格式化的文件路径（格式化为符合操作系统的分隔符号）
		/// </summary>
		/// <param name="filePath">文件的路径</param>
		/// <returns>结果</returns>
		public static String GetFormatFilePath(String filePath)
		{
			filePath = filePath.Replace("\\", SmartComputer.DirectorySeparator);
			filePath = filePath.Replace("/", SmartComputer.DirectorySeparator);
			filePath = filePath.Replace(SmartComputer.DirectorySeparator + SmartComputer.DirectorySeparator, SmartComputer.DirectorySeparator);
			return filePath;
		}

		/// <summary>
		/// 写入日志
		/// </summary>
		/// <param name="filePath">文件路径，文件不存在时会自动创建，存在时则追加信息</param>
		/// <param name="message">写入内容</param>
		/// <param name="isNewline">是否自动换行</param>
		/// <param name="encoding">编码方式</param>
		public static void Write(string filePath, string message, bool isNewline = true, Encoding encoding = null)
		{
			filePath = GetFormatFilePath(filePath);
			encoding = encoding ?? SmartEncoding.Default;

			try {
				Directory.CreateDirectory(Path.GetDirectoryName(filePath));
			} catch {
			}

			using (var streamWriter = new StreamWriter(filePath, true, encoding)) {
				if (isNewline) {
					streamWriter.WriteLine(message);
				} else {
					streamWriter.Write(message);
				}
				streamWriter.Flush();
			}
		}

		/// <summary>
		/// 获得读取流
		/// </summary>
		/// <param name="path">路径</param>
		/// <param name="fileType">文件类型</param>
		/// <param name="fileEncoding">文件编码</param>
		/// <returns>结果</returns>
		public static StreamReader GetStreamReader(string path, SmartFileType fileType = SmartFileType.Text, Encoding fileEncoding = null)
		{
			path = GetFormatFilePath(path);
			if (fileEncoding == null) {
				fileEncoding = SmartEncoding.Default;
			}
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			if (fileType == SmartFileType.GZip) {
				GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);
				return new StreamReader(gzipStream, fileEncoding);
			} else {
				return new StreamReader(fileStream, fileEncoding);
			}
		}

		/// <summary>
		/// 获得输出流
		/// </summary>
		/// <param name="path">路径</param>
		/// <param name="fileType">文件类型</param>
		/// <param name="fileEncoding">文件编码</param>
		/// <param name="fileMode">文件模式</param>
		/// <param name="fileAccess">文件控制</param>
		/// <returns>结果</returns>
		public static StreamWriter GetStreamWriter(string path, SmartFileType fileType = SmartFileType.Text, Encoding fileEncoding = null, FileMode fileMode = FileMode.Append, FileAccess fileAccess = FileAccess.Write)
		{
			path = GetFormatFilePath(path);
			if (fileEncoding == null) {
				fileEncoding = SmartEncoding.Default;
			}
			FileStream fileStream = new FileStream(path, fileMode, fileAccess);
			if (fileType == SmartFileType.GZip) {
				GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Compress);
				return new StreamWriter(gzipStream, fileEncoding);
			} else {
				return new StreamWriter(fileStream, fileEncoding);
			}
		}

		/// <summary>
		/// 拆分文件
		/// </summary>
		/// <param name="filePath">源文件路径</param>
		/// <param name="splitFilePath">目标文件路径</param>
		/// <param name="quantity">数量</param>
		/// <param name="postfix">拆分的文件后缀</param>
		public static void Split(string filePath, string splitFilePath, int quantity = 10, string postfix = ".split")
		{
			filePath = GetFormatFilePath(filePath);
			splitFilePath = SmartDirectory.GetFormatDirectoryPath(splitFilePath);
			var fileName = Path.GetFileNameWithoutExtension(filePath);

			using (var sourceFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
				var fileSize = Convert.ToInt64(Math.Ceiling(Convert.ToDouble(sourceFileStream.Length) / Convert.ToDouble(quantity)));
				for (var i = 0; i < quantity; i++) {
					var name = i.ToString(SmartString.Repeat("0", quantity.ToString().Length));
					using (var targetFileStream = new FileStream((string.Format(@"{0}{1}_{2}{3}", splitFilePath, fileName, name, postfix)), FileMode.OpenOrCreate, FileAccess.Write)) {
						long count = 0;
						var buffer = new byte[fileSize];
						count = sourceFileStream.Read(buffer, 0, Convert.ToInt32(fileSize));
						if (count > 0) {
							targetFileStream.Write(buffer, 0, Convert.ToInt32(count));
						}
					}
				}
			}
		}

		/// <summary>
		/// 合并文件
		/// </summary>
		/// <param name="directoryPath">拆分文件所在文件夹</param>
		/// <param name="uniteFilePath">合并文件路径</param>
		public static void Unite(string directoryPath, string uniteFilePath)
		{
			directoryPath = SmartDirectory.GetFormatDirectoryPath(directoryPath);
			uniteFilePath = GetFormatFilePath(uniteFilePath);
			var splitFilePaths = Directory.GetFiles(directoryPath, "*");

			using (var targetFileStream = new FileStream(uniteFilePath, FileMode.OpenOrCreate, FileAccess.Write)) {
				var linq = from filePath in splitFilePaths
				                       orderby filePath ascending
				                       select filePath;
				linq.ToList().ForEach(filePath => {
					using (var sourceFileStream = new FileStream((filePath), FileMode.Open, FileAccess.Read)) {
						long count;
						var buffer = new byte[1024];
						while ((count = sourceFileStream.Read(buffer, 0, 1024)) > 0) {
							targetFileStream.Write(buffer, 0, Convert.ToInt32(count));
						}
					}
				});
			}
		}

		/// <summary>
		/// 在一个文件夹内递归查找文件，判断文件是否存在
		/// </summary>
		/// <param name="fileName">待查找的文件名，必须有扩展名</param>
		/// <param name="directoryPath">查找范围的文件夹</param>
		/// <param name="filePathList">找到的文件的路径</param>
		/// <param name="searchOption">搜索的范围，是不是包含子目录</param>
		/// <returns>是否存在</returns>
		public static bool Exists(string fileName, string directoryPath, out List<string> filePathList, SearchOption searchOption = SearchOption.AllDirectories)
		{
			directoryPath = SmartDirectory.GetFormatDirectoryPath(directoryPath);
			filePathList = new List<string>(Directory.GetFiles(directoryPath, fileName, searchOption));
			return filePathList.Count > 0;
		}

		/// <summary>
		/// 通过文件的字节数获得文件的易理解大小，如1.5GB
		/// </summary>
		/// <param name="fileSize">字节大小</param>
		/// <param name="rounded">是否取整</param>
		/// <returns>文件大小的易理解形式</returns>
		public static string FormatSize(long fileSize, bool rounded = false)
		{
			const double kb = 1024.0;
			const double mb = 1048576.0;
			const double gb = 1000000000.0;
			const double tb = 1000000000000.0;
			double dValue;
			string result;

			var format = rounded ? "{0:0}" : "{0:0.##}";

			if (fileSize >= kb && fileSize <= mb) {
				dValue = (fileSize / kb);
				result = string.Format("{0} KBs", String.Format(format, dValue));
			} else if (fileSize >= mb && fileSize <= gb) {
				dValue = (fileSize / mb);
				result = string.Format("{0} MBs", String.Format(format, dValue));
			} else if (fileSize >= gb && fileSize <= tb) {
				dValue = (fileSize / gb);
				result = string.Format("{0} GBs", String.Format(format, dValue));
			} else if (fileSize >= tb) {
				dValue = (fileSize / tb);
				result = string.Format("{0} TBs", String.Format(format, dValue));
			} else {
				result = string.Format("{0} bytes", fileSize);
			}
			return result;
		}

		/// <summary>
		/// 修改文件名称
		/// </summary>
		/// <param name="filePath">文件路径</param>
		/// <param name="newName">新的文件名</param>
		/// <param name="overWriteFile">是否覆盖文件</param>
		public static void ChangeName(string filePath, string newName, bool overWriteFile = true)
		{
			filePath = GetFormatFilePath(filePath);
			File.Move(filePath, SmartDirectory.GetFormatDirectoryPath(Path.GetDirectoryName(filePath)) + newName);
		}
        
		/// <summary>
		/// 将对象转成二进制文件存储到对应的目录
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="path">文件地址</param>
		/// <param name="fileType">文件类型</param>
		/// <param name="fileMode">打开文件方式</param>
		/// <param name="fileAccess">文件访问方式</param>
		public static void BinaryWrite(object obj, string path, SmartFileType fileType = SmartFileType.Text, FileMode fileMode = FileMode.OpenOrCreate, FileAccess fileAccess = FileAccess.Write)
		{
			path = GetFormatFilePath(path);
			using (FileStream fileStream = new FileStream(path, fileMode, fileAccess)) {
				BinaryFormatter formatter = new BinaryFormatter();

				if (fileType == SmartFileType.Text) {
					formatter.Serialize(fileStream, obj);
				} else {
					using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Compress)) {
						formatter.Serialize(gzipStream, obj);
					}
				}

			}
		}

		/// <summary>
		/// 将二进制文件转成对象并返回
		/// </summary>
		/// <typeparam name="T">返回类型</typeparam>
		/// <param name="path">文件地址</param>
		/// <param name="fileType">文件类型</param>
		/// <param name="fileMode">打开文件方式</param>
		/// <param name="fileAccess">文件访问方式</param>
		/// <returns>对象</returns>
		public static T BinaryRead<T>(string path, SmartFileType fileType = SmartFileType.Text, FileMode fileMode = FileMode.Open, FileAccess fileAccess = FileAccess.Read)
		{
			path = GetFormatFilePath(path);
			if (!File.Exists(path)) {
				return default(T);
			}
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fileStream = new FileStream(path, fileMode, fileAccess)) {
				if (fileType == SmartFileType.Text) {
					return (T)formatter.Deserialize(fileStream);
				} else {
					using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress)) {
						return (T)formatter.Deserialize(gzipStream);
					}
				}

			}
		}
	}
}
