<?php

namespace Smartkernel\Framework {

    use \Exception;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\SmartMath;

/*
     * 随机数类，提供多种产生随机数的方式，不光可以产生随机数字，还可以产生随机字符串等任何格式的字符
     * 
     */

    class SmartRandom {
        /*
         * 产生指定范围的随机数，随机数可以取开始和结束两个边界值
         * 
         * @param int $start，开始边界
         * @param int $end，结束边界
         * @return int，随机数
         */

        public static function nextInt($start, $end) {
            return mt_rand($start, $end);
        }

        /*
         * 获得放大为无小数的整数所需的放大倍数
         * 
         * @param float $number，浮点数
         * @return int，放大倍数
         * 
         */

        private static function getMaxScaleupMultiple($number) {
            $i = 1;
            try {
                while ($number * $i < SmartInt32::MaxValue) {
                    $i = $i * 10;
                }
            } catch (Exception $err) {
                
            }
            $i = $i / 10;
            return intval($i);
        }

        /*
         * 产生指定范围和指定长度的随机字符串，随机字符串的长度不受范围长度的限制
         * 
         * @param string $scope，随机字符串的范围，可以取任何字符串
         * @param int $length，需要返回的随机字符串的长度
         * @return string，随机字符串
         * 
         */

        public static function nextString($scope, $length) {
            $chars = SmartString::toCharArray($scope);

            $count = count($chars);

            $result = "";

            for ($i = 0; $i < $length; $i++) {
                $result.=$chars[self::nextInt(0, $count - 1)];
            }

            return $result;
        }

        /*
         * 获得随机大写字符串，字符串范围ABCDEFGHIJKLMNOPQRSTUVWXYZ
         * 
         * @param int $length，字符串长度
         * @return bool，随机字符串
         * 
         */

        public static function nextCapitalString($length) {
            return self::nextString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", $length);
        }

        /*
         * 生成一个随机数学表达式
         * 
         * @param int $start，表达式中使用数字的左边界，不应该包括0
         * @param int $end，表达式中使用数字的右边界，不应该包括0
         * @param int &$result，表达式的计算结果
         * @return string，生成的随机表达式
         * 
         */

        public static function nextMathExpression($start, $end, &$result) {
            $expression = sprintf("%d %s %d", self::nextInt($start, $end), self::nextString("+-*", 1), self::nextInt($start, $end));
            $result = SmartMath::evalExpression($expression);
            return $expression;
        }

        /*
         * 从列表中获得随机对象
         * 
         * @param array $list，对象列表
         * @return object，随机对象
         * 
         */

        public static function nextObject(array $list) {
            return $list[self::nextInt(0, count($list) - 1)];
        }

        /*
         * 获得随机布尔值
         * 
         * @return bool，随机布尔值
         * 
         */

        public static function nextBool() {
            $list = array(true, false);
            return self::nextObject($list);
        }

        /*
         * 产生指定范围的随机数，随机数可以取开始和结束两个边界值
         * 
         * @param float $start，开始边界
         * @param float $end，结束边界
         * @return float，随机数
         * 
         */

        public static function nextFloat($start, $end) {
            $start = floatval($start);
            $end = floatval($end);
            $offset = 0.0;

            if ($start < 0) {
                $offset = -$offset + 1;
            }

            $start = $start + $offset;
            $end = $end + $offset;

            $scaleStart = self::getMaxScaleupMultiple($start);
            $scaleEnd = self::getMaxScaleupMultiple($end);

            $scaleMin = SmartMath::min($scaleStart, $scaleEnd);

            $startInt = intval($start * $scaleMin);
            $endInt = intval($end * $scaleMin);

            $result = self::nextInt($startInt, $endInt);

            return floatval($result) / floatval($scaleMin) - $offset;
        }

    }

}