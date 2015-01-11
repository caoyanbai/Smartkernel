<?php

namespace Smartkernel\Framework {

    use \Exception;
    use Smartkernel\Framework\SmartMath;

/*
     * 数字类型相关
     */

    class SmartNumeric {
        /*
         * 是否是0
         * 
         * @param float $input，待检查的数字
         * @param float $compareValue，比较的值
         * @return bool，结果
         * 
         */

        public static function isZero($input, $compareValue = 2.2204460492503131E-15) {
            return SmartMath::abs($input) < $compareValue;
        }

        /*
         * 近似相等
         * 
         * @param float $left，左操作数
         * @param float $right，右操作数
         * @param float $compareValue，比较的值
         * @return bool，是否相等
         * 
         */

        public static function nearEquals($left, $right, $compareValue = 2.2204460492503131E-16) {
            if ($left == $right) {
                return true;
            }
            $a = (SmartMath::abs($left) + SmartMath::abs($right) + 10.0) * $compareValue;
            $b = $left - $right;
            return (-$a < $b) && ($a > $b);
        }

        /*
         * 是否在两个数字之间
         * 
         * @param float $number，要比较的数字
         * @param float $from，开始
         * @param float $to，结束
         * @param bool $isLimitFrom，是否包含左边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界
         * @param bool $isLimitTo，是否包含右边界，False时，通常不包括边界，也就是等于边界认为是不在范围内，但两个边界相同时如果相等，认为在边界内。True时包含边界
         * @return bool，结果
         * 
         */

        public static function between($number, $from, $to, $isLimitFrom = false, $isLimitTo = false) {
            if ($from == $to) {
                return $number == $from;
            }

            if ($from > $to) {
                throw new Exception("左侧边界不能大于右侧边界！");
            }

            if ($isLimitFrom && $isLimitTo) {
                return $from <= $number && $number <= $to;
            } else if ($isLimitFrom && !$isLimitTo) {
                return $from <= $number && $number < $to;
            } else if (!$isLimitFrom && $isLimitTo) {
                return $from < $number && $number <= $to;
            } else {
                return $from < $number && $number < $to;
            }
        }

        /*
         * 验证是不是Double类型的数字：25，1.23，-10等都是合法的数字
         * 
         * @param string $input，待检查的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isFloat($input) {
            $input = floatval($input);
            return is_float($input);
        }

        /*
         * 验证是不是正整数：大于0的整数（2.0，+32.0,3.也判断为正整数）
         * 
         * @param string $input，待检查的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isPositiveInteger($input) {
            $pattern1 = "/^[+]?[0-9]+[.]?[0]*$/";
            $pattern2 = "/^[+-]?[0]+[.]?[0]*$/";
            return self::isFloat($input) && floatval($input) > 0 && (preg_match($pattern1, $input) > 0 || preg_match($pattern2, $input));
        }

        /*
         * 验证是不是整数：可以为正也可以为负（0.0，2.0，+32.0，-123.00000，3.也判断为整数）
         * 
         * @param string $input，待检查的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isInteger($input) {
            $pattern = "/^[+-]?[0-9]+[.]?[0]*$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是数字
         * 
         * @param string $input，待检查的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isNumberic($input) {
            return self::isFloat($input);
        }

        /*
         * 验证小数位数是不是在指定的范围内
         * 
         * @param string $input，待检查的字符串
         * @param int $start，起始边界
         * @param int $end，结束边界
         * @return bool，验证的结果
         * 
         */

        public static function isDecimalDigitsBetween($input, $start, $end) {
            $pattern = sprintf("/^[+-]?[0-9]+(.[0-9]{%d,%d})$/", $start, $end);
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证小数位数是不是指定的长度
         * 
         * @param string $input，待检查的字符串
         * @param int $start，起始边界
         * @param int $end，结束边界
         * @return bool，验证的结果
         * 
         */

        public static function isDecimalDigits($input, $length = 2) {
            $pattern = sprintf("/^[+-]?[0-9]+(.[0-9]{%d})$/", $length);
            return preg_match($pattern, $input) > 0;
        }

    }

}
