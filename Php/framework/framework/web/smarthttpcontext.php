<?php

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
