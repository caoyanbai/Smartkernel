<?php

namespace Smartkernel\Framework {

    use \ReflectionClass;

/*
     * 枚举辅助操作类
     */

    class SmartEnum {
        /*
         * 获得枚举值的字符串表示
         * 
         * @param string $fullClassName，类的全名（包含命名空间）
         * @param object $value，值
         * @return string，结果
         * 
         */

        public static function getName($fullClassName, $value) {
            $items = self::getAll($fullClassName);
            foreach ($items as $key => $val) {
                if ($val === $value) {
                    return $key;
                }
            }

            return null;
        }

        /*
         * 获得枚举值的全部字符串表示
         * 
         * @param string $fullClassName，类的全名（包含命名空间）
         * @return string，结果
         * 
         */

        public static function getAll($fullClassName) {
            $result = array();
            if (class_exists($fullClassName, true)) {
                $reflector = new ReflectionClass($fullClassName);
                foreach ($reflector->getConstants() as $key => $value) {
                    $result[$key] = $value;
                }
            }

            return $result;
        }

        /*
         * 解析字符串
         * 
         * @param string $fullClassName，类的全名（包含命名空间）
         * @param string $name，名称
         * @param bool $ignoreCase，忽略大小写
         * @return object，结果
         * 
         */

        public static function parse($fullClassName, $name, $ignoreCase = true) {
            $items = self::getAll($fullClassName);
            foreach ($items as $key => $val) {
                if (($ignoreCase && strtolower($key) === strtolower($name)) || (!$ignoreCase && $key === $name)) {
                    return $val;
                }
            }

            return null;
        }

        /*
         * 设置新类型
         * 
         * @param int $newType，新类型
         * @param int $oldType，旧类型
         * @result int，复合类型
         * 
         */

        public static function setEnumType($newType, $oldType) {
            $defineTypes = self::getAll("SlBbsArticleType");
            $resultTypes = array();

            foreach ($defineTypes as $key => $value) {
                if ($oldType & $value) {
                    $resultTypes[] = $value;
                }
            }

            if (!in_array($newType, $resultTypes)) {
                $resultTypes[] = $newType;
            }

            $result = 0;

            foreach ($resultTypes as $resultType) {
                $result = $result | $resultType;
            }

            return $result;
        }

        /*
         * 获取类型组合信息
         * 
         * @param int $type，类型值
         * @return array，类型组合信息
         * 
         */

        public static function getEnumType($type) {
            $defineTypes = self::getAll("SlBbsArticleType");
            $resultTypes = array();

            foreach ($defineTypes as $key => $value) {
                if ($type & $value) {
                    $resultTypes[$key] = $value;
                }
            }

            return $resultTypes;
        }

    }

}