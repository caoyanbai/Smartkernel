/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * HashCode
 * 
 */
public class SmartHashCode {
	/**
	 * 获得哈希值
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static int getHashCode(String input) {
		int length = input.length();
		int hashCode = 0;
		for (int i = 0; i < length; i++) {
			hashCode = (int) (hashCode * 31 + Integer.valueOf(input.charAt(i)));
			if ((hashCode & 0x80000000) == 0) {
				hashCode &= 0x7fffffff;
			} else {
				hashCode = (int) ((hashCode & 0x7fffffff) - 2147483648l);
			}
		}
		return hashCode;
	}
}
