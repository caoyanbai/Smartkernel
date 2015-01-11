<?php

namespace Smartkernel\Framework {

    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\SmartMath;

/*
     * 金钱
     */

    class SmartMoney {

        private static function splitToChinese($input, $index) {
            $result = array('零', '壹', '贰', '叁', '肆', '伍', '陆', '染', '捌', '玖');
            $length = count($input);
            if ($index > $length - 1) {
                return "零";
            }
            return $result[intval($input[$length - 1 - $index])];
        }

        /*
         * 金额转换为中文大写形式
         * 
         * @param float $money，金额
         * @param bool $isFixLength，是否固定长度，如果为false，将删除无效的零
         * @return string，中文大写形式
         * 
         */

        public static function toChinese($money, $isFixLength = true) {
            $result = "{17}仟{16}佰{15}拾{14}万{13}仟{12}佰{11}拾{10}億{9}仟{8}佰{7}拾{6}萬{5}仟{4}佰{3}拾{2}元{1}角{0}分";
            $format = SmartString::toCharArray(SmartString::replace(sprintf("%.2f", $money), ".", ""));
            $result = SmartString::format($result, self::splitToChinese($format, 0), self::splitToChinese($format, 1), self::splitToChinese($format, 2), self::splitToChinese($format, 3), self::splitToChinese($format, 4), self::splitToChinese($format, 5), self::splitToChinese($format, 6), self::splitToChinese($format, 7), self::splitToChinese($format, 8), self::splitToChinese($format, 9), self::splitToChinese($format, 10), self::splitToChinese($format, 11), self::splitToChinese($format, 12), self::splitToChinese($format, 13), self::splitToChinese($format, 14), self::splitToChinese($format, 15), self::splitToChinese($format, 16), self::splitToChinese($format, 17));
            if (!$isFixLength) {
                $result = SmartString::replaceMore($result, array("零角", "零分"), "");
                $result = SmartString::replaceMore($result, array("零拾", "零佰", "零仟", "零万"), "零");
                $result = SmartString::replace($result, "零萬", "萬");
                $result = SmartString::replace($result, "零億", "億");
                $result = SmartString::repeatReplace($result, "零元", "元");
                $result = SmartString::repeatReplace($result, "零萬", "萬");
                $result = SmartString::repeatReplace($result, "零億", "億");
                $result = SmartString::repeatReplace($result, "零零", "零");
                $result = SmartString::replace($result, "億萬", "億零");
                $result = SmartString::replace(SmartString::trimStart($result, '億'), "万", "萬");
                $result = SmartString::repeatTrimStart($result, "零");
                return $result;
            }
            return SmartString::replace($result, "万", "萬");
        }

        /*
         * 数值转换为英文形式
         * 
         * @param float $money，数量
         * @return string，英文形式
         * 
         */

        public static function toEnglish($money) {
            return (new SmartEnglishConverter())->convert($money);
        }

    }

    /*
     * 英文转换器
     */

    class SmartEnglishConverter {

        private $figs = array();
        private $tens = array();
        private $units = array();

        /*
         * 转换
         * 
         * @param float $number，数字
         * @return string，转换的结果
         * 
         */

        public function convert($number) {
            $left = "";
            $right = "";
            $temp = "";
            self::init();
            $result = strval(SmartMath::round($number, 2));
            if (SmartString::indexOf($result, ".") == -1) {
                $left = $result;
                $right = "";
            } else {
                $left = SmartString::substring($result, 0, SmartString::indexOf($result, "."));
                $right = SmartString::substring($result, SmartString::indexOf($result, ".") + 1, SmartString::length($result) - SmartString::indexOf($result, ".") - 1);
            }
            if (SmartString::length($left) > 12) {
                return null;
            }
            $result = "";
            while (SmartString::length($left) > 0) {
                $length = self::len($left);
                $current = "";
                if ($length % 3 == 0) {
                    $current = self::left($left, 3);
                    $left = self::right($left, $length - 3);
                } else {
                    $current = self::left($left, ($length % 3));
                    $left = self::right($left, $length - ($length % 3));
                }
                $nbit = self::len($left) / 3;
                $temp = self::decodeHundred($current);
                if (($left == strval(self::len($left)) || $nbit == 0) && self::len($current) == 3) {
                    if (intval(self::left($current, 1)) != 0 & intval(self::right($current, 2)) != 0) {
                        $temp = self::left($temp, SmartString::indexOf($temp, $this->units[3]) + self::len($this->units[3])) . $this->units[7] . " " . self::right($temp, self::len($temp) - (SmartString::indexOf($temp, $this->units[3]) + self::len($this->units[3])));
                    } else {
                        $temp = $this->units[7] . " " . $temp;
                    }
                }
                if ($nbit == 0) {
                    $result = SmartString::trim(strval($result . " " . $temp));
                } else {
                    $result = SmartString::trim(strval($result . " " . $temp . " " . $this->units[$nbit - 1]));
                }
                if (self::left($result, 3) == $this->units[7]) {
                    $result = SmartString::trim(strval(self::right($result, self::len($result) - 3)));
                }
                if ($left == strval(self::len($left))) {
                    return "";
                }
            }
            $left = $result;
            if (self::len($right) > 0) {
                $right = $this->units[5] . " " . self::decodeHundred($right) . " " . $this->units[6];
            } else {
                $right = $this->units[4];
            }
            return SmartString::toUpper(($left . " " . $right));
        }

        private function init() {
            $this->figs[0] = "One";
            $this->figs[1] = "Two";
            $this->figs[2] = "Three";
            $this->figs[3] = "Four";
            $this->figs[4] = "Five";
            $this->figs[5] = "Six";
            $this->figs[6] = "Seven";
            $this->figs[7] = "Eight";
            $this->figs[8] = "Nine";
            $this->figs[9] = "Ten";
            $this->figs[10] = "Eleven";
            $this->figs[11] = "Twelve";
            $this->figs[12] = "Thirteen";
            $this->figs[13] = "Fourteen";
            $this->figs[14] = "Fifteen";
            $this->figs[15] = "Sixteen";
            $this->figs[16] = "Seventeen";
            $this->figs[17] = "Eighteen";
            $this->figs[18] = "Nineteen";
            $this->tens[0] = "Ten";
            $this->tens[1] = "Twenty";
            $this->tens[2] = "Thirty";
            $this->tens[3] = "Forty";
            $this->tens[4] = "Fifty";
            $this->tens[5] = "Sixty";
            $this->tens[6] = "Seventy";
            $this->tens[7] = "Eighty";
            $this->tens[8] = "Ninety";
            $this->units[0] = "Thousand";
            $this->units[1] = "Million";
            $this->units[2] = "Billion";
            $this->units[3] = "Hundred";
            $this->units[4] = "Only";
            $this->units[5] = "Dollars and";
            $this->units[6] = "Cent";
            $this->units[7] = "";
        }

        private function decodeHundred($hundredString) {
            $rtn = "";
            if (self::len($hundredString) > 0 && self::len($hundredString) <= 3) {
                $tmp = 0;
                switch (self::len($hundredString)) {
                    case 1:
                        $tmp = intval($hundredString);
                        if ($tmp != 0) {
                            $rtn = $this->figs[$tmp - 1];
                        }
                        break;
                    case 2:
                        $tmp = intval($hundredString);
                        if ($tmp != 0) {
                            if (($tmp < 20)) {
                                $rtn = $this->figs[$tmp - 1];
                            } else {
                                $rtn = intval(self::right($hundredString, 1)) == 0 ? $this->tens[intval($tmp / 10) - 1] : strval($this->tens[intval($tmp / 10) - 1] . " " . $this->figs[intval(self::right($hundredString, 1)) - 1]);
                            }
                        }
                        break;
                    case 3:
                        $rtn = intval(self::left($hundredString, 1)) != 0 ? strval($this->figs[intval(self::left($hundredString, 1)) - 1] . " " . $this->units[3] . "AND " . self::decodeHundred(self::right($hundredString, 2))) : self::decodeHundred(self::right($hundredString, 2));
                        break;
                    default:
                        break;
                }
            }
            return $rtn;
        }

        private static function left($str, $n) {
            return SmartString::substring($str, 0, $n);
        }

        private static function right($str, $n) {
            return SmartString::substring($str, SmartString::length($str) - $n, $n);
        }

        private static function len($str) {
            return SmartString::length($str);
        }

    }

}

