/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Text;
using System.Web;
using Smartkernel.Framework.Text;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// 响应
    /// </summary>
    public static class SmartResponse
    {
        /// <summary>
        /// 输出文件功能
        /// </summary>
        /// <param name="fileName">下载文件显示的文件名，注意，一般不要用中文</param>
        /// <param name="filePath">文件的虚拟路径</param>
        /// <param name="encoding">文件内容的编码</param>
        public static void OutputVirtualFileToFile(string fileName, string filePath, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;
            var response = HttpContext.Current.Response;
            response.ContentEncoding = encoding;
            response.ContentType = "application/octet-stream";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            response.Clear();
            response.WriteFile(filePath);
            response.End();
        }

        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="html">要导出的html内容</param>
        /// <param name="fileName">文件名</param>
        /// <param name="contentType">内容类型</param>
        /// <param name="encoding">编码格式</param>
        public static void OutputContentToFile(string html, string fileName = "file.doc", string contentType = "application/ms-word", string encoding = "GB2312")
        {
            var encodeFileName = HttpUtility.UrlEncode(fileName, Encoding.GetEncoding(encoding));

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(string.Format("<meta http-equiv=Content-Type content=text/html;charset={0}>", encoding));
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", encodeFileName));
            HttpContext.Current.Response.Charset = encoding;
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding(encoding);
            HttpContext.Current.Response.ContentType = contentType;
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();
        }
    }
}
