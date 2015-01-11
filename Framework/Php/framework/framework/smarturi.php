<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use Smartkernel\Framework\SmartString;

/*
     * 是否Uri
     */

    class SmartUri {
        /*
         * 验证是不是Uri地址。注意，必须有http等协议开头的前缀，www.smartkernel.com是不能验证通过的
         * 
         * @param string input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isUri($input) {
            return preg_match("/^((http|https|ftp):\/\/[\w\-_]+(\.[\w\-_]+)+([a-z])+([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?)$/", $input) > 0;
        }

        /// <summary>
        /// 验证是不是Uri地址。注意，不需要有前缀
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>验证的结果</returns>
        public static function isUriWithoutProtocol($input) {

            if (SmartString::isNullOrWhiteSpace($input)) {
                return false;
            }
            $input = SmartString::toLower($input);

            if (!SmartString::startsWith($input, "http://") && !SmartString::startsWith($input, "https://") && !SmartString::startsWith($input, "ftp://")) {
                $input = "http://" . $input;
            }

            return self::isUri($input);
        }

    }

}