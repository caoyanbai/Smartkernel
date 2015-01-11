/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.Messaging
{
    /// <summary>
    /// 消息队列中的实体
    /// </summary>
    [Serializable]
    public class SmartMessage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="label">标签</param>
        /// <param name="body">正文</param>
        public SmartMessage(string label, string body)
        {
            Label = label;
            Body = body;
        }

        /// <summary>
        /// 获取消息实体的标签
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// 获取消息实体的正文
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// 重写Equals方法，注意，标签相同就认为是同一个消息实体
        /// </summary>
        /// <param name="obj">比较的对象</param>
        /// <returns>比较的结果</returns>
        public override bool Equals(object obj)
        {
            var other = obj as SmartMessage;
            return other != null && other.Label == Label;
        }

        /// <summary>
        /// 重写GetHashCode，注意，以标签的哈希码为消息实体的哈希码
        /// </summary>
        /// <returns>哈希码</returns>
        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }
    }
}