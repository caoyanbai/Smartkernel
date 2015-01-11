<?php

namespace Smartkernel\Framework\Net {
    /*
     * 邮件Smtp客户端的配置实体
     */

    class SmartSmtpClientConfig {
        /*
         * 构造函数
         * 
         * @param string $host，Smtp服务器地址
         * @param string $senderEmail，发送者邮箱
         * @param string senderUsername，发送者用户名
         * @param string $senderPassword，发送者密码
         * @param int $port，Smtp服务器端口
         * @param int $timeout，发送超时时间
         * 
         */

        function __construct($host, $senderEmail, $senderUsername = null, $senderPassword = null, $port = 25, $timeout = 30000) {
            $this->Host = $host;
            $this->Port = $port;
            $this->SenderEmail = $senderEmail;
            $this->SenderUsername = $senderUsername;
            $this->SenderPassword = $senderPassword;
            $this->Timeout = $timeout;
        }

        //Smtp服务器地址
        public $Host;
        //Smtp服务器端口
        public $Port;
        //发送者邮箱
        public $SenderEmail;
        //发送者用户名
        public $SenderUsername;
        //发送者密码
        public $SenderPassword;
        //发送超时时间
        public $Timeout;

    }

}