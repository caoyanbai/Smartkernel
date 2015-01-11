<?php

namespace Smartkernel\Framework\Office {

    use Smartkernel\Framework\Computer\SmartComputer;

/*
     * Csv
     */

    class SmartCsv {
        /*
         * 转换为Csv文件
         * 
         * @param array $rows，列表
         * @return string，结果
         * 
         */

        public static function toCsv(array $rows) {
            $result = "";

            $rowCount = count($rows);

            if ($rows == null || $rowCount == 0) {
                return "";
            }

            $columnCount = count($rows[0]);

            $i = 0;

            foreach ($rows[0] as $columnName => $columnValue) {
                if ($i == $columnCount - 1) {
                    $result .= "\"" . $columnName . "\"" . SmartComputer::LineSeparator;
                } else {
                    $result .= "\"" . $columnName . "\"" . ",";
                }
                $i++;
            }

            $j = 0;
            foreach ($rows as $row) {
                $i = 0;
                foreach ($row as $columnName => $columnValue) {
                    if ($i == $columnCount - 1) {
                        if ($j == $rowCount - 1) {
                            $result .= "\"" . str_replace("\"", "\"\"", $columnValue) . "\"";
                        } else {
                            $result .= "\"" . str_replace("\"", "\"\"", $columnValue) . "\"" . SmartComputer::LineSeparator;
                        }
                    } else {
                        $result .= "\"" . str_replace("\"", "\"\"", $columnValue) . "\"" . ",";
                    }
                    $i++;
                }
                $j++;
            }

            return $result;
        }

    }

}
