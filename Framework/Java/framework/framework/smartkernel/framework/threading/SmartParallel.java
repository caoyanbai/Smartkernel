/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.threading;

import java.util.*;
import java.util.concurrent.*;

import smartkernel.framework.*;

/**
 * 并行处理
 *
 */
public class SmartParallel {
	/**
	 * 并行处理
	 * 
	 * @param items
	 *            ，元素
	 * @param maxDegreeOfParallelism
	 *            ，并行度
	 * @param func
	 *            ，行为
	 */
	public static <T> void forEach(Iterable<T> items,
			int maxDegreeOfParallelism, ISmartInvokeWithTFunc<T> func) {
		ExecutorService executorService = Executors
				.newFixedThreadPool(maxDegreeOfParallelism);
		List<Future<?>> futures = new LinkedList<Future<?>>();

		for (final T item : items) {
			Future<?> future = executorService.submit(new Runnable() {

				@Override
				public void run() {
					func.invoke(item);
				}
			});

			futures.add(future);
		}

		for (Future<?> future : futures) {
			try {
				future.get();
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}

		executorService.shutdown();
	}

	/**
	 * 并行处理
	 * 
	 * @param start
	 *            ，开始
	 * @param stop
	 *            ，结束
	 * @param func
	 *            ，行为
	 */
	public static void forLoop(int start, int stop,
			ISmartInvokeWithTFunc<Integer> func) {
		ExecutorService executorService = Executors.newFixedThreadPool(stop);
		List<Future<?>> futures = new LinkedList<Future<?>>();

		for (int i = start; i < stop; i++) {

			final int temp = i;
			Future<?> future = executorService.submit(new Runnable() {

				@Override
				public void run() {
					func.invoke(temp);
				}
			});

			futures.add(future);
		}

		for (Future<?> future : futures) {
			try {
				future.get();
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}

		executorService.shutdown();
	}
}
