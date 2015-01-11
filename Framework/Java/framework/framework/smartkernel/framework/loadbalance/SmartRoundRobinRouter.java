/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.loadbalance;

import java.util.*;

import smartkernel.framework.SmartMath;

/**
 * 负载均衡轮询路由器，处理器组中的每个处理器都有相同的机会（可根据处理能力进行权重调节）被使用
 * 
 */
public class SmartRoundRobinRouter extends SmartRouter {
	/**
	 * 当前处理器的索引
	 */
	private int currentIndex;

	/**
	 * 构造函数
	 * 
	 * @param name
	 *            ，路由器名称
	 * @param processors
	 *            ，处理器数组
	 */
	public SmartRoundRobinRouter(String name,
			ArrayList<SmartProcessor> processors) {
		super(name, processors);
		updateTruePower();
	}

	/**
	 * 构造函数
	 * 
	 * @param name
	 *            ，路由器名称
	 */
	public SmartRoundRobinRouter(String name) {
		this(name, null);
	}

	/**
	 * 构造函数
	 */
	public SmartRoundRobinRouter() {
		this(null, null);
	}

	@Override
	public SmartProcessor generate(int parameter) {
		throw new RuntimeException("方法不支持！");
	}

	@Override
	public SmartProcessor generate() {
		synchronized (SyncRoot) {
			// 当前的处理器
			SmartRoundRobinProcessor currentProcessor = (SmartRoundRobinProcessor) processors
					.get(currentIndex % processors.size());
			// 增加当前处理器的处理量
			currentProcessor.setCurrentProcessQuantity(currentProcessor
					.getCurrentProcessQuantity() + 1);
			// 当当前处理器处理量等于权重数时，使用下一个处理器处理，且刷新当前处理器的处理量
			if (currentProcessor.getCurrentProcessQuantity() == currentProcessor
					.getTruePower()) {
				currentProcessor.setCurrentProcessQuantity(0);
				currentIndex++;
			}
			current = currentProcessor;
			return currentProcessor;
		}
	}

	/**
	 * 更新实际处理权重
	 */
	private void updateTruePower() {
		synchronized (SyncRoot) {
			// 没有处理器的时候不用更新
			if (processors.size() == 0) {
				return;
			}

			// 获得所有处理权重列表
			ArrayList<Integer> powerList = new ArrayList<Integer>();
			for (SmartProcessor item : processors) {
				SmartRoundRobinProcessor roundRobinProcessor = (SmartRoundRobinProcessor) item;
				powerList.add(roundRobinProcessor.getPower());
			}

			// 求得最大公约数
			int maxDivisor = SmartMath.getMaxDivisor(powerList);

			for (SmartProcessor item : processors) {
				SmartRoundRobinProcessor roundRobinProcessor = (SmartRoundRobinProcessor) item;
				roundRobinProcessor.setTruePower(roundRobinProcessor.getPower()
						/ maxDivisor);
			}
		}
	}

	@Override
	public void add(SmartProcessor processor) {
		super.add(processor);
		updateTruePower();
	}

	@Override
	public void addRange(ArrayList<SmartProcessor> processors) {
		super.addRange(processors);
		updateTruePower();
	}

	@Override
	public void remove(String name) {
		super.remove(name);
		updateTruePower();
	}

}
