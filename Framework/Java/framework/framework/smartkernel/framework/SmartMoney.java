/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * 金钱
 * 
 */
public class SmartMoney {
	/**
	 * 金额转换为中文大写形式
	 * 
	 * @param money
	 *            ，金额
	 * @param isFixLength
	 *            ，是否固定长度，如果为false，将删除无效的零
	 * @return，中文大写形式
	 */
	public static String toChinese(double money, boolean isFixLength) {
		String result = "{17}仟{16}佰{15}拾{14}万{13}仟{12}佰{11}拾{10}億{9}仟{8}佰{7}拾{6}萬{5}仟{4}佰{3}拾{2}元{1}角{0}分";
		String format = SmartNumeric.toString(money, "#.00").replace(".", "");

		result = SmartString.format(result, splitToChinese(format, 0),
				splitToChinese(format, 1), splitToChinese(format, 2),
				splitToChinese(format, 3), splitToChinese(format, 4),
				splitToChinese(format, 5), splitToChinese(format, 6),
				splitToChinese(format, 7), splitToChinese(format, 8),
				splitToChinese(format, 9), splitToChinese(format, 10),
				splitToChinese(format, 11), splitToChinese(format, 12),
				splitToChinese(format, 13), splitToChinese(format, 14),
				splitToChinese(format, 15), splitToChinese(format, 16),
				splitToChinese(format, 17));
		if (!isFixLength) {
			result = SmartString.replace(result, new String[] { "零角", "零分" },
					"");
			result = SmartString
					.replace(result, new String[] { "零拾", "零佰", "零仟", "零万" },
							"零").replace("零萬", "萬").replace("零億", "億");
			result = SmartString.repeatReplace(result, "零元", "元");
			result = SmartString.repeatReplace(result, "零萬", "萬");
			result = SmartString.repeatReplace(result, "零億", "億");
			result = SmartString.repeatReplace(result, "零零", "零");
			result = result.replace("億萬", "億零");
			result = SmartString.trimStart(result, "億").replace("万", "萬");
			result = SmartString.repeatTrimStart(result, "零");
			return result;
		}
		return result.replace("万", "萬");
	}

	/**
	 * 金额转换为中文大写形式
	 * 
	 * @param money
	 *            ，金额
	 * @return，中文大写形式
	 */
	public static String toChinese(double money) {
		return toChinese(money, true);
	}

	private static String splitToChinese(String input, int index) {
		String[] result = new String[] { "零", "壹", "贰", "叁", "肆", "伍", "陆",
				"染", "捌", "玖" };
		if (index > input.length() - 1) {
			return "零";
		}
		return result[Integer.parseInt(String.valueOf(input.charAt(input
				.length() - 1 - index)))];
	}

	private static final SmartEnglishConverter englishConverter = new SmartEnglishConverter();

	/**
	 * 数值转换为英文形式
	 * 
	 * @param money
	 *            ，数量
	 * @return，英文形式
	 */
	public static String toEnglish(double money) {
		return englishConverter.convert(money);
	}

	/**
	 * 英文转换器
	 * 
	 */
	static class SmartEnglishConverter {
		private final String[] figs = new String[19];

		private final String[] tens = new String[9];

		private final String[] units = new String[8];

		/**
		 * 转换
		 * 
		 * @param number
		 *            ，数字
		 * @return，转换的结果
		 */
		public String convert(double number) {
			String left;
			String right;
			String temp;
			Init();
			String result = String.valueOf(SmartMath.round(number, 2));
			if (result.indexOf(".") == -1) {
				left = result;
				right = "";
			} else {
				left = SmartString.substringByLength(result, 0,
						result.indexOf("."));
				right = SmartString.substringByLength(result,
						result.indexOf(".") + 1,
						result.length() - result.indexOf(".") - 1);
			}
			if (left.length() > 12) {
				return null;
			}
			result = "";
			while (left.length() > 0) {
				int length = len(left);
				String current;
				if (length % 3 == 0) {
					current = left(left, 3);
					left = right(left, length - 3);
				} else {
					current = left(left, (length % 3));
					left = right(left, length - (length % 3));
				}
				int nbit = len(left) / 3;
				temp = decodeHundred(current);
				if ((left.equals(String.valueOf(len(left))) || nbit == 0)
						&& len(current) == 3) {
					if (Integer.valueOf(left(current, 1)) != 0
							& Integer.valueOf(right(current, 2)) != 0) {
						temp = left(temp, temp.indexOf(units[3])
								+ len(units[3]))
								+ units[7]
								+ " "
								+ right(temp,
										len(temp)
												- (temp.indexOf(units[3]) + len(units[3])));
					} else {
						temp = units[7] + " " + temp;
					}
				}
				if (nbit == 0) {
					result = String.valueOf(result + " " + temp).trim();
				} else {
					result = String.valueOf(
							result + " " + temp + " " + units[nbit - 1]).trim();
				}
				if (left(result, 3).endsWith(units[7])) {
					result = String.valueOf(right(result, len(result) - 3))
							.trim();
				}
				if (left.equals(String.valueOf(len(left)))) {
					return "";
				}
			}
			left = result;
			if (len(right) > 0) {
				right = units[5] + " " + decodeHundred(right) + " " + units[6];
			} else {
				right = units[4];
			}
			return (left + " " + right).toUpperCase();
		}

		private void Init() {
			if (figs[0] != "One") {
				figs[0] = "One";
				figs[1] = "Two";
				figs[2] = "Three";
				figs[3] = "Four";
				figs[4] = "Five";
				figs[5] = "Six";
				figs[6] = "Seven";
				figs[7] = "Eight";
				figs[8] = "Nine";
				figs[9] = "Ten";
				figs[10] = "Eleven";
				figs[11] = "Twelve";
				figs[12] = "Thirteen";
				figs[13] = "Fourteen";
				figs[14] = "Fifteen";
				figs[15] = "Sixteen";
				figs[16] = "Seventeen";
				figs[17] = "Eighteen";
				figs[18] = "Nineteen";
				tens[0] = "Ten";
				tens[1] = "Twenty";
				tens[2] = "Thirty";
				tens[3] = "Forty";
				tens[4] = "Fifty";
				tens[5] = "Sixty";
				tens[6] = "Seventy";
				tens[7] = "Eighty";
				tens[8] = "Ninety";
				units[0] = "Thousand";
				units[1] = "Million";
				units[2] = "Billion";
				units[3] = "Hundred";
				units[4] = "Only";
				units[5] = "Dollars and";
				units[6] = "Cent";
				units[7] = "";
			}
		}

		private String decodeHundred(String hundredString) {
			String rtn = "";
			if (len(hundredString) > 0 && len(hundredString) <= 3) {
				int tmp;
				switch (len(hundredString)) {
				case 1:
					tmp = Integer.valueOf(hundredString);
					if (tmp != 0) {
						rtn = figs[tmp - 1];
					}
					break;
				case 2:
					tmp = Integer.valueOf(hundredString);
					if (tmp != 0) {
						if ((tmp < 20)) {
							rtn = figs[tmp - 1];
						} else {
							rtn = Integer.valueOf(right(hundredString, 1)) == 0 ? tens[Integer
									.valueOf(tmp / 10) - 1]
									: String.valueOf(tens[Integer
											.valueOf(tmp / 10) - 1]
											+ " "
											+ figs[Integer.valueOf(right(
													hundredString, 1)) - 1]);
						}
					}
					break;
				case 3:
					rtn = Integer.valueOf(left(hundredString, 1)) != 0 ? String
							.valueOf(figs[Integer
									.valueOf(left(hundredString, 1)) - 1]
									+ " "
									+ units[3]
									+ "AND "
									+ decodeHundred(right(hundredString, 2)))
							: decodeHundred(right(hundredString, 2));
					break;
				default:
					break;
				}
			}
			return rtn;
		}

		private static String left(String str, int n) {
			return SmartString.substringByLength(str, 0, n);
		}

		private static String right(String str, int n) {
			return SmartString.substringByLength(str, str.length() - n, n);
		}

		private static int len(String str) {
			return str.length();
		}
	}
}
