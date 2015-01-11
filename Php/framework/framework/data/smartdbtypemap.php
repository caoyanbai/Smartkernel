<?php

namespace Smartkernel\Framework\Data {
    /*
     * Db类型映射
     */

    class SmartDbTypeMap {
        /*
         * 映射
         * 
         * @param string $dbType，数据库类型
         * @return string，.NET类型
         * 
         */

        public static function map($dbType) {
            switch ($dbType) {
                case "bigint":
                    return "long";
                case "int":
                    return "int";
                case "tinyint":
                    return "byte";
                case "bit":
                    return "bool";
                case "smalldatetime":
                case "date":
                case "datetime":
                    return "DateTime";
                case "decimal":
                    return "decimal";
                case "float":
                    return "float";
                default:
                    return "string";
            }
        }

    }

}
