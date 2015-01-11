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
    /// 非对称加密（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证），非对称加密的性能开销很大，使用时需要注意
    /// </summary>
    public static class SmartRsa
    {
        /// <summary>
        /// 创建密钥对，每次调用都会创建新的密钥对
        /// </summary>
        /// <returns>密钥对实体</returns>
        public static SmartRsaKey CreateKey()
        {
            return new SmartRsaKey();
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="input">待加密的字节数组</param>
        /// <param name="privateKeyOrPubliclKey">加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <returns>加密之后的字节数组</returns>
        public static byte[] Encrypt(byte[] input, string privateKeyOrPubliclKey)
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(privateKeyOrPubliclKey);
                return rsaCryptoServiceProvider.Encrypt(input, false);
            }
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <param name="privateKeyOrPubliclKey">加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <param name="encoding">编码</param>
        /// <returns>加密之后的字符串</returns>
        public static string EncryptToHexString(string input, string privateKeyOrPubliclKey, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            var output = Encrypt(encoding.GetBytes(input), privateKeyOrPubliclKey);

            return Encoding.UTF8.GetString(SmartHex.ToHex(output));
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="input">待解密的字节数组</param>
        /// <param name="privateKey">加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <returns>解密之后的字节数组</returns>
        public static byte[] Decrypt(byte[] input, string privateKey)
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(privateKey);

                return rsaCryptoServiceProvider.Decrypt(input, false);
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="input">待解密的字符串</param>
        /// <param name="privateKey">加密的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <param name="encoding">编码</param>
        /// <returns>解密之后的字符串</returns>
        public static string DecryptFromHexString(string input, string privateKey, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            var output = Decrypt(SmartHex.FromHex(Encoding.UTF8.GetBytes(input)), privateKey);

            return encoding.GetString(output);
        }

        /// <summary>
        /// 私钥签名
        /// </summary>
        /// <param name="input">待签名的字节数组</param>
        /// <param name="privateKey">签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <returns>签名之后的字节数组</returns>
        public static byte[] SignData(byte[] input, string privateKey, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Sha1)
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(privateKey);
                return rsaCryptoServiceProvider.SignData(input, CreateHashAlgorithm(hashAlgorithmType));
            }
        }

        /// <summary>
        /// 私钥签名
        /// </summary>
        /// <param name="input">待签名的字符串</param>
        /// <param name="privateKey">签名的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <param name="encoding">编码</param>
        /// <returns>签名之后的字节数组</returns>
        public static string SignDataToHexString(string input, string privateKey, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Sha1, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(privateKey);
                byte[] output = rsaCryptoServiceProvider.SignData(encoding.GetBytes(input), CreateHashAlgorithm(hashAlgorithmType));
                return Encoding.UTF8.GetString(SmartHex.ToHex(output));
            }
        }

        /// <summary>
        /// 公钥验证签名
        /// </summary>
        /// <param name="input">待签名验证的字节数组</param>
        /// <param name="signInput">验证字节数组</param>
        /// <param name="publicKey">签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <returns>是否验证通过</returns>
        public static bool VerifyData(byte[] input, byte[] signInput, string publicKey, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Sha1)
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(publicKey);
                return rsaCryptoServiceProvider.VerifyData(input, CreateHashAlgorithm(hashAlgorithmType), signInput);
            }
        }

        /// <summary>
        /// 公钥验证签名
        /// </summary>
        /// <param name="input">待签名验证的字符串</param>
        /// <param name="signInput">验证字符串</param>
        /// <param name="publicKey">签名验证的Key（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）</param>
        /// <param name="hashAlgorithmType">算法类型</param>
        /// <param name="encoding">编码</param>
        /// <returns>是否验证通过</returns>
        public static bool VerifyDataFromHex(string input, string signInput, string publicKey, SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Sha1, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.FromXmlString(publicKey);
                return rsaCryptoServiceProvider.VerifyData(encoding.GetBytes(input), CreateHashAlgorithm(hashAlgorithmType), SmartHex.FromHex(Encoding.UTF8.GetBytes(signInput)));
            }
        }

        /// <summary>
        /// 产生哈希算法
        /// </summary>
        /// <param name="hashAlgorithmType">哈希算法的类型</param>
        /// <returns>哈希算法</returns>
        private static string CreateHashAlgorithm(SmartHashAlgorithmType hashAlgorithmType = SmartHashAlgorithmType.Sha1)
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

            return hashAlgorithmString;
        }
    }
}
