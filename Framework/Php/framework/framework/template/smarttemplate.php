<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Template {

    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\IO\SmartFile;

/*
     * 模板生成器
     */

    class SmartTemplate {
        /*
         * 生成
         * 
         * @param string $templet，模板
         * @param array $data，参数
         * @return string，结果
         */

        public static function generate($templet, array $data = null) {
            if ($data != null) {
                foreach ($data as $key => $value) {
                    $templet = SmartString::repeatReplace($templet, SmartString::format("@({0})", $key), $value);
                }
            }
            return $templet;
        }

        /*
         * 生成
         * 
         * @param string $templet，模板
         * @param string $filePath，保存路径
         * @param array $data，参数
         * @param bool $isOverWrite，是否覆盖
         * @param string $encoding，文件编码
         * @param string $filePathEncoding，文件路径编码
         * @return string，结果
         */

        public static function generateFile($templet, $filePath, array $data = null, $isOverWrite = false, $encoding = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;

            $code = self::generate($templet, $data);
            if ($isOverWrite) {
                //覆盖
                SmartFile::delete($filePath, $filePathEncoding);
                SmartFile::write($filePath, $code, true, $encoding, $filePathEncoding);
            } else {
                //不覆盖
                if (!SmartFile::exists($filePath, $filePathEncoding)) {
                    SmartFile::write($filePath, $code, true, $encoding, $filePathEncoding);
                }
            }
        }

    }

}