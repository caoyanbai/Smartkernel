<?php

namespace Smartkernel\Framework\Web {
    /*
     * Xss攻击防御
     */

    class SmartAntiXss {
        /*
         * 获得安全的Html片段（不会自动补全Html标签）
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function getSafeHtmlFragment($input) {
            // Fix &entity\n;
            $input = str_replace(array('&amp;', '&lt;', '&gt;'), array('&amp;amp;', '&amp;lt;', '&amp;gt;'), $input);
            $input = preg_replace('/(&#*\w+)[\x00-\x20]+;/u', '$1;', $input);
            $input = preg_replace('/(&#x*[0-9A-F]+);*/iu', '$1;', $input);
            $input = html_entity_decode($input, ENT_COMPAT, 'UTF-8');

            // Remove any attribute starting with "on" or xmlns
            $input = preg_replace('#(<[^>]+?[\x00-\x20"\'])(?:on|xmlns)[^>]*+>#iu', '$1>', $input);

            // Remove javascript: and vbscript: protocols
            $input = preg_replace('#([a-z]*)[\x00-\x20]*=[\x00-\x20]*([`\'"]*)[\x00-\x20]*j[\x00-\x20]*a[\x00-\x20]*v[\x00-\x20]*a[\x00-\x20]*s[\x00-\x20]*c[\x00-\x20]*r[\x00-\x20]*i[\x00-\x20]*p[\x00-\x20]*t[\x00-\x20]*:#iu', '$1=$2nojavascript...', $input);
            $input = preg_replace('#([a-z]*)[\x00-\x20]*=([\'"]*)[\x00-\x20]*v[\x00-\x20]*b[\x00-\x20]*s[\x00-\x20]*c[\x00-\x20]*r[\x00-\x20]*i[\x00-\x20]*p[\x00-\x20]*t[\x00-\x20]*:#iu', '$1=$2novbscript...', $input);
            $input = preg_replace('#([a-z]*)[\x00-\x20]*=([\'"]*)[\x00-\x20]*-moz-binding[\x00-\x20]*:#u', '$1=$2nomozbinding...', $input);

            // Only works in IE: <span style="width: expression(alert('Ping!'));"></span>
            $input = preg_replace('#(<[^>]+?)style[\x00-\x20]*=[\x00-\x20]*[`\'"]*.*?expression[\x00-\x20]*\([^>]*+>#i', '$1>', $input);
            $input = preg_replace('#(<[^>]+?)style[\x00-\x20]*=[\x00-\x20]*[`\'"]*.*?behaviour[\x00-\x20]*\([^>]*+>#i', '$1>', $input);
            $input = preg_replace('#(<[^>]+?)style[\x00-\x20]*=[\x00-\x20]*[`\'"]*.*?s[\x00-\x20]*c[\x00-\x20]*r[\x00-\x20]*i[\x00-\x20]*p[\x00-\x20]*t[\x00-\x20]*:*[^>]*+>#iu', '$1>', $input);

            // Remove namespaced elements (we do not need them)
            $input = preg_replace('#</*\w+:\w[^>]*+>#i', '', $input);

            do {
                // Remove really unwanted tags
                $old_data = $input;
                $input = preg_replace('#</*(?:applet|b(?:ase|gsound|link)|embed|frame(?:set)?|i(?:frame|layer)|l(?:ayer|ink)|meta|object|s(?:cript|tyle)|title|xml)[^>]*+>#i', '', $input);
            } while ($old_data !== $input);

            // we are done...
            return $input;
        }

        /*
         * 获得安全的Text
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function getSafeText($input) {
            return strip_tags($input);
        }

    }

}

