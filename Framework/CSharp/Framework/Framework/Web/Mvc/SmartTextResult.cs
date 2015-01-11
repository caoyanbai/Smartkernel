/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Web.Mvc;

namespace Smartkernel.Framework.Web.Mvc
{
    /// <summary>
    /// Text结果
    /// </summary>
    public class SmartTextResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SmartTextResult()
            : base()
        {
            this.ContentType = SmartMimeType.Text;
        }
    }
}
