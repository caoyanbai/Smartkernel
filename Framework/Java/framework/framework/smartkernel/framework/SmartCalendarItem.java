/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * 日历项
 * 
 */
public class SmartCalendarItem {
	private Date date;

	private int year;

	private int yearMonth;

	private int yearMonthDay;

	private int yearWeek;

	private int yearWeekDay;

	private int yearQuarter;

	private int yearQuarterDay;

	/**
	 * 日期
	 * 
	 * @return，日期
	 */
	public Date getDate() {
		return date;
	}

	/**
	 * 日期
	 * 
	 * @param date
	 *            ，日期
	 */
	public void setDate(Date date) {
		this.date = date;
	}

	/**
	 * 年
	 * 
	 * @return，年
	 */
	public int getYear() {
		return year;
	}

	/**
	 * 年
	 * 
	 * @param year
	 *            ，年
	 */
	public void setYear(int year) {
		this.year = year;
	}

	/**
	 * 年月
	 * 
	 * @return，年月
	 */
	public int getYearMonth() {
		return yearMonth;
	}

	/**
	 * 年月
	 * 
	 * @param yearMonth
	 *            ，年月
	 */
	public void setYearMonth(int yearMonth) {
		this.yearMonth = yearMonth;
	}

	/**
	 * 年月日
	 * 
	 * @return，年月日
	 */
	public int getYearMonthDay() {
		return yearMonthDay;
	}

	/**
	 * 年月日
	 * 
	 * @param yearMonthDay
	 *            ，年月日
	 */
	public void setYearMonthDay(int yearMonthDay) {
		this.yearMonthDay = yearMonthDay;
	}

	/**
	 * 年周
	 * 
	 * @return，年周
	 */
	public int getYearWeek() {
		return yearWeek;
	}

	/**
	 * 年周
	 * 
	 * @param yearWeek
	 *            ，年周
	 */
	public void setYearWeek(int yearWeek) {
		this.yearWeek = yearWeek;
	}

	/**
	 * 年周日
	 * 
	 * @return，年周日
	 */
	public int getYearWeekDay() {
		return yearWeekDay;
	}

	/**
	 * 年周日
	 * 
	 * @param yearWeekDay
	 *            ，年周日
	 */
	public void setYearWeekDay(int yearWeekDay) {
		this.yearWeekDay = yearWeekDay;
	}

	/**
	 * 年季
	 * 
	 * @return，年季
	 */
	public int getYearQuarter() {
		return yearQuarter;
	}

	/**
	 * 年季
	 * 
	 * @param yearQuarter
	 *            ，年季
	 */
	public void setYearQuarter(int yearQuarter) {
		this.yearQuarter = yearQuarter;
	}

	/**
	 * 年季日
	 * 
	 * @return，年季日
	 */
	public int getYearQuarterDay() {
		return yearQuarterDay;
	}

	/**
	 * 年季日
	 * 
	 * @param yearQuarterDay
	 *            ，年季日
	 */
	public void setYearQuarterDay(int yearQuarterDay) {
		this.yearQuarterDay = yearQuarterDay;
	}
}
