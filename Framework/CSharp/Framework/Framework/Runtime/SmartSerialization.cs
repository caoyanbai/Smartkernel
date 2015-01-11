/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Smartkernel.Framework.Runtime
{
    /// <summary>
    /// 序列化
    /// </summary>
    public static class SmartSerialization
    {
        /// <summary>
        /// 二进制序列化器
        /// </summary>
        private static readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns>克隆之后的对象</returns>
        public static T Clone<T>(object obj) where T : new()
        {
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }

        /// <summary>
        /// 序列化过程
        /// </summary>
        /// <param name="obj">准备序列化的对象</param>
        /// <param name="stream">序列化对象写入的流</param>
        /// <param name="serializationFormatType">序列化的类型</param>
        public static void Serialize(Object obj, Stream stream, SmartSerializationFormatType serializationFormatType = SmartSerializationFormatType.Binary)
        {
            IFormatter formatter = null;
            switch (serializationFormatType)
            {
                case SmartSerializationFormatType.Soap:
                    formatter = new SoapFormatter();
                    break;
                case SmartSerializationFormatType.Binary:
                    formatter = new BinaryFormatter();
                    break;
                default:
                    formatter = new BinaryFormatter();
                    break;
            }
            formatter.Serialize(stream, obj);
            stream.Position = 0;
        }

        /// <summary>
        /// 序列化过程
        /// </summary>
        /// <param name="obj">准备序列化的对象</param>
        /// <param name="filePath">序列化写入的文件</param>
        /// <param name="serializationFormatType">序列化的类型</param>
        public static void Serialize(Object obj, string filePath, SmartSerializationFormatType serializationFormatType = SmartSerializationFormatType.Binary)
        {
            var directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            using (Stream stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                Serialize(obj, stream, serializationFormatType);
            }
        }

        /// <summary>
        /// 反序列化过程
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型</typeparam>
        /// <param name="stream">序列化对象的流</param>
        /// <param name="serializationFormatType">序列化的类型</param>
        /// <returns>返回反序列化的对象</returns>
        public static T Deserialize<T>(Stream stream, SmartSerializationFormatType serializationFormatType = SmartSerializationFormatType.Binary)
        {
            IFormatter formatter = null;
            switch (serializationFormatType)
            {
                case SmartSerializationFormatType.Soap:
                    formatter = new SoapFormatter();
                    break;
                case SmartSerializationFormatType.Binary:
                    formatter = new BinaryFormatter();
                    break;
                default:
                    formatter = new BinaryFormatter();
                    break;
            }
            return (T)formatter.Deserialize(stream);
        }

        /// <summary>
        /// 反序列化过程
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型</typeparam>
        /// <param name="filePath">读取序列化数据的文件</param>
        /// <param name="serializationFormatType">序列化的类型</param>
        /// <returns>返回反序列化的对象</returns>
        public static T Deserialize<T>(string filePath, SmartSerializationFormatType serializationFormatType = SmartSerializationFormatType.Binary)
        {
            using (Stream stream = new FileStream(filePath, FileMode.Open))
            {
                return Deserialize<T>(stream, serializationFormatType);
            }
        }
    }
}
