<?php

namespace Smartkernel\Framework\Data {

    use Smartkernel\Framework\SmartString;

/*
     * 数据库操作
     */

    class SmartDatabase {

        private static $sqlCommandKeywords = "and|exec|execute|insert|select|delete|update|count|chr|mid|master|char|declare|sitename|net user|xp_cmdshell|or|create|drop|table|from|grant|use|group_concat|column_name|information_schema.columns|table_schema|union|where|select|delete|update|orderhaving|having|by|count|*|truncate|like";
        private static $sqlSeparatKeywords = "'|;|,|--|\'|\"|/*|%|#";

        private static function getSqlKeywordsArray() {
            $sqlCommandKeywordArray = explode("|", self::$sqlCommandKeywords);
            $sqlSeparatKeywordArray = explode("|", self::$sqlSeparatKeywords);

            $sqlKeywordsArray = array();

            foreach ($sqlCommandKeywordArray as $sqlCommandKeyword) {
                $sqlKeywordsArray[] = $sqlCommandKeyword . " ";
                $sqlKeywordsArray[] = " " . $sqlCommandKeyword;
            }

            foreach ($sqlSeparatKeywordArray as $sqlSeparatKeyword) {
                $sqlKeywordsArray[] = $sqlSeparatKeyword;
            }

            return $sqlCommandKeywordArray;
        }

        /*
         * 是否安全
         * 
         * @param string $input，输入
         * @return bool，返回
         */

        public static function isSafetySql($input) {
            if (SmartString::isNullOrWhiteSpace($input)) {
                return true;
            }
            $input = strtolower(urldecode($input));

            $sqlKeywordsArray = self::getSqlKeywordsArray();

            foreach ($sqlKeywordsArray as $sqlKeyword) {
                if (strpos($input, $sqlKeyword) !== false) {
                    return false;
                }
            }
            return true;
        }

        /*
         * 返回安全字符串
         * 
         * @param string $input，输入
         * @return string，返回
         * 
         */

        public static function getSafetySql($input) {
            if (SmartString::isNullOrWhiteSpace($input)) {
                return "";
            }
            $input = strtolower(urldecode($input));

            $sqlKeywordsArray = self::getSqlKeywordsArray();

            foreach ($sqlKeywordsArray as $sqlKeyword) {
                if (strpos($input, $sqlKeyword) !== false) {
                    $input = str_replace($sqlKeyword, "", $input);
                }
            }
            return $input;
        }

    }

}