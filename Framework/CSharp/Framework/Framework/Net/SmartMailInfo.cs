/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using LumiSoft.Net.Mail;
using LumiSoft.Net.MIME;

namespace Smartkernel.Framework.Net
{
    /// <summary>
    /// 邮件内容实体类
    /// </summary>
    public class SmartMailInfo
    {
        private readonly Mail_Message mime;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mime">Mime类型</param>
        public SmartMailInfo(Mail_Message mime)
        {
            this.mime = mime;
        }

        /// <summary>
        /// 获取邮件正文
        /// </summary>
        public string HtmlBody { get { return mime.BodyHtmlText; } }

        /// <summary>
        /// 获取邮件来源地址
        /// </summary>
        public string From { get { return mime.From.ToString(); } }

        /// <summary>
        /// 获取邮件的附件
        /// </summary>
        public MIME_Entity[] Attachments { get { return mime.Attachments; } }

        /// <summary>
        /// 获取邮件发送时间
        /// </summary>
        public DateTime Date { get { return mime.Date; } }

        /// <summary>
        /// 获取邮件标题
        /// </summary>
        public string Subject { get { return mime.Subject; } }
    }
}