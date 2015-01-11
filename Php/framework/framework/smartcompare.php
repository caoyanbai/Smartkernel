<?php

namespace Smartkernel\Framework {
    /*
     * 比较
     */

    class SmartCompare {
        /*
         * 判断一个值是否在一个值范围内
         * 
         * @param number $input，输入
         * @param number $start，开始
         * @param number $end，结束
         * @return bool，结果
         * 
         */

        public static function inScope($input, $start, $end) {
            return $input >= $start && $input <= $end;
        }

        /*
         * 判断一个值是否不在一个值范围内
         * 
         * @param number $input，输入
         * @param number $start，开始
         * @param number $end，结束
         * @return bool，结果
         * 
         */

        public static function notInScope($input, $start, $end) {
            return !self::inScope($input, $start, $end);
        }

        /*
         * 判断一个值是否在一个值范围内（有一个在其范围内即为真）
         * 
         * @param array $inputs，输入
         * @param number $start，开始
         * @param number $end，结束
         * @return bool，结果
         * 
         */

        public static function anyInScope(array $inputs, $start, $end) {
            foreach ($inputs as $input) {
                if (self::inScope($input, $start, $end)) {
                    return true;
                }
            }
            return false;
        }

        /*
         * 判断一个值是否不在一个值范围内（有一个在其范围内即为假）
         * 
         * @param array $inputs，输入
         * @param number $start，开始
         * @param number $end，结束
         * @return bool，结果
         * 
         */

        public static function notAnyInScope(array $inputs, $start, $end) {
            return self::anyInScope($inputs, $start, $end);
        }

        /*
         * 判断一个值是否在一个值范围内（有一个在其范围内即为真）
         * 
         * @param array $inputs，输入
         * @param number $start，开始
         * @param number $end，结束
         * @return bool，结果
         * 
         */

        public static function allInScope(array $inputs, $start, $end) {
            foreach ($inputs as $input) {
                if (!self::inScope($input, $start, $end)) {
                    return false;
                }
            }
            return true;
        }

        /*
         * 判断一个值是否不在一个值范围内（有一个在其范围内即为假）
         * 
         * @param array $inputs，输入
         * @param number $start，开始
         * @param number $end，结束
         * @return bool，结果
         * 
         */

        public static function notAllInScope(array $inputs, $start, $end) {
            return self::allInScope($inputs, $start, $end);
        }

    }

}
