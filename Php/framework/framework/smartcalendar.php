<?php

namespace Smartkernel\Framework {

    use \DateTime;

/*
     * 日历
     */

    class SmartCalendar {
        /*
         * 
         * 
         * */

        /*
         * 获得一项
         * 
         * @param DateTime $dateTime，日期
         * @return SmartCalendarItem，结果
         * 
         */

        public static function getItem($dateTime) {
            $dateTime = DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-m-d 00:00:00"));

            $currentYearStartTime = DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-01-01 00:00:00"));

            //周定义：周五（1）、周六（2）、周日（3）、周一（4）、周二（5）、周三（6）、周四（7）
            $dayOfKpiWeek = 1;
            $dateTimeDayOfWeek = $dateTime->format("N");
            switch ($dateTimeDayOfWeek) {
                case 5:
                    $dayOfKpiWeek = 1;
                    break;
                case 6:
                    $dayOfKpiWeek = 2;
                    break;
                case 7:
                    $dayOfKpiWeek = 3;
                    break;
                case 1:
                    $dayOfKpiWeek = 4;
                    break;
                case 2:
                    $dayOfKpiWeek = 5;
                    break;
                case 3:
                    $dayOfKpiWeek = 6;
                    break;
                case 4:
                    $dayOfKpiWeek = 7;
                    break;
            }

            $currentDayOfKpiWeek = 1;
            $currentYearStartTimeDayOfWeek = $currentYearStartTime->format("N");
            switch ($currentYearStartTimeDayOfWeek) {
                case 5:
                    $currentDayOfKpiWeek = 1;
                    break;
                case 6:
                    $currentDayOfKpiWeek = 2;
                    break;
                case 7:
                    $currentDayOfKpiWeek = 3;
                    break;
                case 1:
                    $currentDayOfKpiWeek = 4;
                    break;
                case 2:
                    $currentDayOfKpiWeek = 5;
                    break;
                case 3:
                    $currentDayOfKpiWeek = 6;
                    break;
                case 4:
                    $currentDayOfKpiWeek = 7;
                    break;
            }

            $currentYearStartTime = $currentYearStartTime->modify(sprintf("%s day", strval(-($currentDayOfKpiWeek - 1))));

            if (intval($currentYearStartTime->format("Y")) == (intval($dateTime->format("Y")) - 1)) {
                $currentYearStartTime = $currentYearStartTime->modify("7 day");
            }

            //最后一周如果跨年，算上一年的最后一周
            $currentKpiWeek = intval(floor($dateTime->diff($currentYearStartTime)->days / 7)) + 1;
            $yearKpiWeek = 0;

            if ($currentKpiWeek == 0) {
                $lastYearEndTime = DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-01-01 00:00:00"))->modify("-1 day");
                $yearKpiWeek = self::getItem($lastYearEndTime)->KpiYearWeek;
            } else {
                $yearKpiWeek = intval($dateTime->format("Y") . sprintf("%02d", $currentKpiWeek));
            }

            $yearQuarter = 0;
            $dayOfQuarter = 0;

            if (intval($dateTime->format("m")) == 1 || intval($dateTime->format("m")) == 2 || intval($dateTime->format("m")) == 3) {
                $yearQuarter = intval($dateTime->format("Y") . "01");
                $dayOfQuarter = intval($dateTime->diff(DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-01-01 00:00:00")))->days + 1);
            } else if (intval($dateTime->format("m")) == 4 || intval($dateTime->format("m")) == 5 || intval($dateTime->format("m")) == 6) {
                $yearQuarter = intval($dateTime->format("Y") . "02");
                $dayOfQuarter = intval($dateTime->diff(DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-04-01 00:00:00")))->days + 1);
            } else if (intval($dateTime->format("m")) == 7 || intval($dateTime->format("m")) == 8 || intval($dateTime->format("m")) == 9) {
                $yearQuarter = intval($dateTime->format("Y") . "03");
                $dayOfQuarter = intval($dateTime->diff(DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-07-01 00:00:00")))->days + 1);
            } else {
                $yearQuarter = intval($dateTime->format("Y") . "04");
                $dayOfQuarter = intval($dateTime->diff(DateTime::createFromFormat("Y-m-d H:i:s", $dateTime->format("Y-10-01 00:00:00")))->days + 1);
            }

            $result = new SmartCalendarItem();

            $result->Date = $dateTime;
            $result->Year = $dateTime->format("Y");
            $result->YearMonth = intval($dateTime->format("Ym"));
            $result->YearMonthDay = intval($dateTime->format("Ymd"));
            $result->KpiYearWeek = $yearKpiWeek;
            $result->KpiYearWeekDay = intval(strval($yearKpiWeek) . sprintf("%02d", $dayOfKpiWeek));
            $result->YearWeek = intval($dateTime->format("Y") . $dateTime->format("W"));
            $result->YearWeekDay = intval($dateTime->format("Y") . $dateTime->format("W") . sprintf("%02d", (intval($dateTime->format("N")) + 1)));
            $result->YearQuarter = $yearQuarter;
            $result->YearQuarterDay = intval(strval($yearQuarter) . sprintf("%02d", $dayOfQuarter));

            return $result;
        }

    }

}