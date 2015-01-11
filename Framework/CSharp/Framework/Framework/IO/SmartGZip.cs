/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Smartkernel.Framework.IO
{
    /// <summary>
    /// GZip
    /// </summary>
    public static class SmartGZip
    {
        /// <summary>
        /// 压缩流
        /// </summary>
        /// <param name="inputStream">需要被压缩的流</param>
        /// <param name="bufferSize">缓存大小</param>
        /// <returns>压缩之后的流</returns>
        public static Stream Compress(Stream inputStream, int bufferSize = 1024*8)
        {
            var outputStream = new MemoryStream();
            using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress, true))
            {
                var buffer = new byte[bufferSize];
                var count = inputStream.Read(buffer, 0, bufferSize);
                while (count > 0)
                {
                    gzipStream.Write(buffer, 0, count);
                    count = inputStream.Read(buffer, 0, bufferSize);
                }
                gzipStream.Flush();
            }
            outputStream.Position = 0;
            return outputStream;
        }

        /// <summary>
        /// 解压流
        /// </summary>
        /// <param name="inputStream">需要被解压的流</param>
        /// <param name="bufferSize">缓存大小</param>
        /// <returns>解压之后的流</returns>
        public static Stream Decompress(Stream inputStream, int bufferSize = 1024*8)
        {
            var outputStream = new MemoryStream();
            using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress, true))
            {
                var buffer = new byte[bufferSize];
                var count = gzipStream.Read(buffer, 0, bufferSize);
                while (count > 0)
                {
                    outputStream.Write(buffer, 0, count);
                    count = gzipStream.Read(buffer, 0, bufferSize);
                }
            }
            outputStream.Position = 0;
            return outputStream;
        }

        /// <summary>
        /// 压缩文件：被压缩的文件必须存在
        /// </summary>
        /// <param name="sourceFilePath">需要被压缩的文件</param>
        /// <param name="zipFilePath">压缩之后保存的文件路径</param>
        public static void Compress(string sourceFilePath, string zipFilePath)
        {
            sourceFilePath = SmartFile.GetFormatFilePath(sourceFilePath);
            zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
            using (Stream input = File.Open(sourceFilePath, FileMode.Open), output = Compress(input), fileStream = File.Create(zipFilePath))
            {
                var data = new byte[output.Length];
                output.Read(data, 0, data.Length);
                fileStream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// 解压缩文件：被解压缩的文件必须存在
        /// </summary>
        /// <param name="zipFilePath">需要被解压的文件</param>
        /// <param name="targetFilePath">解压之后保存的文件路径</param>
        public static void Decompress(string zipFilePath, string targetFilePath)
        {
            zipFilePath = SmartFile.GetFormatFilePath(zipFilePath);
            targetFilePath = SmartFile.GetFormatFilePath(targetFilePath);
            using (Stream input = File.Open(zipFilePath, FileMode.Open), output = Decompress(input), fileStream = File.Create(targetFilePath))
            {
                var data = new byte[output.Length];
                output.Read(data, 0, data.Length);
                fileStream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string Compress(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                byte[] source = Encoding.UTF8.GetBytes(input);

                result = SmartBase64.ToBase64WithArray(((MemoryStream)Compress(SmartByte.ToMemoryStream(source))).ToArray());
            }

            return result;
        }

        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string Decompress(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                byte[] source = SmartBase64.FromBase64WithArray(input);

                result = Encoding.UTF8.GetString(((MemoryStream)Decompress(SmartByte.ToMemoryStream(source))).ToArray());
            }

            return result;
        }
    }
}
