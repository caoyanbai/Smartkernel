<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Text {

    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 十六进制转换（输入项是区分大小写的，结果不区分。也就是输入项大小写不同时，结果不同。但是结果大小写不同，输入相同）
     */

    class SmartHex {
        /*
         * 转换为十六进制
         * 
         * @param array $datas，数据
         * @return array，转换的结果
         * 
         */

        public static function toHexArray(array $datas) {
            $hexChars = array('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F');

            $result = array();
            foreach ($datas as $data) {
                $hexByte0 = $hexChars[($data & 0xF0) >> 4];
                $hexByte1 = $hexChars[$data & 0x0F];
                $result[] = ord($hexByte0);
                $result[] = ord($hexByte1);
            }

            return $result;
        }

        /*
         * 转换为十六进制
         * 
         * @param string $input，待转换的字符串
         * @param string $encoding，编码方式
         * @return string，转换的结果
         * 
         */

        public static function toHex($input, $encoding = null) {
            $data = SmartEncoding::getBytes($input, $encoding);

            $hexData = self::toHexArray($data);

            return iconv(SmartEncoding::AnsiiEncodingValue, SmartEncoding::DefaultValue, SmartEncoding::getString($hexData, SmartEncoding::DefaultValue));
        }

        /*
         * 由十六进制数据转换为原形式
         * 
         * @param array $hexData，十六进制数据
         * @return array，原形式
         * 
         */

        public static function fromHexArray(array $hexData) {
            $result = array();
            $length = count($hexData);

            for ($i = 0; $i < $length; $i += 2) {
                $hexPairInDecimal = array();
                $hexPairInDecimal[0] = 0;
                $hexPairInDecimal[1] = 0;
                $hexPairInDecimal = array();
                for ($h = 0; $h < 2; $h++) {
                    $temp = chr($hexData[$i + $h]);
                    if ($temp == '0') {
                        $hexPairInDecimal[$h] = 0;
                    } else if ($temp == '1') {
                        $hexPairInDecimal[$h] = 1;
                    } else if ($temp == '2') {
                        $hexPairInDecimal[$h] = 2;
                    } else if ($temp == '3') {
                        $hexPairInDecimal[$h] = 3;
                    } else if ($temp == '4') {
                        $hexPairInDecimal[$h] = 4;
                    } else if ($temp == '5') {
                        $hexPairInDecimal[$h] = 5;
                    } else if ($temp == '6') {
                        $hexPairInDecimal[$h] = 6;
                    } else if ($temp == '7') {
                        $hexPairInDecimal[$h] = 7;
                    } else if ($temp == '8') {
                        $hexPairInDecimal[$h] = 8;
                    } else if ($temp == '9') {
                        $hexPairInDecimal[$h] = 9;
                    } else if ($temp == 'A' || $temp == 'a') {
                        $hexPairInDecimal[$h] = 10;
                    } else if ($temp == 'B' || $temp == 'b') {
                        $hexPairInDecimal[$h] = 11;
                    } else if ($temp == 'C' || $temp == 'c') {
                        $hexPairInDecimal[$h] = 12;
                    } else if ($temp == 'D' || $temp == 'd') {
                        $hexPairInDecimal[$h] = 13;
                    } else if ($temp == 'E' || $temp == 'e') {
                        $hexPairInDecimal[$h] = 14;
                    } else if ($temp == 'F' || $temp == 'f') {
                        $hexPairInDecimal[$h] = 15;
                    }
                }

                $result[] = (($hexPairInDecimal[0] << 4) | $hexPairInDecimal[1]);
            }

            return $result;
        }

        /*
         * 转换回原形式
         * 
         * @param string $input，待转换的字符串
         * @param string $encoding，编码方式
         * @return string，原形式
         * 
         */

        public static function fromHex($input, $encoding = null) {
            $hexData = SmartEncoding::getBytes($input, $encoding);

            $data = self::fromHexArray($hexData);

            return SmartEncoding::getString($data, $encoding);
        }

    }

}
