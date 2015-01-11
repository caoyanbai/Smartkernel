<?php

namespace Smartkernel\Framework {

    use \Exception;
    use Smartkernel\Framework\SmartBoolean;
    use Smartkernel\Framework\SmartDateTime;
    use Smartkernel\Framework\SmartEnum;
    use Smartkernel\Framework\SmartString;

/*
     * 转换
     */

    class SmartConvert {
        /*
         * 尝试转换（失败则返回默认值）-- 转换为Int32类型
         * 
         * @param object $input，输入
         * @param int $defaultValue，默认值
         * @return int，结果
         * 
         */

        public static function tryToInt($input, $defaultValue = 0) {
            try {
                return intval($input);
            } catch (Exception $err) {
                return $defaultValue;
            }
        }

        /*
         * 尝试转换（失败则返回默认值）-- 转换为 Float 类型
         * 
         * @param object $input，输入
         * @param float $defaultValue，默认值
         * @return float，结果
         * 
         */

        public static function tryToFloat($input, $defaultValue = 0.00) {
            try {
                return floatval($input);
            } catch (Exception $err) {
                return $defaultValue;
            }
        }

        /*
         * 从源类型转换为目标类型
         * 
         * @param object $source，源
         * @param string $type，目标类型（可以是枚举、DateTime、Array[string]、其他基本类型等）
         * @return object，转换之后的对象
         */

        public static function to($source, $type) {
            $result = $source;

            if ($source === null) {
                return null;
            }

            $sourceString = $source === null ? null : strval($source);

            if (SmartString::startsWith($type, "Smart") && SmartString::endsWith($type, "Type")) {
                //目标类型为枚举类型
                $result = SmartEnum::parse($type, $sourceString, true);
            } else if (is_int($source) && SmartString::startsWith($type, "Smart") && SmartString::endsWith($type, "Type")) {
                //源为整形，目标为枚举类型
                $result = SmartEnum::getName($type, $source);
            } else if ($type == "DateTime") {
                //目标类型为时间类型
                $result = SmartDateTime::parse($sourceString);
            } else if (is_bool($source) && $type === "string") {
                //如果源是布尔值，目标是字符串
                $result = SmartBoolean::toString($source);
            } else {
                //一般类型的转换
                $result = eval("return ($type)'$sourceString';");
            }

            return $result;
        }

    }

}
