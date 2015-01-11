/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Smartkernel.Framework.Net
{
	/// <summary>
	/// IP地址
	/// </summary>
	public static class SmartIPAddress
	{
		/// <summary>
		/// 验证是不是IP地址
		/// </summary>
		/// <param name="input">待验证的字符串</param>
		/// <returns>验证的结果</returns>
		public static bool IsIPAddress(string input)
		{
			const string pattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
			if (Regex.IsMatch(input, pattern))
			{
				IPAddress ipAddress;
				return IPAddress.TryParse(input, out ipAddress);
			}
			return false;
		}

		/// <summary>
		/// 比较IP地址的大小
		/// </summary>
		/// <param name="left">第一个IP</param>
		/// <param name="right">第二个IP</param>
		/// <returns>如果第一个大于第二个返回-1，如果第一个小于第二个返回1</returns>
		public static int Compare(string left, string right)
		{
			var numberLeft = ToNumber(left);
			var numberRight = ToNumber(right);
			if (numberLeft > numberRight) {
				return -1;
			}
			if (numberLeft < numberRight) {
				return 1;
			}
			return 0;
		}

		/// <summary>
		/// 是否是私有IP
		/// </summary>
		/// <param name="ip">IP地址</param>
		/// <returns>是否是私有IP</returns>
		public static bool IsPrivate(string ip)
		{
			var ipAddress = IPAddress.Parse(ip);
			if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
			{
				var ipBytes = ipAddress.GetAddressBytes();
				if (ipBytes[0] == 192 && ipBytes[1] == 168)
				{
					return true;
				}
				if (ipBytes[0] == 172 && ipBytes[1] >= 16 && ipBytes[1] <= 31)
				{
					return true;
				}
				if (ipBytes[0] == 10)
				{
					return true;
				}
				if (ipBytes[0] == 169 && ipBytes[1] == 254)
				{
					return true;
				}
				if (ipBytes[0] == 127)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// IP转换为数字
		/// </summary>
		/// <param name="ip">IP地址</param>
		/// <returns>结果</returns>
		public static long ToNumber(string ip)
		{
			try
			{
				string[] ips = ip.Split('.');
				return Convert.ToInt64(ips[0]) * 256 * 256 * 256 + Convert.ToInt64(ips[1]) * 256 * 256 + Convert.ToInt64(ips[2]) * 256 + Convert.ToInt64(ips[3]);
			}
			catch
			{
				return -1;
			}
		}


		/// <summary>
		/// 数字转换为IPAddress
		/// </summary>
		/// <param name="ipValue">ipValue</param>
		/// <returns>结果</returns>
		public static string ToIPAddress(long ipValue)
		{
			try
			{
				string ip = String.Empty;

				for (int i = 4; i > 0; i--)
				{
					ip = (ipValue % 256).ToString() + "." + ip;
					ipValue = ipValue / 256;
				}

				return ip.TrimEnd('.');
			}
			catch
			{
				return "";
			}
		}
	}
}
