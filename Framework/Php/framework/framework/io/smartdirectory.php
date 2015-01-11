<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\IO {

    use \DateTime;
    use Smartkernel\Framework\IO\SmartFile;
    use Smartkernel\Framework\IO\SmartSearchOptionType;
    use Smartkernel\Framework\IO\SmartPath;
    use Smartkernel\Framework\Text\SmartEncoding;
    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * 文件夹操作类（只能访问Web服务器有权访问的目录）
     */

    class SmartDirectory {
        /*
         * 计算指定文件夹的总大小，包含所有子目录中的文件
         * 
         * @param string $directoryPath，文件夹的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return long ，总大小
         * 
         */

        public static function getTotalSize($directoryPath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $files = self::getFiles($directoryPath, $encoding);

            $size = 0.0;

            foreach ($files as $file) {
                $size += filesize(SmartFile::getSafeFilePath($file, $encoding));
            }

            $subDirectories = self::getDirectories($directoryPath, $encoding);

            foreach ($subDirectories as $subDirectorie) {
                $size += self::getTotalSize($subDirectorie, $encoding);
            }

            return $size;
        }

        /*
         * 获得格式化的目录路径（格式化为符合操作系统的分隔符号和包含结尾分隔符号）
         * 
         * @param string $directoryPath，目录的路径
         * @return string，结果
         * 
         */

        public static function getFormatDirectoryPath($directoryPath) {
            $directoryPath = str_replace("\\", SmartComputer::DirectorySeparator, $directoryPath);
            $directoryPath = str_replace("/", SmartComputer::DirectorySeparator, $directoryPath);
            $directoryPath = str_replace(SmartComputer::DirectorySeparator . SmartComputer::DirectorySeparator, SmartComputer::DirectorySeparator, $directoryPath);
            $directoryPath = rtrim($directoryPath, SmartComputer::DirectorySeparator);
            return $directoryPath . SmartComputer::DirectorySeparator;
        }

        /*
         * 获得安全的目录路径（格式化为符合操作系统的分隔符号、文件路径编码和包含结尾分隔符号）
         * 
         * @param string $directoryPath，目录的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return string，结果
         * 
         */

        public static function getSafeDirectoryPath($directoryPath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $directoryPath = iconv(SmartEncoding::DefaultValue, $encoding, $directoryPath);

            return self::getFormatDirectoryPath($directoryPath);
        }

        /*
         * 获得显示的目录路径（格式化为符合操作系统的分隔符号、显示编码和包含结尾分隔符号）
         * 
         * @param string $directoryPath，目录的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return string，结果
         * 
         */

        public static function getDisplayDirectoryPath($directoryPath, $encoding = SmartEncoding::DefaultSafePathValue) {
            $directoryPath = iconv($encoding, SmartEncoding::DefaultValue, $directoryPath);

            return self::getFormatDirectoryPath($directoryPath);
        }

        /*
         * 获得目录下的文件列表
         * 
         * @param string $directoryPath，目录的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @param SmartSearchOptionType $searchOptionType，搜索选项类型
         * @return array，结果
         * 
         */

        public static function getFiles($directoryPath, $encoding = SmartEncoding::DefaultSafePathValue, $searchOptionType = SmartSearchOptionType::TopDirectoryOnly) {
            if ($searchOptionType === SmartSearchOptionType::TopDirectoryOnly) {
                $directoryPath = self::getSafeDirectoryPath($directoryPath, $encoding);
                $result = array();
                $directory = opendir($directoryPath);
                $directoryPathTemp = iconv($encoding, SmartEncoding::DefaultValue, $directoryPath);
                while (($item = readdir($directory)) !== false) {
                    if ($item != "." && $item != "..") {
                        if (is_file($directoryPath . $item)) {
                            //PHP的文件路径函数要考虑编码情况
                            $itemTemp = iconv($encoding, SmartEncoding::DefaultValue, $item);
                            $result[] = $directoryPathTemp . $itemTemp;
                        }
                    }
                }
                closedir($directory);
                return $result;
            } else {

                $result = self::getFiles($directoryPath, $encoding, SmartSearchOptionType::TopDirectoryOnly);

                $subDirectories = self::getDirectories($directoryPath, $encoding);

                foreach ($subDirectories as $subDirectorie) {
                    $resultTemp = self::getFiles($subDirectorie, $encoding, SmartSearchOptionType::AllDirectories);
                    foreach ($resultTemp as $itemTemp) {
                        $result[] = $itemTemp;
                    }
                }

                return $result;
            }
        }

        /*
         * 获得目录下的子目录列表
         * 
         * @param string $directoryPath，目录的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @param SmartSearchOptionType $searchOptionType，搜索选项类型
         * @return array，结果
         * 
         */

        public static function getDirectories($directoryPath, $encoding = SmartEncoding::DefaultSafePathValue, $searchOptionType = SmartSearchOptionType::TopDirectoryOnly) {
            if ($searchOptionType === SmartSearchOptionType::TopDirectoryOnly) {
                $directoryPath = self::getSafeDirectoryPath($directoryPath, $encoding);
                $result = array();
                $directory = opendir($directoryPath);
                $directoryPathTemp = iconv($encoding, SmartEncoding::DefaultValue, $directoryPath);
                while (($item = readdir($directory)) !== false) {
                    if ($item != "." && $item != "..") {
                        if (is_dir($directoryPath . $item)) {
                            //PHP的文件路径函数要考虑编码情况
                            $itemTemp = iconv($encoding, SmartEncoding::DefaultValue, $item);
                            $result[] = $directoryPathTemp . $itemTemp;
                        }
                    }
                }
                closedir($directory);
                return $result;
            } else {
                $result = self::getDirectories($directoryPath, $encoding, SmartSearchOptionType::TopDirectoryOnly);

                $subDirectories = self::getDirectories($directoryPath, $encoding);

                foreach ($subDirectories as $subDirectorie) {
                    $resultTemp = self::getDirectories($subDirectorie, $encoding, SmartSearchOptionType::AllDirectories);
                    foreach ($resultTemp as $itemTemp) {
                        $result[] = $itemTemp;
                    }
                }

                return $result;
            }
        }

        /*
         * 获得指定文件夹下的文件扩展名类型
         * 
         * @param string $directoryPath，目录的路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @param SmartSearchOptionType $searchOptionType，搜索选项类型
         * @return array，结果
         * 
         */

        public static function getExtensionTypes($directoryPath, $encoding = SmartEncoding::DefaultSafePathValue, $searchOptionType = SmartSearchOptionType::TopDirectoryOnly) {
            $files = self::getFiles($directoryPath, $encoding, $searchOptionType);

            $extensionTypes = array();

            foreach ($files as $file) {
                $extensionType = SmartPath::getPathInfo(SmartFile::getSafeFilePath($file, $encoding))["extension"];

                if (in_array($extensionType, $extensionTypes) === false) {
                    $extensionTypes[] = $extensionType;
                }
            }

            return $extensionTypes;
        }

        /*
         * 创建目录（可以创建多层）
         * 
         * @param string $path，路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function create($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            $path = self::getSafeDirectoryPath($path, $encoding);
            $parts = explode(SmartComputer::DirectorySeparator, $path);

            $temp = "";
            foreach ($parts as $part) {
                if ($temp === "") {
                    $temp.=$part;
                } else {
                    $temp = $temp . SmartComputer::DirectorySeparator . $part;
                }
                if (is_dir($temp) === false) {
                    mkdir($temp, 0777);
                }
            }
        }

        /*
         * 删除目录（可以删除多层）
         * 
         * @param string $path，路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function delete($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            clearstatcache();
            $pathSafe = self::getSafeDirectoryPath($path, $encoding);
            if (is_dir($pathSafe)) {
                $files = self::getFiles($path, $encoding, SmartSearchOptionType::TopDirectoryOnly);

                foreach ($files as $file) {
                    $file = SmartFile::getSafeFilePath($file, $encoding);
                    unlink($file);
                }

                $directorys = self::getDirectories($path, $encoding, SmartSearchOptionType::TopDirectoryOnly);
                if (count($directorys) > 0) {
                    foreach ($directorys as $directory) {
                        self::delete($directory, $encoding);
                    }
                }
                rmdir($pathSafe);
            }
        }

        /*
         * 递归复制文件夹及所有文件
         * 
         * @param string $sourceDirectoryPath，源文件夹
         * @param string $targetDirectoryPath，目标文件夹
         * @param bool $overwrite，是否覆盖
         * @param SmartEncoding $encoding，系统的文件路径编码
         * 
         */

        public static function copy($sourceDirectoryPath, $targetDirectoryPath, $overwrite = true, $encoding = SmartEncoding::DefaultSafePathValue) {

            $sourceDirectoryPathSafe = self::getSafeDirectoryPath($sourceDirectoryPath, $encoding);
            $targetDirectoryPathSafe = self::getSafeDirectoryPath($targetDirectoryPath, $encoding);

            $sourceDirectoryPath = self::getDisplayDirectoryPath($sourceDirectoryPathSafe, $encoding);
            $targetDirectoryPath = self::getDisplayDirectoryPath($targetDirectoryPathSafe, $encoding);

            if (is_dir($targetDirectoryPathSafe) === false) {
                mkdir($targetDirectoryPathSafe, 0777);
            }

            if (is_dir($sourceDirectoryPathSafe) === false) {
                return;
            }

            $directories = self::getDirectories($sourceDirectoryPath, $encoding);

            if (count($directories) > 0) {
                foreach ($directories as $directory) {
                    self::copy($directory, $targetDirectoryPath . substr($directory, strrpos($directory, SmartComputer::DirectorySeparator) + 1), $overwrite, $encoding);
                }
            }

            $sourceFiles = self::getFiles($sourceDirectoryPath, $encoding);

            if (count($sourceFiles) > 0) {
                foreach ($sourceFiles as $sourceFile) {
                    $sourceFileSafe = SmartFile::getSafeFilePath($sourceFile);
                    $targetFileSafe = $targetDirectoryPathSafe . substr($sourceFileSafe, strrpos($sourceFileSafe, SmartComputer::DirectorySeparator) + 1);
                    $isExists = file_exists($targetFileSafe);


                    if ($overwrite === true && $isExists === true) {
                        unlink($targetFileSafe);
                    }
                    if (!($overwrite === false && $isExists === true)) { {
                            copy($sourceFileSafe, $targetFileSafe);
                        }
                    }
                }
            }
        }

        /*
         * 判断文件夹是否存在
         * 
         * @param string $path，路径
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return bool，结果
         * 
         */

        public static function exists($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            $path = self::getSafeDirectoryPath($path, $encoding);
            return is_dir($path);
        }

        /*
         * 获取创建时间
         * 
         * @param string $path，目录
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return DateTime，结果
         * 
         */

        public static function getCreationTime($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            if (self::exists($path, $encoding)) {
                $path = self::getSafeDirectoryPath($path, $encoding);
                return new DateTime(date("Y-m-d H:i:s", filemtime($path)));
            }

            return null;
        }

        /*
         * 获得父路径
         * 
         * @param string $path，目录
         * @param SmartEncoding $encoding，系统的文件路径编码
         * @return string，结果
         * 
         */

        public static function getParent($path, $encoding = SmartEncoding::DefaultSafePathValue) {
            $path = self::getFormatDirectoryPath($path);

            $parts = explode(SmartComputer::DirectorySeparator, $path);

            $count = count($parts);

            $result = "";

            for ($i = 0; $i < $count - 2; $i++) {
                if ($i === 0) {
                    $result = $parts[$i];
                } else {
                    $result = $result . SmartComputer::DirectorySeparator . $parts[$i];
                }
            }

            return self::getFormatDirectoryPath($result);
        }

    }

}
