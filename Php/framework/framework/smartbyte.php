<?php

namespace Smartkernel\Framework {

    use Smartkernel\Framework\SmartInt32;

/*
     * 字节类
     */

    class SmartByte {
        /*
         * 字符串转换为字节数组
         * 
         * @param string $input，输入
         * @return array，结果
         * 
         */

        public static function fromString($input) {
            $array = unpack("C*", $input);
            $result = array();
            foreach ($array as $item) {
                $result[] = $item;
            }
            return $result;
        }

        /*
         * 字节数组转换为字符串
         * 
         * @param array $input，输入
         * @return string，结果
         * 
         */

        public static function toString(array $input) {
            $result = '';
            foreach ($input as $ch) {
                $result .= chr($ch);
            }

            return $result;
        }

        /*
         * 拷贝字节数组的一部分
         * 
         * @param array $source，源
         * @param int $startIndex，开始的索引
         * @param int $length，长度
         * @return array，拷贝的结果
         * 
         */

        public static function blockCopy(array $source, $startIndex, $length) {
            return SmartArray::getSegment($source, $startIndex, $length);
        }

        /*
         * 合并两个字节数组
         * 
         * @param array $source，源
         * @param array $other，另外一个字节数组
         * @return array，合并的结果
         * 
         */

        private static function combine(array $source, array $other) {
            return SmartArray::addRange($source, $other);
        }

        /*
         * 比较两个字节数组是否相等
         * 
         * @param array $source，源
         * @param array $other，目标
         * @return int，比较的结果
         * 
         */

        public static function compareTo(array $source, array $other) {
            if ($source == null && $other == null) {
                return 0;
            }
            if ($source == null) {
                return 1;
            }
            if ($other == null) {
                return -1;
            }
            $sourceLength = count($source);
            $otherLength = count($other);

            if ($sourceLength == $otherLength) {
                $comparision = 0;
                for ($i = 0; $i < $sourceLength; $i++) {
                    $comparision = SmartInt32::compareTo($source[$i], $other[$i]);
                    if ($comparision != 0) {
                        break;
                    }
                }
                return $comparision;
            }
            return SmartInt32::compareTo($sourceLength, $otherLength);
        }

        /*
         * 转换为字符串（64位编码）
         * 
         * @param array $source，字节数组
         * @return string，转换的结果
         * 
         */

        public static function toBase64(array $source) {
            return base64_encode(self::toString($source));
        }

        /*
         * 转换为字符串（十六进制）
         * 
         * @param array $source，字节数组
         * @param string，转换的结果
         * 
         */

        public static function toHex(array $source) {
            return unpack("H*", self::toString($source))[1];
        }

        /*
         * 转换回字节数组
         * 
         * @param string $input，字符串
         * @return array，转换的结果
         * 
         */

        public static function fromBase64($input) {
            return self::fromString(base64_decode($input));
        }

        /*
         * 转换回字节数组
         * 
         * @param string $source，字符串
         * @param string，转换的结果
         * 
         */

        public static function fromHex($source) {
            return self::fromString(pack("H*", $source));
        }

    }

}