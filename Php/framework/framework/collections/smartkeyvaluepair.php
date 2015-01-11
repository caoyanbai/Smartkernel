<?php

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