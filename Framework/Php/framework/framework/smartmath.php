<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use Smartkernel\Framework\SmartGeneric;
    use Smartkernel\Framework\Collections\SmartKeyValuePair;

/*
     * 数学辅助类
     */

    class SmartMath {
        /*
         * 取绝对值
         * 
         * @param number $input，输入
         * @return float，结果
         * 
         */

        public static function abs($input) {
            return abs($input);
        }

        /*
         * 返回大于等于输入值的最小整数
         * 
         * @param number $input，输入
         * @return float，结果
         * 
         */

        public static function ceiling($input) {
            return ceil($input);
        }

        /*
         * 返回小于等于输入值的最大整数
         * 
         * @param number $input，输入
         * @return float，结果
         * 
         */

        public static function floor($input) {
            return floor($input);
        }

        /*
         * 取最大值
         * 
         * @param number $left，输入
         * @param number $right，输入
         * @return float，结果
         * 
         */

        public static function max($left, $right) {
            return max($left, $right);
        }

        /*
         * 取最小值
         * 
         * @param number $left，输入
         * @param number $right，输入
         * @return float，结果
         * 
         */

        public static function min($left, $right) {
            return min($left, $right);
        }

        /*
         * 计算幂
         * 
         * @param number $x，输入
         * @param number $y，幂
         * @return float，结果
         * 
         */

        public static function pow($x, $y) {
            return pow($x, $y);
        }

        /*
         * 按指定的小数位舍入
         * 
         * @param number $d，输入
         * @param int $decimals，小数位数
         * @return float，结果
         * 
         */

        public static function round($d, $decimals) {
            return round($d, $decimals);
        }

        /*
         * 获取符号（-1为负数，1为正数）
         * 
         * @param number $input，输入
         * @return int，结果
         * 
         */

        public static function sign($input) {
            if ($input > 0) {
                return 1;
            } else if ($input < 0) {
                return -1;
            } else {
                return 0;
            }
        }

        /*
         * 开平方
         * 
         * @param number $input，输入
         * @return float，结果
         * 
         */

        public static function sqrt($input) {
            return sqrt($input);
        }

        /*
         * 计算表达式
         * 
         * @param string $expression，表达式
         * @return float，结果
         * 
         * */

        public static function evalExpression($expression) {
            eval('$result = ' . $expression . ';');

            return $result;
        }

        /*
         * 求质因数
         * 
         * @param int $number，待求质因数的数字，必须大于0。且是整数
         * @return array，质因数列表
         * 
         */

        public static function getPrimeDivisors($number) {
            $number = intval($number);
            $list = array();

            for ($i = 2; SmartGeneric::lessThanOrEquals($i, $number); $i = SmartGeneric::increase($i)) {

                while (SmartGeneric::notEquals($number, $i)) {
                    $divideRemainder = SmartGeneric::divideRemainder($number, $i);
                    if (SmartGeneric::equals($divideRemainder, 0)) {
                        $list[] = $i;
                        $number = SmartGeneric::divide($number, $i);
                    } else {
                        break;
                    }
                }
            }
            $list[] = $number;

            return $list;
        }

        /*
         * 求最大公约数，如果没有，则返回1
         * 
         * $param array $numbers，待求的数字列表
         * $return int，最大公约数
         * 
         */

        public static function getMaxDivisor(array $numbers) {
            $numberList = $numbers;
            $commonPrimeDivisors = array();

            foreach ($numberList as $number) {
                $list = array();

                $primeDivisors = self::getPrimeDivisors($number);

                foreach ($primeDivisors as $primeDivisor) {
                    $i = 0;
                    while (SmartArray::contains($list, new SmartKeyValuePair($primeDivisor, $i))) {
                        $i++;
                    }
                    $list[] = new SmartKeyValuePair($primeDivisor, $i);
                }

                if (count($commonPrimeDivisors) == 0) {
                    $commonPrimeDivisors = SmartArray::addRange($commonPrimeDivisors, $list);
                } else {
                    $commonPrimeDivisors = SmartArray::intersect($commonPrimeDivisors, $list);
                }
            }

            //所有公共质因数的乘积就是最大公约数
            $result = 1;

            foreach ($commonPrimeDivisors as $item) {
                $result = SmartGeneric::multiply($result, $item->Key);
            }
            return $result;
        }

        /*
         * 二进制转换为十进制
         * 
         * @param string $input，待转换的字符串
         * @return float，转换的结果
         * 
         */

        public static function binaryToDecimal($input) {
            return base_convert($input, 2, 10);
        }

        /*
         * 八进制转换为十进制
         * 
         * @param string $input，待转换的字符串
         * @return float，转换的结果
         * 
         */

        public static function octalToDecimal($input) {
            return base_convert($input, 8, 10);
        }

        /*
         * 十六进制转换为十进制
         * 
         * @param string $input，待转换的字符串
         * @return float，转换的结果
         * 
         */

        public static function hexToDecimal($input) {
            return base_convert($input, 16, 10);
        }

        /*
         * 十进制转换为二进制
         * 
         * @param string $input，待转换的字符串
         * @return float，转换的结果
         * 
         */

        public static function decimalToBinary($input) {
            return base_convert($input, 10, 2);
        }

        /*
         * 十进制转换为八进制
         * 
         * @param string $input，待转换的字符串
         * @return float，转换的结果
         * 
         */

        public static function decimalToOctal($input) {
            return base_convert($input, 10, 8);
        }

        /*
         * 十进制转换为八进制
         * 
         * @param string $input，待转换的字符串
         * @return float，转换的结果
         * 
         */

        public static function decimalToHex($input) {
            return base_convert($input, 10, 16);
        }

        /*
         * 角度转换为弧度
         * 
         * @param float $input，待转换的角度值
         * @return float，弧度表示
         * 
         */

        public static function angleToRadian($input) {
            return (M_PI * $input) / 180;
        }

        /*
         * 弧度转换为角度
         * 
         * @param float $input，待转换的角度值
         * @return float，角度表示
         * 
         */

        public static function radianToAngle($input) {
            return $input * 180 / M_PI;
        }

        /*
         * 计算利息
         * 
         * @param float $principalMoney，本金
         * @param int $year，年数
         * @param float $rate，年利率
         * @param bool $isCompoundInterest，是否复利
         * @return float，本利和
         * 
         */

        public static function calculateInterest($principalMoney, $year, $rate, $isCompoundInterest = true) {
            if ($isCompoundInterest) {
                return self::pow(1 + $rate, $year) * $principalMoney;
            }
            return (1 + $rate * $year) * $principalMoney;
        }

        /*
         * 通过角度计算偏移
         * 
         * @param float $angle，角度
         * @param float $distance，距离
         * @return point，结果
         * 
         */

        public static function getOffsetFromAngleAndDistance($angle, $distance) {
            $x = cos(self::angleToRadian($angle)) * $distance;
            $y = tan(self::angleToRadian($angle)) * $x;
            return array("x" => $x, "y" => $y);
        }

        /*
         * 通过偏移计算角度
         * 
         * @param point $offset，偏移
         * @param float，结果
         * 
         */

        public static function getAngleFromOffset(array $offset) {
            $opposite = self::abs($offset["y"]);
            $adjacent = self::abs($offset["x"]);

            if ($offset["x"] < 0) {
                $opposite = -$opposite;
            }

            $angle = self::radianToAngle(atan($opposite / $adjacent));

            if ($offset["x"] < 0) {
                $angle = 90 + (90 - $angle);
            }

            return $angle;
        }

    }

}