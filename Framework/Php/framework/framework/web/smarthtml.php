<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

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