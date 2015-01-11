<?php

namespace Smartkernel\Framework\Data {

    use \DateTime;

/*
     * Db时间类型
     */

    class SmartDbDateTime {
        /*
         * 默认
         * 
         * @return DateTime，结果
         * 
         */

        public static function getDefaultValue() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "1900-01-01 00:00:00");
        }

        /*
         * 开始时间（SqlServer的DateTime最小值为1753-01-01 00:00:00，MySql的DateTime最小值为1000-01-01 00:00:00，取二者最大的）
         * 
         * @return DateTime，结果
         * 
         */

        public static function getMinTime() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "1753-01-01 00:00:00");
        }

        /*
         * 结束时间（SqlServer和MySql的DateTime最大值一样）
         * 
         * @return DateTime，结果
         * 
         */

        public static function getMaxTime() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "9999-12-31 23:59:59");
        }

        /*
         * 开始时间（SqlServer的DateTime最小值为1753-01-01 00:00:00，MySql的DateTime最小值为1000-01-01 00:00:00，取二者最大的）
         * 
         * @return DateTime，结果
         * 
         */

        public static function getMinDate() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "1753-01-01 00:00:00");
        }

        /*
         * 结束时间（SqlServer和MySql的DateTime最大值一样）
         * 
         * @return DateTime，结果
         * 
         */

        public static function getMaxDate() {
            return DateTime::createFromFormat("Y-m-d H:i:s", "9999-12-31 00:00:00");
        }

        /*
         * 是否合法的时间
         * 
         * @param DateTime $dateTime，时间
         * @return bool，结果
         */

        public static function isLegalDateTime(DateTime $dateTime) {
            if ($dateTime < self::getMinTime() || $dateTime > self::getMaxTime()) {
                return false;
            }

            return true;
        }

    }

}