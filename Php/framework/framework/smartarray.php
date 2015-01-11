<?php

namespace Smartkernel\Framework {
    /*
     * 数组
     */

    class SmartArray {
        /*
         * 获得数组片段
         * 
         * @param array $array，数组
         * @param int $startIndex，开始索引
         * @param int $count，长度
         * @return array，结果
         * 
         */

        public static function getSegment(array $array, $startIndex, $count) {
            $result = array();
            $length = count($array);
            for ($i = 0; $i < $length; $i++) {
                if ($i >= $startIndex && $i < $startIndex + $count) {
                    $result[] = $array[$i];
                }
            }

            return $result;
        }

        /*
         * 折半查找（数组必须是排序好的）
         * 
         * @param array $array，数组
         * @param object $value，值
         * @return int，索引位置
         * 
         */

        public static function binarySearch(array $array, $value) {
            $top = sizeof($array) - 1;
            $bot = 0;
            while ($top >= $bot) {
                $p = floor(($top + $bot) / 2);
                if ($array[$p] < $value) {
                    $bot = $p + 1;
                } elseif ($array[$p] > $value) {
                    $top = $p - 1;
                } else {
                    return $p;
                }
            }
            return 0;
        }

        /*
         * 拷贝数组
         * 
         * @param array $array，数组
         * @param int $startIndex，开始索引
         * @param int $length，长度
         * @return array，结果
         * 
         */

        public static function copy(array $array, $startIndex, $length = -1) {
            $arraySize = count($array);
            $endIndex = $length === -1 ? $arraySize : $startIndex + $length;
            $result = array();

            for ($i = $startIndex; $i < $endIndex; $i++) {
                $result[] = $array[$i];
            }

            return $result;
        }

        /*
         * 反转数组
         * 
         * @param array $array，数组
         * @return array，结果
         * 
         */

        public static function reverse(array $array) {
            return array_reverse($array);
        }

        /*
         * 排序数组
         * 
         * @param array $array，数组
         * @return array，结果
         * 
         */

        public static function sort(array $array) {
            sort($array);
            return $array;
        }

        /*
         * 数组长度
         * 
         * @param array $array，数组
         * @return int，结果
         * 
         */

        public static function length(array $array) {
            return count($array);
        }

        /*
         * 获得重复元素初始化的数组
         * 
         * @param object $value，值
         * @param int $count，数量
         * @return array，结果
         * 
         */

        public static function repeat($value, $count) {
            $result = array();
            for ($i = 0; $i < $count; $i++) {
                $result[] = $value;
            }

            return $result;
        }

        /*
         * 取交集
         * 
         * @param array $array1，数组
         * @param array $array2，数组
         * @return array，结果
         * 
         */

        public static function intersect(array $array1, array $array2) {
            $result = array();

            foreach ($array1 as $item) {
                if (in_array($item, $array2)) {
                    $result[] = $item;
                }
            }
            return $result;
        }

        /*
         * 加入序列
         * 
         * @param array $array，数组
         * @param array $addArray，加入的数组
         * @return array，结果
         * 
         */

        public static function addRange(array $array, array $addArray) {
            foreach ($addArray as $item) {
                $array[] = $item;
            }
            return $array;
        }

        /*
         * 是否包含
         * 
         * @param array $array，数组
         * @param object $value，值
         * @return bool，结果
         * 
         */

        public static function contains(array $array, $value) {
            return in_array($value, $array);
        }

        /*
         * 排重
         * 
         * @param array $array，数组
         * @return array，结果
         * 
         */

        public static function distinct(array $array) {
            $result = array();
            foreach ($array as $item) {
                if (!self::contains($result, $item)) {
                    $result[] = $item;
                }
            }
            return $result;
        }

        /*
         * 最大值
         * 
         * @param array $array，数组
         * @return object，结果
         * 
         */

        public static function max(array $array) {
            $result = $array[0];
            foreach ($array as $item) {
                if ($item >= $result) {
                    $result = $item;
                }
            }
            return $result;
        }

        /*
         * 最小值
         * 
         * @param array $array，数组
         * @return object，结果
         * 
         */

        public static function min(array $array) {
            $result = $array[0];
            foreach ($array as $item) {
                if ($item <= $result) {
                    $result = $item;
                }
            }
            return $result;
        }

        /*
         * 取前几个
         * 
         * @param array $array，数组
         * @param int $count，数量
         * @return array，结果
         * 
         */

        public static function take(array $array, $count) {
            $result = array();
            for ($i = 0; $i < $count; $i++) {
                $result[] = $array[$i];
            }
            return $result;
        }

        /*
         * 过滤
         * 
         * @param array $array，数组
         * @param function $where，过滤条件
         * @return array，结果
         * 
         */

        public static function where(array $array, $where) {
            $result = array();
            foreach ($array as $item) {
                if ($where($item) === true) {
                    $result[] = $item;
                }
            }
            return $result;
        }

        /*
         * 循环处理
         * 
         * @param array $array，数组
         * @param function $action，函数
         * 
         */

        public static function forEachOne(array $array, $action) {
            foreach ($array as $item) {
                $action($item);
            }
        }

        /*
         * 拼接数组
         * 
         * @param array $array，数组
         * @param string $seperator，分隔符
         * @return string，结果
         * 
         */

        public static function join(array $array, $seperator = "") {
            return join($array, $seperator);
        }

        /*
         * 解析为数组
         * 
         * @param string $value，值
         * @param string $split，分割符
         * @return array，结果
         * 
         */

        public static function parse($value, $split = '|') {
            return explode($split, $value);
        }

    }

}