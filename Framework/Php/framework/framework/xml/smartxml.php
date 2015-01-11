<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Xml {

    use \SimpleXMLElement;

/*
     * Xml
     */

    class SmartXml {
        /*
         * 转换为Xml文档
         * 
         * @param array $array，数组
         * @param SimpleXMLElement $node，节点
         * @return string，结果
         * 
         */

        public static function toXml(array $array, SimpleXMLElement $node = null) {
            if ($node === null) {
                $node = new SimpleXMLElement("<root/>");
            }
            while (list($key, $value) = each($array)) {
                if (is_array($value)) {
                    $subNode = $node->addChild($key);
                    self::toXml($value, $subNode);
                } else {
                    $node->addChild($key, $value);
                }
            }

            return $node->asXml();
        }

        /*
         * 转换为数组
         * 
         * @param string $xml，文档
         * @return array，结果
         * 
         */

        public static function toArray($xml) {
            return json_decode(json_encode(simplexml_load_string($xml)), true);
        }

    }

}