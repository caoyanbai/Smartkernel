<?php

namespace Smartkernel\Framework {
    /*
     * HashCode
     */

    class SmartHashCode {
        /*
         * 获取哈希值
         * 
         * $param string $input
         * $return int，结果
         * 
         */

        public static function getHashCode($input) {
            $input = SmartString::toCharArray($input);

            $length = count($input);
            $hashCode = 0;
            for ($i = 0; $i < $length; $i++) {
                $hashCode = (int) ($hashCode * 31 + SmartChar::toInt($input[$i]));
                if (($hashCode & 0x80000000) == 0) {
                    $hashCode &= 0x7fffffff;
                } else {
                    $hashCode = ($hashCode & 0x7fffffff) - 2147483648;
                }
            }
            return $hashCode;
        }

    }

}