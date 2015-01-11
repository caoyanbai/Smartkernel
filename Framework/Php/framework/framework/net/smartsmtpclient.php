<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Net {
    require_once ('Mail.php');
    require_once ('Mail/mime.php');

    use \Mail;
    use \PEAR;
    use \Mail_mime;
    use Smartkernel\Framework\Text\SmartEncoding;
    use SoufunLab\Framework\Web\SmartMime;
    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * 邮件Smtp客户端类（基于PEAR中的Mail和Mail_Mime和Net_SMTP）
     */

    class SmartSmtpClient {

        private $smtpClientConfig;

        /*
         * 构造函数
         * 
         * @param SmartSmtpClientConfig $smtpClientConfig，Smtp配置实体
         * 
         */

        function __construct(SmartSmtpClientConfig $smtpClientConfig) {
            $this->smtpClientConfig = $smtpClientConfig;
        }

        /*
         * 发送邮件
         * 
         * @param string $to，接收者，多个接收者以逗号分隔，例如：test1@126.com,test2@126.com
         * @param string $subject，邮件标题
         * @param string $body，邮件正文
         * @param array $attachments，邮件附件
         * @param string $encoding，编码方式
         * @param bool $isBodyHtml，是否Html格式
         * 
         */

        public function send($to, $subject, $body, array $attachments = null, $encoding = null, $isBodyHtml = true) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;

            $mime = new Mail_mime();
            if ($attachments != null && count($attachments) > 0) {
                foreach ($attachments as $attachment) {
                    @$mime->addAttachment($attachment, SmartMime::getMimeType($attachment), basename($attachment));
                }
            }

            if ($isBodyHtml === true) {
                @$mime->setHTMLBody($body);
                @$body = $mime->get(array('html_charset' => $encoding, 'text_charset' => $encoding, 'eol' => SmartComputer::LineSeparator));
            } else {
                @$mime->setTXTBody($body);
                @$body = $mime->get();
            }

            $headers = array('From' => $this->smtpClientConfig->SenderEmail, 'To' => $to, 'Subject' => $subject);

            $smtp = null;

            if ($this->smtpClientConfig->SenderUsername != null && $this->smtpClientConfig->SenderPassword != null) {
                @$smtp = Mail::factory('smtp', array('host' => $this->smtpClientConfig->Host, 'port' => $this->smtpClientConfig->Port, 'auth' => true, 'username' => $this->smtpClientConfig->SenderUsername, 'password' => $this->smtpClientConfig->SenderPassword, 'timeout' => $this->smtpClientConfig->Timeout));
            } else {
                @$smtp = Mail::factory('smtp', array('host' => $this->smtpClientConfig->Host, 'port' => $this->smtpClientConfig->Port, 'auth' => false, 'timeout' => $this->smtpClientConfig->Timeout));
            }

            @$headers = $mime->headers($headers);

            @$smtp->send($to, $headers, $body);
        }

    }

}