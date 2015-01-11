<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web {

    /*
     * Http上下文
     */

    class SmartHttpContext {

        //项目所在目录（有斜线结尾）
        public static function getDirectory() {
            return $_SERVER['DOCUMENT_ROOT'];
        }

    }

}
