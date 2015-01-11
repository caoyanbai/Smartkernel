/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * Guid
 * 
 */
public class SmartGuid {
	/**
	 * 产生Guid
	 * 
	 * @return，结果
	 */
	public static String newGuid() {
		return UUID.randomUUID().toString().replace("-", "");
	}

	/**
	 * 判断是否是Guid
	 * 
	 * @param guid
	 *            ，guid的字符串表示形式
	 * @return，判断的结果
	 */
	public static boolean isGuid(String guid) {
		return guid.matches("[a-fA-F0-9]{32}");
	}
}
