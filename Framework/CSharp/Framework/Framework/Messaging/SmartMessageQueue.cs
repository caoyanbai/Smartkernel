/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Messaging;

namespace Smartkernel.Framework.Messaging
{
    /// <summary>
    /// 提供对消息队列的常用操作
    /// </summary>
    public class SmartMessageQueue
    {
        /// <summary>
        /// 向消息队列发送一个消息
        /// </summary>
        /// <param name="address">地址，例如：FormatName:Direct=OS:.\private$\SKMQDEMO</param>
        /// <param name="message">消息实体</param>
        public static void Send(string address, SmartMessage message)
        {
            //创建一个消息
            using (var tempMessage = new Message())
            {
                tempMessage.Label = message.Label;
                tempMessage.Body = message.Body;

                //保存消息到队列中
                using (var messageQueue = new MessageQueue(address))
                {
                    messageQueue.Send(tempMessage);
                }
            }
        }

        /// <summary>
        /// 从消息队列取出一个消息，并移除消息
        /// </summary>
        /// <param name="address">地址，例如：FormatName:Direct=OS:.\private$\SKMQDEMO</param>
        /// <returns>返回消息实体</returns>
        public static SmartMessage Receive(string address)
        {
            SmartMessage message;
            //取出一个消息进行处理
            using (var messageQueue = new MessageQueue(address))
            {
                ((XmlMessageFormatter) messageQueue.Formatter).TargetTypeNames = new string[] {typeof (string).ToString()};
                var tempMessage = messageQueue.Receive();
                message = new SmartMessage(tempMessage.Label, tempMessage.Body.ToString());
            }
            return message;
        }

        /// <summary>
        /// 从消息队列取出一个消息，不移除消息
        /// </summary>
        /// <param name="address">地址，例如：FormatName:Direct=OS:.\private$\SKMQDEMO</param>
        /// <returns>返回消息实体</returns>
        public static SmartMessage Peek(string address)
        {
            SmartMessage message;
            //取出一个消息进行处理
            using (var messageQueue = new MessageQueue(address))
            {
                ((XmlMessageFormatter) messageQueue.Formatter).TargetTypeNames = new string[] {typeof (string).ToString()};
                var tempMessage = messageQueue.Peek();
                message = new SmartMessage(tempMessage.Label, tempMessage.Body.ToString());
            }
            return message;
        }
    }
}