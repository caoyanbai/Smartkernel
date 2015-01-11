<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Text {

    use \Exception;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\SmartMath;

/*
     * 整数与32进制间的转换（只支持int类型）
     */

    class SmartNumber32 {

        //0-31 对应32个字符
        private static $zipMapWords = "0123456789abcdefghjklmnpqrtuvwxy";
        //整数与32进制 对照字典
        private static $dictNumberTo32 = array();
        //32进制与整数 对照字典
        private static $dict32ToNumber = array();

        /*
         * 初始化字典
         */

        private static function initialize() {
            if (count(self::$dictNumberTo32) === 0 && count(self::$dict32ToNumber) === 0) {
                $i = 0;
                $key = "";
                $value = "";
                $zipMapWordsArray = SmartString::toCharArray(self::$zipMapWords);
                foreach ($zipMapWordsArray as $item) {
                    $key = strval($i);
                    $value = strval($item);
                    //压缩\反压缩字典key-value相反,以实现快速查找.
                    self::$dictNumberTo32[$key] = $value;
                    self::$dict32ToNumber[$value] = $key;
                    $i++;
                }
            }
        }

        /*
         * 整数转为32进制
         * 
         * @param int $theNumber，要转换的整数
         * @return string，结果
         * 
         */

        public static function convertTo32($theNumber) {
            $num32 = "";
            self::recursiveConvertTo32($theNumber, $num32);
            return $num32;
        }

        private static function recursiveConvertTo32($theNumber, &$num32) {
            $temp;
            $temp = intval(fmod(intval($theNumber), 32));
            $num32 = self::chang($temp) . $num32;
            if (intval($theNumber / 32) > 0.0) {
                self::recursiveConvertTo32(intval($theNumber / 32), $num32);
            }
        }

        /*
         * 整数对应的32进制值
         * 
         * @param int $number,数字
         * @return string，结果
         * 
         */

        private static function chang($number) {
            try {
                self::initialize();
                return self::$dictNumberTo32[strval($number)];
            } catch (Exception $err) {
                
            }
            return strval($number);
        }

        /*
         * 32进制转为整数
         * 
         * @param string $the32Data，32进制
         * @return int，结果
         * 
         */

        public static function convertToNumber($the32Data) {
            $result = 0;
            try {
                self::initialize();
                $the32Data = SmartString::toCharArray(SmartString::toLower($the32Data));
                $length = count($the32Data);
                $i = 0;
                foreach ($the32Data as $item) {
                    $result += intval(self::$dict32ToNumber[strval($item)]) * SmartMath::pow(32, $length - $i - 1);
                    $i++;
                }
            } catch (Exception $err) {
                
            }
            return $result;
        }

    }

}