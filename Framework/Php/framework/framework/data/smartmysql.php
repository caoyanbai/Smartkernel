<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Data {

    use Smartkernel\Framework\SmartString;
    use \PDO;

/*
     * MySql（数据库链接字符串示例：mysql:host=127.0.0.1;port=3306;dbname=test;charset=utf8;|root|123456）
     */

    class SmartMySql {
        /*
         * 执行INSERT、UPDATE、DELETE以及不返回数据集的存储过程
         * 
         * @param string $connectionString，数据库连接字符串
         * @param string $sentence，Sql命令或存储过程名
         * @param array 参数数组
         * 
         */

        public static function executeNonQuery($connectionString, $sentence, array $parameters = null) {

            $parts = SmartString::split($connectionString, "|");
            $pdo = new PDO($parts[0], $parts[1], $parts[2], array(PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION, PDO::ATTR_TIMEOUT => "3600"));

            $sth = $pdo->prepare($sentence);
            if ($parameters == null) {
                $sth->execute();
            } else {
                foreach ($parameters as $key => $value) {
                    if (is_null($value)) {
                        $sth->bindValue($key, $value, PDO::PARAM_NULL);
                    } else if (is_integer($value)) {
                        $sth->bindValue($key, $value, PDO::PARAM_INT);
                    } else {
                        $sth->bindValue($key, $value, PDO::PARAM_STR);
                    }
                }
                $sth->execute();
            }
            $pdo = null;

            return $sth->rowCount();
        }

        /*
         * 填充数据集
         * 
         * @param string $connectionString，数据库连接字符串
         * @param string $sentence，Sql命令或存储过程名
         * @param array $parameters，参数数组
         * @return object，数据集的第一行第一列
         * 
         */

        public static function fill($connectionString, $sentence, array $parameters = null) {
            $parts = SmartString::split($connectionString, "|");
            $pdo = new PDO($parts[0], $parts[1], $parts[2], array(PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION, PDO::ATTR_TIMEOUT => "3600"));

            $sth = $pdo->prepare($sentence);
            if ($parameters == null) {
                $sth->execute();
            } else {
                foreach ($parameters as $key => $value) {
                    if (is_null($value)) {
                        $sth->bindValue($key, $value, PDO::PARAM_NULL);
                    } else if (is_integer($value)) {
                        $sth->bindValue($key, $value, PDO::PARAM_INT);
                    } else {
                        $sth->bindValue($key, $value, PDO::PARAM_STR);
                    }
                }
                $sth->execute();
            }

            $rows = $sth->fetchAll(PDO::FETCH_ASSOC);

            $pdo = null;

            return $rows;
        }

        /*
         * 返回数据集的第一行第一列。数据库中为Null或空，都返回Null
         * 
         * @param string $connectionString，数据库连接字符串
         * @param string $sentence，Sql命令或存储过程名
         * @param array $parameters，参数数组
         * @return object，数据集的第一行第一列
         * 
         */

        public static function executeScalar($connectionString, $sentence, array $parameters = null) {
            $parts = SmartString::split($connectionString, "|");
            $pdo = new PDO($parts[0], $parts[1], $parts[2], array(PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION, PDO::ATTR_TIMEOUT => "3600"));

            $sth = $pdo->prepare($sentence);
            if ($parameters == null) {
                $sth->execute();
            } else {
                foreach ($parameters as $key => $value) {
                    if (is_null($value)) {
                        $sth->bindValue($key, $value, PDO::PARAM_NULL);
                    } else if (is_integer($value)) {
                        $sth->bindValue($key, $value, PDO::PARAM_INT);
                    } else {
                        $sth->bindValue($key, $value, PDO::PARAM_STR);
                    }
                }
                $sth->execute();
            }

            $rows = $sth->fetchAll(PDO::FETCH_NUM);

            $pdo = null;

            return $rows[0][0];
        }

    }

}
