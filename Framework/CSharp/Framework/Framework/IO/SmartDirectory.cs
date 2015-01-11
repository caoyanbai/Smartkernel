/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Computer;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace Smartkernel.Framework.IO
{
	/// <summary>
	/// 文件夹操作类
	/// </summary>
	public static class SmartDirectory
	{
		/// <summary>
		/// 获得格式化的目录路径（格式化为符合操作系统的分隔符号和包含结尾分隔符号）
		/// </summary>
		/// <param name="directoryPath">目录的路径</param>
		/// <returns>结果</returns>
		public static string GetFormatDirectoryPath(string directoryPath)
		{
			directoryPath = directoryPath.Replace("\\", SmartComputer.DirectorySeparator);
			directoryPath = directoryPath.Replace("/", SmartComputer.DirectorySeparator);
			directoryPath = directoryPath.Replace(SmartComputer.DirectorySeparator + SmartComputer.DirectorySeparator, SmartComputer.DirectorySeparator);
			directoryPath = SmartString.TrimEnd(directoryPath, SmartComputer.DirectorySeparator);
			return directoryPath + SmartComputer.DirectorySeparator;
		}

		/// <summary>
		/// 删除共享
		/// </summary>
		/// <param name="shareName">共享名称</param>
		public static void DeleteShare(string shareName)
		{
			var objectQuery = new ObjectQuery(string.Format("SELECT * FROM Win32_Share WHERE name = '{0}'", shareName));
			using (var managementObjectSearcher = new ManagementObjectSearcher(objectQuery)) {
				using (var managementObjectCollection = managementObjectSearcher.Get()) {
					foreach (ManagementObject managementObject in managementObjectCollection) {
						managementObject.Delete();
					}
				}
			}
		}

		/// <summary>
		/// 设置指定目录为共享目录
		/// </summary>
		/// <param name="directoryPath">目录路径</param>
		/// <param name="shareName">共享名称</param>
		public static void CreateShare(string directoryPath, string shareName)
		{
			directoryPath = GetFormatDirectoryPath(directoryPath);
			var managementClass = new ManagementClass(new ManagementPath("Win32_Share"));
			object[] args = {
				directoryPath,
				shareName,
				"0",
				"10",
				shareName,
				""
			};
			managementClass.InvokeMethod("create", args);
		}

		/// <summary>
		/// 计算指定文件夹的总大小，包含所有子目录中的文件
		/// </summary>
		/// <param name="directoryPath">文件夹的路径</param>
		/// <returns>总大小</returns>
		public static long GetTotalSize(string directoryPath)
		{
			directoryPath = GetFormatDirectoryPath(directoryPath);
			var directory = new DirectoryInfo(directoryPath);
			var files = directory.GetFiles();
			var size = files.Sum(file => file.Length);
			var subDirectories = directory.GetDirectories();
			size += subDirectories.Sum(subDirectory => GetTotalSize(subDirectory.FullName));
			return size;
		}

		/// <summary>
		/// 获得指定文件夹下的文件扩展名类型
		/// </summary>
		/// <param name="directoryPath">文件夹路径</param>
		/// <param name="searchOption">搜索的范围，是不是包含子目录</param>
		/// <returns>查找的结果</returns>
		public static List<string> GetExtensionTypes(string directoryPath, SearchOption searchOption = SearchOption.AllDirectories)
		{
			directoryPath = GetFormatDirectoryPath(directoryPath);
			var linq = from file in Directory.GetFiles(directoryPath, "*.*", searchOption)
			           select Path.GetExtension(file);
			return linq.Distinct().ToList();
		}

		/// <summary>
		/// 递归复制文件夹及所有文件
		/// </summary>
		/// <param name="sourceDirectoryPath">源文件夹</param>
		/// <param name="targetDirectoryPath">目标文件夹</param>
		/// <param name="overwrite">是否覆盖</param>
		public static void Copy(string sourceDirectoryPath, string targetDirectoryPath, bool overwrite = true)
		{
			sourceDirectoryPath = GetFormatDirectoryPath(sourceDirectoryPath);
			targetDirectoryPath = GetFormatDirectoryPath(targetDirectoryPath);
			if (!Directory.Exists(targetDirectoryPath)) {
				Directory.CreateDirectory(targetDirectoryPath);
			}

			if (!Directory.Exists(sourceDirectoryPath)) {
				return;
			}

			var directories = Directory.GetDirectories(sourceDirectoryPath);

			if (directories.Length > 0) {
				foreach (var directory in directories) {
					var temp = GetFormatDirectoryPath(directory);
					Copy(directory, targetDirectoryPath + temp.Substring(temp.LastIndexOf(SmartComputer.DirectorySeparator)), overwrite);
				}
			}

			var files = Directory.GetFiles(sourceDirectoryPath);

			if (files.Length > 0) {
				foreach (var file in files) {
					var temp = SmartFile.GetFormatFilePath(file);
					File.Copy(file, targetDirectoryPath + temp.Substring(temp.LastIndexOf(SmartComputer.DirectorySeparator)), overwrite);
				}
			}
		}
	}
}
