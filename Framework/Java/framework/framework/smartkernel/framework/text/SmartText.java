/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.text;

import java.io.*;
import java.util.*;
import java.util.regex.*;

import smartkernel.framework.*;
import net.sourceforge.pinyin4j.*;
import net.sourceforge.pinyin4j.format.*;
import net.sourceforge.pinyin4j.format.exception.*;

/**
 * 文本
 * 
 */
public class SmartText {
	/**
	 * 汉字转化为拼音
	 * 
	 * @param input
	 *            ，汉字
	 * @return，全拼
	 */
	public static String getPinyin(String input) {
		char[] t1 = null;
		t1 = input.toCharArray();
		String[] t2 = new String[t1.length];
		HanyuPinyinOutputFormat t3 = new HanyuPinyinOutputFormat();
		t3.setCaseType(HanyuPinyinCaseType.LOWERCASE);
		t3.setToneType(HanyuPinyinToneType.WITHOUT_TONE);
		t3.setVCharType(HanyuPinyinVCharType.WITH_V);
		String t4 = "";
		int t0 = t1.length;
		try {
			for (int i = 0; i < t0; i++) {
				// 判断是否为汉字字符
				if (java.lang.Character.toString(t1[i]).matches(
						"[\\u4E00-\\u9FA5]+")) {
					t2 = PinyinHelper.toHanyuPinyinStringArray(t1[i], t3);
					t4 += t2[0];
				} else {
					t4 += java.lang.Character.toString(t1[i]);
				}
			}
			return t4;
		} catch (BadHanyuPinyinOutputFormatCombination e1) {
			e1.printStackTrace();
		}
		return t4;
	}

	/**
	 * 汉字转化为拼音首字母
	 * 
	 * @param input
	 *            ，汉字
	 * @return，首字母
	 */
	public static String getInitialPinyin(String input) {
		String r = "";
		char[] chars = input.toCharArray();

		for (char obj : chars) {
			try {
				String t = getPinyin(String.valueOf(obj));
				r += t.substring(0, 1);
			} catch (Exception exception) {
				r += String.valueOf(obj);
			}
		}
		return r;
	}

	/**
	 * 转换为半角格式（英文标点格式）
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换之后的结果
	 */
	public static String toDbc(String input) {
		// 转半角(DBC case)
		// 全角空格为12288，半角空格为32
		// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
		char[] chars = input.toCharArray();
		for (int i = 0; i < chars.length; i++) {
			if (chars[i] == 12288) {
				chars[i] = (char) 32;
				continue;
			}
			if (chars[i] == 12290) {
				chars[i] = (char) 46;
				continue;
			}
			if (chars[i] > 65280 && chars[i] < 65375) {
				chars[i] = (char) (chars[i] - 65248);
			}
		}
		String result = new String(chars);
		result = result.replace("。", ".");
		return result;
	}

	/**
	 * 转换为全角格式（中文标点格式）
	 * 
	 * @param input
	 *            ，待转换的字符串
	 * @return，转换之后的结果
	 */
	public static String toSbc(String input) {
		// 转全角(SBC case)
		// 全角空格为12288，半角空格为32
		// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
		char[] chars = input.toCharArray();
		for (int i = 0; i < chars.length; i++) {
			if (chars[i] == 32) {
				chars[i] = (char) 12288;
				continue;
			}
			if (chars[i] == 46) {
				chars[i] = (char) 12290;
				continue;
			}
			if (chars[i] < 127) {
				chars[i] = (char) (chars[i] + 65248);
			}
		}
		String result = new String(chars);
		result = result.replace(".", "。");
		return result;
	}

	/**
	 * 把多行文档转换为多行列表
	 * 
	 * @param input
	 *            ，输入项
	 * @return，转换的结果
	 */
	public static ArrayList<String> toLines(String input) {
		if (SmartString.isNullOrEmpty(input)) {
			return new ArrayList<String>();
		}

		try (StringReader reader = new StringReader(input)) {
			try (BufferedReader bufferedReader = new BufferedReader(reader)) {
				String currentLine = bufferedReader.readLine();
				ArrayList<String> lines = new ArrayList<String>();
				while (currentLine != null) {
					lines.add(currentLine);
					currentLine = bufferedReader.readLine();
				}
				return lines;
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 获得单词的重复数量
	 * 
	 * @param input
	 *            ，输入的字符串
	 * @param word
	 *            ，单词
	 * @param regexOptions
	 *            ，匹配选项
	 * @return，重复数量
	 */
	public static int getWordRepeatCount(String input, String word,
			int regexOptions) {
		Pattern pattern = Pattern.compile("\\b(" + word + ")\\b", regexOptions);
		Matcher matcher = pattern.matcher(input);
		int i = 0;
		while (matcher.find()) {
			matcher.group(0);
			i++;
		}
		return i;
	}

	/**
	 * 获得单词的重复数量
	 * 
	 * @param input
	 *            ，输入的字符串
	 * @param word
	 *            ，单词
	 * @return，重复数量
	 */
	public static int getWordRepeatCount(String input, String word) {
		return getWordRepeatCount(input, word, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 获得字符串的重复数量
	 * 
	 * @param input
	 *            ，输入的字符串
	 * @param str
	 *            ，字符串
	 * @param regexOptions
	 *            ，匹配选项
	 * @return，重复数量
	 */
	public static int getStringRepeatCount(String input, String str,
			int regexOptions) {
		Pattern pattern = Pattern.compile("(" + str + ")", regexOptions);
		Matcher matcher = pattern.matcher(input);
		int i = 0;
		while (matcher.find()) {
			matcher.group(0);
			i++;
		}
		return i;
	}

	/**
	 * 获得字符串的重复数量
	 * 
	 * @param input
	 *            ，输入的字符串
	 * @param str
	 *            ，字符串
	 * @return，重复数量
	 */
	public static int getStringRepeatCount(String input, String str) {
		return getWordRepeatCount(input, str, Pattern.CASE_INSENSITIVE);
	}

	/**
	 * 获得字符串中重复的单词
	 * 
	 * @param input，输入的字符串
	 * @param regexOptions，匹配选项
	 * @return，重复字符串的列表（并带有每个字符串的数量）
	 */
	public static HashMap<String, Integer> getRepeatWords(String input,
			int regexOptions) {
		ArrayList<String> list = new ArrayList<String>();
		HashMap<String, Integer> dictionary = new HashMap<String, Integer>();

		Pattern pattern = Pattern.compile(
				"('\\w+)|(\\w+'\\w+)|(\\w+')|(\\w+)", regexOptions);
		Matcher matcher = pattern.matcher(input);
		while (matcher.find()) {
			String word = matcher.group(0);
			if (regexOptions == Pattern.CASE_INSENSITIVE) {
				word = word.toLowerCase();
			}
			if (!list.contains(word)) {
				list.add(word);
			}
			for (String key : list) {
				int value = getWordRepeatCount(input, key, regexOptions);
				dictionary.put(key, value);
			}
		}
		return dictionary;
	}
}
