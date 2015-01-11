<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {
    /*
     * 泛型相关
     */

    class SmartGeneric {
        /*
         * 加号（+），将返回为左操作数类型的结果
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return object，相加的和
         * 
         */

        public static function add($left, $right) {
            return $left + $right;
        }

        /*
         * 减号（-），将返回为左操作数类型的结果
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return object，相减的差
         * 
         */

        public static function subtract($left, $right) {
            return $left - $right;
        }

        /*
         * 乘号（×），将返回为左操作数类型的结果
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return object，相乘的积
         * 
         */

        public static function multiply($left, $right) {
            return $left * $right;
        }

        /*
         * 除号（／），将返回为左操作数类型的结果
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return object，相除的商
         * 
         */

        public static function divide($left, $right) {
            return $left / $right;
        }

        /*
         * 大于号（＞），左操作数是否大于右操作数
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return bool，比较的结果
         * 
         */

        public static function moreThan($left, $right) {
            return $left > $right;
        }

        /*
         * 小于号（＜），左操作数是否小于右操作数
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return bool，比较的结果
         * 
         */

        public static function lessThan($left, $right) {
            return $left < $right;
        }

        /*
         * 大于等于号（≥），左操作数是否大于等于右操作数
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return bool，比较的结果
         * 
         */

        public static function moreThanOrEquals($left, $right) {
            return $left >= $right;
        }

        /*
         * 小于等于号（≤），左操作数是否小于等于右操作数
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return bool，比较的结果
         * 
         */

        public static function lessThanOrEquals($left, $right) {
            return $left <= $right;
        }

        /*
         * 等于号（＝＝），左操作数是否等于右操作数
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return bool，比较的结果
         * 
         */

        public static function equals($left, $right) {
            return $left == $right;
        }

        /*
         * 不等于号（!＝），左操作数是否不等于右操作数
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return bool，比较的结果
         * 
         */

        public static function notEquals($left, $right) {
            return !self::equals($left, $right);
        }

        /*
         * 求余数（%），将返回为左操作数类型的结果
         * 
         * @param object $left，左操作数
         * @param object $right，右操作数
         * @return object，相除的余数
         * 
         */

        public static function divideRemainder($left, $right) {
            return $left % $right;
        }

        /*
         * 递增（++）
         * 
         * @param object $number，输入
         * @return object，递增的结果
         * 
         */

        public static function increase($number) {
            $number++;
            return $number;
        }

        /*
         * 递减（--）
         * 
         * @param object $number，输入
         * @return object，递减的结果
         * 
         */

        public static function decrease($number) {
            $number--;
            return $number;
        }

        /*
         * 取反（-）
         * 
         * @param object $number，输入
         * @return object，取反的结果
         * 
         */

        public static function reverse($number) {
            return -$number;
        }

    }

}
