/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

import java.util.*;

import smartkernel.framework.*;

/**
 * Db时间类型
 * 
 */
public class SmartDbDateTime {
	/**
	 * 默认
	 */
	public static final Date Default = SmartDateTime
			.parse("1900-01-01 00:00:00");

	/**
	 * 开始时间
	 */
	public static final Date MinTime = SmartDateTime
			.parse("1753-01-01 00:00:00");

	/**
	 * 结束时间
	 */
	public static final Date MaxTime = SmartDateTime
			.parse("9999-12-31 23:59:59.997");

	/**
	 * 开始日期
	 */
	public static final Date MinDate = SmartDateTime
			.parse("1753-01-01 00:00:00");

	/**
	 * 结束日期
	 */
	public static final Date MaxDate = SmartDateTime
			.parse("9999-12-31 00:00:00");

	/**
	 * 是否合法的时间
	 * 
	 * @param dateTime
	 *            ，时间
	 * @return，结果
	 */
	public static boolean isLegalDateTime(Date dateTime) {
		if (dateTime.before(MinTime) || dateTime.after(MaxTime)) {
			return false;
		}

		return true;
	}
}
