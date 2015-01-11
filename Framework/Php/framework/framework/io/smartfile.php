<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\IO {

    use \DateTime;
    use \Exception;
    use Smartkernel\Framework\SmartString;
    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\IO\SmartFileType;
    use Smartkernel\Framework\IO\SmartDirectory;
    use Smartkernel\Framework\IO\SmartSearchOptionType;
    use Smartkernel\Framework\IO\SmartPath;
    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * 文件
     */

    class SmartFile {

        //默认缓冲区大小
        const DefaultBufferSizeValue = 4096;

        /*
         * 获得安全的文件路径（格式化为符合操作系统的分隔符号、文件路径编码）
         * 
         * @param string $filePath，文件的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return string，结果
         * 
         */

        public static function getSafeFilePath($filePath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $filePath = iconv(SmartEncoding::DefaultValue, $encoding, $filePath);

            return self::getFormatFilePath($filePath);
        }

        /*
         * 获得格式化的文件路径（格式化为符合操作系统的分隔符号）
         * 
         * @param string $filePath，文件的路径
         * @return string，结果
         * 
         */

        public static function getFormatFilePath($filePath) {
            $filePath = str_replace("\\", SmartComputer::DirectorySeparator, $filePath);
            $filePath = str_replace("/", SmartComputer::DirectorySeparator, $filePath);
            $filePath = str_replace(SmartComputer::DirectorySeparator . SmartComputer::DirectorySeparator, SmartComputer::DirectorySeparator, $filePath);
            return $filePath;
        }

        /*
         * 获得显示的文件路径（格式化为符合操作系统的分隔符号、显示编码）
         * 
         * @param string $filePath，文件的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return string，结果
         * 
         */

        public static function getDisplayFilePath($filePath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $filePath = iconv($encoding, SmartEncoding::DefaultValue, $filePath);

            return self::getFormatFilePath($filePath);
        }

        /*
         * 通过文件的字节数获得文件的易理解大小，如1.5GB
         * 
         * @param long $fileSize，字节大小
         * @param bool $rounded，是否取整
         * return string，文件大小的易理解形式
         * 
         */

        public static function formatSize($fileSize, $rounded = false) {
            $kb = 1024.0;
            $mb = 1048576.0;
            $gb = 1000000000.0;
            $tb = 1000000000000.0;
            $dValue = 0.0;
            $result = "";

            $format = $rounded ? "%d" : "%.2f";

            if ($fileSize >= $kb && $fileSize <= $mb) {
                $dValue = ($fileSize / $kb);
                $result = sprintf($format . " KBs", $dValue);
            } else if ($fileSize >= $mb && $fileSize <= $gb) {
                $dValue = ($fileSize / $mb);
                $result = sprintf($format . " MBs", $dValue);
            } else if ($fileSize >= $gb && $fileSize <= $tb) {
                $dValue = ($fileSize / $gb);
                $result = sprintf($format . " GBs", $dValue);
            } else if ($fileSize >= $tb) {
                $dValue = ($fileSize / $tb);
                $result = sprintf($format . " TBs", $dValue);
            } else {
                $result = sprintf("%s bytes", $fileSize);
            }
            return $result;
        }

        /*
         * 写入日志
         * 
         * @param string $filePath，文件路径，文件不存在时会自动创建，存在时则追加信息
         * @param string $message，写入内容
         * @param $isNewline，是否自动换行
         * @param $encoding，编码方式
         * @param $filePathEncoding，文件路径编码
         * 
         */

        public static function write($filePath, $message, $isNewline = true, $encoding = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $filePath = self::getSafeFilePath($filePath, $filePathEncoding);
            try {
                @mkdir(dirname($filePath), 0777, true);
            } catch (Exception $err) {
                
            }

            $mode = 'a';

            if ($fp = fopen($filePath, $mode)) {
                $startTime = microtime();
                do {
                    $canWrite = flock($fp, LOCK_EX);
                    if (!$canWrite) {
                        usleep(round(rand(0, 100) * 1000));
                    }
                } while ((!$canWrite) && ((microtime() - $startTime) < 1000));
                if ($canWrite) {
                    if ($isNewline === true) {
                        $message = iconv(SmartEncoding::DefaultValue, $encoding, $message . SmartComputer::LineSeparator);
                        fwrite($fp, $message);
                    } else {
                        $message = iconv(SmartEncoding::DefaultValue, $encoding, $message);
                        fwrite($fp, $message);
                    }
                }
                fclose($fp);
            }
        }

        /*
         * 获得读取流
         * 
         * @param $path，路径
         * @param $fileType，文件类型
         * @param $filePathEncoding，文件路径编码
         * 
         */

        public static function getStreamReader($path, SmartFileType $fileType = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            if ($fileType === null) {
                $fileType = SmartFileType::Text;
            }
            $path = self::getSafeFilePath($path, $filePathEncoding);
            if ($fileType === SmartFileType::GZip) {
                return gzopen($path, "r");
            } else {
                return fopen($path, "r");
            }
        }

        /*
         * 获得写入流
         * 
         * @param $path，路径
         * @param $fileType，文件类型
         * @param $filePathEncoding，文件路径编码
         * 
         */

        public static function getStreamWriter($path, SmartFileType $fileType = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            if ($fileType === null) {
                $fileType = SmartFileType::Text;
            }
            $path = self::getSafeFilePath($path, $filePathEncoding);
            if ($fileType === SmartFileType::GZip) {
                return gzopen($path, "a");
            } else {
                return fopen($path, "a");
            }
        }

        /*
         * 拆分文件
         * 
         * @param string $filePath，源文件路径
         * @param string $splitFilePath，目标文件路径
         * @param int $quantity，数量
         * @param string $postfix，拆分的文件后缀
         * @param $filePathEncoding，文件路径编码
         * 
         */

        public static function split($filePath, $splitFilePath, $quantity = 10, $postfix = ".split", $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            $filePath = self::getSafeFilePath($filePath, $filePathEncoding);
            $splitFilePath = SmartDirectory::getSafeDirectoryPath($splitFilePath, $filePathEncoding);

            $fileName = SmartPath::getPathInfo(self::getFormatFilePath($filePath))["basename"];

            $sourceFileStream = fopen($filePath, "r");

            $fileSize = intval(ceil(filesize($filePath) / $quantity));

            for ($i = 0; $i < $quantity; $i++) {
                $name = sprintf("%0" . strlen(strval($quantity)) . "d", $i);
                $targetFile = sprintf("%s%s_%s%s", $splitFilePath, $fileName, $name, $postfix);
                $targetFileStream = fopen($targetFile, "a");

                $buffer = fread($sourceFileStream, $fileSize);
                if ($buffer) {
                    fwrite($targetFileStream, $buffer);
                }

                fclose($targetFileStream);
            }

            fclose($sourceFileStream);
        }

        /*
         * 合并文件
         * 
         * @param string $filePath，拆分文件所在文件夹
         * @param string $uniteFilePath，合并文件路径
         * @param SmartEncoding $encoding，系统的文件路径编码 
         * 
         */

        public static function unite($filePath, $uniteFilePath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $uniteFilePath = self::getSafeFilePath($uniteFilePath, $encoding);
            $splitFilePaths = SmartDirectory::getFiles($filePath, $encoding);
            $targetFileStream = fopen($uniteFilePath, "a");

            sort($splitFilePaths);

            foreach ($splitFilePaths as $splitFilePath) {
                $splitFilePath = self::getSafeFilePath($splitFilePath, $encoding);
                $sourceFileStream = fopen($splitFilePath, "r");
                while (!feof($sourceFileStream)) {
                    $buffer = fread($sourceFileStream, self::DefaultBufferSizeValue);
                    fwrite($targetFileStream, $buffer);
                }
                fclose($sourceFileStream);
            }

            fclose($targetFileStream);
        }

        /*
         * 在一个文件夹内递归查找文件，判断文件是否存在
         * 
         * @param string $fileName，待查找的文件名，必须有扩展名
         * @param string $filePath，查找范围的文件夹
         * @param array &$filePathList，找到的文件的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @param SmartSearchOptionType searchOptionType，搜索的范围，是不是包含子目录
         * @return bool，是否存在
         * 
         */

        public static function existsMore($fileName, $filePath, array &$filePathList, $encoding = SmartEncoding::DefaultSafePathValue, $searchOptionType = SmartSearchOptionType::AllDirectories) {
            $files = SmartDirectory::getFiles($filePath, $encoding, $searchOptionType);

            foreach ($files as $file) {
                if (SmartString::endsWith($file, $fileName) === true) {
                    $filePathList[] = $file;
                }
            }
            if (count($filePathList) > 0) {
                return true;
            } else {
                return false;
            }
        }

        /*
         * 修改文件名称
         * 
         * @param string $filePath，文件路径
         * @param string $newName，新的文件名
         * @param bool $overWriteFile，是否覆盖文件
         * @param SmartEncoding $encoding，系统的文件路径编码
         */

        public static function changeName($filePath, $newName, $overWriteFile = true, $encoding = SmartEncoding::DefaultSafePathValue) {
            $filePath = self::getFormatFilePath($filePath);
            $pathInfo = SmartPath::getPathInfo($filePath);
            $newPath = $pathInfo["dirname"] . $newName;

            $filePath = self::getSafeFilePath($filePath, $encoding);
            $newPath = self::getSafeFilePath($newPath, $encoding);

            $isExists = file_exists($newPath);

            if ($overWriteFile === true && $isExists === true) {
                unlink($newPath);
            }
            rename($filePath, $newPath);
        }

        /*
         * 将对象转成二进制文件存储到对应的目录
         * 
         * @param object $obj，对象
         * @param string $path，文件地址
         * @param SmartFileType $fileType，文件类型
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function binaryWrite($obj, $path, $fileType = SmartFileType::Text, $encoding = SmartEncoding::DefaultSafePathValue) {
            $content = serialize($obj);

            $path = self::getSafeFilePath($path, $encoding);

            if ($fileType === SmartFileType::Text) {
                $handle = fopen($path, "a");

                fwrite($handle, $content);

                fclose($handle);
            } else {
                $handle = gzopen($path, "a");

                gzwrite($handle, $content);

                gzclose($handle);
            }
        }

        /*
         * 将二进制文件转成对象并返回
         * 
         * @param string $path，文件地址
         * @param SmartFileType $fileType，文件类型
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function binaryRead($path, $fileType = SmartFileType::Text, $encoding = SmartEncoding::DefaultSafePathValue) {
            $content = "";

            $path = self::getSafeFilePath($path, $encoding);

            if ($fileType === SmartFileType::Text) {
                $handle = fopen($path, "r");

                while (!feof($handle)) {
                    $content .= fread($handle, self::DefaultBufferSizeValue);
                }

                fclose($handle);
            } else {
                $handle = gzopen($path, "r");

                while (!gzeof($handle)) {
                    $content .= gzread($handle, self::DefaultBufferSizeValue);
                }

                gzclose($handle);
            }
            return unserialize($content);
        }

        /*
         * 删除文件
         * 
         * @param string $filePath，文件的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function delete($filePath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $filePath = self::getSafeFilePath($filePath, $encoding);

            @unlink($filePath);
        }

        /*
         * 判断文件是否存在
         * 
         * @param string $path，路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return bool，结果
         * 
         */

        public static function exists($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            $path = self::getSafeFilePath($path, $encoding);
            return file_exists($path);
        }

        /*
         * 获取创建时间
         * 
         * @param string $path，文件
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return DateTime，结果
         * 
         */

        public static function getCreationTime($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            if (self::exists($path, $encoding)) {
                $path = self::getSafeFilePath($path, $encoding);
                return new DateTime(date("Y-m-d H:i:s", filemtime($path)));
            }

            return null;
        }

        /*
         * 获取文件大小（字节大小，除以1024为KB）
         * 
         * @param string $path，文件
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return float，结果
         * 
         */

        public static function getFileSize($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            $path = self::getSafeFilePath($path, $encoding);
            return filesize($path);
        }

        /*
         * 获取文件内容
         * 
         * @param string $path，文件
         * @param $encoding，编码方式
         * @param $filePathEncoding，文件路径编码
         * @return string，结果
         * 
         */

        public static function readAllText($path, $encoding = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            $encoding = $encoding == null ? SmartEncoding::DefaultValue : $encoding;
            $path = self::getSafeFilePath($path, $filePathEncoding);
            return iconv($encoding, SmartEncoding::DefaultValue, file_get_contents($path));
        }

    }

}