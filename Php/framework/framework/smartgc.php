<?php

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