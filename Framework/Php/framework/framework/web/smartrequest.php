<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web {

    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\SmartRegex;
    use Smartkernel\Framework\Net\SmartIPAddress;
    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\Web\SmartHttpActionType;

/*
     * 请求
     */

    class SmartRequest {
        /*
         * 从$_REQUEST查询参数（不区分大小写）
         * 
         * @param string $key，参数名
         * @return string，结果
         * 
         */

        public static function query($key) {
            $key = trim($key);
            $newkey = strtolower($key);
            foreach ($_REQUEST as $k => $v) {
                $nkey = strtolower($k);
                if ($newkey == $nkey) {
                    return $v;
                }
            }
        }

        /*
         * 获得操作系统名称（出现新的操作系统时，这个方法需要更新）
         * 
         * @return string，结果
         * 
         */

        public static function getUserHostOS() {
            $userAgent = $_SERVER['HTTP_USER_AGENT'];

            $os = "Other OS";

            if (SmartString::contains($userAgent, "NT 6.1")) {
                $os = "Windows 7/Server 2008 R2";
            } else if (SmartString::contains($userAgent, "NT 6.0")) {
                $os = "Windows Vista/Server 2008";
            } else if (SmartString::contains($userAgent, "NT 5.2")) {
                $os = "Windows Server 2003";
            } else if (SmartString::contains($userAgent, "NT 5.1")) {
                $os = "Windows XP";
            } else if (SmartString::contains($userAgent, "NT 5")) {
                $os = "Windows 2000";
            } else if (SmartString::contains($userAgent, "NT 4")) {
                $os = "Windows NT4";
            } else if (SmartString::contains($userAgent, "Me")) {
                $os = "Windows Me";
            } else if (SmartString::contains($userAgent, "98")) {
                $os = "Windows 98";
            } else if (SmartString::contains($userAgent, "95")) {
                $os = "Windows 95";
            } else if (SmartString::contains($userAgent, "NT")) {
                $os = "Windows NT";
            } else if (SmartString::contains($userAgent, "Mac")) {
                $os = "Mac";
            } else if (SmartString::contains($userAgent, "Unix")) {
                $os = "UNIX";
            } else if (SmartString::contains($userAgent, "Linux")) {
                $os = "Linux";
            } else if (SmartString::contains($userAgent, "SunOS")) {
                $os = "SunOS";
            }
            return $os;
        }

        /*
         * 获得移动设备信息（出现新的移动设备品牌时，这个方法需要更新）
         * 
         * @return string，结果
         * 
         */

        public static function getUserHostMobile() {
            $mobiles = array("iphone", "android", "symbian", "windows phone", "windows ce", "blackberry");

            $mobile = "";
            $userAgent = SmartString::toLower($_SERVER['HTTP_USER_AGENT']);
            foreach ($mobiles as $item) {
                if (SmartString::contains($userAgent, $item)) {
                    $mobile = $item;
                    break;
                }
            }
            return $mobile;
        }

        /*
         * 获得爬虫信息（出现新的爬虫时，这个方法需要更新）
         * 
         * @return string，结果
         * 
         */

        public static function getUserHostCrawler() {
            $crawlers = array("Baiduspider",
                "msnbot",
                "Googlebot",
                "Scooter",
                "Mercator",
                "Smarturp",
                "Gulliver",
                "ArchitextSpider",
                "Lycos_Spider",
                "Ask Jeeves",
                "FAST-WebCrawler",
                "crawler");

            $crawler = "";
            $userAgent = SmartString::toLower($_SERVER['HTTP_USER_AGENT']);
            foreach ($crawlers as $item) {
                if (SmartString::contains($userAgent, $item)) {
                    $crawler = $item;
                    break;
                }
            }
            return $crawler;
        }

        /*
         * 客户端IP地址（已经考虑了使用代理服务器的情况）
         * 
         * @return string，结果
         * 
         */

        public static function getUserHostAddress() {
            $ip = isset($_SERVER["HTTP_X_FORWARDED_FOR"]) ? $_SERVER["HTTP_X_FORWARDED_FOR"] : "";

            if (!SmartString::isNullorEmpty($ip)) {
                //可能有代理 
                if (SmartString::indexOf($ip, ".") == -1) {
                    //没有“.”肯定是非IPv4格式 
                    $ip = null;
                } else {
                    if (SmartString::indexOf($ip, ".") != -1) {
                        //有“,”，估计多个代理。取第一个不是内网的IP。 
                        $ip = SmartString::replace(SmartString::replace($ip, " ", ""), "'", "");
                        $ips = SmartRegex::split($ip, "/,|;/");
                        $length = count($ips);
                        for ($i = 0; $i < $length; $i++) {
                            if (SmartIPAddress::isIPAddress($ips[$i]) && SmartString::substring($ips[$i], 0, 3) != "10." && SmartString::substring($ips[$i], 0, 7) != "192.168" && SmartString::substring($ips[$i], 0, 7) != "172.16.") {
                                //找到不是内网的地址 
                                return $ips[$i];
                            }
                        }
                    } else if (SmartIPAddress::isIPAddress($ip)) {
                        //代理即是IP格式 
                        return $ip;
                    } else {
                        //代理中的内容 非IP，取IP 
                        $ip = null;
                    }
                }
            }

            if (null == $ip || $ip == "") {
                $ip = $_SERVER["REMOTE_ADDR"];
            }

            return $ip;
        }

        /*
         * 请求是否来自于自己的主机
         * 
         * @return bool，是否相同的主机
         * 
         */

        public static function isFromSelfHost() {
            @$host = $_SERVER["HTTP_HOST"];
            @$referer = parse_url($_SERVER['HTTP_REFERER'])["host"];
            if (SmartString::toLower($host) == SmartString::toLower(@$referer)) {
                return true;
            } else {
                return false;
            }
        }

        /*
         * 用户端口号
         * 
         * @return string，结果
         * 
         */

        public static function getUserHostPort() {
            @$port1 = $_SERVER["HTTP_REMOTE_PORT"];
            @$port2 = $_SERVER["REMOTE_PORT"];
            if (SmartString::isNullorEmpty($port1)) {
                return $port2;
            } else {
                return $port1;
            }
        }

        /// <summary>
        /// 下载字符串
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encoding">编码</param>
        /// <param name="timeout">超时</param>
        /// <param name="httpActionType">请求类型</param>
        /// <param name="postParameter">参数</param>
        /// <returns>结果</returns>

        public static function downloadString($url, $encoding = null, $timeout = 10000, $httpActionType = SmartHttpActionType::Get, $postParameter = "") {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;

            if ($httpActionType == SmartHttpActionType::Get) {
                $curl = curl_init($url);
                curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
                curl_setopt($curl, CURLOPT_HTTPHEADER, array('Accept-Encoding: gzip, deflate'));
                curl_setopt($curl, CURLOPT_ENCODING, 'gzip,deflate');
                curl_setopt($curl, CURLOPT_CONNECTTIMEOUT, $timeout / 1000);
                $html = curl_exec($curl);
                curl_close($curl);
                return iconv($encoding, SmartEncoding::DefaultValue, $html);
            } else {
                $curl = curl_init($url);
                curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
                curl_setopt($curl, CURLOPT_POST, 1);
                curl_setopt($curl, CURLOPT_POSTFIELDS, $postParameter);
                curl_setopt($curl, CURLOPT_HTTPHEADER, array('Accept-Encoding: gzip, deflate'));
                curl_setopt($curl, CURLOPT_ENCODING, 'gzip,deflate');
                curl_setopt($curl, CURLOPT_CONNECTTIMEOUT, $timeout / 1000);
                $html = curl_exec($curl);
                curl_close($curl);
                return iconv($encoding, SmartEncoding::DefaultValue, $html);
            }
        }

    }

}