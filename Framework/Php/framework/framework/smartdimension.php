<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {
    /*
     * 维度
     */

    class SmartDimension {
        /*
         * 获得可能
         * 
         * @param int $totalCount，总维度数
         * @param int $joinCount，参与维度数（几个为true）
         * @return array，结果
         * 
         */

        public static function getPossibly($totalCount, $joinCount) {
            $result = array();

            $maxFormat = "";
            $minFormat = "";

            for ($i = 0; $i < $totalCount; $i++) {
                $maxFormat = $maxFormat . "1";
                $minFormat = $minFormat . "0";
            }

            $max = bindec($maxFormat);
            $min = bindec($minFormat);

            $count = 0;

            for ($i = $min; $i < $max; $i++) {
                $count = 0;
                $current = sprintf("%0" . (string) (strlen($minFormat)) . "d", decbin($i));
                $array = SmartString::toCharArray($current);
                $item = array();
                $totalCount = count($array);
                for ($j = 0; $j < $totalCount; $j++) {
                    if ($array[$j] == '1') {
                        $count++;
                    }
                    $item[$j] = ($array[$j] == '1');
                }
                if ($count == $joinCount) {
                    $result[] = $item;
                }
            }

            return $result;
        }

    }

}