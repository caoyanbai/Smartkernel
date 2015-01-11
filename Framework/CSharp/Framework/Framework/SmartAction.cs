/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Threading;
using System.Windows.Threading;

namespace Smartkernel.Framework
{
    /// <summary>
    /// Action
    /// </summary>
    public static class SmartAction
    {
        /// <summary>
        /// 重试调用
        /// </summary>
        /// <param name="action">行为</param>
        /// <param name="maxTryCount">最大尝试次数</param>
        /// <param name="interval">间隔（毫秒）</param>
        public static void RetryInvoke(Action action, int maxTryCount = 10, int interval = 60 * 1000)
        {
            bool isSuccess = false;
            var retryCount = 0;
            var outException = default(Exception);

            while (retryCount < maxTryCount)
            {
                try
                {
                    action();
                    isSuccess = true;
                    break;
                }
                catch (Exception exception)
                {
                    outException = exception;
                    retryCount++;
                    Thread.Sleep(interval);
                }
            }

            if (!isSuccess)
            {
                if (outException != null)
                {
                    throw outException;
                }
                else
                {
                    throw new Exception("重试执行失败！");
                }
            }
        }

        /// <summary>
        /// 尝试执行，有异常不抛出
        /// </summary>
        /// <param name="action">行为</param>
        public static void TryInvoke(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch { }
        }

        /// <summary>
        /// 判断委托调用是不是会抛出异常
        /// </summary>
        /// <param name="action">待调用的行为</param>
        /// <returns>调用的结果</returns>
        public static bool IsInvokeFail(Action action)
        {
            var isInvokeFail = false;
            try
            {
                action.Invoke();
            }
            catch
            {
                isInvokeFail = true;
            }
            return isInvokeFail;
        }

        /// <summary>
        /// 延迟调用
        /// </summary>
        /// <param name="action">行为</param>
        /// <param name="delayTime">延迟时间</param>
        public static void DelayInvoke(Action action, TimeSpan delayTime)
        {
            var timer = new DispatcherTimer { Interval = delayTime };
            timer.Tick += (sender, e) =>
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        /// <summary>
        /// 异步方法调用
        /// </summary>
        /// <param name="action">需要被异步执行的方法，方法必须无返回值无参数</param>
        /// <param name="asyncType">异步的方式</param>
        public static void AsyncInvoke(Action action, SmartAsyncType asyncType = SmartAsyncType.ThreadPool)
        {
            switch (asyncType)
            {
                case SmartAsyncType.Delegate:
                    {
                        action.BeginInvoke(null, null);
                    }
                    break;
                case SmartAsyncType.NewThread:
                    {
                        new Thread(new ThreadStart(action)).Start();
                    }
                    break;
                case SmartAsyncType.ThreadPool:
                    {
                        //对传入的方法进行包装，使其符合线程池的参数要求
                        WaitCallback waitCallback = delegate { action.Invoke(); };

                        ThreadPool.QueueUserWorkItem(waitCallback);
                    }
                    break;
            }
        }
    }
}
