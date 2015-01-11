/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Web.Mvc;

namespace Smartkernel.Framework.Web.Mvc
{
    /// <summary>
    /// Json结果
    /// </summary>
    public class SmartJsonResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SmartJsonResult()
            : base()
        {
            this.ContentType = SmartMimeType.Json;
        }
    }
}
