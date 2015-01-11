<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web {

    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\Text\SmartHex;
    use Smartkernel\Framework\SmartString;
    use \Exception;

/*
     * UrlParameter
     */

    class SmartUrlParameter {
        /*
         * 编码参数对
         * 
         * @param array $parameters，参数对列表
         * @param string $encoding，字符编码
         * @return string，编码结果
         * 
         */

        public static function toOne($parameters, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $result = "";

            foreach ($parameters as $key => $value) {
                $result .= (SmartHex::toHex(SmartString::toLower($key), $encoding) . "=" . SmartHex::toHex(SmartString::toLower($value), $encoding) . "|");
            }
            return SmartHex::toHex(SmartString::trimEnd($result, "|"), $encoding);
        }

        /*
         * 解码Url参数
         * 
         * @param string $data，编码的参数
         * @param string $encoding，字符编码
         * @return array，结果之后的键值对
         * 
         */

        public static function toAll($data, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $parameters = array();
            $output = SmartHex::fromHex($data, $encoding);
            $kvs = SmartString::split($output, "|");
            $length = count($kvs);
            for ($i = 0; $i < $length; $i++) {
                $kv = SmartString::split($kvs[$i], "=");
                $parameters[SmartHex::fromHex($kv[0], $encoding)] = SmartHex::fromHex($kv[1], $encoding);
            }
            return $parameters;
        }

        /*
         * 查询一个参数（不存在则返回null）
         * 
         * @param string $data，编码的数据
         * @param string $key，键
         * @param string $encoding，字符编码
         * @return string，值
         * 
         */

        public static function query($data, $key, $encoding = null) {
            try {
                $parameters = self::toAll($data, $encoding);

                $value = null;

                foreach ($parameters as $k => $v) {
                    if (SmartString::toLower($k) == SmartString::toLower($key)) {
                        $value = $v;
                        break;
                    }
                }
                return $value;
            } catch (Exception $err) {
                return null;
            }
        }

    }

}
