/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Smartkernel.Framework.Web.Mvc
{
    /// <summary>
    /// Excel文件（Html方式）
    /// </summary>
    public class SmartExcelHtmlFileResult : ActionResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">内容</param>
        /// <param name="encoding">编码</param>
        public SmartExcelHtmlFileResult(string fileName, string content, Encoding encoding = null)
        {
            this.FileName = fileName;
            this.Content = content;
            if (encoding == null)
            {
                this.Encoding = SmartEncoding.Default;
            }
            else
            {
                this.Encoding = encoding;
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        //如果只输出内容而不是整个页面，则会出现乱码
        //即使是完整的Html，如果没有meta的情况下，保存后打开不乱码，而直接打开乱码
        private static string html = @"
                        <!DOCTYPE html>

                        <html>
                        <head>
                            <title>Excel</title>
                            <meta http-equiv=Content-Type content='text/html; charset=utf-8' />
                        </head>
                        <body>
                            <div>
                                {0}
                            </div>
                        </body>
                        </html>
                        ";

        /// <summary>
        /// 重写ExecuteResult
        /// </summary>
        /// <param name="context">上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;

            response.Buffer = false;
            response.ClearContent();
            //如果文件名不编码，中文情况下会出现乱码
            response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(FileName, this.Encoding));
            response.ContentType = "application/vnd.ms-excel";
            response.HeaderEncoding = this.Encoding;
            response.ContentEncoding = this.Encoding;
            response.Charset = this.Encoding.WebName;
            response.Write(string.Format(html, Content));
            response.End();
        }
    }
}
