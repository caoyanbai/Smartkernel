/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * 断言
 * 
 */
public class SmartAssert {
	/**
	 * 判断是否为True，不为True则抛出异常
	 * 
	 * @param input
	 *            ，待判断项目
	 */
	public static void isTrue(boolean input) {
		if (!input) {
			throw new RuntimeException();
		}
	}

	/**
	 * 判断是否为False，不为False则抛出异常
	 * 
	 * @param input
	 *            ，待判断项目
	 */
	public static void isFalse(boolean input) {
		if (input) {
			throw new RuntimeException();
		}
	}

	/**
	 * 判断是否相等，不相等则抛出异常
	 * 
	 * @param left
	 *            ，左对象
	 * @param right
	 *            ，右对象
	 */
	public static void isEquals(Object left, Object right) {
		if (!left.equals(right)) {
			throw new RuntimeException();
		}
	}

	/**
	 * 判断是否不相等，相等则抛出异常
	 * 
	 * @param left
	 *            ，左对象
	 * @param right
	 *            ，右对象
	 */
	public static void isNotEquals(Object left, Object right) {
		if (left.equals(right)) {
			throw new RuntimeException();
		}
	}

	/**
	 * 判断是否为Null，不为Null则抛出异常
	 * 
	 * @param input
	 *            ，待判断项目
	 */
	public static void isNull(Object input) {
		if (input != null) {
			throw new RuntimeException();
		}
	}

	/**
	 * 判断是否不为Null，为Null则抛出异常
	 * 
	 * @param input
	 *            ，待判断项目
	 */
	public static void isNotNull(Object input) {
		if (input == null) {
			throw new RuntimeException();
		}
	}
}
