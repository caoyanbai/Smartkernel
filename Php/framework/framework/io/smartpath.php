<?php

namespace Smartkernel\Framework\IO {

    use Smartkernel\Framework\IO\SmartFile;
    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * 路径操作
     */

    class SmartPath {
        /*
         * 获得文件路径信息（pathinfo函数不能正确处理多字节编码类型的路径名）
         * 
         * @param string $filePath，文件路径
         * @return array，结果
         * 
         */

        public static function getPathInfo($filePath) {

            $result = array();
            $result ["dirname"] = rtrim(substr($filePath, 0, strrpos($filePath, SmartComputer::DirectorySeparator)), SmartComputer::DirectorySeparator) . SmartComputer::DirectorySeparator;
            $result ["basename"] = ltrim(substr($filePath, strrpos($filePath, SmartComputer::DirectorySeparator)), SmartComputer::DirectorySeparator);
            $result ["extension"] = substr(strrchr($filePath, "."), 1);
            $result ["filename"] = ltrim(substr($result ["basename"], 0, strrpos($result ["basename"], ".")), SmartComputer::DirectorySeparator);
            return $result;
        }

        //目录分隔符号
        const DirectorySeparatorChar = SmartComputer::DirectorySeparator;

        /*
         * 获得目录名称
         * 
         * @param string $filePath，路径
         * @return string，结果
         * 
         */

        public static function getDirectoryName($filePath) {
            return self::getPathInfo($filePath)["dirname"];
        }

        /*
         * 获得扩展名称
         * 
         * @param string $filePath，路径
         * @return string，结果
         * 
         */

        public static function getExtension($filePath) {
            return self::getPathInfo($filePath)["extension"];
        }

        /*
         * 获得文件名称（不包含扩展名）
         * 
         * @param string $filePath，路径
         * @return string，结果
         * 
         */

        public static function getFileNameWithoutExtension($filePath) {
            return self::getPathInfo($filePath)["filename"];
        }

        /*
         * 获得文件名称（包含扩展名）
         * 
         * @param string $filePath，路径
         * @return string，结果
         * 
         */

        public static function getFileName($filePath) {
            $pathInfo = self::getPathInfo($filePath);
            return $pathInfo["filename"] . "." . $pathInfo["extension"];
        }

        /*
         * 获得文件根目录
         * 
         * @param string $filePath，路径
         * @return string，结果
         * 
         */

        public static function getPathRoot($filePath) {
            $filePath = SmartFile::getFormatFilePath($filePath);
            $parts = explode(self::DirectorySeparatorChar, $filePath);
            return $parts[0] . self::DirectorySeparatorChar;
        }

    }

}