<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Text {

    use \Exception;
    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * Base64
     */

    class SmartBase64 {
        /*
         * 转换为Base64
         * 
         * @param string $input，待转换的字符串
         * @param string $encoding，编码方式
         * @return string，转换的结果
         * 
         */

        public static function toBase64($input, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            return base64_encode(iconv(SmartEncoding::DefaultValue, $encoding, $input));
        }

        /*
         * 转换回原形式
         * 
         * @param string $input，待转换的字符串
         * @param string $encoding，编码方式
         * @return string，原形式
         * 
         */

        public static function fromBase64($input, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            return iconv($encoding, SmartEncoding::DefaultValue, base64_decode($input));
        }

        /*
         * 检查是不是合法的64位编码格式的字符串
         * 
         * @param string $input，待检查的字符串。空字符串和空格都是合法的64位编码
         * @param string $encoding，编码方式
         * @return bool，是否是64位编码
         * 
         */

        public static function isBase64($input, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $isBase64 = true;
            try {
                if (@self::fromBase64($input, $encoding) === false) {
                    throw new Exception("");
                }
            } catch (Exception $err) {
                $isBase64 = false;
            }
            return $isBase64;
        }

    }

}