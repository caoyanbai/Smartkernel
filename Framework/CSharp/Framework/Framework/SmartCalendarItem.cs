/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework
{
    /// <summary>
    /// 日历项
    /// </summary>
    public class SmartCalendarItem
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public int YearMonth { get; set; }

        /// <summary>
        /// 年月日
        /// </summary>
        public int YearMonthDay { get; set; }

        /// <summary>
        /// 年周
        /// </summary>
        public int YearWeek { get; set; }

        /// <summary>
        /// 年周日
        /// </summary>
        public int YearWeekDay { get; set; }

        /// <summary>
        /// 年季
        /// </summary>
        public int YearQuarter { get; set; }

        /// <summary>
        /// 年季日
        /// </summary>
        public int YearQuarterDay { get; set; }
    }
}
