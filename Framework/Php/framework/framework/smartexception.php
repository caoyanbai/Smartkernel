<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use \SimpleXMLElement;
    use \Exception;
    use Smartkernel\Framework\SmartDateTime;
    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * 异常
     */

    class SmartException {
        /*
         * 转换为Xml
         * 
         * @param Exception $exception，异常
         * @return string，结果
         * 
         */

        public static function toXml(Exception $exception) {
            $xml = new SimpleXMLElement('<?xml version="1.0" ?><Exception></Exception>');
            $xml->addChild('OccurTime', SmartDateTime::nowTime()->format("Y-m-d H:i:s"));
            $xml->addChild('Message', htmlentities($exception->getMessage()));
            $xml->addChild('Code', $exception->getCode());
            $xml->addChild('File', $exception->getFile());
            $xml->addChild('Trace', htmlentities($exception->getTraceAsString()));

            return $xml->asXML();
        }

        /*
         * 转换为Json
         * 
         * @param Exception $exception，异常
         * @return string，结果
         * 
         */

        public static function toJson(Exception $exception) {
            $obj = array
                (
                "OccurTime" => SmartDateTime::nowTime()->format("Y-m-d H:i:s"),
                "Message" => htmlentities($exception->getMessage()),
                "Code" => $exception->getCode(),
                "File" => $exception->getFile(),
                "Trace" => htmlentities($exception->getTraceAsString())
            );

            return json_encode($obj);
        }

        /*
         * 转换为字符串
         * 
         * @param Exception $exception，异常
         * @return string，结果
         * 
         */

        public static function toString(Exception $exception) {
            $messages = "";
            $messages = $messages . SmartComputer::LineSeparator . $exception->getMessage();
            $messages = $messages . SmartComputer::LineSeparator . $exception->getCode();
            $messages = $messages . SmartComputer::LineSeparator . $exception->getFile();
            $messages = $messages . SmartComputer::LineSeparator . $exception->getTraceAsString();

            return $messages;
        }

    }

}
