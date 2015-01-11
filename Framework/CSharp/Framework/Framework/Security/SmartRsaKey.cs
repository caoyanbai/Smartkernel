/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Security.Cryptography;

namespace Smartkernel.Framework.Security
{
    /// <summary>
    /// 密钥对
    /// </summary>
    [Serializable]
    public class SmartRsaKey
    {
        private readonly string privateKey;

        private readonly string publicKey;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SmartRsaKey()
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                privateKey = rsaCryptoServiceProvider.ToXmlString(true);
                publicKey = rsaCryptoServiceProvider.ToXmlString(false);
            }
        }

        /// <summary>
        /// 密钥对的公钥（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
        /// </summary>
        public string PublicKey { get { return publicKey; } }

        /// <summary>
        /// 密钥对的私钥（公钥和私钥都可以用于加密，只有私钥可以进行解密。私钥可以进行签名，公钥可以进行签名验证）
        /// </summary>
        public string PrivateKey { get { return privateKey; } }
    }
}
