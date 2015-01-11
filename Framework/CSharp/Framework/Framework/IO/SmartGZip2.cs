/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Text;

namespace Smartkernel.Framework.IO
{
    /// <summary>
    /// GZip2（支持压缩之后保存文件名信息）
    /// </summary>
    public static class SmartGZip2
    {
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileIn">输入文件</param>
        /// <param name="fileOut">输出文件</param>
        public static void Compress(string fileIn, string fileOut)
        {
            fileIn = SmartFile.GetFormatFilePath(fileIn);
            fileOut = SmartFile.GetFormatFilePath(fileOut);
            using (FileStream fileStreamReader = new FileStream(fileIn, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileStreamWriter = new FileStream(fileOut, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    using (ZipOutputStream zipOutputStream = new ZipOutputStream(fileStreamWriter))
                    {
                        ZipEntry zipEntry = new ZipEntry(Path.GetFileName(fileIn));
                        zipOutputStream.PutNextEntry(zipEntry);

                        int data = -1;
                        while ((data = fileStreamReader.ReadByte()) != -1)
                        {
                            zipOutputStream.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }
}
