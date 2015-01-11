<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Net {

    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 套接字
     */

    class SmartSocket {
        /*
         * 发送信息
         * @param string $ip，端点IP
         * @param string $port，端点Port
         * @param string $requestText，消息
         * @param string $flgReceive，是否接受消息
         * @param string $encoding，数据编码方式
         * @return string,发送消息
         * */

        public static function send($ip, $port, $requestText, $flgReceive = true, $encoding = null) {
            $socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
            $connection = socket_connect($socket, $ip, $port);

            $encoding = $encoding == null ? SmartEncoding::DefaultEncoding : $encoding;

            socket_write($socket, iconv($encoding, SmartEncoding::DefaultEncoding, $requestText));
            socket_shutdown($socket, STREAM_SHUT_WR);
            if ($flgReceive === false) {
                return "";
            }
            $responseText = '';
            do {
                $buffer = socket_read($socket, 1024);
                $response .= $buffer;
            } while (!empty($buffer));
            socket_shutdown($socket, STREAM_SHUT_RD);
            return iconv(SmartEncoding::DefaultEncoding, $encoding, $responseText);
        }

        /*
         * 监听消息
         * @param string $ip，端点IP
         * @param string $port，端点Port
         * @param string $interact，交互处理
         * @param string $encoding，数据编码方式
         * */

        function listen($ip, $port, $interact, $encoding = null) {
            $serverSocket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
            socket_bind($serverSocket, $ip, $port);
            socket_listen($serverSocket);

            $encoding = $encoding == null ? SmartEncoding::DefaultEncoding : $encoding;
            while (true) {
                $socket = socket_accept($serverSocket);
                if ($socket) {
                    $requestText = '';
                    do {
                        $buffer = socket_read($socket, 1024);
                        $requestText .= $buffer;
                    } while (!empty($buffer));
                    socket_shutdown($socket, STREAM_SHUT_RD);
                    $requestText = iconv(SmartEncoding::DefaultEncoding, $encoding, $requestText);
                    $responseText = $interact($requestText);
                    socket_write($socket, iconv($encoding, SmartEncoding::DefaultEncoding, $responseText));
                    socket_shutdown($socket, STREAM_SHUT_WR);
                }
            }
        }

    }

}
