<?php

/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */

namespace Smartkernel\Framework {

    use \Exception;

/*
     * Action
     */

    class SmartAction {
        /*
         * 将函数合并在一起
         * 
         * @return function，结果
         * 
         */

        public static function combine() {
            $args = func_get_args();
            return function() use($args) {
                foreach ($args as $arg) {
                    $arg();
                }
            };
        }

        /*
         * 重试调用
         * 
         * @param function $action，行为
         * @param int $maxTryCount，最大尝试次数
         * @param int $interval，间隔（毫秒）
         * 
         */

        public static function retryInvoke($action, $maxTryCount = 10, $interval = 600000) {
            $isSuccess = false;
            $retryCount = 0;
            $outException = null;

            while ($retryCount < $maxTryCount) {
                try {
                    $action();
                    $isSuccess = true;
                    break;
                } catch (Exception $exception) {
                    $outException = $exception;
                    $retryCount++;
                    usleep($interval * 1000);
                }
            }

            if (!$isSuccess) {
                if ($outException != null) {
                    throw $outException;
                } else {
                    throw new Exception("重试执行失败！");
                }
            }
        }

        /*
         * 尝试执行，有异常不抛出
         * 
         * @param function $action，行为
         * 
         */

        public static function tryInvoke($action) {
            try {
                @action();
            } catch (Exception $err) {
                
            }
        }

        /*
         * 判断委托调用是不是会抛出异常
         * 
         * @param function $action，待调用的行为
         * @return bool，调用的结果
         */

        public static function isInvokeFail($action) {
            $isInvokeFail = false;
            try {
                $action();
            } catch (Exception $err) {
                $isInvokeFail = true;
            }
            return $isInvokeFail;
        }

        /*
         * 延迟调用
         * 
         * @param function $action，行为
         * @paran int $delayTime，延迟时间（毫秒）
         * 
         */

        public static function delayInvoke($action, $delayTime) {
            usleep($delayTime * 1000);
            $action();
        }

    }

}