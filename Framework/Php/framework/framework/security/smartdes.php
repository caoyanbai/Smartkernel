<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Security {

    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * Des
     */

    class SmartDes {
        /*
         * 加密方法
         * 
         * @param $input，待加密的字符串
         * @param $password，加密的密码（只能为8位长）
         * @param $iv，偏移
         * @param $encoding，编码
         * @return，加密之后的字符串
         * 
         */

        public static function encryptToHexString($input, $password, $iv, $encoding = null) {

            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $input = iconv(SmartEncoding::DefaultValue, $encoding, $input);
            $size = mcrypt_get_block_size(MCRYPT_DES, MCRYPT_MODE_CBC);
            $input = self::pkcs5Pad($input, $size);
            $output = mcrypt_encrypt(MCRYPT_DES, $password, $input, MCRYPT_MODE_CBC, $iv);
            return strtoupper(bin2hex($output));
        }

        /*
         * 解密方法
         * 
         * @param $input，待解密的字符串
         * @param $password，解密的密码（只能为8位长）
         * @param $iv，偏移
         * @param $encoding，编码
         * @return，解密之后的字符串
         * 
         */

        public static function decryptFromHexString($input, $password, $iv, $encoding = null) {

            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $output = mcrypt_decrypt(MCRYPT_DES, $password, hex2bin($input), MCRYPT_MODE_CBC, $iv);
            $output = iconv($encoding, SmartEncoding::DefaultValue, $output);
            return self::pkcs5Unpad($output);
        }

        private static function pkcs5Pad($text, $blocksize) {
            $pad = $blocksize - (strlen($text) % $blocksize);
            return $text . str_repeat(chr($pad), $pad);
        }

        private static function pkcs5Unpad($text) {
            $pad = ord($text {strlen($text) - 1});
            if ($pad > strlen($text)) {
                return false;
            }
            if (strspn($text, chr($pad), strlen($text) - $pad) != $pad) {
                return false;
            }
            return substr($text, 0, - 1 * $pad);
        }

    }

}