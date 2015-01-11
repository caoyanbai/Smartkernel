/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using OpenExcel.OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Smartkernel.Framework.Office
{
	/// <summary>
	/// Excel操作类
	/// </summary>
	public static class SmartExcel
	{
		/// <summary>
		/// 导出Excel（使用属性名称作为列头，顺序按定义顺序）
		/// </summary>
		/// <param name="items">数据项</param>
		/// <param name="outputFile">输出文件路径</param>
		/// <param name="sheetRowCount">每个表单的数据行数</param>
		/// <param name="sheetName">表单名称：支持{0}格式，{0}是表单序号</param>
		public static void ToExcel(List<object> items, string outputFile, int sheetRowCount = 50000, string sheetName = "Sheet{0}")
		{
			//使用items.GetType().GetGenericArguments()[0]获得的类型有误
			var linq = from column in SmartType.GetProperties(items.FirstOrDefault().GetType())
			                    select new KeyValuePair<string, string>(column.Name, column.Name);
			var columns = linq.ToList();
			var excelDocument = ExcelDocument.CreateWorkbook(outputFile);

			ToExcel(excelDocument, items, columns, sheetRowCount, sheetName);
		}

		/// <summary>
		/// 导出Excel
		/// </summary>
		/// <param name="items">数据项</param>
		/// <param name="columns">列头：顺序按列表顺序</param>
		/// <param name="outputFile">输出文件路径</param>
		/// <param name="sheetRowCount">每个表单的数据行数</param>
		/// <param name="sheetName">表单名称：支持{0}格式，{0}是表单序号</param>
		public static void ToExcel(List<object> items, List<KeyValuePair<string, string>> columns, string outputFile, int sheetRowCount = 50000, string sheetName = "Sheet{0}")
		{
			var excelDocument = ExcelDocument.CreateWorkbook(outputFile);

			ToExcel(excelDocument, items, columns, sheetRowCount, sheetName);
		}

		private static void ToExcel(ExcelDocument excelDocument, List<object> items, List<KeyValuePair<string, string>> columns, int sheetRowCount = 50000, string sheetName = "Sheet{0}")
		{
			//获得表单分页数量
			int sheetCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(items.Count) / Convert.ToDouble(sheetRowCount)));

			using (excelDocument)
			{
				//循环每个表单
				for (int sc = 0; sc < sheetCount; sc++)
				{
					ExcelWorksheet excelWorksheet = excelDocument.Workbook.Worksheets.Add(string.Format(sheetName, sc + 1));

					//写入列头
					for (int cc = 0; cc < columns.Count; cc++)
					{
						excelWorksheet.Cells[Convert.ToUInt32(1), Convert.ToUInt32(cc + 1)].Value = columns[cc].Value;
					}

					//循环写入数据
					for (int ic = sc * sheetRowCount; ic < (sc + 1) * sheetRowCount; ic++)
					{
						if (ic >= items.Count())
						{
							break;
						}

						var item = items[ic];
						var propertiesDictionary = SmartType.GetPropertiesDictionary(item);

						for (int vc = 0; vc < columns.Count; vc++)
						{
							var value = propertiesDictionary[columns[vc].Key];
							//行与列都是从1开始。另外一个加1是去掉列头缩在的行
							excelWorksheet.Cells[Convert.ToUInt32(ic - sc * sheetRowCount + 1 + 1), Convert.ToUInt32(vc + 1)].Value = value;
						}
					}
				}
			}
		}

		/// <summary>
		/// 导出Excel（使用属性名称作为列头，顺序按定义顺序）
		/// </summary>
		/// <param name="items">数据项</param>
		/// <param name="outputStream">输出流</param>
		/// <param name="sheetRowCount">每个表单的数据行数</param>
		/// <param name="sheetName">表单名称：支持{0}格式，{0}是表单序号</param>
		public static void ToExcel(List<object> items, Stream outputStream, int sheetRowCount = 50000, string sheetName = "Sheet{0}")
		{
			var linq = from column in SmartType.GetProperties(items.FirstOrDefault().GetType())
			                    select new KeyValuePair<string, string>(column.Name, column.Name);
			var columns = linq.ToList();
			var excelDocument = ExcelDocument.CreateWorkbook(outputStream);

			ToExcel(excelDocument, items, columns, sheetRowCount, sheetName);
		}

		/// <summary>
		/// 导出Excel
		/// </summary>
		/// <param name="items">数据项</param>
		/// <param name="outputStream">输出流</param>
		/// <param name="columns">列头：顺序按列表顺序</param>
		/// <param name="sheetRowCount">每个表单的数据行数</param>
		/// <param name="sheetName">表单名称：支持{0}格式，{0}是表单序号</param>
		public static void ToExcel(List<object> items, List<KeyValuePair<string, string>> columns, Stream outputStream, int sheetRowCount = 50000, string sheetName = "Sheet{0}")
		{
			var excelDocument = ExcelDocument.CreateWorkbook(outputStream);

			ToExcel(excelDocument, items, columns, sheetRowCount, sheetName);
		}
	}
}
