<?php

namespace Smartkernel\Framework {
    /*
     * Int32
     */

    class SmartInt32 {

        //Int32 的最大可能值
        const MaxValue = 2147483647;
        //Int32 的最小可能值
        const MinValue = -2147483648;

        /*
         * 比较两个整数是否相等
         * 
         * @param int $source，源
         * @param int $other，目标
         * @return int，比较的结果
         * 
         */

        public static function compareTo($source, $other) {
            if ($source === $other) {
                return 0;
            }

            if ($source > $other) {
                return 1;
            }

            if ($source < $other) {
                return -1;
            }
        }

    }

}