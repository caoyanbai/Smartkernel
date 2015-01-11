<?php

namespace Smartkernel\Framework {
    /*
     * 对象辅助类
     */

    class SmartObject {
        /*
         * 获得类型
         * 
         * @param object $obj，对象
         * @return string，结果
         * 
         */

        public static function getType($obj) {
            return gettype($obj);
        }

    }

}