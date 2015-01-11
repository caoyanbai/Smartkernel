<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web {

    /*
     * Cookie操作类
     */

    class SmartCookie {
        /*
         * 增加存储的数据
         * 
         * @param string $category，分类
         * @param array $keyValues，存储的键值对
         * @param int $timeOut，超时时间，默认是30天（单位秒）
         * @param string $path，路径
         * @param string $domain，域名
         * @param bool $secure，SSL
         * @param bool $httponly，httponly
         * 
         */

        public static function add($category, $keyValues, $timeOut = 2592000, $path = null, $domain = null, $secure = false, $httponly = true) {
            foreach ($keyValues as $key => $value) {
                setcookie($category . "[" . $key . "]", $value, time() + $timeOut, $path, $domain, $secure, $httponly);
            }
        }

        /*
         * 删除分类
         * 
         * @param string $category，分类名称
         * 
         */

        public static function remove($category) {
            if (isset($_COOKIE[$category])) {
                if (is_array($_COOKIE[$category])) {
                    foreach ($_COOKIE[$category] as $key => $value) {
                        setcookie($category . "[" . $key . "]", "", time() - 365 * 24 * 60 * 60);
                    }
                }
            }
        }

        /*
         * 是否包含这个分类
         * 
         * @param string $category，分类
         * @return bool，是否包含
         * 
         */

        public static function contains($category) {
            return isset($_COOKIE[$category]) && is_array($_COOKIE[$category]);
        }

        /*
         * 获得值
         * 
         * @param string $category，分类
         * @param string $key，键
         * @return string，值
         * 
         */

        public static function getValue($category, $key) {
            return @$_COOKIE[$category][$key];
        }

        /*
         * 获得键值
         * 
         * @param string $category，分类
         * @return array，键值
         * 
         */

        public static function getKeyValues($category) {
            return @$_COOKIE[$category];
        }

    }

}