<?php

namespace Smartkernel\Framework {

    use \Exception;

/*
     * 布尔类型
     */

    class SmartBoolean {

        //假的字符串表示
        const FalseString = "False";
        //真的字符串表示
        const TrueString = "True";

        /*
         * 严格解析
         * 
         * @param string $input，输入
         * @return bool，结果
         * 
         */

        public static function parse($input) {
            $input = strval($input);
            if (strtolower(self::FalseString) === strtolower($input)) {
                return false;
            }
            if (strtolower(self::TrueString) === strtolower($input)) {
                return true;
            }
            throw new Exception("未知的字符串类型");
        }

        /*
         * 转换为字符串
         * 
         * @param string $input，输入
         * @return bool，结果
         * 
         */

        public static function toString($input) {
            if ($input === false) {
                return self::FalseString;
            }
            if ($input === true) {
                return self::TrueString;
            }
            throw new Exception("类型错误");
        }

    }

}