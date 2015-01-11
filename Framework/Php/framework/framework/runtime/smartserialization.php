<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Runtime {

    use Smartkernel\Framework\IO\SmartPath;
    use Smartkernel\Framework\IO\SmartDirectory;
    use Smartkernel\Framework\IO\SmartFile;
    use Smartkernel\Framework\Text\SmartEncoding;

/*
     * 序列化
     */

    class SmartSerialization {
        /*
         * 序列化过程
         * 
         * @param object $obj，准备序列化的对象
         * @param string $filePath，文件路径，文件不存在时会自动创建
         * @param $encoding，编码方式
         * @param $filePathEncoding，文件路径编码
         * 
         */

        public static function serialize($obj, $filePath, $encoding = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {
            $directoryName = SmartPath::getDirectoryName($filePath);
            if (!SmartDirectory::exists($directoryName)) {
                SmartDirectory::createDirectory($directoryName);
            }
            SmartFile::write($filePath, serialize($obj), false, $encoding, $filePathEncoding);
        }

        /*
         * 反序列化过程
         * 
         * @param string $filePath，读取序列化数据的文件
         * @param $encoding，编码方式
         * @param $filePathEncoding，文件路径编码
         * @return object，返回反序列化的对象
         * 
         */

        public static function deserialize($filePath, $encoding = null, $filePathEncoding = SmartEncoding::DefaultSafePathValue) {

            return unserialize(SmartFile::readAllText($filePath, $encoding, $filePathEncoding));
        }

        /*
         * 克隆对象
         * 
         * @param object $obj，对象
         * @return object，克隆之后的对象
         * 
         */

        public static function cloneObject($obj) {
            return unserialize(serialize($obj));
        }

    }

}