/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;
using System.Text;
using Ionic.Zip;
using Smartkernel.Framework.Text;

namespace Smartkernel.Framework.IO
{
	/// <summary>
	/// Zip文件的格式的压缩解压处理（只能处理zip格式，rar格式无法处理）
	/// </summary>
	public class SmartZip
	{
		/// <summary>
		/// 压缩文件列表
		/// </summary>
		/// <param name="sourceFilePaths">文件列表</param>
		/// <param name="zipFilePath">压缩文件保存的路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="password">解压密码</param>
		/// <param name="rootPath">压缩的根目录</param>
		public static void CompressFiles(IEnumerable<string> sourceFilePaths, string zipFilePath, Encoding encoding = null, string password = null, string rootPath = @"/")
		{
			encoding = encoding ?? SmartEncoding.Default;
			zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
			using (var zip = new ZipFile(encoding)) {
				if (!string.IsNullOrEmpty(password)) {
					zip.Password = password;
				}
				zip.AddFiles(sourceFilePaths, rootPath);
				zip.Save(zipFilePath);
			}
		}

		/// <summary>
		/// 压缩文件列表
		/// </summary>
		/// <param name="sourceFilePath">文件</param>
		/// <param name="zipFilePath">压缩文件保存的路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="password">解压密码</param>
		/// <param name="rootPath">压缩的根目录</param>
		public static void CompressFile(string sourceFilePath, string zipFilePath, Encoding encoding = null, string password = null, string rootPath = @"/")
		{
			encoding = encoding ?? SmartEncoding.Default;
			sourceFilePath = SmartFile.GetFormatFilePath(sourceFilePath);
			zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
			using (var zip = new ZipFile(encoding)) {
				if (!string.IsNullOrEmpty(password)) {
					zip.Password = password;
				}
				zip.AddFile(sourceFilePath, rootPath);
				zip.Save(zipFilePath);
			}
		}

		/// <summary>
		/// 压缩文件夹列表
		/// </summary>
		/// <param name="sourceDirectoryPaths">文件夹列表</param>
		/// <param name="zipFilePath">压缩文件保存的路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="password">解压密码</param>
		/// <param name="rootPath">压缩的根目录</param>
		public static void CompressDirectories(IEnumerable<string> sourceDirectoryPaths, string zipFilePath, Encoding encoding = null, string password = null, string rootPath = @"/")
		{
			encoding = encoding ?? SmartEncoding.Default;
			using (var zip = new ZipFile(encoding)) {
				if (!string.IsNullOrEmpty(password)) {
					zip.Password = password;
				}
				var enumerator = sourceDirectoryPaths.GetEnumerator();
				while (enumerator.MoveNext()) {
					zip.AddDirectory(enumerator.Current, rootPath);
				}
				zip.Save(zipFilePath);
			}
		}

		/// <summary>
		/// 压缩文件夹列表
		/// </summary>
		/// <param name="sourceDirectoryPath">文件夹列表</param>
		/// <param name="zipFilePath">压缩文件保存的路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="password">解压密码</param>
		/// <param name="rootPath">压缩的根目录</param>
		public static void CompressDirectory(string sourceDirectoryPath, string zipFilePath, Encoding encoding = null, string password = null, string rootPath = @"/")
		{
			encoding = encoding ?? SmartEncoding.Default;
			sourceDirectoryPath = SmartDirectory.GetFormatDirectoryPath(sourceDirectoryPath);
			zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
			using (var zip = new ZipFile(encoding)) {
				if (!string.IsNullOrEmpty(password)) {
					zip.Password = password;
				}
				zip.AddDirectory(sourceDirectoryPath, rootPath);
				zip.Save(zipFilePath);
			}
		}

		/// <summary>
		/// 解压文件
		/// </summary>
		/// <param name="zipFilePath">压缩文件所在的路径</param>
		/// <param name="sourceDirectoryPath">解压到的文件夹路径</param>
		/// <param name="encoding">编码</param>
		/// <param name="password">解压密码</param>
		public static void Decompress(string zipFilePath, string sourceDirectoryPath, Encoding encoding = null, string password = null)
		{
			encoding = encoding ?? SmartEncoding.Default;
			sourceDirectoryPath = SmartDirectory.GetFormatDirectoryPath(sourceDirectoryPath);
			zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
			using (var zip = ZipFile.Read(zipFilePath)) {
				if (!string.IsNullOrEmpty(password)) {
					zip.Password = password;
				}
				zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
				zip.ExtractAll(sourceDirectoryPath);
			}
		}
	}
}
