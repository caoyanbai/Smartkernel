<?php

namespace Smartkernel\Framework\Text {

    use Smartkernel\Framework\SmartString;

/*
     * 编码
     */

    class SmartEncoding {

        //默认
        const DefaultValue = "UTF-8";
        //安全路径编码
        const DefaultSafePathValue = "GBK";
        //Ansii编码
        const AnsiiEncodingValue = "ISO-8859-1";

        /*
         * 判断是否全部为Ascii编码的字符
         * 
         * @param string $input，待检查的输入
         * @return bool，结果
         * 
         */

        public static function isAsciiEncoding($input) {
            if (SmartString::isNullOrEmpty($input)) {
                return true;
            }
            $chars = SmartString::toCharArray($input);
            $length = count($chars);

            for ($i = 0; $i < $length; $i++) {
                if (ord($chars[$i]) > 127) {
                    return false;
                }
            }
            return true;
        }

        /*
         * 获得字节数组
         * 
         * @param string $input，输入
         * @param string $encoding，编码
         * @return array，结果
         * 
         */

        public static function getBytes($input, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $input = mb_convert_encoding($input, $encoding, SmartEncoding::DefaultValue);
            $strlen = SmartString::length($input, SmartEncoding::AnsiiEncodingValue);
            while ($strlen) {
                $result[] = ord(SmartString::substring($input, 0, 1, SmartEncoding::AnsiiEncodingValue));
                $input = SmartString::substring($input, 1, $strlen, SmartEncoding::AnsiiEncodingValue);
                $strlen = SmartString::length($input, SmartEncoding::AnsiiEncodingValue);
            }
            return $result;
        }

        /*
         * 获得字符串
         * 
         * @param array $data，字节数组
         * @param string $encoding，编码
         * @return string，结果
         * 
         */

        public static function getString(array $data, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $result = implode(array_map('chr', $data));
            $result = mb_convert_encoding($result, SmartEncoding::DefaultValue, $encoding);
            return $result;
        }

        /*
         * 计算字符串的长度，一个中文算两个字符长度
         * 
         * @param string $input，需要检查的字符串
         * @return int，长度
         * 
         */

        public static function getAsciiLength($input) {
            if (SmartString::isNullOrEmpty($input)) {
                return 0;
            }
            $chars = SmartString::toCharArray($input);
            $length = count($chars);
            $result = 0;
            for ($i = 0; $i < $length; $i++) {
                if (ord($chars[$i]) > 127) {
                    $result++;
                }
                if (ord($chars[$i]) == 63) {
                    $result++;
                }
                $result++;
            }
            return $result;
        }

    }

}
    