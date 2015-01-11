/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Smartkernel.Framework.Security
{
    /// <summary>
    /// 哈希密码
    /// </summary>
    public static class SmartHashAlgorithm
    {
        /// <summary>
        /// 获得哈希密码
        /// </summary>
        /// <param name="input">待处理的字节数组</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <returns>哈希密码</returns>
        public static byte[] ComputeHash(byte[] input, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Md5)
        {
            using (var hashAlgorithm = CreateHashAlgorithm(hashAlgorithmType))
            {
                var hash = hashAlgorithm.ComputeHash(input);
                return hash;
            }
        }

        /// <summary>
        /// 获得哈希密码
        /// </summary>
        /// <param name="input">待处理的字符串</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <param name="encoding">编码</param>
        /// <returns>哈希密码</returns>
        public static string ComputeHashToHexString(string input, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Md5, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            using (var hashAlgorithm = CreateHashAlgorithm(hashAlgorithmType))
            {
                var hash = hashAlgorithm.ComputeHash(encoding.GetBytes(input));
                return encoding.GetString(SmartHex.ToHex(hash));
            }
        }

        /// <summary>
        /// 计算文件的哈希密码
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <returns>编码了的哈希码</returns>
        public static byte[] ComputeFileHash(string filePath, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Md5)
        {
            using (var hashAlgorithm = CreateHashAlgorithm(hashAlgorithmType))
            {
                using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var hash = hashAlgorithm.ComputeHash(stream);
                    return hash;
                }
            }
        }

        /// <summary>
        /// 计算流的哈希密码
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <returns>编码了的哈希码</returns>
        public static byte[] ComputeStreamHash(Stream stream, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Md5)
        {
            using (var hashAlgorithm = CreateHashAlgorithm(hashAlgorithmType))
            {
                var hash = hashAlgorithm.ComputeHash(stream);
                return hash;
            }
        }

        /// <summary>
        /// 产生哈希算法
        /// </summary>
        /// <param name="hashAlgorithmType">哈希算法的类型</param>
        /// <returns>哈希算法</returns>
        private static HashAlgorithm CreateHashAlgorithm(SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Md5)
        {
            var hashAlgorithmString = string.Empty;
            switch (hashAlgorithmType)
            {
                case SmartHashAlgorithmType.Md5:
                    hashAlgorithmString = "MD5";
                    break;
                case SmartHashAlgorithmType.Sha1:
                    hashAlgorithmString = "SHA1";
                    break;
            }

            return HashAlgorithm.Create(hashAlgorithmString);
        }
    }
}
