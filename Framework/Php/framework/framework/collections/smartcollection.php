<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Collections {
    /*
     * 集合类的辅助工具
     */

    class SmartCollection {
        /*
         * 将多个枚举类型合并成一个
         * 
         * @param array $lists，多个枚举类型
         * @return array，结果
         * 
         */

        public static function unionAll(array $lists) {
            $result = array();

            if ($lists != null) {
                foreach ($lists as $list) {
                    if ($list != null) {
                        foreach ($list as $item) {
                            $result[] = $item;
                        }
                    }
                }
            }

            return $result;
        }

        /*
         * 判断集合是否为空或null
         * @param array $list，集合
         * @return bool，是否为空
         */

        public static function isNullOrEmpty(array $list) {
            return $list == null || count($list) == 0;
        }

        /*
         * 随机排序
         * @param array $list，列表
         * 
         */

        public static function randomSort(array &$list) {
            shuffle($list);
        }

        /*
         * 获得集合的字符串表示
         * @param array $list，集合
         * @param string $leftEmbodySymbol，左包含符
         * @param string $rightEmbodySymbol，右包含符
         * @param string $splitSymbol，分隔符
         * $return string，字符串表示
         * 
         */

        public static function toJoinString(array $list, $leftEmbodySymbol = "'", $rightEmbodySymbol = "'", $splitSymbol = "|") {
            $temp = array();

            foreach ($list as $item) {
                $temp[] = $leftEmbodySymbol . $item . $rightEmbodySymbol;
            }
            return implode($splitSymbol, $temp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="target">目标</param>
        /// <returns>是否相等</returns>

        /*
         * 判断两个枚举类型是否相同，且具有相同数量的元素（每一个位置的值都相同）
         * @param array $source，源
         * @param array $target，目标
         * return bool，是否相等
         * 
         */
        public static function equalsByEachOne(array $source, array $target) {
            return count(array_diff_assoc($source, $target)) === 0 && count(array_diff_assoc($target, $source)) === 0;
        }

    }

}