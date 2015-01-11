<?php

namespace Smartkernel\Framework {

    use Smartkernel\Framework\SmartString;

/*
     * Guid（Guid是微软特有技术，此方法无法保证唯一性，只能提供类似格式的随机字符串）
     */

    class SmartGuid {
        /*
         * 产生Guid
         * 
         * @return string，结果
         * 
         */

        public static function newGuid() {
            $part1 = base_convert(str_replace("-", "", str_replace(".", "", strval(microtime(true))) . strval(SmartString::getHashCode(md5(strval(uniqid(rand(), true)))))), 10, 32);
            $part2 = sprintf('%04x%04x%04x%04x%04x%04x%04x%04x', mt_rand(0, 65535), mt_rand(0, 65535), mt_rand(0, 65535), mt_rand(16384, 20479), mt_rand(32768, 49151), mt_rand(0, 65535), mt_rand(0, 65535), mt_rand(0, 65535));
            $guid = substr($part1 . $part2, 0, 32);

            return $guid;
        }

    }

}
