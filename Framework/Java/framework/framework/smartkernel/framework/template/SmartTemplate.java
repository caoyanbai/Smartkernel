/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.template;

import java.util.*;

import smartkernel.framework.*;
import smartkernel.framework.io.*;
import smartkernel.framework.text.*;

/**
 * 模板生成器
 * 
 */
public class SmartTemplate {
	/*
	 * 生成
	 * 
	 * @param templet，模板
	 * 
	 * @param data，参数
	 * 
	 * @return，结果
	 */

	public static String generate(String templet, HashMap<String, String> data) {
		Set<String> set = data.keySet();
		for (String key : set) {
			String value = data.get(key);

			templet = SmartString.repeatReplace(templet,
					SmartString.format("@({0})", key), value);
		}

		return templet;
	}

	/*
	 * 生成
	 * 
	 * @param templet，模板
	 * 
	 * @param filePath，保存路径
	 * 
	 * @param data，参数
	 * 
	 * @param isOverWrite，是否覆盖
	 * 
	 * @param encoding，文件编码
	 * 
	 * @return，结果
	 */

	public static void generateFile(String templet, String filePath,
			HashMap<String, String> data, boolean isOverWrite, String encoding) {
		encoding = encoding == null ? SmartEncoding.Default : encoding;

		String code = generate(templet, data);
		if (isOverWrite) {
			// 覆盖
			SmartFile.delete(filePath);
			SmartFile.write(filePath, code, true, encoding);
		} else {
			// 不覆盖
			if (!SmartFile.exists(filePath)) {
				SmartFile.write(filePath, code, true, encoding);
			}
		}
	}

	/*
	 * 生成
	 * 
	 * @param templet，模板
	 * 
	 * @param filePath，保存路径
	 * 
	 * @param data，参数
	 * 
	 * @param isOverWrite，是否覆盖
	 * 
	 * 
	 * @return，结果
	 */

	public static void generateFile(String templet, String filePath,
			HashMap<String, String> data, boolean isOverWrite) {
		generateFile(templet, filePath, data, isOverWrite, null);
	}

	/*
	 * 生成
	 * 
	 * @param templet，模板
	 * 
	 * @param filePath，保存路径
	 * 
	 * @param data，参数
	 * 
	 * @return，结果
	 */

	public static void generateFile(String templet, String filePath,
			HashMap<String, String> data) {
		generateFile(templet, filePath, data, false, null);
	}
}
