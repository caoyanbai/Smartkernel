/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

import java.util.*;

import smartkernel.framework.*;
import smartkernel.framework.web.*;

/**
 * 数据库操作
 * 
 */
public class SmartDatabase {
	private static final String sqlCommandKeywords = "and|exec|execute|insert|select|delete|update|count|chr|mid|master|"
			+ "char|declare|sitename|net user|xp_cmdshell|or|create|drop|table|from|grant|use|group_concat|column_name|"
			+ "information_schema.columns|table_schema|union|where|select|delete|update|orderhaving|having|by|count|*|truncate|like";

	private static final String sqlSeparatKeywords = "'|;|,|--|\'|\"|/*|%|#";

	private static final ArrayList<String> sqlKeywordsArray = new ArrayList<String>();

	/**
	 * 静态构造函数
	 * 
	 */
	static {
		String[] sqlSeparatKeywordsArray = sqlSeparatKeywords.split("\\|");
		for (String item : sqlSeparatKeywordsArray) {
			sqlKeywordsArray.add(item);
		}
		String[] sqlCommandKeywordsArray = sqlCommandKeywords.split("\\|");
		for (String item : sqlCommandKeywordsArray) {
			sqlKeywordsArray.add(item + " ");
			sqlKeywordsArray.add(" " + item);
		}
	}

	/**
	 * 是否安全
	 * 
	 * @param input
	 *            ，输入
	 * @return，返回
	 */
	public static boolean isSafetySql(String input) {
		if (SmartString.isNullOrWhiteSpace(input)) {
			return true;
		}
		input = (SmartHttpUtility.urlDecode(input)).toLowerCase();

		for (String sqlKeyword : sqlKeywordsArray) {
			if (input.indexOf(sqlKeyword) >= 0) {
				return false;
			}
		}
		return true;
	}

	/**
	 * 返回安全字符串
	 * 
	 * @param input
	 *            ，输入
	 * @return，返回
	 */
	public static String getSafetySql(String input) {
		if (SmartString.isNullOrEmpty(input)) {
			return "";
		}
		input = (SmartHttpUtility.urlDecode(input)).toLowerCase();

		for (String sqlKeyword : sqlKeywordsArray) {
			if (input.indexOf(sqlKeyword) >= 0) {
				input = input.replace(sqlKeyword, "");
			}
		}
		return input;
	}
}
