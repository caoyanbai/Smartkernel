<?php

namespace Smartkernel\Framework\Web {

    use Smartkernel\Framework\Text\SmartRegex;

/*
     * Html
     */

    class SmartHtml {
        /*
         * 去除Html标记
         * 
         * @param string $input，待处理的字符串
         * @param string $pattern，模式
         * @return string，处理的结果
         * 
         */

        public static function clear($input, $pattern = "/\<.*?>/") {
            return SmartRegex::replace($input, $pattern, "");
        }

    }

}