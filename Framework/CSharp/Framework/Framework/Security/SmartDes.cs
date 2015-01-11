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
    /// Des
    /// </summary>
    public static class SmartDes
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="input">待加密的字节数组</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        /// <returns>加密之后的字节数组</returns>
        public static byte[] Encrypt(byte[] input, byte[] password, byte[] iv)
        {
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(password, iv), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(input, 0, input.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="input">待解密的字节数组</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        /// <returns>解密之后的字节数组</returns>
        public static byte[] Decrypt(byte[] input, byte[] password, byte[] iv)
        {
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(password, iv), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(input, 0, input.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        /// <param name="encoding">编码</param>
        /// <returns>加密之后的字符串</returns>
        public static string EncryptToHexString(string input, string password, string iv, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            var output = Encrypt(encoding.GetBytes(input), Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(iv));

            return Encoding.UTF8.GetString(SmartHex.ToHex(output));
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="input">待解密的字符串</param>
        /// <param name="password">解密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        /// <param name="encoding">编码</param>
        /// <returns>解密之后的字符串</returns>
        public static string DecryptFromHexString(string input, string password, string iv, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            var output = Decrypt(SmartHex.FromHex(Encoding.UTF8.GetBytes(input)), Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(iv));

            return encoding.GetString(output);
        }

        /// <summary>
        /// 加密文件的方法
        /// </summary>
        /// <param name="sourceFilePath">待加密的文件路径</param>
        /// <param name="encryptFilePath">加密之后的文件路径</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        public static void EncryptFile(string sourceFilePath, string encryptFilePath, byte[] password, byte[] iv)
        {
            using (Stream stream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                var datas = new byte[stream.Length];
                stream.Read(datas, 0, datas.Length);
                using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(password, iv), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(datas, 0, datas.Length);
                            cryptoStream.FlushFinalBlock();
                            var buffer = new byte[memoryStream.Length];
                            memoryStream.Position = 0;
                            memoryStream.Read(buffer, 0, buffer.Length);

                            using (Stream newStream = new FileStream(encryptFilePath, FileMode.CreateNew, FileAccess.Write))
                            {
                                newStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 加密流的方法
        /// </summary>
        /// <param name="inputStream">待加密的流</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        /// <returns>加密之后的流</returns>
        public static Stream EncryptStream(Stream inputStream, byte[] password, byte[] iv)
        {
            var datas = new byte[inputStream.Length];
            inputStream.Read(datas, 0, datas.Length);
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(password, iv), CryptoStreamMode.Write);
                cryptoStream.Write(datas, 0, datas.Length);
                cryptoStream.FlushFinalBlock();
                memoryStream.Position = 0;
                return memoryStream;
            }
        }

        /// <summary>
        /// 解密文件的方法
        /// </summary>
        /// <param name="encryptFilePath">待解密的文件路径</param>
        /// <param name="decryptFilePath">解密之后保存的路径</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        public static void DecryptFile(string encryptFilePath, string decryptFilePath, byte[] password, byte[] iv)
        {
            using (Stream stream = new FileStream(encryptFilePath, FileMode.Open, FileAccess.Read))
            {
                var datas = new byte[stream.Length];
                stream.Read(datas, 0, datas.Length);
                using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(password, iv), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(datas, 0, datas.Length);
                            cryptoStream.FlushFinalBlock();
                            var buffer = new byte[memoryStream.Length];
                            memoryStream.Position = 0;
                            memoryStream.Read(buffer, 0, buffer.Length);

                            using (Stream newStream = new FileStream(decryptFilePath, FileMode.CreateNew, FileAccess.Write))
                            {
                                newStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 解密流的方法
        /// </summary>
        /// <param name="inputStream">待解密的流</param>
        /// <param name="password">加密的密码（只能为8位长）</param>
        /// <param name="iv">偏移</param>
        /// <returns>解密之后的流</returns>
        public static Stream DecryptStream(Stream inputStream, byte[] password, byte[] iv)
        {
            var datas = new byte[inputStream.Length];
            inputStream.Read(datas, 0, datas.Length);
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(password, iv), CryptoStreamMode.Write);
                cryptoStream.Write(datas, 0, datas.Length);
                cryptoStream.FlushFinalBlock();
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
    }
}
