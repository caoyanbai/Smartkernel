<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {
    /*
     * GC
     */

    class SmartGC {
        /*
         * 回收
         */

        public static function collect() {
            gc_collect_cycles();
        }

    }

}