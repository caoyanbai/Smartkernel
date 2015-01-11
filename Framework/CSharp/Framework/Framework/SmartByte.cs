/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 字节类
    /// </summary>
    public static class SmartByte
    {
        /// <summary>
        /// 高性能拷贝字节数组的一部分
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="startIndex">开始的索引</param>
        /// <param name="length">长度</param>
        /// <returns>拷贝的结果</returns>
        public static byte[] BlockCopy(byte[] source, int startIndex, int length)
        {
            var bytes = new byte[source.Length - startIndex < length ? source.Length - startIndex : length];
            Buffer.BlockCopy(source, startIndex, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// 合并两个字节数组
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="other">另外一个字节数组</param>
        /// <returns>合并的结果</returns>
        private static byte[] Combine(byte[] source, byte[] other)
        {
            var bytes = new byte[source.Length + other.Length];
            Buffer.BlockCopy(source, 0, bytes, 0, source.Length);
            Buffer.BlockCopy(other, 0, bytes, source.Length, other.Length);
            return bytes;
        }

        /// <summary>
        /// 合并多个字节数组
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="others">待合并的字节数组</param>
        /// <returns>合并的结果</returns>
        public static byte[] Combine(byte[] source, params byte[][] others)
        {
            for (var i = 0; i < others.Length; i++)
            {
                source = SmartByte.Combine(source, others[i]);
            }
            return source;
        }

        /// <summary>
        /// 合并二维字节数组为一维字节数组
        /// </summary>
        /// <param name="twoDimensionsBytes">二维字节数组</param>
        /// <returns>合并的结果</returns>
        public static byte[] Combine(byte[][] twoDimensionsBytes)
        {
            var memoryStream = new MemoryStream();
            for (var i = 0; i < twoDimensionsBytes.Length; i++)
            {
                memoryStream.Write(twoDimensionsBytes[i], 0, twoDimensionsBytes[i].Length);
            }
            return memoryStream.ToArray();
        }

        /// <summary>
        /// 比较两个字节数组是否相等
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="other">目标</param>
        /// <returns>比较的结果</returns>
        public static int CompareTo(byte[] source, byte[] other)
        {
            if (source == null && other == null)
            {
                return 0;
            }
            if (source == null)
            {
                return 1;
            }
            if (other == null)
            {
                return -1;
            }
            var sourceLength = source.Length;
            var otherLength = other.Length;

            if (sourceLength == otherLength)
            {
                var comparision = 0;
                for (var i = 0; i < sourceLength; i++)
                {
                    comparision = source[i].CompareTo(other[i]);
                    if (comparision != 0)
                    {
                        break;
                    }
                }
                return comparision;
            }
            return sourceLength.CompareTo(otherLength);
        }

        /// <summary>
        /// 转换为字符串（64位编码）
        /// </summary>
        /// <param name="source">字节数组</param>
        /// <returns>转换的结果</returns>
        public static string ToBase64(byte[] source)
        {
            return Convert.ToBase64String(source);
        }

        /// <summary>
        /// 转换为字符串（十六进制）
        /// </summary>
        /// <param name="source">字节数组</param>
        /// <returns>转换的结果</returns>
        public static string ToHex(byte[] source)
        {
            return string.Join("", source.Select(item => item.ToString("X2")).ToArray());
        }

        /// <summary>
        /// 转换为内存流
        /// </summary>
        /// <param name="source">字节数组</param>
        /// <returns>转换的结果</returns>
        public static MemoryStream ToMemoryStream(byte[] source)
        {
            return new MemoryStream(source);
        }

        /// <summary>
        /// 转换回字节数组
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>转换的结果</returns>
        public static byte[] FromBase64(string input)
        {
            return Convert.FromBase64String(input);
        }

        /// <summary>
        /// 转换回字节数组
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>转换的结果</returns>
        public static byte[] FromHex(string input)
        {
            if (input.Length == 0 || input.Length % 2 != 0)
            {
                return new byte[0];
            }
            byte[] bytes = new byte[input.Length / 2];
            char c;
            for (int byteIndex = 0, stringIndex = 0; byteIndex < bytes.Length; ++byteIndex, ++stringIndex)
            {
                //转换前半部分   
                c = input[stringIndex];
                bytes[byteIndex] = (byte)((c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0')) << 4);
                //转换后半部分    
                c = input[++stringIndex];
                bytes[byteIndex] |= (byte)(c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0'));
            }
            return bytes;
        }

        /// <summary>
        /// 转换回字节数组
        /// </summary>
        /// <param name="input">内存流</param>
        /// <returns>转换的结果</returns>
        public static byte[] FromMemoryStream(MemoryStream input)
        {
            var buffer = new byte[input.Length];
            input.Position = 0;
            input.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
