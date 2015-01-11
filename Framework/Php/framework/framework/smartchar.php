<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use \Exception;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 字符类型
     */

    class SmartChar {
        /*
         * 转换为Int
         * 
         * @param char $input，输入字符
         * @return int，结果
         * 
         */

        public static function toInt($input) {
            if (!self::isChar($input)) {
                throw new Exception("不是字符类型");
            }
            return hexdec(bin2hex(iconv(SmartEncoding::DefaultValue, 'UCS-2', $input)));
        }

        /*
         * 判断是不是字符
         * 
         * @param char $input，输入
         * @return bool，结果
         * 
         */

        public static function isChar($input) {
            $charArray = SmartString::toCharArray($input);

            return count($charArray) === 1 && $input === $charArray[0];
        }

        /*
         * 判断是不是数字
         * 
         * @param char $input，输入
         * @return bool，结果
         * 
         */

        public static function isDigit($input) {
            if (!self::isChar($input)) {
                throw new Exception("不是字符类型");
            }

            for ($i = 0; $i <= 9; $i++) {
                if (strval($i) === $input) {
                    return true;
                }
            }

            return false;
        }

        /*
         * 判断是不是字母
         * 
         * @param char $input，输入
         * @return bool，结果
         * 
         */

        public static function isLetter($input) {
            if (!self::isChar($input)) {
                throw new Exception("不是字符类型");
            }

            for ($i = "a"; $i <= "z"; $i++) {
                if (strval($i) === $input) {
                    return true;
                }
            }

            for ($i = "A"; $i <= "Z"; $i++) {
                if (strval($i) === $input) {
                    return true;
                }
            }

            return false;
        }

        /*
         * 判断是不是小写
         * 
         * @param char $input，输入
         * @return bool，结果
         * 
         */

        public static function isLower($input) {
            if (!self::isChar($input)) {
                throw new Exception("不是字符类型");
            }

            if ($input === strtolower($input)) {
                return true;
            }

            return false;
        }

        /*
         * 判断是不是大写
         * 
         * @param char $input，输入
         * @return bool，结果
         * 
         */

        public static function isUpper($input) {
            if (!self::isChar($input)) {
                throw new Exception("不是字符类型");
            }

            if ($input === strtoupper($input)) {
                return true;
            }

            return false;
        }

        /*
         * 判断是不是空白
         * 
         * @param char $input，输入
         * @return bool，结果
         * 
         */

        public static function isWhiteSpace($input) {
            if (!self::isChar($input)) {
                throw new Exception("不是字符类型");
            }

            if ($input === " ") {
                return true;
            }

            return false;
        }

        /*
         * 数字转换为字符
         * 
         * @param int $num，数字
         * @return char，字符
         * 
         */

        public static function utf8Chr($num) {
            if ($num <= 0x7F)
                return chr($num);
            if ($num <= 0x7FF)
                return chr(($num >> 6) + 192) . chr(($num & 63) + 128);
            if ($num <= 0xFFFF)
                return chr(($num >> 12) + 224) . chr((($num >> 6) & 63) + 128) . chr(($num & 63) + 128);
            if ($num <= 0x1FFFFF)
                return chr(($num >> 18) + 240) . chr((($num >> 12) & 63) + 128) . chr((($num >> 6) & 63) + 128) . chr(($num & 63) + 128);
            return '';
        }

        /*
         * 字符转换为数字
         * 
         * @param char $c，字符
         * @return int，数字
         * 
         */

        public static function utf8Ord($c) {
            $ord0 = ord($c{0});
            if ($ord0 >= 0 && $ord0 <= 127)
                return $ord0;
            $ord1 = ord($c{1});
            if ($ord0 >= 192 && $ord0 <= 223)
                return ($ord0 - 192) * 64 + ($ord1 - 128);
            $ord2 = ord($c{2});
            if ($ord0 >= 224 && $ord0 <= 239)
                return ($ord0 - 224) * 4096 + ($ord1 - 128) * 64 + ($ord2 - 128);
            $ord3 = ord($c{3});
            if ($ord0 >= 240 && $ord0 <= 247)
                return ($ord0 - 240) * 262144 + ($ord1 - 128) * 4096 + ($ord2 - 128) * 64 + ($ord3 - 128);
            return false;
        }

    }

}