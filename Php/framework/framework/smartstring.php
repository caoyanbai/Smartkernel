<?php

namespace Smartkernel\Framework {

    use Smartkernel\Framework\SmartArray;
    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 字符串
     */

    class SmartString {

        //空字符串
        const EmptyValue = "";

        /*
         * 判断是不是为null、空或空格
         * 
         * @param string $input，输入
         * @return bool，结果
         * 
         */

        public static function isNullOrWhiteSpace($input) {
            return $input === null || str_replace(" ", "", $input) === "";
        }

        /*
         * 判断是不是为null、空
         * 
         * @param string $input，输入
         * @return bool，结果
         * 
         */

        public static function isNullOrEmpty($input) {
            return $input === null || $input === "";
        }

        /*
         * 结束于
         * 
         * @param string $input，输入
         * @param string $search，搜索
         * @return bool，结果
         */

        public static function endsWith($input, $search) {
            $len1 = self::length($input);
            $len2 = self::length($search);

            return $search === "" || $search === self::substring($input, $len1 - $len2, $len2);
        }

        /*
         * 开始于
         * 
         * @param string $input，输入
         * @param string $search，搜索
         * @return bool，结果
         */

        public static function startsWith($input, $search) {
            $len2 = self::length($search);

            return $search === "" || $search === self::substring($input, 0, $len2);
        }

        /*
         * 拼接数组片段
         * 
         * @param string $separator，分隔符
         * @param array $array，数组
         * @param int $startIndex，开始索引
         * @param int $count，长度
         * @return string，结果
         * 
         */

        public static function joinArraySegment($separator, array $array, $startIndex, $count) {
            $result = "";
            $length = count($array);
            for ($i = 0; $i < $length; $i++) {
                if ($i == $startIndex) {
                    $result = $array[$i];
                } else if ($i >= $startIndex && $i < $startIndex + $count) {
                    $result = $result . $separator . $array[$i];
                }
            }

            return $result;
        }

        /*
         * 拼接动态参数
         * 
         * @return string，结果
         * 
         */

        public static function join() {
            $args = func_get_args();
            $separator = $args[0];
            $arrayTemp = array();
            $length = count($args);
            for ($i = 1; $i < $length; $i++) {
                $arrayTemp[] = $args[$i];
            }
            return self::joinArraySegment($separator, $arrayTemp, 0, $length - 1);
        }

        /*
         * 拼接数组
         * 
         * @param string $separator，分隔符
         * @param array $array，数组
         * @return string，结果
         * 
         */

        public static function joinArray($separator, array $array) {
            return self::joinArraySegment($separator, $array, 0, count($array));
        }

        /*
         * 转换为字节数组
         * 
         * @param string $input，输入
         * @param string $encoding，编码
         * @return array，结果
         * 
         */

        public static function toCharArray($input, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $input = mb_convert_encoding($input, $encoding, SmartEncoding::DefaultValue);
            $strlen = self::length($input, $encoding);
            while ($strlen) {
                $result[] = self::substring($input, 0, 1, $encoding);
                $input = self::substring($input, 1, $strlen, $encoding);
                $strlen = self::length($input, $encoding);
            }
            return $result;
        }

        /*
         * 转换为字节数组片段
         * 
         * @param string $input，输入
         * @param int $startIndex，开始索引
         * @param int $count，长度
         * @return array，结果
         * 
         */

        public static function toCharArraySegment($input, $startIndex, $count) {
            $charArray = self::toCharArray($input);
            return SmartArray::getSegment($charArray, $startIndex, $count);
        }

        /*
         * 获得哈希值
         * 
         * @param string $input，输入
         * @return int，结果
         * 
         */

        public static function getHashCode($input) {
            $length = strlen($input);
            $hashCode = 0;
            for ($i = 0; $i < $length; $i++) {
                $hashCode = (int) ($hashCode * 31 + ord($input[$i]));
                if (($hashCode & 0x80000000) == 0) {
                    $hashCode &= 0x7fffffff;
                } else {
                    $hashCode = ($hashCode & 0x7fffffff) - 2147483648;
                }
            }
            return $hashCode;
        }

        /*
         * 拆分字符串为数组
         * 
         * @param string $input，输入
         * @param string or array $separator，分隔符号
         * @return array，结果
         * 
         */

        public static function split($input, $separator) {
            if (is_array($separator)) {
                $one = $separator[0];
                foreach ($separator as $item) {
                    $input = str_replace($item, $one, $input);
                }
                return explode($one, $input);
            } else {
                return explode($separator, $input);
            }
        }

        /*
         * 截取字符串
         * 
         * @param string $input，输入
         * @param int $startIndex，开始索引
         * @param int $length，长度
         * @param string $encoding，编码
         * @return string，结果
         * 
         */

        public static function substring($input, $startIndex, $length = -1, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            if ($length == -1) {
                $inputLength = self::length($input, $encoding);
                return mb_substr($input, $startIndex, $inputLength - $startIndex, $encoding);
            }
            return mb_substr($input, $startIndex, $length, $encoding);
        }

        /*
         * 删除开始和结尾某些字符
         * 
         * @param string $input，输入
         * @param string or array $trimChar，字符
         * @return string，结果
         * 
         */

        public static function trim($input, $trimChar = " ") {
            if (is_array($trimChar)) {
                foreach ($trimChar as $item) {
                    $input = rtrim(ltrim($input, $item), $item);
                }
                return $input;
            } else {
                return rtrim(ltrim($input, $trimChar), $trimChar);
            }
        }

        /*
         * 删除开始某些字符
         * 
         * @param string $input，输入
         * @param string or array $trimChar，字符
         * @return string，结果
         * 
         */

        public static function trimStart($input, $trimChar = " ") {
            if (is_array($trimChar)) {
                foreach ($trimChar as $item) {
                    $input = ltrim($input, $item);
                }
                return $input;
            } else {
                return ltrim($input, $trimChar);
            }
        }

        /*
         * 删除结尾某些字符
         * 
         * @param string $input，输入
         * @param string or array $trimChar，字符
         * @return string，结果
         * 
         */

        public static function trimEnd($input, $trimChar = " ") {
            if (is_array($trimChar)) {
                foreach ($trimChar as $item) {
                    $input = rtrim($input, $item);
                }
                return $input;
            } else {
                return rtrim($input, $trimChar);
            }
        }

        /*
         * 比较字符串
         * 
         * @param string $strA，字符串
         * @param string $strB，字符串
         * @param bool $ignoreCase，是否忽略大小写
         * @return int，结果
         * 
         */

        public static function compare($strA, $strB, $ignoreCase = true) {
            if ($ignoreCase == true) {
                $strA = strtolower($strA);
                $strB = strtolower($strB);
            }

            if ($strA == $strB) {
                return 0;
            }
            if ($strA == null || $strA < $strB) {
                return -1;
            }
            if ($strB == null || $strA > $strB) {
                return 1;
            }
        }

        /*
         * 是否包含
         * 
         * @param string $input，输入
         * @param string $value，字符串
         * @return bool，结果
         * 
         */

        public static function contains($input, $value) {
            return mb_strpos($input, $value, 0, SmartEncoding::DefaultValue) !== false;
        }

        /*
         * 判断位置
         * 
         * @param string $input，输入
         * @param string $value，字符串
         * @return int，结果
         * 
         */

        public static function indexOf($input, $value) {
            $result = mb_strpos($input, $value, 0, SmartEncoding::DefaultValue);
            if ($result === false) {
                return -1;
            } else {
                return $result;
            }
        }

        /*
         * 判断位置（从后开始）
         * 
         * @param string $input，输入
         * @param string $value，字符串
         * @return int，结果
         * 
         */

        public static function lastIndexOf($input, $value) {
            $result = mb_strrpos($input, $value, 0, SmartEncoding::DefaultValue);
            if ($result === false) {
                return -1;
            } else {
                return $result;
            }
        }

        /*
         * 计算长度
         * 
         * @param string $input，长度
         * @param string $encoding，编码
         * @return int，结果
         * 
         */

        public static function length($input, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            return mb_strlen($input, $encoding);
        }

        /*
         * 左侧对齐
         * 
         * @param string $input，输入
         * @param int $totalWidth，总长度
         * @param string $paddingChar，填充字符串
         * @return string，结果
         * 
         */

        public static function padLeft($input, $totalWidth, $paddingChar) {
            $len1 = self::length($input);
            $len2 = $totalWidth - $len1;
            $temp = "";
            while ($len2 > 0) {
                $len2--;
                $temp.=$paddingChar;
            }
            return $temp . $input;
        }

        /*
         * 右侧对齐
         * 
         * @param string $input，输入
         * @param int $totalWidth，总长度
         * @param string $paddingChar，填充字符串
         * @return string，结果
         * 
         */

        public static function rightLeft($input, $totalWidth, $paddingChar) {
            $len1 = self::length($input);
            $len2 = $totalWidth - $len1;
            $temp = "";
            while ($len2 > 0) {
                $len2--;
                $temp.=$paddingChar;
            }
            return $input . $temp;
        }

        /*
         * 小写
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function toLower($input) {
            return mb_strtolower($input, SmartEncoding::DefaultValue);
        }

        /*
         * 大写
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function toUpper($input) {
            return mb_strtoupper($input, SmartEncoding::DefaultValue);
        }

        /*
         * 插入字符串
         * 
         * @param string $input，输入
         * @param int $startIndex，开始索引
         * @param string $value，字符串
         * @return string，结果
         * 
         */

        public static function insert($input, $startIndex, $value) {
            $left = self::substring($input, 0, $startIndex);
            $right = self::substring($input, $startIndex);
            return $left . $value . $right;
        }

        /*
         * 字符串替换
         * 
         * @param string $input，输入
         * @param string $oldValue，旧值
         * @param string $newValue，新值
         * @param string，结果
         * 
         */

        public static function replace($input, $oldValue, $newValue) {
            return str_replace($oldValue, $newValue, $input);
        }

        /*
         * 格式化字符串
         * 
         * @param string $format，格式化字符串
         * @return string，结果
         * 
         */

        public static function format($format) {
            $count_args = func_num_args();
            if ($count_args == 1) {
                return $format;
            }

            for ($i = 0; $i < $count_args - 1; $i++) {
                $arg_value = func_get_arg($i + 1);
                $format = str_replace("{{$i}}", $arg_value, $format);
            }

            return $format;
        }

        /*
         * 截取字符串左侧指定长度的字符，如果不足指定的长度，则取整个字符串
         * 
         * @param string $input，待截取的字符串
         * @param int $length，截取的长度
         * @param string $ellipsis，如果发生截取，则使用的结尾符号
         * @return string，截取的结果
         * 
         */

        public static function left($input, $length, $ellipsis = "") {
            $inputLength = self::length($input);
            return $inputLength <= $length ? $input : self::substring($input, 0, $length) . $ellipsis;
        }

        /*
         * 截取字符串右侧指定长度的字符，如果不足指定的长度，则取整个字符串
         * 
         * @param string $input，待截取的字符串
         * @param int $length，截取的长度
         * @param string $ellipsis，如果发生截取，则使用的结尾符号
         * @return string，截取的结果
         * 
         */

        public static function right($input, $length, $ellipsis = "") {
            $inputLength = self::length($input);
            return $inputLength <= $length ? $input : $ellipsis . self::substring($input, $inputLength - $length, $length);
        }

        /*
         * 否全为空（只要有一个不为空，则返回false）
         * 
         * @return bool，结果
         * 
         */

        public static function isNullOrEmptyAll() {
            $args = func_get_args();
            foreach ($args as $one) {
                if (!self::IsNullOrEmpty($one)) {
                    return false;
                }
            }
            return true;
        }

        /*
         * 是否有一个为空（只要有一个为空，则返回true）
         * 
         * @return bool，结果
         * 
         */

        public static function isNullOrEmptyAny() {
            $args = func_get_args();
            foreach ($args as $one) {
                if (self::isNullOrEmpty($one)) {
                    return true;
                }
            }

            return false;
        }

        /*
         * 是否全为空（只要有一个不为空，则返回false）
         * 
         * @return bool，结果
         * 
         */

        public static function isNullOrWhiteSpaceAll() {
            $args = func_get_args();
            foreach ($args as $one) {
                if (!self::isNullOrWhiteSpace($one)) {
                    return false;
                }
            }
            return true;
        }

        /*
         * 是否有一个为空（只要有一个为空，则返回true）
         * 
         * @return bool，结果
         * 
         */

        public static function isNullOrWhiteSpaceAny() {
            $args = func_get_args();
            foreach ($args as $one) {
                if (self::isNullOrWhiteSpace($one)) {
                    return true;
                }
            }

            return false;
        }

        /*
         * 获得重复字符组成的字符串
         * 
         * @param string $input，字符
         * @param int $count，重复次数
         * @return string，字符串
         * 
         */

        public static function repeat($input, $count) {
            $result = "";
            for ($i = 0; $i < $count; $i++) {
                $result = $result . strval($input);
            }
            return $result;
        }

        /*
         * 翻转字符串
         * 
         * @param string $input，输入的字符串
         * @return string，翻转的结果
         * 
         */

        public static function reverse($input) {
            $chars = self::toCharArray($input);
            $chars = SmartArray::reverse($chars);
            return SmartArray::join($chars);
        }

        /*
         * 进行不区分大小写的比较
         * 
         * @param string $input，原字符串
         * @param string $other，待比较的字符串
         * @return bool，结果
         * 
         */

        public static function compareIgnoreCase($input, $other) {
            return strtolower($input) === strtolower($other);
        }

        /*
         * 验证是不是邮箱地址
         * 
         * @param string $input，待检查的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isEmail($input) {
            $pattern = "/^([a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是包含小写字符串，包含非字母符号不影响结果
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function containsLow($input) {
            $pattern = "/[a-z]/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是包含大写字符串，包含非字母符号不影响结果
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function containsUp($input) {
            $pattern = "/[A-Z]/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是字母字符串，空格也认为是非字母
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isAlphabetic($input) {
            $pattern = "/^[a-zA-Z]+$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是包含字母
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function containsAlphabetic($input) {
            $pattern = "/[a-zA-Z]/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是包含数字
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function containsNumberic($input) {
            $pattern = "/[0-9]/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是中文字符，空格也认为是非中文（仅支持UTF-8）
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isChinese($input) {
            $pattern = "/^[\x{4e00}-\x{9fa5}]+$/u";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是包含中文字符（仅支持UTF-8）
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function containsChinese($input) {
            $pattern = "/[\x{4e00}-\x{9fa5}]/u";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是字母和数字组合
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isAlphabeticNumberic($input) {
            $pattern = "/^[A-Za-z0-9]+$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证是不是手机号码
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isChineseMobilePhone($input) {
            $pattern = "/^[1]{1}[0-9]{10}$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 验证长度是不是在指定的范围内
         * 
         * @param string $input，待验证的字符串
         * @param int $start，起始边界
         * @param int $end，结束边界
         * @return bool，验证的结果
         * 
         */

        public static function isLengthBetween($input, $start, $end) {
            $pattern = sprintf("/^.{%d,%d}$/", $start, $end);
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 设置单词首字母大写
         * 
         * @param string $input，待处理的字符串
         * @return string，处理的结果
         * 
         */

        public static function toTitleCase($input) {
            return ucwords(strtolower($input));
        }

        /*
         * 设置单词首字母小写
         * 
         * @param string $input，待处理的字符串
         * @return string，处理的结果
         * 
         */

        public static function toCamelCase($input) {
            return strtolower(self::left($input, 1)) . self::right($input, self::length($input) - 1);
        }

        /*
         * 验证是不是电话号码，匹配010-1234567、010-12345678、0316-1234567、0316-12345678、1234567、12345678。
         * 以及所有前面的号码加“-”、“转”、“#”之后加分机号码。
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isChinesePhone($input) {
            return preg_match("/^\d{7,8}$/", $input) > 0 || preg_match("/^\d{7,8}[-转#]\d{1,6}$/", $input) > 0 || preg_match("/^\d{3,4}-\d{7,8}$/", $input) > 0 || preg_match("/^\d{3,4}-\d{7,8}[-转#]\d{1,6}$/", $input) > 0;
        }

        /*
         * 删除所有空格
         * 
         * @param string $input，待处理的字符串
         * @return string，处理的结果
         * 
         */

        public static function trimAll($input) {
            return self::replace($input, " ", "");
        }

        /*
         * 替换指定的字符串列表
         * 
         * @param string $input，待处理的字符串
         * @param array $oldValues，旧的字符串
         * @param string $newValue，新的字符串
         * @return string，处理的结果
         * 
         */

        public static function replaceMore($input, array $oldValues, $newValue = "") {
            foreach ($oldValues as $oldValue) {
                $input = self::replace($input, $oldValue, $newValue);
            }
            return $input;
        }

        /*
         * 多次反复替换直到完全不包含指定的字符为止
         * 
         * @param string $input，待处理的字符串
         * @param string $oldValue，旧的字符串
         * @param string $newValue，新的字符串
         * @return string，处理的结果
         * 
         */

        public static function repeatReplace($input, $oldValue, $newValue = "") {
            while (self::contains($input, $oldValue)) {
                $input = self::replace($input, $oldValue, $newValue);
            }
            return $input;
        }

        /*
         * 多次反复删除开始的字符直到完全不包含指定的字符为止
         * 
         * @param string $input，待处理的字符串
         * @param string $value，移除的字符串
         * @return string，结果
         * 
         */

        public static function repeatTrimStart($input, $value) {
            while (self::startsWith($input, $value)) {
                $input = self::trimStart($input, $value);
            }
            return $input;
        }

        /*
         * 多次反复删除结束的字符直到完全不包含指定的字符为止
         * 
         * @param string $input，待处理的字符串
         * @param string $value，移除的字符串
         * @return string，结果
         * 
         */

        public static function repeatTrimEnd($input, $value) {
            while (self::endsWith($input, $value)) {
                $input = self::trimEnd($input, $value);
            }
            return $input;
        }

        /*
         * 验证是不是邮编
         * 
         * @param string $input，待验证的字符串
         * @return bool，验证的结果
         * 
         */

        public static function isChineseZipCode($input) {
            $pattern = "/^\d{6}$/";
            return preg_match($pattern, $input) > 0;
        }

        /*
         * 根据片段的长度拆分字符串获得字符串数组
         * 
         * @param string $input，待处理的字符串
         * @param int $segmentSize，片段的长度
         * @return array，处理的结果
         * 
         */

        public static function splitBySegment($input, $segmentSize = 1) {
            if (self::isNullOrEmpty($input)) {
                return array("");
            }
            $totalSegments = intval(ceil(self::length($input) / $segmentSize));

            $segments = array();

            $length = self::length($input);

            for ($i = 0; $i < $totalSegments; $i++) {
                if ($i * $segmentSize + $segmentSize >= $length) {
                    $segments[] = self::substring($input, $i * $segmentSize);
                } else {
                    $segments[] = self::substring($input, $i * $segmentSize, $segmentSize);
                }
            }
            return $segments;
        }

        /*
         * 截取字符串（通过范围，不包括范围标记）
         * 
         * @param string $input，待截取的字符串
         * @param string $left，左边界
         * @param string $right，右边界
         * @return string，结果
         * 
         */

        public static function subStringByScope($input, $left, $right) {
            $leftIndex = self::indexOf($input, $left) + self::length($left);
            $rightIndex = self::indexOf($input, $right);

            return self::substring($input, $leftIndex, $rightIndex - $leftIndex);
        }

    }

}