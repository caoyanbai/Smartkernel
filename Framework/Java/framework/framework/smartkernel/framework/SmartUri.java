/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * 是否Uri
 * 
 */
public class SmartUri {
	/**
	 * 验证是不是Uri地址。注意，必须有http等协议开头的前缀，www.smartkernel.com是不能验证通过的
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isUri(String input) {
		String pattern = "^((http|https|ftp):\\/\\/[\\w\\-_]+(\\.[\\w\\-_]+)+([a-z])+([\\w\\-\\.,@?^=%&amp;:/~\\+#]*[\\w\\-\\@?^=%&amp;/~\\+#])?)$";
		return input.matches(pattern);
	}

	/**
	 * 验证是不是Uri地址。注意，不需要有前缀
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isUriWithoutProtocol(String input) {
		if (SmartString.isNullOrWhiteSpace(input)) {
			return false;
		}

		if (!input.toLowerCase().startsWith("http://")
				&& !input.toLowerCase().startsWith("https://")
				&& !input.toLowerCase().startsWith("ftp://")) {
			input = "http://" + input;
		}
		return isUri(input);
	}
}
