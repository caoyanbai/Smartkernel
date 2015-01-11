<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Web\Mvc {

    use Smartkernel\Framework\Web\SmartMimeType;

/*
     * 结果
     */

    class SmartContentResult {

        public $ContentType;
        public $Content;
        public $ContentEncoding;

        /*
         * 构造函数
         */

        function __construct() {
            $this->ContentType = SmartMimeType::Html;
            $this->ContentEncoding = "utf-8";
        }

        public function render() {
            header("Content-type: " . $this->ContentType . "; charset=" . $this->ContentEncoding);
            return $this->Content;
        }

    }

}