/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.office;

import java.lang.reflect.*;
import java.util.*;

import javax.sql.rowset.CachedRowSet;

import smartkernel.framework.*;
import smartkernel.framework.computer.*;

/**
 * Csv
 * 
 */
public class SmartCsv {
	/**
	 * 转换为Csv
	 * 
	 * @param rows
	 *            ，列表
	 * @return，结果
	 */
	public static String toCsv(ArrayList<Object> rows) {
		StringBuilder result = new StringBuilder();

		if (rows == null || rows.size() == 0) {
			return "";
		}

		Field[] properties = SmartType.getFields(rows.get(0).getClass());

		for (int i = 0; i < properties.length; i++) {
			Field property = properties[i];
			property.setAccessible(true);

			if (i == properties.length - 1) {
				result.append("\"" + property.getName() + "\""
						+ SmartComputer.LineSeparator);
			} else {
				result.append("\"" + property.getName() + "\"" + ",");
			}
		}

		int j = 0;

		for (Object item : rows) {
			j++;
			for (int i = 0; i < properties.length; i++) {
				Field property = properties[i];
				property.setAccessible(true);
				try {
					if (i == properties.length - 1) {
						if (j == rows.size()) {
							result.append("\""
									+ property.get(item).toString()
											.replace("\"", "\"\"") + "\"");
						} else {
							result.append("\""
									+ property.get(item).toString()
											.replace("\"", "\"\"") + "\""
									+ SmartComputer.LineSeparator);
						}
					} else {
						result.append("\""
								+ property.get(item).toString()
										.replace("\"", "\"\"") + "\"" + ",");
					}
				} catch (Exception err) {
					throw new RuntimeException(err);
				}
			}
		}

		return result.toString();
	}

	/**
	 * 转换为Csv
	 * 
	 * @param rows
	 *            ，列表
	 * @return，结果
	 */
	public static String toCsv(CachedRowSet rows) {
		StringBuilder result = new StringBuilder();

		try {
			if (rows == null) {
				return "";
			}

			int columnCount = rows.getMetaData().getColumnCount();

			for (int i = 1; i < columnCount + 1; i++) {
				String columnName = rows.getMetaData().getColumnName(i);

				if (i == columnCount) {
					result.append("\"" + columnName + "\""
							+ SmartComputer.LineSeparator);
				} else {
					result.append("\"" + columnName + "\"" + ",");
				}
			}

			while (rows.next()) {

				for (int i = 1; i < columnCount + 1; i++) {

					if (i == columnCount) {
						if (rows.isLast()) {
							result.append("\""
									+ rows.getObject(i).toString()
											.replace("\"", "\"\"") + "\"");
						} else {
							result.append("\""
									+ rows.getObject(i).toString()
											.replace("\"", "\"\"") + "\""
									+ SmartComputer.LineSeparator);
						}
					} else {
						result.append("\""
								+ rows.getObject(i).toString()
										.replace("\"", "\"\"") + "\"" + ",");
					}
				}
			}

			return result.toString();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
