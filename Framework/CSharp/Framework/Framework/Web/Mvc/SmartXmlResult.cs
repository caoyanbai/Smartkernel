/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Web.Mvc;

namespace Smartkernel.Framework.Web.Mvc
{
    /// <summary>
    /// Xml结果
    /// </summary>
    public class SmartXmlResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SmartXmlResult()
            : base()
        {
            this.ContentType = SmartMimeType.Xml;
        }
    }
}
