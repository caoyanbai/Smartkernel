/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework
{
	/// <summary>
	/// HashCode
	/// </summary>
	public static class SmartHashCode
	{
		/// <summary>
		/// 获得哈希值
		/// </summary>
		/// <param name="input">输入</param>
		/// <returns>结果</returns>
		public static int GetHashCode(string input)
		{
			var length = input.Length;
			var hashCode = 0;
			for (var i = 0; i < length; i++)
			{
				hashCode = (int)(hashCode * 31 + Convert.ToInt32(input[i]));
				if ((hashCode & 0x80000000) == 0)
				{
					hashCode &= 0x7fffffff;
				}
				else
				{
					hashCode = Convert.ToInt32((hashCode & 0x7fffffff) - 2147483648);
				}
			}
			return hashCode;
		}
		
		/// <summary>
		/// 获取哈希值（32位）
		/// </summary>
		/// <param name="input">输入项</param>
		/// <returns>结果</returns>
		public static unsafe int GetHashCodeFor32(string input)
		{
			fixed (char* str = input.ToCharArray())
			{
				char* chPtr = str;
				int num = 0x15051505;
				int num2 = num;
				int* numPtr = (int*)chPtr;
				int length = input.Length;
				while (length > 2)
				{
					num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
					num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ numPtr[1];
					numPtr += 2;
					length -= 4;
				}
				if (length > 0)
				{
					num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
				}
				return (num + (num2 * 0x5d588b65));
			}
		}

		/// <summary>
		/// 获取哈希值（64位）
		/// </summary>
		/// <param name="input">输入项</param>
		/// <returns>结果</returns>
		public static unsafe int GetHashCodeFor64(string input)
		{
			fixed (char* str = input.ToCharArray())
			{
				int num3;
				char* chPtr = str;
				int num = 0x1505;
				int num2 = num;
				for (char* chPtr2 = chPtr; (num3 = chPtr2[0]) != '\0'; chPtr2 += 2)
				{
					num = ((num << 5) + num) ^ num3;
					num3 = chPtr2[1];
					if (num3 == 0)
					{
						break;
					}
					num2 = ((num2 << 5) + num2) ^ num3;
				}
				return (num + (num2 * 0x5d588b65));
			}
		}
	}
}
