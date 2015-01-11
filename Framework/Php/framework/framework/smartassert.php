<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use \Exception;

/*
     * 断言
     */

    class SmartAssert {
        /*
         * 判断是否为True，不为True则抛出异常
         * 
         * @param bool $input，待判断项目
         * 
         */

        public static function isTrue($input) {
            if ($input === false) {
                throw new Exception(var_export(debug_backtrace()));
            }
        }

        /*
         * 判断是否为False，不为False则抛出异常
         * 
         * @param bool $input，待判断项目
         * 
         */

        public static function isFalse($input) {
            if ($input === true) {
                throw new Exception(var_export(debug_backtrace()));
            }
        }

        /*
         * 判断是否相等，不相等则抛出异常
         * 
         * @param object $left，左对象
         * @param object $right，右对象
         * 
         */

        public static function isEquals($left, $right) {
            if ($left !== $right) {
                throw new Exception(var_export(debug_backtrace()));
            }
        }

        /*
         * 判断是否不相等，相等则抛出异常
         * 
         * @param object $left，左对象
         * @param object $right，右对象
         * 
         */

        public static function isNotEquals($left, $right) {
            if ($left !== $right) {
                throw new Exception(var_export(debug_backtrace()));
            }
        }

        /*
         * 判断是否为Null，不为Null则抛出异常
         * 
         * @param bool $input，待判断项目
         * 
         */

        public static function isNull($input) {
            if ($input !== null) {
                throw new Exception(var_export(debug_backtrace()));
            }
        }

        /*
         * 判断是否不为Null，为Null则抛出异常
         * 
         * @param bool $input，待判断项目
         * 
         */

        public static function isNotNull($input) {
            if ($input === null) {
                throw new Exception(var_export(debug_backtrace()));
            }
        }

    }

}
