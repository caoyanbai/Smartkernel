<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Net {

    use \Exception;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 网络操作相关功能
     */

    class SmartNet {
        /*
         * 获得主机IP
         * 
         * @param string $hostName，主机名，为空时则返回本机IP
         * @return string，结果
         * 
         */

        public static function getIPAddress($hostName = "") {
            $result = gethostbyname($hostName);
            if ($result === $hostName) {
                return "";
            } else {
                return $result;
            }
        }

        //最大端口号
        const MaxPortValue = 65535;
        //最小端口号
        const MinPortValue = 0;

        /*
         * 检查端口状态，是否启用TCP监听
         * 
         * @param string $ip，IP地址
         * @param int $port，端口
         * @return bool，状态
         * 
         */

        public static function checkPort($ip, $port) {
            $socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
            $isListening = false;

            try {
                @$connection = socket_connect($socket, $ip, $port);
                if ($connection) {
                    socket_close($socket);
                    $isListening = true;
                }
            } catch (Exception $err) {
                
            }
            return $isListening;
        }

        /*
         * 检查网址是否可以访问
         * 
         * @param string $uri，测试的网址地址：例如，http://www.caoyanbai.com
         * @param int $timeOut，设置超时时间，在指定的时间内无响应的认为是无法访问，单位为毫秒
         * @return bool，是否可以访问
         * 
         */

        public static function isCanVisit($uri, $timeOut = 6000) {
            $uri = SmartString::format("http://{0}", SmartString::replace($uri, "http://", ""));
            try {
                $curl = curl_init($uri);
                curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
                curl_setopt($curl, CURLOPT_HEADER, true);
                curl_setopt($curl, CURLOPT_NOBODY, true);
                curl_setopt($curl, CURLOPT_CONNECTTIMEOUT, $timeOut / 1000);
                $html = curl_exec($curl);
                $http_status = curl_getinfo($curl, CURLINFO_HTTP_CODE);
                curl_close($curl);
                return $http_status == 200;
            } catch (Exception $err) {
                return false;
            }
        }

        /*
         * Ping目标计算机
         * 
         * @param string $host，目标计算机的IP（211.66.4.102）或者主机名（SmartKernel-PC）
         * @paran string $encoding，结果编码
         * @return string，结果
         * 
         */

        public static function ping($host, $encoding = "GBK") {
            return iconv($encoding, SmartEncoding::DefaultValue, shell_exec("ping -n 1 -w 1 $host"));
        }

    }

}