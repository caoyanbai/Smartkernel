<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use \Exception;
    use \ReflectionClass;
    use \ReflectionObject;
    use \ReflectionProperty;
    use \ReflectionMethod;

/*
     * 类型操作相关功能（PHP不区分属性和字段，类型也不是那么重要）
     */

    class SmartType {
        /*
         * 创建的类型对象
         * 
         * @param string $type，类型
         * @return object，创建的对象
         * 
         */

        public static function createInstance($type) {
            return (new ReflectionClass($type))->newInstanceWithoutConstructor();
        }

        /*
         * 获得某种类型的属性集合，包括公共属性和非公共属性
         * 
         * @param string or object $type，类型或者对象
         * @param ReflectionProperty $bindingFlags，绑定标志
         * @return array，属性的数组
         * 
         */

        public static function getProperties($type, $bindingFlags = -1) {
            if ($bindingFlags === -1) {
                $bindingFlags = ReflectionProperty::IS_PUBLIC | ReflectionProperty::IS_PRIVATE | ReflectionProperty::IS_PROTECTED | ReflectionProperty::IS_STATIC;
            }
            if (gettype($type) === "string") {
                return (new ReflectionClass($type))->getProperties($bindingFlags);
            } else {
                return (new ReflectionObject($type))->getProperties();
            }
        }

        /*
         * 获得某种类型的指定属性名称的属性对象
         * 
         * @param string or object $type，类型或者对象
         * @param string $propertyName，属性名称
         * @param ReflectionProperty $bindingFlags，绑定标志
         * @return ReflectionProperty，属性对象
         * 
         */

        public static function getProperty($type, $propertyName, $bindingFlags = -1) {
            $properties = self::getProperties($type, $bindingFlags);
            foreach ($properties as $property) {
                if ($property->name === $propertyName) {
                    return $property;
                }
            }
            return null;
        }

        /*
         * 判断某种类型的指定属性名称的属性是否存在
         * 
         * @param string or object $type，类型或者对象
         * @param string $propertyName，属性名称
         * @param ReflectionProperty $bindingFlags，绑定标志
         * @return bool，是否存在
         * 
         */

        public static function containsProperty($type, $propertyName, $bindingFlags = -1) { {
                return self::getProperty($type, $propertyName, $bindingFlags) != null;
            }
        }

        /*
         * 获得类型的根类型（PHP没有统一的object根类型）
         * 
         * @param string or object $type，类型或者对象
         * @return string，根类型
         * 
         */

        public static function getRootType($type) {
            $resultType = "";
            if (gettype($type) === "string") {
                $resultType = (new ReflectionClass($type))->getParentClass();
            } else {
                $resultType = (new ReflectionObject($type))->getParentClass();
            }

            if ($resultType !== false && $resultType !== null) {

                return self::getRootType($resultType->name);
            } else {
                return $type;
            }
        }

        /*
         * 判断是不是数字类型
         * 
         * @param string $type，类型
         * @return bool，是否数字类型
         * 
         */

        public static function isNumbericType($type) {
            return $type === "integer" || $type === "double";
        }

        /*
         * 判断是不是可为null的类型
         * 
         * @param string $type，类型
         * @return bool，是不是可为null的类型
         * 
         */

        public static function isNullType($type) {
            return $type === "NULL";
        }

        /*
         * 是否包含方法
         * 
         * @param string $type，类型
         * @param string $methodName，方法名称
         * @return bool，是否包含
         * 
         */

        public static function containsMethod($type, $methodName) {
            try {
                (new ReflectionMethod($type, $methodName));
                return true;
            } catch (Exception $err) {
                return false;
            }
        }

        /*
         * 获取方法
         * 
         * @param string $type，类型
         * @param string $methodName，方法名称
         * @return ReflectionMethod，方法
         * 
         */

        public static function getMethod($type, $methodName) {
            return new ReflectionMethod($type, $methodName);
        }

        /*
         * 设置对象的属性值
         * 
         * @param object $obj，对象
         * @param string $name，属性名
         * @param object $value，值
         * 
         */

        public static function setPropertyValue($obj, $name, $value) {
            eval('$obj->$name=$value;');
        }

        /*
         * 通过反射调用对象的方法，并返回值
         * 
         * @param string $target，对象
         * @param string $methodName，方法名，区分大小写
         * @param array $args，方法的参数数组
         * @return object，方法调用返回的结果
         * 
         */

        public static function methodInvoke($target, $methodName, $args = array()) {
            return call_user_func_array(array($target, $methodName), $args);
        }

        /*
         * 获取对象指定属性的值
         * 
         * @param object $obj，对象
         * @param string $propertyName，属性名
         * @return object，值
         * 
         */

        public static function getPropertyValue($obj, $propertyName) {
            return eval('return $obj->$propertyName;');
        }

        /*
         * 获得对象所有属性值的键值对列表
         * 
         * @param object $obj，对象
         * @param ReflectionProperty $bindingFlags，绑定标志 
         * @return array，属性值的键值对列表
         * 
         */

        public static function getPropertiesDictionary($obj, $bindingFlags = null) {

            $properties = self::getProperties($obj, $bindingFlags);

            $result = array();
            foreach ($properties as $property) {
                $result[$property->name] = self::getPropertyValue($obj, $property->name);
            }

            return $result;
        }

        /*
         * 通过成员的简单拷贝进行对象复制。实现浅表复制，只实现第一层成员的复制。某些成员复制失败，不会影响其他成员的复制
         * 
         * @param object $source，源对象
         * @param object $target，目标对象
         * @param ReflectionProperty $bindingFlags，绑定标志
         * 
         */

        public static function membersSimpleCopy($source, $target, $bindingFlags = -1) {
            $properties = self::getProperties($source, $bindingFlags);
            foreach ($properties as $property) {
                $value = self::getPropertyValue($source, $property->name);
                if (self::containsProperty($target, $property->name, $bindingFlags)) {
                    self::setPropertyValue($target, $property->name, $value);
                }
            }
        }

        /*
         * 简单成员比较，如果成员相等，则认为是相等。类型不同的两个对象也可以比较，主要相同名称的成员相等就认为是相等
         * 
         * @param object $source，源对象
         * @param object $target，目标对象
         * @param ReflectionProperty $bindingFlags，绑定标志
         * @return bool，是否相等
         * 
         */

        public static function membersSimpleCompare($source, $target, $bindingFlags = -1) {
            $properties = self::getProperties($source, $bindingFlags);
            foreach ($properties as $property) {
                $sourceValue = self::getPropertyValue($source, $property->name);
                if (self::containsProperty($target, $property->name, $bindingFlags)) {
                    $targetValue = self::getPropertyValue($target, $property->name);

                    if ($sourceValue !== $targetValue) {
                        return false;
                    }
                }
            }

            return true;
        }

        /*
         * 是否数组
         * 
         * @param object $obj，对象
         * @return bool，结果
         * 
         */

        public static function isArray($obj) {
            return is_array($obj);
        }

        /*
         * 获得所有公开静态成员属性的值列表
         * 
         * @param string or object $type，类型或者对象
         * @return array，结果
         * 
         */

        public static function getAllPublicStaticPropertyValues($type) {
            return self::getProperties($type, ReflectionProperty::IS_STATIC);
        }

    }

}