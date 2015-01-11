/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.text.*;
import java.util.*;

/**
 * 时间
 * 
 */
/**
 * @author Administrator
 * 
 */
public class SmartDateTime {

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addMilliseconds(Date date, long param) {
		return new Date(date.getTime() + param);
	}

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addSeconds(Date date, long param) {
		return new Date(date.getTime() + param * 1000);
	}

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addMinutes(Date date, long param) {
		return new Date(date.getTime() + param * 60 * 1000);
	}

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addHours(Date date, long param) {
		return new Date(date.getTime() + param * 60 * 60 * 1000);
	}

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addDays(Date date, long param) {
		return new Date(date.getTime() + param * 24 * 60 * 60 * 1000);
	}

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addMonths(Date date, long param) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(date);
		calendar.add(Calendar.MONTH, (int) param);
		return calendar.getTime();
	}

	/**
	 * 增加时间片段
	 * 
	 * @param date
	 *            ，日期
	 * @param param
	 *            ，参数
	 * @return，结果
	 */
	public static Date addYears(Date date, long param) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(date);
		calendar.add(Calendar.YEAR, (int) param);
		return calendar.getTime();
	}

	private static ArrayList<String> animals = new ArrayList<String>();

	private static ArrayList<String> dateTimeFormats = new ArrayList<String>();

	/**
	 * 静态构造函数
	 * 
	 */
	static {
		String[] animalsArray = new String[] { "猴", "鸡", "狗", "猪", "鼠", "牛",
				"虎", "兔", "龙", "蛇", "马", "羊" };
		for (String animal : animalsArray) {
			animals.add(animal);
		}

		dateTimeFormats.add("yyyy-MM-dd HH:mm:ss.SSS");
		dateTimeFormats.add("yyyy/MM/dd HH:mm:ss.SSS");
		dateTimeFormats.add("yyyy.MM.dd HH:mm:ss.SSS");
		dateTimeFormats.add("yyyy年MM月dd日 HH点mm分ss秒SSS毫秒");
		dateTimeFormats.add("yy-M-d H:m:s.SSS");
		dateTimeFormats.add("yy/M/d H:m:s.SSS");
		dateTimeFormats.add("yy.M.d H:m:s.SSS");
		dateTimeFormats.add("yy年M月d日 H点m分s秒SSS毫秒");

		dateTimeFormats.add("yyyy-MM-dd HH:mm:ss");
		dateTimeFormats.add("yyyy/MM/dd HH:mm:ss");
		dateTimeFormats.add("yyyy.MM.dd HH:mm:ss");
		dateTimeFormats.add("yyyy年MM月dd日 HH点mm分ss秒");
		dateTimeFormats.add("yy-M-d H:m:s");
		dateTimeFormats.add("yy/M/d H:m:s");
		dateTimeFormats.add("yy.M.d H:m:s");
		dateTimeFormats.add("yy年M月d日 H点m分s秒");

		dateTimeFormats.add("yyyy-MM-dd");
		dateTimeFormats.add("yyyy/MM/dd");
		dateTimeFormats.add("yyyy.MM.dd");
		dateTimeFormats.add("yyyy年MM月dd日");
		dateTimeFormats.add("yy-M-d");
		dateTimeFormats.add("yy/M/d");
		dateTimeFormats.add("yy.M.d");
		dateTimeFormats.add("yy年M月d日");

		dateTimeFormats.add("yyyy-MM");
		dateTimeFormats.add("yyyy/MM");
		dateTimeFormats.add("yyyy.MM");
		dateTimeFormats.add("yyyy年MM月");
		dateTimeFormats.add("yy-M");
		dateTimeFormats.add("yy/M");
		dateTimeFormats.add("yy.M");
		dateTimeFormats.add("yy年M月");

		dateTimeFormats.add("yyyy");
		dateTimeFormats.add("yyyy年");
		dateTimeFormats.add("yy");
		dateTimeFormats.add("yy年");
	}

	/**
	 * 
	 * 解析时间
	 * 
	 * @param input
	 *            ，输入
	 * @return，结果
	 */
	public static Date parse(String input) {
		Date result = null;
		for (String format : dateTimeFormats) {
			if (result == null) {
				try {
					result = new SimpleDateFormat(format).parse(input);
				} catch (Exception err) {
				}
			} else {
				break;
			}
		}
		return result;
	}

	/**
	 * 解析时间
	 * 
	 * @param input
	 *            ，输入
	 * @param format
	 *            ，格式
	 * @return，结果
	 */
	public static Date parse(String input, String format) {
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat(format);

		Date result = null;
		try {
			result = simpleDateFormat.parse(input);
		} catch (Exception err) {
		}

		return result;
	}

	/**
	 * 格式化时间
	 * 
	 * @param dateTime
	 *            ，时间
	 * @return，结果
	 */
	public static String format(Date dateTime) {
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat(
				"yyyy-MM-dd HH:mm:ss.SSS");
		return simpleDateFormat.format(dateTime);
	}

	/**
	 * 格式化时间
	 * 
	 * @param dateTime
	 *            ，时间
	 * @param format
	 *            ，格式
	 * @return，结果
	 */
	public static String format(Date dateTime, String format) {
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat(format);
		return simpleDateFormat.format(dateTime);
	}

	/**
	 * 毫秒转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，毫秒
	 * @return，结果
	 */
	public static double fromMillisecond(
			SmartDateTimeUnitType dateTimeUnitType, double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time / (12 * 30 * 24 * 60 * 60 * 1000);
			break;
		case Month:
			result = time / (30 * 24 * 60 * 60 * 1000);
			break;
		case Day:
			result = time / (24 * 60 * 60 * 1000);
			break;
		case Hour:
			result = time / (60 * 60 * 1000);
			break;
		case Minute:
			result = time / (60 * 1000);
			break;
		case Second:
			result = time / (1000);
			break;
		case Millisecond:
			result = time;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 秒转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，秒
	 * @return，结果
	 */
	public static double fromSecond(SmartDateTimeUnitType dateTimeUnitType,
			double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time / (12 * 30 * 24 * 60 * 60);
			break;
		case Month:
			result = time / (30 * 24 * 60 * 60);
			break;
		case Day:
			result = time / (24 * 60 * 60);
			break;
		case Hour:
			result = time / (60 * 60);
			break;
		case Minute:
			result = time / (60);
			break;
		case Second:
			result = time;
			break;
		case Millisecond:
			result = time * 1000;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 分钟转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，分钟
	 * @return，结果
	 */
	public static double fromMinute(SmartDateTimeUnitType dateTimeUnitType,
			double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time / (12 * 30 * 24 * 60);
			break;
		case Month:
			result = time / (30 * 24 * 60);
			break;
		case Day:
			result = time / (24 * 60);
			break;
		case Hour:
			result = time / (60);
			break;
		case Minute:
			result = time;
			break;
		case Second:
			result = time * 60;
			break;
		case Millisecond:
			result = time * 60 * 1000;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 小时转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，小时
	 * @return，结果
	 */
	public static double fromHour(SmartDateTimeUnitType dateTimeUnitType,
			double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time / (12 * 30 * 24);
			break;
		case Month:
			result = time / (30 * 24);
			break;
		case Day:
			result = time / (24);
			break;
		case Hour:
			result = time;
			break;
		case Minute:
			result = time * 60;
			break;
		case Second:
			result = time * 60 * 60;
			break;
		case Millisecond:
			result = time * 60 * 60 * 1000;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 天转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，小时
	 * @return，结果
	 */
	public static double fromDay(SmartDateTimeUnitType dateTimeUnitType,
			double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time / (12 * 30);
			break;
		case Month:
			result = time / (30);
			break;
		case Day:
			result = time;
			break;
		case Hour:
			result = time * 24;
			break;
		case Minute:
			result = time * 24 * 60;
			break;
		case Second:
			result = time * 24 * 60 * 60;
			break;
		case Millisecond:
			result = time * 24 * 60 * 60 * 1000;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 月转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，小时
	 * @return，结果
	 */
	public static double fromMonth(SmartDateTimeUnitType dateTimeUnitType,
			double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time / 12;
			break;
		case Month:
			result = time;
			break;
		case Day:
			result = time * 30;
			break;
		case Hour:
			result = time * 30 * 24;
			break;
		case Minute:
			result = time * 30 * 24 * 60;
			break;
		case Second:
			result = time * 30 * 24 * 60 * 60;
			break;
		case Millisecond:
			result = time * 30 * 24 * 60 * 60 * 1000;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 年转其他时间
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param time
	 *            ，年
	 * @return，结果
	 */
	public static double fromYear(SmartDateTimeUnitType dateTimeUnitType,
			double time) {
		double result = 0.0;
		switch (dateTimeUnitType) {
		case Year:
			result = time;
			break;
		case Month:
			result = time * 12;
			break;
		case Day:
			result = time * 12 * 30;
			break;
		case Hour:
			result = time * 12 * 30 * 24;
			break;
		case Minute:
			result = time * 12 * 30 * 24 * 60;
			break;
		case Second:
			result = time * 12 * 30 * 24 * 60;
			break;
		case Millisecond:
			result = time * 12 * 30 * 24 * 60 * 1000;
			break;
		default:
			break;
		}
		return result;
	}

	/**
	 * 获得时间差
	 * 
	 * @param dateTimeUnitType
	 *            ，时间单位
	 * @param dateEnd
	 *            ，结束时间
	 * @param dateStart
	 *            ，开始时间
	 * @return，结果
	 */
	public static double getTimeSpan(SmartDateTimeUnitType dateTimeUnitType,
			Date dateEnd, Date dateStart) {
		return fromMillisecond(dateTimeUnitType,
				dateEnd.getTime() - dateStart.getTime());
	}

	/**
	 * 当前时间
	 * 
	 * @return，当前时间
	 */
	public static String nowTime() {
		return new SimpleDateFormat("HH:mm:ss.SSS").format(new Date());
	}

	/**
	 * 当前日期时间
	 * 
	 * @return，当前日期时间
	 */
	public static String now() {
		return new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS")
				.format(new Date());
	}

	/**
	 * 当前日期
	 * 
	 * @return，当前日期
	 */
	public static String nowDate() {
		return new SimpleDateFormat("yyyy-MM-dd").format(new Date());
	}

	/**
	 * 当前年
	 * 
	 * @return，当前年
	 */
	public static String nowYear() {
		return new SimpleDateFormat("yyyy").format(new Date());
	}

	/**
	 * 当前月
	 * 
	 * @return，当前月
	 */
	public static String nowMonth() {
		return new SimpleDateFormat("MM").format(new Date());
	}

	/**
	 * 当前天
	 * 
	 * @return，当前天
	 */
	public static String nowDay() {
		return new SimpleDateFormat("dd").format(new Date());
	}

	/**
	 * JavaScript最小时间
	 */
	public static final Date JavaScriptMinTime = parse("1970-01-01 08:00:00",
			"yyyy-MM-dd HH:mm:ss");

	/**
	 * 解析配置
	 * 
	 * @param value
	 *            ，值
	 * @param regioneSplit
	 *            ，区域分割线
	 * @param partSplit
	 *            ，部分分割线
	 * @return，结果
	 */
	public static Date[] parseArray(String value, String regioneSplit,
			String partSplit) {
		String[] regiones = value.split(regioneSplit);
		ArrayList<Date> dataDates = new ArrayList<Date>();
		for (int i = 0; i < regiones.length; i++) {
			String region = regiones[i];
			String[] parts = region.split(partSplit);
			if (parts.length == 2) {
				// 说明是范围
				long left = parse(parts[0]).getTime();
				long right = parse(parts[1]).getTime();

				if (left < right) {
					for (long now = left; now <= right; now = now
							+ (long) fromDay(SmartDateTimeUnitType.Millisecond,
									1)) {
						Date temp = new Date(now);
						if (!dataDates.contains(temp)) {
							dataDates.add(temp);
						}
					}
				} else if (left > right) {
					for (long now = left; now >= right; now = now
							- (long) fromDay(SmartDateTimeUnitType.Millisecond,
									1)) {
						Date temp = new Date(now);
						if (!dataDates.contains(temp)) {
							dataDates.add(temp);
						}
					}
				} else {
					Date temp = new Date(left);
					if (!dataDates.contains(temp)) {
						dataDates.add(temp);
					}
				}
			} else {
				if (!dataDates.contains(parse(region))) {
					dataDates.add(parse(region));
				}
			}
		}
		Date[] result = new Date[dataDates.size()];
		return dataDates.toArray(result);
	}

	/**
	 * 解析配置
	 * 
	 * @param value
	 *            ，值
	 * @param regioneSplit
	 *            ，区域分割线
	 * @return，结果
	 */
	public static Date[] parseArray(String value, String regioneSplit) {
		return parseArray(value, regioneSplit, "\\~");
	}

	/**
	 * 解析配置
	 * 
	 * @param value
	 *            ，值
	 * @return，结果
	 */
	public static Date[] parseArray(String value) {
		return parseArray(value, "\\|", "\\~");
	}

	/**
	 * 获得月间隔
	 * 
	 * @param start
	 *            ，开始时间
	 * @param end
	 *            ，结束时间
	 * @return，结果
	 */
	public static ArrayList<Date> getMonthInterval(Date start, Date end) {
		long startTime = start.getTime();
		long endTime = end.getTime();
		Calendar startCalendar = Calendar.getInstance();
		startCalendar.setTime(start);
		int startYear = startCalendar.get(Calendar.YEAR);
		int startMonth = startCalendar.get(Calendar.MONTH) + 1;

		Calendar endCalendar = Calendar.getInstance();
		endCalendar.setTime(end);
		int endYear = endCalendar.get(Calendar.YEAR);
		int endMonth = endCalendar.get(Calendar.MONTH) + 1;

		if (startTime > endTime) {
			throw new RuntimeException("开始时间必须小于等于结束时间！");
		}
		ArrayList<Date> result = new ArrayList<Date>();

		for (int y = startYear; y <= endYear; y++) {
			if (startYear == endYear) {
				for (int m = startMonth; m <= endMonth; m++) {
					result.add(parse(y + "-" + m));
				}
			} else if (y == startYear) {
				for (int m = startMonth; m <= 12; m++) {
					result.add(parse(y + "-" + m));
				}
			} else if (y == endYear) {
				for (int m = 1; m <= endMonth; m++) {
					result.add(parse(y + "-" + m));
				}
			} else {
				for (int m = 1; m <= 12; m++) {
					result.add(parse(y + "-" + m));
				}
			}
		}

		return result;
	}

	/**
	 * 验证是不是日期格式。注意，20080123这样的格式是不能验证的，必须是2008-01-23或2008年01月23
	 * 
	 * @param input
	 *            ，待验证的字符串
	 * @return，验证的结果
	 */
	public static boolean isDateTime(String input) {
		Date result = null;
		try {
			result = SmartDateTime.parse(input);
		} catch (Exception err) {
		}
		return result != null;
	}

	/**
	 * 获得某个时间点所在年的开始时间
	 * 
	 * @param year
	 *            ，年
	 * @return，开始时间
	 */
	public static Date getStartTimeOfYear(int year) {
		return parse(String.format("%s-01-01 00:00:00.000",
				String.valueOf(year)));
	}

	/**
	 * 获得某个时间点所在年的结束时间
	 * 
	 * @param year
	 *            ，年
	 * @return，结束时间
	 */
	public static Date getEndTimeOfYear(int year) {
		return parse(String.format("%s-12-31 23:59:59.998",
				String.valueOf(year)));
	}

	/**
	 * 获得某个时间点所在月的开始时间
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @return，开始时间
	 */
	public static Date getStartTimeOfMonth(int year, int month) {
		return parse(String.format("%s-%02d-01 00:00:00.000",
				String.valueOf(year), month));
	}

	/**
	 * 获得某个时间点所在月的结束时间
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @return，结束时间
	 */
	public static Date getEndTimeOfMonth(int year, int month) {
		return parse(String.format("%s-%02d-%02d 23:59:59.998",
				String.valueOf(year), month, getDaysInMonth(year, month)));
	}

	/**
	 * 获得某个时间点所在日的开始时间
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @param day
	 *            ，日
	 * @return，开始时间
	 */
	public static Date getStartTimeOfDay(int year, int month, int day) {
		return parse(String.format("%s-%02d-%02d 00:00:00.000", year, month,
				day));
	}

	/**
	 * 获得某个时间点所在日的结束时间
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @param day
	 *            ，日
	 * @return，结束时间
	 */
	public static Date getEndTimeOfDay(int year, int month, int day) {
		return parse(String.format("%s-%02d-%02d 23:59:59.998", year, month,
				day));
	}

	/**
	 * 获得某一年的天数
	 * 
	 * @param year
	 *            ，年份
	 * @return，天数
	 */
	public static int getDaysInYear(int year) {
		Calendar calendar = Calendar.getInstance();
		calendar.set(Calendar.YEAR, year);
		return calendar.getActualMaximum(Calendar.DAY_OF_YEAR);
	}

	/**
	 * 根据年份判断生肖
	 * 
	 * @param year
	 *            ，年份
	 * @return，生肖
	 */
	public static String getTwelveAnimal(int year) {
		return animals.get(year % 12);
	}

	/**
	 * 获得某个时间点所在年的开始时间
	 * 
	 * @param dateTime
	 *            ，时间点
	 * @return，开始时间
	 */
	public static Date getStartTimeOfYear(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-01-01 00:00:00.000",
				calendar.get(Calendar.YEAR)));
	}

	/**
	 * 获得某个时间点所在年的结束时间
	 * 
	 * @param dateTime
	 *            ，时间点
	 * @return，开始时间
	 */
	public static Date getEndTimeOfYear(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-12-31 23:59:59.998",
				calendar.get(Calendar.YEAR)));
	}

	/**
	 * 获得某个时间点所在月的开始时间
	 * 
	 * @param dateTime
	 *            ，时间点
	 * @return，开始时间
	 */
	public static Date getStartTimeOfMonth(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-%02d-01 00:00:00.000",
				calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH)));
	}

	/**
	 * 获得某个时间点所在月的结束时间
	 * 
	 * @param dateTime
	 *            ，时间点
	 * @return，结束时间
	 */
	public static Date getEndTimeOfMonth(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-%02d-%02d 23:59:59.998",
				calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH),
				calendar.getActualMaximum(Calendar.DAY_OF_MONTH)));
	}

	/**
	 * 获得某个时间点所在日的开始时间
	 * 
	 * @param dateTime
	 *            ，时间点
	 * @return，开始时间
	 */
	public static Date getStartTimeOfDay(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-%02d-%02d 00:00:00.000",
				calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH),
				calendar.get(Calendar.DAY_OF_MONTH)));
	}

	/**
	 * 获得某个时间点所在日的结束时间
	 * 
	 * @param dateTime
	 *            ，时间点
	 * @return，结束时间
	 */
	public static Date getEndTimeOfDay(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-%02d-%02d 23:59:59.998",
				calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH),
				calendar.get(Calendar.DAY_OF_MONTH)));
	}

	/**
	 * 通过时间部分获得今天日期的完整形式
	 * 
	 * @param dateTime
	 *            ，日期部分
	 * @param timePart
	 *            ，时间部分
	 * @return，今天日期的完整形式
	 */
	public static Date getCombineTime(Date dateTime, String timePart) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		return parse(String.format("%s-%02d-%02d %s",
				calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH),
				calendar.get(Calendar.DAY_OF_MONTH), timePart));
	}

	/**
	 * 获得日期在一年星期中的星期数
	 * 
	 * @param dateTime
	 *            ，日期
	 * @return，星期
	 */
	public static int getWeekOrderOfYear(Date dateTime) {
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		int dayOfYear = calendar.get(Calendar.DAY_OF_YEAR);
		int weekvalue = dayOfYear / 7;
		int remainder = dayOfYear % 7;
		if (remainder == 0) {
			return weekvalue;
		} else {
			return weekvalue + 1;
		}
	}

	/**
	 * 获得日期所在周的开始时间
	 * 
	 * @param dateTime
	 *            ，某个时间
	 * @return，获得日期所在周的开始时间
	 */
	public static Date getStartTimeOfWeek(Date dateTime) {
		String dataTime = String.format("%s 00:00:00.000",
				format(dateTime, "yyyy-MM-dd"));
		dateTime = parse(dataTime);
		Date result = new Date();
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(dateTime);
		int dayOfWeek = calendar.get(Calendar.DAY_OF_WEEK) - 1;
		result = new Date(dateTime.getTime() - dayOfWeek * 24 * 60 * 60 * 1000);

		if (!format(result, "yyyy").equals(format(dateTime, "yyyy"))) {
			result = parse(String.format("%s-%s-%s",
					calendar.get(Calendar.YEAR), 1, 1));
		}
		return new Date(result.getTime() + 24 * 60 * 60 * 1000);
	}

	/**
	 * 获得日期所在周的结束时间
	 * 
	 * @param dateTime
	 *            ，某个时间
	 * @return，获得日期所在周的结束时间
	 */
	public static Date getEndTimeOfWeek(Date dateTime) {
		String dataTime = String.format("%s 23:59:59.998",
				format(getStartTimeOfWeek(dateTime), "yyyy-MM-dd"));
		return new Date(parse(dataTime).getTime() + 6 * 24 * 60 * 60 * 1000);
	}

	/**
	 * 获得某一年的某个月的天数
	 * 
	 * @param year
	 *            ，年份
	 * @param month
	 *            ，月份
	 * @return，天数
	 */
	public static int getDaysInMonth(int year, int month) {
		Calendar calendar = Calendar.getInstance();
		calendar.set(Calendar.YEAR, year);
		calendar.set(Calendar.MONTH, month);
		return calendar.getActualMaximum(Calendar.DAY_OF_MONTH);
	}

	/**
	 * 获得日期在一年星期中的星期数
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @param day
	 *            ，日
	 * @return，星期
	 */
	public static int getWeekOrderOfYear(int year, int month, int day) {
		return getWeekOrderOfYear(parse(year + "-" + month + "-" + day));
	}

	/**
	 * 获得日期所在周的开始时间
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @param day
	 *            ，日
	 * @return，获得日期所在周的开始时间
	 */
	public static Date getStartTimeOfWeek(int year, int month, int day) {
		return getStartTimeOfWeek(parse(String.format("%s-%02d-%02d", year,
				month, day)));
	}

	/**
	 * 获得日期所在周的结束时间
	 * 
	 * @param year
	 *            ，年
	 * @param month
	 *            ，月
	 * @param day
	 *            ，日
	 * @return，获得日期所在周的结束时间
	 */
	public static Date getEndTimeOfWeek(int year, int month, int day) {
		return getEndTimeOfWeek(parse(String.format("%s-%02d-%02d", year,
				month, day)));
	}

	/**
	 * 是否在两个日期之间
	 * 
	 * @param date
	 *            ，要比较的日期
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @param isLimitStart
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @param isLimitEnd
	 *            ，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(Date date, Date start, Date end,
			boolean isLimitStart, boolean isLimitEnd) {
		if (start.getTime() == end.getTime()) {
			return date.getTime() == start.getTime();
		}

		if (start.after(end)) {
			throw new RuntimeException("左侧边界不能大于右侧边界！");
		}

		if (isLimitStart && isLimitEnd) {
			return (start.before(date) || start.getTime() == date.getTime())
					&& (date.before(end) || date.getTime() == end.getTime());
		} else if (isLimitStart && !isLimitEnd) {
			return (start.before(date) || start.getTime() == date.getTime())
					&& (date.before(end));
		} else if (!isLimitStart && isLimitEnd) {
			return (start.before(date))
					&& (date.before(end) || date.getTime() == end.getTime());
		} else {
			return (start.before(date)) && (date.before(end));
		}
	}

	/**
	 * 是否在两个日期之间
	 * 
	 * @param date
	 *            ，要比较的日期
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @param isLimitStart
	 *            ，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。
	 *            True时包含边界
	 * @return，结果
	 */
	public static boolean between(Date date, Date start, Date end,
			boolean isLimitStart) {
		return between(date, start, end, isLimitStart, false);
	}

	/**
	 * 是否在两个日期之间
	 * 
	 * @param date
	 *            ，要比较的日期
	 * @param start
	 *            ，开始
	 * @param end
	 *            ，结束
	 * @return，结果
	 */
	public static boolean between(Date date, Date start, Date end) {
		return between(date, start, end, false, false);
	}

	/**
	 * 获得两个时间的间隔信息（结束时间应该大于开始时间）
	 * 
	 * @param startDateTime
	 *            ，开始时间
	 * @param endDateTime
	 *            ，结束之间
	 * @param format
	 *            ，格式化字符串
	 * @return，间隔信息
	 */
	public static String getIntervalInfo(Date startDateTime, Date endDateTime,
			String format) {
		long interval = endDateTime.getTime() - startDateTime.getTime();
		double totalDays = fromMillisecond(SmartDateTimeUnitType.Day, interval);
		double totalHours = fromMillisecond(SmartDateTimeUnitType.Hour,
				interval);
		double totalMinutes = fromMillisecond(SmartDateTimeUnitType.Minute,
				interval);
		double totalSeconds = fromMillisecond(SmartDateTimeUnitType.Second,
				interval);

		DecimalFormat decimalFormat = new DecimalFormat(format);
		if (totalDays >= 365) {
			return decimalFormat.format((totalDays / 365)) + "年";
		} else if (totalDays >= 30) {
			return decimalFormat.format(totalDays / 30) + "月";
		} else if (totalDays >= 1) {
			return decimalFormat.format(totalDays) + "天";
		} else if (totalHours >= 1) {
			return decimalFormat.format(totalHours) + "小时";
		} else if (totalMinutes >= 1) {
			return decimalFormat.format(totalMinutes) + "分钟";
		} else {
			return decimalFormat.format(totalSeconds) + "秒钟";
		}
	}

	/**
	 * 获得两个时间的间隔信息（结束时间应该大于开始时间）
	 * 
	 * @param startDateTime
	 *            ，开始时间
	 * @param endDateTime
	 *            ，结束之间
	 * @param format
	 *            ，格式化字符串
	 * @return，间隔信息
	 */
	public static String getIntervalInfo(Date startDateTime, Date endDateTime) {
		return getIntervalInfo(startDateTime, endDateTime, "0.#");
	}

	/**
	 * 获得阴历日期
	 * 
	 * @param dateTime
	 *            ，阳历时间
	 * @return，字符串表示
	 */
	public static String toChineseLunisolarCalendar(Date dateTime) {
		return SmartChineseLunisolarCalendar
				.toChineseLunisolarCalendar(dateTime);
	}
}
