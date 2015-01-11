<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework\Diagnostics {
    /*
     * 计时器
     */

    class SmartStopwatch {

        private $startTime = 0;
        private $stopTime = 0;

        /*
         * 开始
         * 
         */

        public function start() {
            list($usec, $sec) = explode(" ", microtime());
            $this->startTime = (float) $usec + (float) $sec;
            $this->stopTime = (float) $usec + (float) $sec;
        }

        /*
         * 结束
         */

        public function stop() {
            list($usec, $sec) = explode(" ", microtime());
            $this->stopTime = (float) $usec + (float) $sec;
        }

        /*
         * 重启
         */

        public function restart() {
            $this->start();
        }

        /*
         * 持续时间
         * 
         * @return float，结果
         * 
         */

        public function elapsed() {
            return ($this->stopTime - $this->startTime) * 1000;
        }

        /*
         * 运行
         * 
         * @param function $action，行为
         * @return float，结果
         * 
         */

        public static function execute($action) {
            $stopwatch = new SmartStopwatch();
            $stopwatch->start();

            $action();

            $stopwatch->stop();
            return $stopwatch->elapsed();
        }

    }

}