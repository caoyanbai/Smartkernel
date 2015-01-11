<?php

namespace Smartkernel\Framework\Web {

    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 响应
     */

    class SmartResponse {
        /*
         * 输出文件功能
         * 
         * @param string $fileName，下载文件显示的文件名，注意，一般不要用中文
         * @param string $filePath，文件的虚拟路径
         * @param string $encoding，文件内容的编码
         * 
         */

        public static function outputVirtualFileToFile($fileName, $filePath, $encoding = null) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            header("Content-Disposition: attachment; filename=" . $fileName);
            header('Content-Type: application/octet-stream;charset=' . $encoding);
            readfile($filePath);
        }

        /*
         * 导出文件
         * 
         * @param string $html，要导出的html内容
         * @param string $fileName，文件名
         * @param string $contentType，内容类型
         * @param string $encoding，编码格式
         * 
         */

        public static function outputContentToFile($html, $fileName = "file.doc", $contentType = "application/ms-word", $encoding = "GB2312") {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            header("Content-Disposition: attachment; filename=" . $fileName);
            header('Content-Type: ' . $contentType . ';charset=' . $encoding);
            echo '<meta http-equiv=Content-Type content=text/html;charset=' . $encoding . '>';
            echo $html;
        }

    }

}