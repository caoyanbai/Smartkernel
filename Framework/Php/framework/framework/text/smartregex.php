<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Text {

    use Smartkernel\Framework\SmartString;

/*
     * Regex
     */

    class SmartRegex {
        /*
         * 去除指定模式的字符串
         * 
         * @param string $input，待处理的字符串
         * @param string $pattern，按匹配的模式删除
         * @return string，处理的结果
         * 
         */

        public static function remove($input, $pattern) {
            return preg_replace($pattern, "", $input);
        }

        /*
         * 是否包含指定模式的字符串
         * 
         * @param string $input，待处理的字符串
         * @param string $pattern，匹配的模式
         * @return bool，处理的结果
         * 
         */

        public static function contains($input, $pattern) {
            return count(self::find($input, $pattern)) > 0;
        }

        /*
         * 替换指定模式的字符串
         * 
         * @param string $input，待处理的字符串
         * @param string $pattern，匹配的模式
         * @param string $replace，替换的字符串
         * @return string，处理的结果
         * 
         */

        public static function replace($input, $pattern, $replace) {
            return preg_replace($pattern, $replace, $input);
        }

        /*
         * 通过正则表达式查找匹配的字符串
         * 
         * @param string $input，待处理的字符串
         * @param string $pattern，模式
         * @return array，查找到的结果列表
         * 
         */

        public static function find($input, $pattern) {
            $result = array();

            if (preg_match_all($pattern, $input, $matchs) > 0) {
                foreach ($matchs[0] as $match) {
                    $result[] = $match;
                }
            }
            return $result;
        }

        /*
         * 正则表达式验证方法
         * 
         * @param string $input，待处理的字符串
         * @param string $pattern，正则表达式模式
         * @return bool，处理的结果
         * 
         */

        public static function isMatch($input, $pattern) {
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 通过正则表达式拆分字符串
         * 
         * @param string $input，输入字符串
         * @param string $pattern，验证模式
         * @return array，拆分的结果
         * 
         */

        public static function split($input, $pattern) {
            $items = preg_split($pattern, $input);
            $result = array();
            foreach ($items as $item) {
                if (!SmartString::isNullOrWhiteSpace($item) && !SmartString::isNullOrEmpty($item)) {
                    $result[] = $item;
                }
            }
            return $result;
        }

    }

}