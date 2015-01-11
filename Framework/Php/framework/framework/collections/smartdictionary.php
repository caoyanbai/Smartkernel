<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Collections {

    use \SimpleXMLElement;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\Xml\SmartXml;
    use Smartkernel\Framework\Web\SmartJson;

/*
     * 字典
     */

    class SmartDictionary {
        /*
         * 字典长度（相同的Key算一个）
         * 
         * @param array $array，字典
         * @return int，结果
         * 
         */

        public static function count(array $array) {
            return count($array);
        }

        /*
         * 加入序列
         * 
         * @param array $array，数组
         * @param array $addArray，加入的字典
         * @return array，结果
         * 
         */

        public static function addRange(array $array, array $addArray) {
            foreach ($addArray as $key => $value) {
                $array[$key] = $value;
            }
            return $array;
        }

        /*
         * 排重
         * 
         * @param array $array，字典
         * @return array，结果
         * 
         */

        public static function distinct(array $array) {
            $result = array();
            foreach ($array as $key => $value) {
                if (!self::containsKey($result, $key)) {
                    $result[$key] = $value;
                }
            }
            return $result;
        }

        /*
         * 是否包含
         * 
         * @param array $array，数组
         * @param object $key，键
         * @return bool，结果
         * 
         */

        public static function containsKey(array $array, $key) {
            return array_key_exists($key, $array);
        }

        /*
         * 过滤
         * 
         * @param array $array，数组
         * @param function $where，过滤条件
         * @return array，结果
         * 
         */

        public static function where(array $array, $where) {
            $result = array();
            foreach ($array as $key => $value) {
                if ($where($key, $value) === true) {
                    $result[$key] = $value;
                }
            }
            return $result;
        }

        /*
         * 循环处理
         * 
         * @param array $array，字典
         * @param function $action，函数
         * 
         */

        public static function forEachOne(array $array, $action) {
            foreach ($array as $key => $value) {
                $action($key, $value);
            }
        }

        /*
         * 对象映射为Xml
         * 
         * @param array $item
         *            ，对象
         * @param string $rootName
         *            ，根元素的名称
         * @return string，xml文档
         */

        public static function toXml(array $item, $rootName) {
            $node = new SimpleXMLElement(SmartString::format("<{0} />", $rootName));
            while (list($key, $value) = each($item)) {
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
         * 从Xml解析
         * 
         * @param string $xml
         *            ，Xml
         * @return array，结果
         */

        public static function fromXml($xml) {
            return SmartXml::toArray($xml);
        }

        /*
         * 对象映射为Json
         * 
         * @param array $item
         *            ，对象
         * @return string，xml文档
         */

        public static function toJson(array $item) {
            return SmartJson::toJson($item);
        }

        /*
         * 从Json解析
         * 
         * @param string $xml
         *            ，Json
         * @return array，结果
         */

        public static function fromJson($json) {
            return (array) SmartJson::fromJson($json);
        }

    }

}