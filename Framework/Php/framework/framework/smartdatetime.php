<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use \DateTime;
    use \Exception;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\SmartArray;
    use Smartkernel\Framework\SmartDayOfWeekType;
    use Smartkernel\Framework\SmartChineseLunisolarCalendar;

/*
     * 时间
     */

    class SmartDateTime {
        /*
         * 获得指定年月的天数
         * 
         * @param int $year，年
         * @param int $month，月
         * @return int，天数
         * 
         */

        public static function getDaysInMonth($year, $month) {
            return (new DateTime(sprintf("%s-%02s-01", $year, $month)))->format("t");
        }

        /*
         * 获得指定年的天数
         * 
         * @param int $year，年
         * @return int，天数
         * 
         */

        public static function getDaysInYear($year) {
            $reault = 0;
            for ($i = 1; $i <= 12; $i++) {
                $reault+=self::daysInMonth($year, $i);
            }
            return intval($reault);
        }

        /*
         * 开始时间
         * 
         * @return DateTime，结果
         * 
         */

        public static function getMinTime() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "0001-01-01 00:00:00");
        }

        /*
         * 结束时间
         * 
         * @return DateTime，结果
         * 
         */

        public static function getMaxTime() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "9999-12-31 23:59:59");
        }

        /*
         * 当前时间
         * 
         * @return DateTime，结果
         * 
         */

        public static function nowTime() {
            return new DateTime();
        }

        /*
         * JavaScript最小时间
         * 
         * * @return DateTime，结果
         * 
         */

        public static function javaScriptMinTime() {
            return self::parse("1970-01-01 08:00:00");
        }

        /*
         * 当前日期
         * 
         * @return DateTime，结果
         * 
         */

        public static function now() {
            $format = "Y-m-d H:i:s";
            $now = self::nowTime();
            $input = $now->format($format);
            return $input;
        }

        /*
         * 当前日期
         * 
         * @return DateTime，结果
         * 
         */

        public static function nowDate() {
            $format = "Y-m-d H:i:s";
            $now = self::nowTime();
            $input = $now->format("Y-m-d 00:00:00");
            return DateTime::createFromFormat($format, $input);
        }

        /*
         * 解析
         * 
         * @param string $input，输入
         * @param string $format，格式
         * @return DateTime，结果
         * 
         */

        public static function parse($input, $format = null) {
            if ($format === null) {
                return new DateTime($input);
            } else {
                return DateTime::createFromFormat($format, $input);
            }
        }

        /*
         * 增加n天
         * 
         * @param DateTime $dateTime，时间
         * @param int $days，天数
         * @return DateTime，结果
         * 
         */

        public static function addDays(DateTime $dateTime, $days) {
            return $dateTime->modify(sprintf("%s day", strval($days)));
        }

        /*
         * 增加n小时
         * 
         * @param DateTime $dateTime，时间
         * @param int $hours，小时
         * @return DateTime，结果
         * 
         */

        public static function addHours(DateTime $dateTime, $hours) {
            return $dateTime->modify(sprintf("%s hours", strval($hours)));
        }

        /*
         * 增加n月
         * 
         * @param DateTime $dateTime，时间
         * @param int $months，月
         * @return DateTime，结果
         * 
         */

        public static function addMonths(DateTime $dateTime, $months) {
            return $dateTime->modify(sprintf("%s months", strval($months)));
        }

        /*
         * 增加n秒
         * 
         * @param DateTime $dateTime，时间
         * @param int $seconds，秒数
         * @return DateTime，结果
         * 
         */

        public static function addSeconds(DateTime $dateTime, $seconds) {
            return $dateTime->modify(sprintf("%s seconds", strval($seconds)));
        }

        /*
         * 增加n年
         * 
         * @param DateTime $dateTime，时间
         * @param int $years，年数
         * @return DateTime，结果
         * 
         */

        public static function addYears(DateTime $dateTime, $years) {
            return $dateTime->modify(sprintf("%s years", strval($years)));
        }

        /*
         * 获得日期部分
         * 
         * @param DateTime $dateTime，日期
         * @return DateTime，结果
         * 
         */

        public static function getDate(DateTime $dateTime) {
            $format = "Y-m-d H:i:s";
            $input = $dateTime->format("Y-m-d 00:00:00");
            return DateTime::createFromFormat($format, $input);
        }

        /*
         * 获得时间部分
         * 
         * @param DateTime $dateTime，日期
         * @return string，结果
         * 
         */

        public static function getTime(DateTime $dateTime) {
            return $dateTime->format("H:i:s");
        }

        /*
         * 获得天
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getDay(DateTime $dateTime) {
            return intval($dateTime->format("j"));
        }

        /*
         * 获得月
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getMonth(DateTime $dateTime) {
            return intval($dateTime->format("n"));
        }

        /*
         * 获得年
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getYear(DateTime $dateTime) {
            return intval($dateTime->format("Y"));
        }

        /*
         * 获得小时
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getHour(DateTime $dateTime) {
            return intval($dateTime->format("H"));
        }

        /*
         * 获得分
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getMinute(DateTime $dateTime) {
            return intval($dateTime->format("i"));
        }

        /*
         * 获得秒
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getSecond(DateTime $dateTime) {
            return intval($dateTime->format("s"));
        }

        /*
         * 获得周几（周日为0）
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getDayOfWeek(DateTime $dateTime) {
            return intval($dateTime->format("w"));
        }

        /*
         * 获得第几天（从1开始）
         * 
         * @param DateTime $dateTime，日期
         * @return int，结果
         * 
         */

        public static function getDayOfYear(DateTime $dateTime) {
            return intval($dateTime->format("z")) + 1;
        }

        /*
         * 是否是闰年
         * 
         * @param int $year，年
         * @return bool，结果
         * 
         */

        public static function isLeapYear($year) {
            return DateTime::createFromFormat("Y-m-d H:i:s", $year . "-01-01 00:00:00")->format("L") === "1";
        }

        /*
         * 获得时区
         * 
         * @param DateTime $dateTime，日期
         * @return string，结果
         * 
         */

        public static function getTimeZone(DateTime $dateTime) {
            return $dateTime->format("e");
        }

        /*
         * 解析配置
         * 
         * @param string $value，值
         * @param string $regioneSplit，区域分割线
         * @param string $partSplit，部分分割线
         * @return array，结果
         * 
         */

        public static function parseArray($value, $regioneSplit = '|', $partSplit = '~') {
            $regiones = SmartString::split($value, $regioneSplit);
            $dataDates = array();
            $length = count($regiones);
            for ($i = 0; $i < $length; $i++) {
                $region = $regiones[$i];
                $parts = SmartString::split($region, $partSplit);
                if (count($parts) == 2) {
                    //说明是范围
                    $left = self::parse($parts[0]);
                    $right = self::parse($parts[1]);

                    if ($left < $right) {
                        for ($now = $left; $now <= $right; $now = self::addDays($now, 1)) {
                            if (!SmartArray::contains($dataDates, $now)) {
                                $dataDates[] = clone $now;
                            }
                        }
                    } else if ($left > $right) {
                        for ($now = $left; $now >= $right; $now = self::addDays($now, -1)) {
                            if (!SmartArray::contains($dataDates, $now)) {
                                $dataDates[] = clone $now;
                            }
                        }
                    } else {
                        if (!SmartArray::contains($dataDates, $left)) {
                            $dataDates[] = clone $left;
                        }
                    }
                } else {
                    if (!SmartArray::contains($dataDates, self::parse($region))) {
                        $dataDates[] = clone self::parse($region);
                    }
                }
            }

            return $dataDates;
        }

        /*
         * 获得月间隔
         * 
         * @param DateTime $start,开始时间
         * @param DateTime $end,结束时间
         * @return array，结果
         * 
         */

        public static function getMonthInterval($start, $end) {
            if ($start > $end) {
                throw new Exception("开始时间必须小于等于结束时间！");
            }
            $result = array();

            for ($y = self::getYear($start); $y <= self::getYear($end); $y++) {
                if (self::getYear($start) == self::getYear($end)) {
                    for ($m = self::getMonth($start); $m <= self::getMonth($end); $m++) {
                        array_push($result, self::parse(sprintf("%04d-%02d-01 00:00:00", $y, $m)));
                    }
                } else if ($y == self::getYear($start)) {
                    for ($m = self::getMonth($start); $m <= 12; $m++) {
                        array_push($result, self::parse(sprintf("%04d-%02d-01 00:00:00", $y, $m)));
                    }
                } else if ($y == self::getYear($end)) {
                    for ($m = 1; $m <= self::getMonth($end); $m++) {
                        array_push($result, self::parse(sprintf("%04d-%02d-01 00:00:00", $y, $m)));
                    }
                } else {
                    for ($m = 1; $m <= 12; $m++) {
                        array_push($result, self::parse(sprintf("%04d-%02d-01 00:00:00", $y, $m)));
                    }
                }
            }

            return $result;
        }

        /*
         * 验证是不是日期格式。注意，20080123这样的格式是不能验证的，必须是2008-01-23或2008年01月23
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isDateTime($input) {
            try {
                self::parse($input);
                return true;
            } catch (Exception $err) {
                return false;
            }
        }

        /*
         * 获得某个时间点所在年的开始时间
         * 
         * @param int $year，年
         * @return DateTime，开始时间
         * 
         */

        public static function getStartTimeOfYear($year) {
            return self::parse(SmartString::format("{0}-01-01 00:00:00.000", $year));
        }

        /*
         * 获得某个时间点所在年的开始时间
         * 
         * @param int $year，年
         * @return DateTime，开始时间
         * 
         */

        public static function getEndTimeOfYear($year) {
            return self::parse(SmartString::format("{0}-12-31 23:59:59.998", $year));
        }

        /*
         * 获得某个时间点所在月的开始时间
         * 
         * @param int $year，年
         * @param int $month，月
         * @return DateTime，开始时间
         * 
         */

        public static function getStartTimeOfMonth($year, $month) {
            return self::parse(SmartString::format("{0}-{1}-01 00:00:00.000", $year, sprintf("%02d", $month)));
        }

        /*
         * 获得某个时间点所在月的结束时间
         * 
         * @param int $year，年
         * @param int $month，月
         * @return DateTime，结束时间
         * 
         */

        public static function getEndTimeOfMonth($year, $month) {
            return self::parse(SmartString::format("{0}-{1}-{2} 23:59:59.998", $year, sprintf("%02d", intval($month)), sprintf("%02d", intval(self::getDaysInMonth($year, $month)))));
        }

        /*
         * 获得某个时间点所在日的开始时间
         * 
         * @param int $year，年
         * @param int $month，月
         * @param int $day，日
         * @return DateTime，开始时间
         * 
         */

        public static function getStartTimeOfDay($year, $month, $day) {
            return self::parse(SmartString::format("{0}-{1}-{2} 00:00:00.000", $year, sprintf("%02d", $month), sprintf("%02d", $day)));
        }

        /*
         * 获得某个时间点所在日的结束时间
         * 
         * @param int $year，年
         * @param int $month，月
         * @param int $day，日
         * @return DateTime，结束时间
         * 
         */

        public static function getEndTimeOfDay($year, $month, $day) {
            return self::parse(SmartString::format("{0}-{1}-{2} 23:59:59.998", $year, sprintf("%02d", $month), sprintf("%02d", $day)));
        }

        /*
         * 获得阴历日期
         * 
         * @param DateTime $dateTime，阳历时间
         * @return string，字符串表示
         * 
         */

        public static function toChineseLunisolarCalendar($dateTime) {
            return SmartChineseLunisolarCalendar::toChineseLunisolarCalendar($dateTime);
        }

        private static $animals = array("猴", "鸡", "狗", "猪", "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊");

        /*
         * 根据年份判断生肖
         * 
         * @param int $year，年份
         * @return string，生肖
         * 
         */

        public static function getTwelveAnimal($year) {
            return self::$animals[$year % 12];
        }

        /*
         * 日期的格式化
         * 
         * @param DateTime $dateTime，待格式化的日期
         * @param string $format，格式化字符串
         * @return string，格式化之后的字符串
         * 
         */

        public static function format($dateTime, $format = "Y-m-d H:i:s") {
            return $dateTime->format($format);
        }

        /*
         * 通过时间部分获得今天日期的完整形式
         * 
         * @param DateTime $dateTime，日期部分
         * @param string $timePart，时间部分
         * @return DateTime，今天日期的完整形式
         * 
         */

        public static function getCombineTime($dateTime, $timePart) {
            return self::parse(SmartString::format("{0}-{1}-{2} {3}", self::getYear($dateTime), self::getMonth($dateTime), self::getDay($dateTime), $timePart));
        }

        /*
         * 获得日期在一年星期中的星期数
         * 
         * @param DateTime $dateTime，日期
         * @return int，星期
         * 
         */

        public static function getWeekOrderOfYear($dateTime) {
            $weekvalue = intval(self::getDayOfYear($dateTime) / 7);
            $remainder = self::getDayOfYear($dateTime) % 7;
            if ($remainder == 0) {
                return $weekvalue;
            } else {
                return $weekvalue + 1;
            }
        }

        /*
         * 获得日期所在周的开始时间
         * 
         * @param DateTime $dateTime，某个时间
         * @return DateTime，获得日期所在周的开始时间
         * 
         */

        public static function getStartTimeOfWeek(DateTime $dateTime) {
            $dataTime = $dateTime->format("Y-m-d");
            $dateTime = self::parse($dataTime);
            $result = self::getMinTime();
            $dayOfWeek = self::getDayOfWeek($dateTime);
            if ($dayOfWeek == SmartDayOfWeekType::Monday) {
                $result = self::addDays($dateTime, -1);
            } else if ($dayOfWeek == SmartDayOfWeekType::Tuesday) {
                $result = self::addDays($dateTime, -2);
            } else if ($dayOfWeek == SmartDayOfWeekType::Wednesday) {
                $result = self::addDays($dateTime, -3);
            } else if ($dayOfWeek == SmartDayOfWeekType::Thursday) {
                $result = self::addDays($dateTime, -4);
            } else if ($dayOfWeek == SmartDayOfWeekType::Friday) {
                $result = self::addDays($dateTime, -5);
            } else if ($dayOfWeek == SmartDayOfWeekType::Saturday) {
                $result = self::addDays($dateTime, -6);
            }
            if (self::getYear($result) != self::getYear($dateTime)) {
                $result = new DateTime(self::getYear($dateTime), 1, 1);
            }
            return self::addDays($result, 1);
        }

        /*
         * 获得日期所在周的结束时间
         * 
         * @param DateTime $dateTime，某个时间
         * @return DateTime，获得日期所在周的结束时间
         * 
         */

        public static function getEndTimeOfWeek(DateTime $dateTime) {
            $startTimeOfWeek = self::getStartTimeOfWeek($dateTime);
            $dataTime = SmartString::format("{0} 23:59:59.998", $startTimeOfWeek->format("Y-m-d"));
            return SmartDateTime::addDays(SmartDateTime::parse($dataTime), 6);
        }

        /*
         * 
         * 是否在两个日期之间
         * 
         * @param DateTime $date，要比较的日期
         * @param DateTime $start，开始
         * @param DateTime $end，结束
         * @param bool $isLimitStart，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界
         * @param bool $isLimitEnd，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界
         * @return bool，结果
         * 
         */

        public static function between(DateTime $date, DateTime $start, DateTime $end, $isLimitStart = false, $isLimitEnd = false) {
            if ($start == $end) {
                return $date == start;
            }

            if ($start > $end) {
                throw new Exception("左侧边界不能大于右侧边界！");
            }

            if ($isLimitStart && $isLimitEnd) {
                return $start <= $date && $date <= $end;
            } else if ($isLimitStart && !$isLimitEnd) {
                return $start <= $date && $date < $end;
            } else if (!$isLimitStart && $isLimitEnd) {
                return $start < $date && $date <= $end;
            } else {
                return $start < $date && $date < $end;
            }
        }

        /*
         * 获得两个时间的间隔信息（结束时间应该大于开始时间）
         * 
         * @param DateTime $startDateTime，开始时间
         * @param DateTime $endDateTime，结束之间
         * @param string $format，格式化字符串
         * @return string，间隔信息
         * 
         */

        public static function getIntervalInfo(DateTime $startDateTime, DateTime $endDateTime, $format = "%.1f") {
            $intervalSeconds = $endDateTime->getTimestamp() - $startDateTime->getTimestamp();
            $intervalMinutes = $intervalSeconds / 60;
            $intervalHours = $intervalMinutes / 60;
            $intervalDays = $intervalHours / 24;

            if ($intervalDays >= 365) {
                return sprintf($format, $intervalDays) . "年";
            } else if ($intervalDays >= 30) {
                return sprintf($format, $intervalDays) . "月";
            } else if ($intervalDays >= 1) {
                return sprintf($format, $intervalDays) . "天";
            } else if ($intervalHours >= 1) {
                return sprintf($format, $intervalHours) . "小时";
            } else if ($intervalMinutes >= 1) {
                return sprintf($format, $intervalMinutes) . "分钟";
            } else {
                return sprintf($format, $intervalSeconds) . "秒钟";
            }
        }

    }

}