<?php

namespace Smartkernel\Framework\IO {

    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\IO\SmartFile;

/*
     * GZip
     */

    class SmartGZip {
        /*
         * 压缩文件：被压缩的文件必须存在
         * 
         * @param string $sourceFilePath，需要被压缩的文件
         * @param string $zipFilePath，压缩之后保存的文件路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function compress($sourceFilePath, $zipFilePath, $encoding = SmartEncoding::DefaultSafePathValue) {

            $sourceFilePath = SmartFile::getSafeFilePath($sourceFilePath);
            $zipFilePath = SmartFile::getSafeFilePath($zipFilePath);

            $input = fopen($sourceFilePath, "r");
            $output = gzopen($zipFilePath, "a");

            while (!feof($input)) {
                $content = fread($input, SmartFile::DefaultBufferSizeValue);
                gzwrite($output, $content);
            }

            fclose($input);
            gzclose($output);
        }

        /*
         * 解压缩文件：被解压缩的文件必须存在
         * 
         * @param string $zipFilePath，需要被解压的文件
         * @param string $targetFilePath，解压之后保存的文件路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function decompress($zipFilePath, $targetFilePath, $encoding = SmartEncoding::DefaultSafePathValue) {

            $zipFilePath = SmartFile::getSafeFilePath($zipFilePath);
            $targetFilePath = SmartFile::getSafeFilePath($targetFilePath);

            $input = gzopen($zipFilePath, "r");
            $output = fopen($targetFilePath, "a");

            while (!gzeof($input)) {
                $content = gzread($input, SmartFile::DefaultBufferSizeValue);
                fwrite($output, $content);
            }

            gzclose($input);
            fclose($output);
        }

        /*
         * 压缩
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function compressString($input) {
            return gzcompress($input);
        }

        /*
         * 解压
         * 
         * @param string $input，输入
         * @return string，结果
         * 
         */

        public static function decompressString($input) {
            return gzuncompress($input);
        }

    }

}