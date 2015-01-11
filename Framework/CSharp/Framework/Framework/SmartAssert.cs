/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Diagnostics;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 断言
    /// </summary>
    public class SmartAssert
    {
        /// <summary>
        /// 判断是否为True，不为True则抛出异常
        /// </summary>
        /// <param name="input">待判断项目</param>
        public static void IsTrue(bool input)
        {
            if (!input)
            {
                var stackFrame = new StackFrame(true);
                throw new Exception(stackFrame.ToString());
            }
        }

        /// <summary>
        /// 判断是否为False，不为False则抛出异常
        /// </summary>
        /// <param name="input">待判断项目</param>
        public static void IsFalse(bool input)
        {
            if (input)
            {
                var stackFrame = new StackFrame(true);
                throw new Exception(stackFrame.ToString());
            }
        }

        /// <summary>
        /// 判断是否相等，不相等则抛出异常
        /// </summary>
        /// <param name="left">左对象</param>
        /// <param name="right">右对象</param>
        public static void IsEquals(object left, object right)
        {
            if (!left.Equals(right))
            {
                var stackFrame = new StackFrame(true);
                throw new Exception(stackFrame.ToString());
            }
        }

        /// <summary>
        /// 判断是否不相等，相等则抛出异常
        /// </summary>
        /// <param name="left">左对象</param>
        /// <param name="right">右对象</param>
        public static void IsNotEquals(object left, object right)
        {
            if (left.Equals(right))
            {
                var stackFrame = new StackFrame(true);
                throw new Exception(stackFrame.ToString());
            }
        }

        /// <summary>
        /// 判断是否为Null，不为Null则抛出异常
        /// </summary>
        /// <param name="input">待判断项目</param>
        public static void IsNull(object input)
        {
            if (input != null)
            {
                var stackFrame = new StackFrame(true);
                throw new Exception(stackFrame.ToString());
            }
        }

        /// <summary>
        /// 判断是否不为Null，为Null则抛出异常
        /// </summary>
        /// <param name="input">待判断项目</param>
        public static void IsNotNull(object input)
        {
            if (input == null)
            {
                var stackFrame = new StackFrame(true);
                throw new Exception(stackFrame.ToString());
            }
        }
    }
}
