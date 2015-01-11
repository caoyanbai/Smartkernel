<?php

namespace Smartkernel\Framework\Web\Mvc {

    use Smartkernel\Framework\Web\SmartMimeType;
    use Smartkernel\Framework\Web\Mvc\SmartContentResult;

/*
     * Text结果
     */

    class SmartTextResult extends SmartContentResult {
        /*
         * 构造函数
         */

        function __construct() {
            parent::__construct();
            $this->ContentType = SmartMimeType::Text;
        }

    }

}