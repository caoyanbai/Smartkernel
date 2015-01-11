<?php

namespace Smartkernel\Framework\Computer {
    /*
     * 本地计算机功能相关
     */

    class SmartComputer {
        /*
         * 获取当前进程是不是64位进程
         */

        public static function is64BitProcess() {
            return PHP_INT_SIZE === 8;
        }

        /*
         * 获取本地计算机名称
         */

        public static function machineName() {
            return gethostname();
        }

        /*
         * 目录分隔符号
         */

        const DirectorySeparator = DIRECTORY_SEPARATOR;

        /*
         * 换行符号
         */
        const LineSeparator = PHP_EOL;

        /*
         * 获得操作系统类型
         * 
         * @return SmartOSType，结果
         */

        public static function getOSType() {
            $osType = null;
            $OS = strtolower(php_uname());
            if (strpos($OS, "win") >= 0) {
                $osType = SmartOSType::Windows;
            } else if ((strpos($OS, "mac") >= 0) || (strpos($OS, "darwin") >= 0)) {
                $osType = SmartOSType . MacOS;
            } else if (strpos($OS, "nux") >= 0) {
                $osType = SmartOSType::Linux;
            } else {
                $osType = SmartOSType::Other;
            }
            return $osType;
        }

    }

}