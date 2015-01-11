<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * 输出
     */

    class SmartConsole {
        /*
         * 输出
         * 
         * @param object $input，输入
         * 
         */

        public static function write($input) {
            echo strval($input);
        }

        /*
         * 换行输出
         * 
         * @param object $input，输入
         * 
         */

        public static function writeLine($input) {
            echo strval($input) . SmartComputer::LineSeparator;
        }

    }

}