/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 转换
    /// </summary>
    public static class SmartConvert
    {
        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为Int32类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static int TryToInt32(object input, int defaultValue = 0)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为Int16类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static Int16 TryToInt16(object input, Int16 defaultValue = 0)
        {
            try
            {
                return Convert.ToInt16(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为Int64类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static Int64 TryToInt64(object input, Int64 defaultValue = 0)
        {
            try
            {
                return Convert.ToInt64(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 Decimal 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static Decimal TryToDecimal(object input, Decimal defaultValue = 0)
        {
            try
            {
                return Convert.ToDecimal(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 Double 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static Double TryToDouble(object input, Double defaultValue = 0.00)
        {
            try
            {
                return Convert.ToDouble(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 String 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static String TryToString(object input, String defaultValue = "")
        {
            try
            {
                return Convert.ToString(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 Char 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static Char TryToChar(object input, Char defaultValue = ' ')
        {
            try
            {
                return Convert.ToChar(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 DateTime类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static DateTime TryToDateTime(object input, DateTime defaultValue = default(DateTime))
        {
            try
            {
                return Convert.ToDateTime(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 bool 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static bool TryToBool(object input, bool defaultValue = false)
        {
            try
            {
                return Convert.ToBoolean(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 byte 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static byte TryToByte(object input, byte defaultValue = 0)
        {
            try
            {
                return Convert.ToByte(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 SByte 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static SByte TryToSByte(object input, SByte defaultValue = 0)
        {
            try
            {
                return Convert.ToSByte(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 float 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static float TryToSingle(object input, float defaultValue = 0)
        {
            try
            {
                return Convert.ToSingle(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 UInt32 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static UInt32 TryToUInt32(object input, UInt32 defaultValue = 0)
        {
            try
            {
                return Convert.ToUInt32(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 UInt16 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static UInt16 TryToUInt16(object input, UInt16 defaultValue = 0)
        {
            try
            {
                return Convert.ToUInt16(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 尝试转换（失败则返回默认值）-- 转换为 UInt64 类型
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>结果</returns>
        public static UInt64 TryToUInt64(object input, UInt64 defaultValue = 0)
        {
            try
            {
                return Convert.ToUInt64(input);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 从源类型转换为目标类型
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="type">目标类型（可以是枚举、TimeSpan、DateTime、List[string]、Color、其他基本类型等）</param>
        /// <returns>转换之后的对象</returns>
        public static object To(object source, Type type)
        {
            object result = source;

            if (source == null)
            {
                return null;
            }

            string sourceString = source == null ? null : source.ToString();

            if (Nullable.GetUnderlyingType(type) != null)
            {
                //如果目标类型是Nullable类型，取原始类型
                type = Nullable.GetUnderlyingType(type);
            }

            if (type.IsEnum)
            {
                //目标类型为枚举类型
                result = Enum.Parse(type, sourceString, true);
            }
            else if (source is Enum && type == typeof(int))
            {
                //源为枚举类型，目标为整形
                result = (int)source;
            }
            else if (source is int && type.IsEnum)
            {
                //源为整形，目标为枚举类型
                result = Convert.ChangeType(source, type, CultureInfo.CurrentCulture);
            }
            else if (type == typeof(DateTime))
            {
                //目标类型为时间类型
                result = DateTime.Parse(sourceString);
            }
            else if (source is bool && type == typeof(string))
            {
                //如果源是布尔值，目标是字符串
                result = sourceString.ToLower();
            }
            else if (source is IConvertible)
            {
                //一般类型的转换
                result = Convert.ChangeType(source, type, CultureInfo.CurrentCulture);
            }

            return result;
        }

        /// <summary>
        /// 从源类型转换为目标类型
        /// </summary>
        /// <typeparam name="T">目标类型（可以是枚举、TimeSpan、DateTime、List[string]、Color、其他基本类型等）</typeparam>
        /// <param name="source">源</param>
        /// <returns>转换之后的对象</returns>
        public static T To<T>(object source)
        {
            return (T)To(source, typeof(T));
        }
    }
}
