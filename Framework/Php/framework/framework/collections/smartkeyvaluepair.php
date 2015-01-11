<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Collections {
    /*
     * 键值对
     */

    class SmartKeyValuePair {

        //键
        public $Key;
        //值
        public $Value;

        /*
         * 构造函数
         * 
         * $param object $key，键
         * $param object $value，值
         * 
         */

        function __construct($key, $value) {
            $this->Key = $key;
            $this->Value = $value;
        }

        /*
         * 转换为字符串
         */

        function __toString() {
            return $this->Key . "=" . $this->Value;
        }

    }

}