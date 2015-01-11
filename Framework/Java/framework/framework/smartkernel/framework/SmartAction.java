/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.util.concurrent.Executors;

import smartkernel.framework.threading.*;

/**
 * Action
 * 
 */
public class SmartAction {
	/**
	 * 重试调用
	 * 
	 * @param action
	 *            ，行为
	 * @param maxTryCount
	 *            ，最大尝试次数
	 * @param interval
	 *            ，间隔（毫秒）
	 */
	public static void retryInvoke(ISmartInvokeFunc action, int maxTryCount,
			int interval) {
		boolean isSuccess = false;
		int retryCount = 0;
		RuntimeException outException = null;

		while (retryCount < maxTryCount) {
			try {
				if (action != null) {
					action.invoke();
				}
				isSuccess = true;
				break;
			} catch (Exception exception) {
				outException = new RuntimeException(exception);
				retryCount++;
				SmartThread.sleep(interval);
			}
		}

		if (!isSuccess) {
			if (outException != null) {
				throw outException;
			} else {
				throw new RuntimeException("重试执行失败！");
			}
		}
	}

	/**
	 * 重试调用
	 * 
	 * @param action
	 *            ，行为
	 * @param maxTryCount
	 *            ，最大尝试次数
	 */
	public static void retryInvoke(ISmartInvokeFunc action, int maxTryCount) {
		retryInvoke(action, maxTryCount, 60 * 1000);
	}

	/**
	 * 重试调用
	 * 
	 * @param action
	 *            ，行为
	 */
	public static void retryInvoke(ISmartInvokeFunc action) {
		retryInvoke(action, 10, 60 * 1000);
	}

	/**
	 * 尝试执行，有异常不抛出
	 * 
	 * @param action
	 *            ，行为
	 */
	public static void tryInvoke(ISmartInvokeFunc action) {
		try {
			action.invoke();
		} catch (Exception err) {
		}
	}

	/**
	 * 判断委托调用是不是会抛出异常
	 * 
	 * @param action
	 *            ，待调用的行为
	 * @return，调用的结果
	 */
	public static boolean isInvokeFail(ISmartInvokeFunc action) {
		boolean isInvokeFail = false;
		try {
			action.invoke();
		} catch (Exception err) {
			isInvokeFail = true;
		}
		return isInvokeFail;
	}

	/**
	 * 延迟调用
	 * 
	 * @param action
	 *            ，行为
	 * @param delayTime
	 *            ，延迟时间
	 */
	public static void delayInvoke(final ISmartInvokeFunc action,
			final long delayTime) {
		new Thread() {
			@Override
			public void run() {
				SmartThread.sleep(delayTime);
				action.invoke();
			}
		}.start();
	}

	/**
	 * 异步方法调用
	 * 
	 * @param action
	 *            ，需要被异步执行的方法，方法必须无返回值无参数
	 * @param asyncType
	 *            ，异步的方式
	 */
	public static void asyncInvoke(final ISmartInvokeFunc action,
			SmartAsyncType asyncType) {
		switch (asyncType) {
		case NewThread: {
			new Thread() {
				@Override
				public void run() {
					action.invoke();
				}
			}.start();
		}
			break;
		case ThreadPool: {
			Executors.newCachedThreadPool().execute(new Runnable() {

				@Override
				public void run() {
					action.invoke();
				}
			});
		}
			break;
		}
	}
}
