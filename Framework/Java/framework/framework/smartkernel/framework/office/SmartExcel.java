/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.office;

import java.io.*;
import java.lang.reflect.*;
import java.util.*;

import org.apache.poi.hssf.usermodel.*;

import smartkernel.framework.*;
import smartkernel.framework.collections.*;

/**
 * Excel操作类
 *
 */
public class SmartExcel {

	/**
	 * 导出Excel（使用属性名称作为列头，顺序按定义顺序）
	 * 
	 * @param items
	 *            ，数据项
	 * @param outputFile
	 *            ，输出文件路径
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 * @param sheetName
	 *            ，表单名称：支持{0}格式，{0}是表单序号
	 */
	public static void toExcel(ArrayList<Object> items, String outputFile,
			int sheetRowCount, String sheetName) {
		ArrayList<SmartKeyValuePair<String, String>> columns = new ArrayList<SmartKeyValuePair<String, String>>();
		Field[] fields = SmartType.getFields(items.get(0).getClass());
		for (Field field : fields) {
			columns.add(new SmartKeyValuePair<String, String>(field.getName(),
					field.getName()));
		}
		HSSFWorkbook excelDocument = new HSSFWorkbook();
		toExcel(excelDocument, items, columns, sheetRowCount, sheetName);

		try (FileOutputStream fileOutputStream = new FileOutputStream(
				outputFile)) {
			excelDocument.write(fileOutputStream);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 导出Excel（使用属性名称作为列头，顺序按定义顺序）
	 * 
	 * @param items
	 *            ，数据项
	 * @param outputFile
	 *            ，输出文件路径
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 */
	public static void toExcel(ArrayList<Object> items, String outputFile,
			int sheetRowCount) {
		toExcel(items, outputFile, sheetRowCount, "Sheet{0}");
	}

	/**
	 * 导出Excel（使用属性名称作为列头，顺序按定义顺序）
	 * 
	 * @param items
	 *            ，数据项
	 * @param outputFile
	 *            ，输出文件路径
	 */
	public static void toExcel(ArrayList<Object> items, String outputFile) {
		toExcel(items, outputFile, 50000, "Sheet{0}");
	}
	
	/**
	 * 导出Excel
	 * 
	 * @param items
	 *            ，数据项
	 * @param columns
	 *            ，列头：顺序按列表顺序
	 * @param outputFile
	 *            ，输出文件路径
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 * @param sheetName
	 *            ，表单名称：支持{0}格式，{0}是表单序号
	 */
	public static void toExcel(ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			String outputFile, int sheetRowCount, String sheetName) {

		HSSFWorkbook excelDocument = new HSSFWorkbook();
		toExcel(excelDocument, items, columns, sheetRowCount, sheetName);

		try (FileOutputStream fileOutputStream = new FileOutputStream(
				outputFile)) {
			excelDocument.write(fileOutputStream);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 导出Excel
	 * 
	 * @param items
	 *            ，数据项
	 * @param columns
	 *            ，列头：顺序按列表顺序
	 * @param outputFile
	 *            ，输出文件路径
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 */
	public static void toExcel(ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			String outputFile, int sheetRowCount) {
		toExcel(items, columns, outputFile, sheetRowCount, "Sheet{0}");
	}

	/**
	 * 导出Excel
	 * 
	 * @param items
	 *            ，数据项
	 * @param columns
	 *            ，列头：顺序按列表顺序
	 * @param outputFile
	 *            ，输出文件路径
	 */
	public static void toExcel(ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			String outputFile) {
		toExcel(items, columns, outputFile, 50000, "Sheet{0}");
	}

	private static void toExcel(HSSFWorkbook excelDocument,
			ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			int sheetRowCount, String sheetName) {
		// 获得表单分页数量
		int sheetCount = (int) Math.ceil((double) items.size()
				/ (double) sheetRowCount);

		// 循环每个表单
		for (int sc = 0; sc < sheetCount; sc++) {
			HSSFSheet excelWorksheet = excelDocument.createSheet(SmartString
					.format(sheetName, sc + 1));

			HSSFRow headerRow = excelWorksheet.createRow(0);
			// 写入列头
			for (int cc = 0; cc < columns.size(); cc++) {
				HSSFCell cell = headerRow.createCell(cc);
				cell.setCellValue(columns.get(cc).getValue());
			}

			// 循环写入数据
			for (int ic = sc * sheetRowCount; ic < (sc + 1) * sheetRowCount; ic++) {
				if (ic >= items.size()) {
					break;
				}

				Object item = items.get(ic);
				HashMap<String, Object> propertiesDictionary = SmartType
						.getFieldsDictionary(item);
				HSSFRow dataRow = excelWorksheet.createRow(ic - sc
						* sheetRowCount + 1);
				for (int vc = 0; vc < columns.size(); vc++) {
					Object value = propertiesDictionary.get(columns.get(vc)
							.getKey());
					// 行与列都是从0开始。另外一个加1是去掉列头缩在的行
					HSSFCell cell = dataRow.createCell(vc);
					cell.setCellValue(value.toString());
				}
			}
		}
	}
	
	/**
	 * 导出Excel（使用属性名称作为列头，顺序按定义顺序）
	 * 
	 * @param items
	 *            ，数据项
	 * @param outputStream
	 *            ，输出流
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 * @param sheetName
	 *            ，表单名称：支持{0}格式，{0}是表单序号
	 */
	public static void toExcel(ArrayList<Object> items, OutputStream outputStream,
			int sheetRowCount, String sheetName) {
		ArrayList<SmartKeyValuePair<String, String>> columns = new ArrayList<SmartKeyValuePair<String, String>>();
		Field[] fields = SmartType.getFields(items.get(0).getClass());
		for (Field field : fields) {
			columns.add(new SmartKeyValuePair<String, String>(field.getName(),
					field.getName()));
		}
		HSSFWorkbook excelDocument = new HSSFWorkbook();
		toExcel(excelDocument, items, columns, sheetRowCount, sheetName);

		try {
			excelDocument.write(outputStream);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}	
	}

	/**
	 * 导出Excel（使用属性名称作为列头，顺序按定义顺序）
	 * 
	 * @param items
	 *            ，数据项
	 * @param outputStream
	 *            ，输出流
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 */
	public static void toExcel(ArrayList<Object> items, OutputStream outputStream,
			int sheetRowCount) {
		toExcel(items, outputStream, sheetRowCount, "Sheet{0}");
	}

	/**
	 * 导出Excel（使用属性名称作为列头，顺序按定义顺序）
	 * 
	 * @param items
	 *            ，数据项
	 * @param outputStream
	 *            ，输出流
	 */
	public static void toExcel(ArrayList<Object> items, OutputStream outputStream) {
		toExcel(items, outputStream, 50000, "Sheet{0}");
	}
	
	/**
	 * 导出Excel
	 * 
	 * @param items
	 *            ，数据项
	 * @param columns
	 *            ，列头：顺序按列表顺序
	 * @param outputStream
	 *            ，输出流
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 * @param sheetName
	 *            ，表单名称：支持{0}格式，{0}是表单序号
	 */
	public static void toExcel(ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			OutputStream outputStream, int sheetRowCount, String sheetName) {

		HSSFWorkbook excelDocument = new HSSFWorkbook();
		toExcel(excelDocument, items, columns, sheetRowCount, sheetName);

		try {
			excelDocument.write(outputStream);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}	
	}

	/**
	 * 导出Excel
	 * 
	 * @param items
	 *            ，数据项
	 * @param columns
	 *            ，列头：顺序按列表顺序
	 * @param outputStream
	 *            ，输出流
	 * @param sheetRowCount
	 *            ，每个表单的数据行数
	 */
	public static void toExcel(ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			OutputStream outputStream, int sheetRowCount) {
		toExcel(items, columns, outputStream, sheetRowCount, "Sheet{0}");
	}

	/**
	 * 导出Excel
	 * 
	 * @param items
	 *            ，数据项
	 * @param columns
	 *            ，列头：顺序按列表顺序
	 * @param outputStream
	 *            ，输出流
	 */
	public static void toExcel(ArrayList<Object> items,
			ArrayList<SmartKeyValuePair<String, String>> columns,
			OutputStream outputStream) {
		toExcel(items, columns, outputStream, 50000, "Sheet{0}");
	}
}
