/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Office;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Smartkernel.Framework.Text;

namespace Smartkernel.Framework.Web.Mvc
{
    /// <summary>
    /// Csv文件结果
    /// </summary>
    public class SmartCsvFileResult : ContentResult
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">数据</param>
        /// <param name="fileName">文件名</param>
        public SmartCsvFileResult(List<dynamic> rows, string fileName = "Export")
            : base()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
            this.Content = SmartCsv.ToCsv(rows);
            this.ContentType = SmartMimeType.Csv;
            this.ContentEncoding = SmartEncoding.Default;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">数据</param>
        /// <param name="fileName">文件名</param>
        public SmartCsvFileResult(DataTable rows, string fileName = "Export")
            : base()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
            this.Content = SmartCsv.ToCsv(rows);
            this.ContentType = SmartMimeType.Csv;
            this.ContentEncoding = SmartEncoding.Default;
        }
    }
}
