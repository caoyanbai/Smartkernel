/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Office;
using Smartkernel.Framework.Text;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Smartkernel.Framework.Web.Mvc
{
    /// <summary>
    /// Excel文件（Xml方式）
    /// </summary>
    public class SmartExcelXmlFileResult : ActionResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="items">数据</param>
        /// <param name="sheetRowCount">每个表单的数据行数</param>
        /// <param name="sheetName">表单名称：支持{0}格式，{0}是表单序号</param>
        /// <param name="columns">列头：以对象属性为键，为名称为值。顺序按列表顺序。如果为null或为空，则取对象的属性名</param>
        /// <param name="encoding">编码</param>
        public SmartExcelXmlFileResult(string fileName, List<object> items, int sheetRowCount, string sheetName, List<KeyValuePair<string, string>> columns, Encoding encoding = null)
        {
            this.FileName = fileName;
            this.Items = items;
            this.SheetRowCount = sheetRowCount;
            this.SheetName = sheetName;
            this.Columns = columns;
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
        /// 数据
        /// </summary>
        public List<object> Items { get; set; }

        /// <summary>
        /// 每个表单的数据行数
        /// </summary>
        public int SheetRowCount { get; set; }

        /// <summary>
        /// 表单名称：支持{0}格式，{0}是表单序号
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// 列头：以对象属性为键，为名称为值。顺序按列表顺序。如果为null或为空，则取对象的属性名
        /// </summary>
        public List<KeyValuePair<string, string>> Columns { get; set; }

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
            response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(this.FileName, this.Encoding));
            response.ContentType = "application/vnd.ms-excel.sheet.binary.macroEnabled.12";
            response.HeaderEncoding = this.Encoding;
            response.ContentEncoding = this.Encoding;
            response.Charset = this.Encoding.WebName;

            if (this.Items != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    if (this.Columns != null && this.Columns.Count > 0)
                    {
                        SmartExcel.ToExcel(this.Items, this.Columns, memoryStream, this.SheetRowCount, this.SheetName);
                    }
                    else
                    {
                        SmartExcel.ToExcel(this.Items, memoryStream, this.SheetRowCount, this.SheetName);
                    }
                    memoryStream.Position = 0;
                    memoryStream.WriteTo(response.OutputStream);
                    response.Flush();
                }
            }

            response.End();
        }
    }
}
