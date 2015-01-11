<?php

namespace Smartkernel\Framework\Web\Mvc {

    use Smartkernel\Framework\Web\SmartMimeType;
    use Smartkernel\Framework\Web\Mvc\SmartContentResult;

/*
     * Xml结果
     */

    class SmartXmlResult extends SmartContentResult {
        /*
         * 构造函数
         */

        function __construct() {
            parent::__construct();
            $this->ContentType = SmartMimeType::Xml;
        }

    }

}