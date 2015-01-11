/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Globalization;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 日历
    /// </summary>
    public static class SmartCalendar
    {
        /// <summary>
        /// 获得一项
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>结果</returns>
        public static SmartCalendarItem GetItem(DateTime dateTime)
        {
            var dataTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd"));

            var yearQuarter = 0;
            var dayOfQuarter = 0;

            if (dataTime.Month == 1 || dataTime.Month == 2 || dataTime.Month == 3)
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "01");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-01-01"))).TotalDays + 1);
            }
            else if (dataTime.Month == 4 || dataTime.Month == 5 || dataTime.Month == 6)
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "02");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-04-01"))).TotalDays + 1);
            }
            else if (dataTime.Month == 7 || dataTime.Month == 8 || dataTime.Month == 9)
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "03");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-07-01"))).TotalDays + 1);
            }
            else
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "04");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-10-01"))).TotalDays + 1);
            }

            var gregorianCalendar = new GregorianCalendar();

            var result = new SmartCalendarItem
            {
                Date = dataTime,
                Year = dataTime.Year,
                YearMonth = Convert.ToInt32(dataTime.ToString("yyyyMM")),
                YearMonthDay = Convert.ToInt32(dataTime.ToString("yyyyMMdd")),
                YearWeek = Convert.ToInt32(dateTime.Year.ToString() + gregorianCalendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString("00")),
                YearWeekDay = Convert.ToInt32(dateTime.Year.ToString() + gregorianCalendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString("00") + (Convert.ToInt32(gregorianCalendar.GetDayOfWeek(dataTime)) + 1).ToString("00")),
                YearQuarter = yearQuarter,
                YearQuarterDay = Convert.ToInt32(yearQuarter.ToString() + dayOfQuarter.ToString("00"))
            };

            return result;
        }
    }
}
