<?php

namespace Smartkernel\Framework\Net {

    use \Exception;

/*
     * IP地址
     */

    class SmartIPAddress {
        /*
         * 验证是不是IP地址
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isIPAddress($input) {
            $pattern = "/^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 是否是私有IP
         * 
         * @param string $ip，IP地址
         * @return bool，是否是私有IP
         * 
         */

        public static function isPrivate($ip) {
            $ipBytes = explode(".", $ip);
            if ($ipBytes[0] == 192 && $ipBytes[1] == 168) {
                return true;
            }
            if ($ipBytes[0] == 172 && $ipBytes[1] >= 16 && $ipBytes[1] <= 31) {
                return true;
            }
            if ($ipBytes[0] == 10) {
                return true;
            }
            if ($ipBytes[0] == 169 && $ipBytes[1] == 254) {
                return true;
            }
            if ($ipBytes[0] == 127) {
                return true;
            }

            return false;
        }

        /*
         * IP转换为数字
         * @param string $ip，IP地址
         * @return long，IP值
         * 
         */

        public static function toNumber($ip) {
            try {
                $ips = explode('.', $ip);
                return $ips[0] * 256 * 256 * 256 + $ips[1] * 256 * 256 + $ips[2] * 256 + $ips[3];
            } catch (Exception $err) {
                return -1;
            }
        }

        /*
         * 数字转换为IP
         * @param long $ipValue，IP值
         * @return string，IP地址
         * 
         */

        public static function toIPAddress($ipValue) {
            try {
                $ipValue = floatval($ipValue);

                $ip1 = ($ipValue >> 24) & 255;
                $ip2 = ($ipValue >> 16) & 255;
                $ip3 = ($ipValue >> 8) & 255;
                $ip4 = $ipValue & 255;

                return "$ip1.$ip2.$ip3.$ip4";
            } catch (Exception $err) {
                return "";
            }
        }

        /*
         * 比较IP地址的大小
         * 
         * @param string $left，第一个IP
         * @param string $right，第二个IP
         * @return int，如果第一个大于第二个返回-1，如果第一个小于第二个返回1
         * 
         */

        public static function compare($left, $right) {
            $numberLeft = self::toNumber($left);
            $numberRight = self::toNumber($right);
            if ($numberLeft > $numberRight) {
                return -1;
            }
            if ($numberLeft < $numberRight) {
                return 1;
            }
            return 0;
        }

    }

}