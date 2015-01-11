/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Diagnostics;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Smartkernel.Framework.IO
{
    /// <summary>
    /// Rar格式压缩解压：提供对Rar格式压缩解压操作
    /// </summary>
    public class SmartRar
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="winRarPath">WinRar运行文件的路径</param>
        public SmartRar(string winRarPath = null)
        {
            winRarPath = SmartDirectory.GetFormatDirectoryPath(winRarPath);
            if (winRarPath == null)
            {
                winRarPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            var path = string.Format(@"{0}WinRAR.zip", winRarPath);

            if (!File.Exists(path))
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    var bytes = SmartResource.WinRar;
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                }
                SmartZip.Decompress(path, winRarPath);
            }

            WinRarPath = string.Format(@"{0}WinRAR\WinRAR.exe", winRarPath);
        }

        /// <summary>
        /// 获取或设置WinRar的安装路径
        /// </summary>
        public string WinRarPath { get; set; }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="sourceFilePathOrDirectoryPath">源文件路径，可以是文件，也可以是文件夹，注意，路径中不能有空格</param>
        /// <param name="zipFilePath">目标路径</param>
        /// <param name="password">压缩的密码</param>
        public void Compress(string sourceFilePathOrDirectoryPath, string zipFilePath, string password = null)
        {
            sourceFilePathOrDirectoryPath = SmartDirectory.GetFormatDirectoryPath(sourceFilePathOrDirectoryPath);
            zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
            var args = password == null ? String.Format("a -r -ep1 -ibck -inul {0} {1}", zipFilePath, sourceFilePathOrDirectoryPath) : String.Format("a -r -ep1 -ibck -inul -p{0} {1} {2}", password, zipFilePath, sourceFilePathOrDirectoryPath);
            SmartProcess.Start(WinRarPath, ProcessWindowStyle.Hidden, args);
        }

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="zipFilePath">压缩文件的路径</param>
        /// <param name="targetFilePathOrDirectoryPath">待解压到的目录</param>
        /// <param name="password">解压的密码</param>
        public void Decompress(string zipFilePath, string targetFilePathOrDirectoryPath, string password = null)
        {
            zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
            targetFilePathOrDirectoryPath = SmartDirectory.GetFormatDirectoryPath(targetFilePathOrDirectoryPath);
            var args = password == null ? String.Format("x -o+ -ibck -inul -ep {0} {1}", zipFilePath, targetFilePathOrDirectoryPath) : String.Format("x -o+ -ibck -inul -ep -p{0} {1} {2}", password, targetFilePathOrDirectoryPath, zipFilePath);
            SmartProcess.Start(WinRarPath, ProcessWindowStyle.Hidden, args);
        }
    }
}
