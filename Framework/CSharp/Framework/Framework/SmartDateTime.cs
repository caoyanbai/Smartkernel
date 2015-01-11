/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 时间
    /// </summary>
    public static class SmartDateTime
    {
        /// <summary>
        /// 系统时间的包装
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct SmartSystemTime
        {
            /// <summary>
            /// wYear
            /// </summary>
            public ushort wYear;

            /// <summary>
            /// wMonth
            /// </summary>
            public ushort wMonth;

            /// <summary>
            /// wDayOfWeek
            /// </summary>
            public ushort wDayOfWeek;

            /// <summary>
            /// wDay
            /// </summary>
            public ushort wDay;

            /// <summary>
            /// wHour
            /// </summary>
            public ushort wHour;

            /// <summary>
            /// wMinute
            /// </summary>
            public ushort wMinute;

            /// <summary>
            /// wSecond
            /// </summary>
            public ushort wSecond;

            /// <summary>
            /// wMiliseconds
            /// </summary>
            public ushort wMiliseconds;
        }

        /// <summary>
        /// 当前时间
        /// </summary>
        public static string NowTime
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss.fff");
            }
        }

        /// <summary>
        /// 当前日期时间
        /// </summary>
        public static string Now
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }

        /// <summary>
        /// 当前日期
        /// </summary>
        public static string NowDate
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 当前年
        /// </summary>
        public static string NowYear
        {
            get
            {
                return DateTime.Now.ToString("yyyy");
            }
        }

        /// <summary>
        /// 当前月
        /// </summary>
        public static string NowMonth
        {
            get
            {
                return DateTime.Now.ToString("MM");
            }
        }

        /// <summary>
        /// 当前天
        /// </summary>
        public static string NowDay
        {
            get
            {
                return DateTime.Now.ToString("dd");
            }
        }

        /// <summary>
        /// JavaScript最小时间
        /// </summary>
        public static readonly DateTime JavaScriptMinTime = DateTime.Parse("1970-01-01 08:00:00");

        /// <summary>
        /// 解析配置
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="regioneSplit">区域分割线</param>
        /// <param name="partSplit">部分分割线</param>
        /// <returns>结果</returns>
        public static DateTime[] ParseArray(string value, char regioneSplit = '|', char partSplit = '~')
        {
            var regiones = value.Split(regioneSplit);
            var dataDates = new List<DateTime>();
            for (int i = 0; i < regiones.Length; i++)
            {
                var region = regiones[i];
                var parts = region.Split(partSplit);
                if (parts.Length == 2)
                {
                    //说明是范围
                    var left = DateTime.Parse(parts[0]);
                    var right = DateTime.Parse(parts[1]);

                    if (left < right)
                    {
                        for (var now = left; now <= right; now = now.AddDays(1))
                        {
                            if (!dataDates.Contains(now))
                            {
                                dataDates.Add(now);
                            }
                        }
                    }
                    else if (left > right)
                    {
                        for (var now = left; now >= right; now = now.AddDays(-1))
                        {
                            if (!dataDates.Contains(now))
                            {
                                dataDates.Add(now);
                            }
                        }
                    }
                    else
                    {
                        if (!dataDates.Contains(left))
                        {
                            dataDates.Add(left);
                        }
                    }
                }
                else
                {
                    if (!dataDates.Contains(DateTime.Parse(region)))
                    {
                        dataDates.Add(DateTime.Parse(region));
                    }
                }
            }

            return dataDates.ToArray();
        }

        /// <summary>
        /// 获得月间隔
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>结果</returns>
        public static List<DateTime> GetMonthInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new Exception("开始时间必须小于等于结束时间！");
            }
            var result = new List<DateTime>();

            for (var y = int.Parse(start.ToString("yyyy")); y <= int.Parse(end.ToString("yyyy")); y++)
            {
                if (start.Year == end.Year)
                {
                    for (var m = start.Month; m <= end.Month; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
                else if (y == start.Year)
                {
                    for (var m = start.Month; m <= 12; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
                else if (y == end.Year)
                {
                    for (var m = 1; m <= end.Month; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
                else
                {
                    for (var m = 1; m <= 12; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 验证是不是日期格式。注意，20080123这样的格式是不能验证的，必须是2008-01-23或2008年01月23
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>验证的结果</returns>
        public static bool IsDateTime(string input)
        {
            DateTime result;
            return DateTime.TryParse(input, out result);
        }

        private static readonly List<string> animals = (new string[] { "猴", "鸡", "狗", "猪", "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊" }).ToList();

        [DllImport("Kernel32.dll")]
        private static extern bool GetSystemTime(ref SmartSystemTime systemTime);

        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns>当前的系统时间</returns>
        public static DateTime GetSystemTime()
        {
            var systemTime = new SmartSystemTime();
            GetSystemTime(ref systemTime);
            return DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", systemTime.wYear, systemTime.wMonth, systemTime.wDay, systemTime.wHour, systemTime.wMinute, systemTime.wSecond));
        }

        /// <summary>
        /// 获得某个时间点所在年的开始时间
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>开始时间</returns>
        public static DateTime GetStartTimeOfYear(int year)
        {
            return DateTime.Parse(string.Format("{0}-01-01 00:00:00.000", year));
        }

        /// <summary>
        /// 获得某个时间点所在年的结束时间
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>结束时间</returns>
        public static DateTime GetEndTimeOfYear(int year)
        {
            return DateTime.Parse(string.Format("{0}-12-31 23:59:59.998", year));
        }

        /// <summary>
        /// 获得某个时间点所在月的开始时间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>开始时间</returns>
        public static DateTime GetStartTimeOfMonth(int year, int month)
        {
            return DateTime.Parse(string.Format("{0}-{1}-01 00:00:00.000", year, month.ToString("00")));
        }

        /// <summary>
        /// 获得某个时间点所在月的结束时间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>结束时间</returns>
        public static DateTime GetEndTimeOfMonth(int year, int month)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} 23:59:59.998", year, month.ToString("00"), GetDaysInMonth(year, month).ToString("00")));
        }

        /// <summary>
        /// 获得某个时间点所在日的开始时间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>开始时间</returns>
        public static DateTime GetStartTimeOfDay(int year, int month, int day)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} 00:00:00.000", year, month.ToString("00"), day.ToString("00")));
        }

        /// <summary>
        /// 获得某个时间点所在日的结束时间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>结束时间</returns>
        public static DateTime GetEndTimeOfDay(int year, int month, int day)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} 23:59:59.998", year, month.ToString("00"), day.ToString("00")));
        }

        /// <summary>
        /// 获得日期在一年星期中的星期数
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>星期</returns>
        public static int GetWeekOrderOfYear(int year, int month, int day)
        {
            return GetWeekOrderOfYear(DateTime.Parse(year + "-" + month + "-" + day));
        }

        /// <summary>
        /// 获得日期所在周的开始时间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>获得日期所在周的开始时间</returns>
        public static DateTime GetStartTimeOfWeek(int year, int month, int day)
        {
            return GetStartTimeOfWeek(DateTime.Parse(string.Format("{0}-{1}-{2}", year, month, day)));
        }

        /// <summary>
        /// 获得日期所在周的结束时间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>获得日期所在周的结束时间</returns>
        public static DateTime GetEndTimeOfWeek(int year, int month, int day)
        {
            return GetEndTimeOfWeek(DateTime.Parse(string.Format("{0}-{1}-{2}", year, month, day)));
        }

        /// <summary>
        /// 获得某一年的天数
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>天数</returns>
        public static int GetDaysInYear(int year)
        {
            var gregorianCalendar = new GregorianCalendar();
            return gregorianCalendar.GetDaysInYear(year);
        }

        /// <summary>
        /// 获得某一年的某个月的天数
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>天数</returns>
        public static int GetDaysInMonth(int year, int month)
        {
            var gregorianCalendar = new GregorianCalendar();
            return gregorianCalendar.GetDaysInMonth(year, month);
        }

        /// <summary>
        /// 根据年份判断生肖
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>生肖</returns>
        public static string GetTwelveAnimal(int year)
        {
            return animals[year % 12];
        }

        [DllImport("Kernel32.dll")]
        private static extern bool SetSystemTime(ref SmartSystemTime systemTime);

        /// <summary>
        /// 设置系统时间
        /// </summary>
        /// <param name="dateTime">设置系统时间</param>
        public static void SetSystemTime(DateTime dateTime)
        {
            var systemTime = new SmartSystemTime { wDay = Convert.ToUInt16(dateTime.Day), wDayOfWeek = Convert.ToUInt16(dateTime.DayOfWeek), wHour = Convert.ToUInt16(dateTime.Hour), wMiliseconds = Convert.ToUInt16(dateTime.Millisecond), wMinute = Convert.ToUInt16(dateTime.Minute), wMonth = Convert.ToUInt16(dateTime.Month), wSecond = Convert.ToUInt16(dateTime.Second), wYear = Convert.ToUInt16(dateTime.Year) };
            SetSystemTime(ref systemTime);
        }

        /// <summary>
        /// 获得某个时间点所在年的开始时间
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns>开始时间</returns>
        public static DateTime GetStartTimeOfYear(DateTime dateTime)
        {
            return DateTime.Parse(string.Format("{0}-01-01 00:00:00.000", dateTime.Year));
        }

        /// <summary>
        /// 获得某个时间点所在年的结束时间
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns>结束时间</returns>
        public static DateTime GetEndTimeOfYear(DateTime dateTime)
        {
            return DateTime.Parse(string.Format("{0}-12-31 23:59:59.998", dateTime.Year));
        }

        /// <summary>
        /// 获得某个时间点所在月的开始时间
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns>开始时间</returns>
        public static DateTime GetStartTimeOfMonth(DateTime dateTime)
        {
            return DateTime.Parse(string.Format("{0}-{1}-01 00:00:00.000", dateTime.Year, dateTime.Month.ToString("00")));
        }

        /// <summary>
        /// 获得某个时间点所在月的结束时间
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns>结束时间</returns>
        public static DateTime GetEndTimeOfMonth(DateTime dateTime)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} 23:59:59.998", dateTime.Year, dateTime.Month.ToString("00"), SmartDateTime.GetDaysInMonth(dateTime.Year, dateTime.Month).ToString("00")));
        }

        /// <summary>
        /// 获得某个时间点所在日的开始时间
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns>开始时间</returns>
        public static DateTime GetStartTimeOfDay(DateTime dateTime)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} 00:00:00.000", dateTime.Year, dateTime.Month.ToString("00"), dateTime.Day.ToString("00")));
        }

        /// <summary>
        ///  获得某个时间点所在日的结束时间
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns>结束时间</returns>
        public static DateTime GetEndTimeOfDay(DateTime dateTime)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} 23:59:59.998", dateTime.Year, dateTime.Month.ToString("00"), dateTime.Day.ToString("00")));
        }

        /// <summary>
        /// 日期的格式化
        /// </summary>
        /// <param name="dateTime">待格式化的日期</param>
        /// <param name="format">格式化字符串</param>
        /// <returns>格式化之后的字符串</returns>
        public static string Format(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss.fff")
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// 通过时间部分获得今天日期的完整形式
        /// </summary>
        /// <param name="dateTime">日期部分</param>
        /// <param name="timePart">时间部分</param>
        /// <returns>今天日期的完整形式</returns>
        public static DateTime GetCombineTime(DateTime dateTime, string timePart)
        {
            return DateTime.Parse(string.Format("{0}-{1}-{2} {3}", dateTime.Year, dateTime.Month, dateTime.Day, timePart));
        }

        /// <summary>
        /// 获得日期在一年星期中的星期数
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>星期</returns>
        public static int GetWeekOrderOfYear(DateTime dateTime)
        {
            var weekvalue = dateTime.DayOfYear / 7;
            var remainder = dateTime.DayOfYear % 7;
            if (remainder == 0)
            {
                return weekvalue;
            }
            else
            {
                return weekvalue + 1;
            }
        }

        /// <summary>
        /// 获得日期所在周的开始时间
        /// </summary>
        /// <param name="dateTime">某个时间</param>
        /// <returns>获得日期所在周的开始时间</returns>
        public static DateTime GetStartTimeOfWeek(DateTime dateTime)
        {
            var dataTime = string.Format("{0} 00:00:00.000", dateTime.ToString("yyyy-MM-dd"));
            dateTime = DateTime.Parse(dataTime);
            var result = DateTime.MinValue;
            if (dateTime.DayOfWeek == DayOfWeek.Monday)
            {
                result = dateTime.AddDays(-1);
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Tuesday)
            {
                result = dateTime.AddDays(-2);
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Wednesday)
            {
                result = dateTime.AddDays(-3);
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Thursday)
            {
                result = dateTime.AddDays(-4);
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Friday)
            {
                result = dateTime.AddDays(-5);
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Saturday)
            {
                result = dateTime.AddDays(-6);
            }
            if (result.Year != dateTime.Year)
            {
                result = new DateTime(dateTime.Year, 1, 1);
            }
            return result.AddDays(1);
        }

        /// <summary>
        /// 获得日期所在周的结束时间
        /// </summary>
        /// <param name="dateTime">某个时间</param>
        /// <returns>获得日期所在周的结束时间</returns>
        public static DateTime GetEndTimeOfWeek(DateTime dateTime)
        {
            var dataTime = string.Format("{0} 23:59:59.998", GetStartTimeOfWeek(dateTime).ToString("yyyy-MM-dd"));
            return DateTime.Parse(dataTime).AddDays(6);
        }

        /// <summary>
        /// 获得两个时间的间隔信息（结束时间应该大于开始时间）
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束之间</param>
        /// <param name="format">格式化字符串</param>
        /// <returns>间隔信息</returns>
        public static string GetIntervalInfo(DateTime startDateTime, DateTime endDateTime, string format = "0.#")
        {
            var interval = endDateTime - startDateTime;
            if (interval.TotalDays >= 365)
            {
                return (interval.TotalDays / 365).ToString(format) + "年";
            }
            else if (interval.TotalDays >= 30)
            {
                return (interval.TotalDays / 30).ToString(format) + "月";
            }
            else if (interval.TotalDays >= 1)
            {
                return interval.TotalDays.ToString(format) + "天";
            }
            else if (interval.TotalHours >= 1)
            {
                return interval.TotalHours.ToString(format) + "小时";
            }
            else if (interval.TotalMinutes >= 1)
            {
                return interval.TotalMinutes.ToString(format) + "分钟";
            }
            else
            {
                return interval.TotalSeconds.ToString(format) + "秒钟";
            }
        }

        /// <summary>
        /// 是否在两个日期之间
        /// </summary>
        /// <param name="date">要比较的日期</param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="isLimitStart">是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
        /// <param name="isLimitEnd">是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界</param>
        /// <returns>结果</returns>
        public static bool Between(DateTime date, DateTime start, DateTime end, bool isLimitStart = false, bool isLimitEnd = false)
        {
            if (start == end)
            {
                return date == start;
            }

            if (start > end)
            {
                throw new Exception("左侧边界不能大于右侧边界！");
            }

            if (isLimitStart && isLimitEnd)
            {
                return start <= date && date <= end;
            }
            else if (isLimitStart && !isLimitEnd)
            {
                return start <= date && date < end;
            }
            else if (!isLimitStart && isLimitEnd)
            {
                return start < date && date <= end;
            }
            else
            {
                return start < date && date < end;
            }
        }

        /// <summary>
        /// 获得阴历日期
        /// </summary>
        /// <param name="dateTime">阳历时间</param>
        /// <returns>字符串表示</returns>
        public static string ToChineseLunisolarCalendar(DateTime dateTime)
        {
            ChineseLunisolarCalendar chineseLunisolarCalendar = new ChineseLunisolarCalendar();
            return string.Format("{0}-{1}-{2}", chineseLunisolarCalendar.GetYear(dateTime).ToString(), chineseLunisolarCalendar.GetMonth(dateTime).ToString("00"), chineseLunisolarCalendar.GetDayOfMonth(dateTime).ToString("00"));
        }
    }
}
