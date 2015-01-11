<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

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