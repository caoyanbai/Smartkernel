<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web {

    use Smartkernel\Framework\SmartString;

/*
     * Json格式数据处理
     */

    class SmartJson {
        /*
         * 将对象序列化为Json格式的字符串
         * 
         * @param object $source，源类型对象
         * @return string，Json格式的字符串
         * 
         */

        public static function toJson($source) {
            return json_encode($source);
        }

        /*
         * 将Json格式的数据转换为对象
         * 
         * @param string $source，json格式的字符串
         * @return object，序列化之后的格式
         * 
         */

        public static function fromJson($source) {
            return json_decode($source);
        }

        /*
         * 判断是否相等
         * 
         * @param object $a，a
         * @param object $b，b
         * @return bool，结果
         * 
         */

        public static function jsonEquals($a, $b) {
            return self::toJson($a) == self::toJson($b);
        }

        /*
         * 获得安全字符串
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function getSafeJson($input) {
            if (SmartString::isNullOrWhiteSpace($input)) {
                return "";
            }
            return ltrim(rtrim(self::toJson($input), '"'), '"');
        }

    }

}