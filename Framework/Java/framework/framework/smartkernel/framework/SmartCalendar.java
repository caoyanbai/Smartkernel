/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.*;

/**
 * 日历
 * 
 */
public class SmartCalendar {
	/**
	 * 获得一项
	 * 
	 * @param dateTime
	 *            ，日期
	 * @return，结果
	 */
	public static SmartCalendarItem getItem(Date dateTime) {
		Date dataTime = SmartDateTime.parse(SmartDateTime.format(dateTime,
				"yyyy-MM-dd"));

		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dataTime);
		int year = calendar.get(Calendar.YEAR);
		int month = calendar.get(Calendar.MONTH) + 1;
		int weekOfYear = calendar.get(Calendar.WEEK_OF_YEAR);
		int dayOfWeek = calendar.get(Calendar.DAY_OF_WEEK);
		int yearQuarter = 0;
		int dayOfQuarter = 0;

		if (month == 1 || month == 2 || month == 3) {
			yearQuarter = Integer.parseInt(year + "01");
			int totalDays = (int) SmartDateTime.getTimeSpan(
					SmartDateTimeUnitType.Day, dataTime,
					SmartDateTime.parse(SmartDateTime.format(dataTime,
							"yyyy-01-01")));
			dayOfQuarter = totalDays + 1;
		} else if (month == 4 || month == 5 || month == 6) {
			yearQuarter = Integer.parseInt(year + "02");
			int totalDays = (int) SmartDateTime.getTimeSpan(
					SmartDateTimeUnitType.Day, dataTime,
					SmartDateTime.parse(SmartDateTime.format(dataTime,
							"yyyy-04-01")));
			dayOfQuarter = totalDays + 1;
		} else if (month == 7 || month == 8 || month == 9) {
			yearQuarter = Integer.parseInt(year + "03");
			int totalDays = (int) SmartDateTime.getTimeSpan(
					SmartDateTimeUnitType.Day, dataTime,
					SmartDateTime.parse(SmartDateTime.format(dataTime,
							"yyyy-07-01")));
			dayOfQuarter = totalDays + 1;
		} else {
			yearQuarter = Integer.parseInt(year + "04");
			int totalDays = (int) SmartDateTime.getTimeSpan(
					SmartDateTimeUnitType.Day, dataTime,
					SmartDateTime.parse(SmartDateTime.format(dataTime,
							"yyyy-10-01")));
			dayOfQuarter = totalDays + 1;
		}

		SmartCalendarItem result = new SmartCalendarItem();
		result.setDate(dataTime);
		result.setYear(year);
		result.setYearMonth(Integer.parseInt(SmartDateTime.format(dateTime,
				"yyyyMM")));
		result.setYearMonthDay(Integer.parseInt(SmartDateTime.format(dateTime,
				"yyyyMMdd")));
		result.setYearWeek(Integer.parseInt(year
				+ String.format("%02d", weekOfYear)));
		result.setYearWeekDay(Integer.parseInt(year
				+ String.format("%02d", weekOfYear)
				+ String.format("%02d", dayOfWeek)));
		result.setYearQuarter(yearQuarter);
		result.setYearQuarterDay(Integer.parseInt(yearQuarter
				+ String.format("%02d", dayOfQuarter)));

		return result;
	}
}
