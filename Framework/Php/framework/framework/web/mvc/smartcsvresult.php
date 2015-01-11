<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web\Mvc {

    use Smartkernel\Framework\Web\SmartMimeType;
    use Smartkernel\Framework\Web\Mvc\SmartContentResult;
    use Smartkernel\Framework\Office\SmartCsv;

/*
     * Csv结果
     */

    class SmartCsvResult extends SmartContentResult {
        /*
         * 构造函数
         */

        function __construct($rows, $fileName = "Export") {
            parent::__construct();
            $this->ContentType = SmartMimeType::Csv;
            header("Content-Disposition: attachment; filename=" . $fileName . ".csv");
            $this->Content = SmartCsv::toCsv($rows);
        }

    }

}