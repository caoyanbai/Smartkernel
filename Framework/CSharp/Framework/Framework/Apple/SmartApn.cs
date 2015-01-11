/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Smartkernel.Framework.Apple
{
	/// <summary>
	/// 苹果推送服务
	/// </summary>
	public static class SmartApn
	{
		private static object syncObj = new object();

		/// <summary>
		/// 发送
		/// </summary>
		/// <param name="hostname">服务器</param>
		/// <param name="port">端口</param>
		/// <param name="certificateFilePath">证书地址</param>
		/// <param name="certificatePassword">证书密码</param>
		/// <param name="token">设备编号</param>
		/// <param name="message">消息</param>
		public static void Push(string hostname, int port, string certificateFilePath, string certificatePassword, string token, string message)
		{
			var x509Certificate2 = new X509Certificate2(File.ReadAllBytes(certificateFilePath), certificatePassword, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

			var x509Certificate2Collection = new X509Certificate2Collection(x509Certificate2);

			using (var client = new TcpClient(hostname, port))
			{
				using (var sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null))
				{
					lock (syncObj)
					{
						sslStream.AuthenticateAsClient(hostname, x509Certificate2Collection, SslProtocols.Ssl3, false);
					}
					sslStream.Write(ToBytes(token, message));
					sslStream.Flush();
				}
			}
		}

		private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors == SslPolicyErrors.None)
			{
				return true;
			}
			return false;
		}

		private static byte[] ToBytes(string token, string message)
		{
			int identifier = 0;
			byte[] identifierBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(identifier));

			int expiryTimeStamp = -1;
			DateTime concreteExpireDateUtc = DateTime.UtcNow.AddMonths(1).ToUniversalTime();
			TimeSpan epochTimeSpan = concreteExpireDateUtc - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			;
			expiryTimeStamp = (int)epochTimeSpan.TotalSeconds;

			byte[] expiry = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(expiryTimeStamp));

			byte[] deviceToken = new byte[token.Length / 2];
			for (int i = 0; i < deviceToken.Length; i++)
			{
				deviceToken[i] = byte.Parse(token.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
			}

			byte[] deviceTokenSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Convert.ToInt16(deviceToken.Length)));

			byte[] payload = Encoding.UTF8.GetBytes(message);

			byte[] payloadSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Convert.ToInt16(payload.Length)));

			int bufferSize = sizeof(Byte) + deviceTokenSize.Length + deviceToken.Length + payloadSize.Length + payload.Length;
			byte[] buffer = new byte[bufferSize];

			List<byte[]> list = new List<byte[]>();

			list.Add(new byte[] { 0x01 });
			list.Add(identifierBytes);
			list.Add(expiry);
			list.Add(deviceTokenSize);
			list.Add(deviceToken);
			list.Add(payloadSize);
			list.Add(payload);

			return Join(list);
		}

		private static byte[] Join(IList<byte[]> bufferParts)
		{
			int bufferSize = 0;
			for (int i = 0; i < bufferParts.Count; i++)
			{
				bufferSize += bufferParts[i].Length;
			}

			byte[] buffer = new byte[bufferSize];
			int position = 0;
			for (int i = 0; i < bufferParts.Count; i++)
			{
				byte[] part = bufferParts[i];
				Buffer.BlockCopy(bufferParts[i], 0, buffer, position, part.Length);
				position += part.Length;
			}
			return buffer;
		}
	}
}
