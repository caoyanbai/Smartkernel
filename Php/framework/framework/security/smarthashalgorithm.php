<?php

namespace Smartkernel\Framework\Security {

    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\Security\SmartHashAlgorithmType;

/*
     * 哈希密码
     */

    class SmartHashAlgorithm {
        /*
         * 获得哈希密码
         * 
         * @param $input，待处理的字符串
         * @param $hashAlgorithmType，算法类型
         * @param $encoding，编码
         * @return string，哈希密码
         * 
         */

        public static function computeHashToHexString($input, $hashAlgorithmType = SmartHashAlgorithmType::Md5, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $input = iconv(SmartEncoding::DefaultValue, $encoding, $input);

            if ($hashAlgorithmType == SmartHashAlgorithmType::Md5) {
                return strtoupper(md5($input));
            } else {
                return strtoupper(sha1($input));
            }
        }

    }

}