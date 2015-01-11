/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.loadbalance;

/**
 * 轮询处理器
 * 
 */
public class SmartRoundRobinProcessor extends SmartProcessor {
	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，主机信息
	 * @param power
	 *            ，处理能力权重
	 * @param name
	 *            ，处理器的名称
	 */
	public SmartRoundRobinProcessor(Object host, int power, String name) {
		super(host, name);
		this.power = power;
	}

	/**
	 * 构造函数
	 * 
	 * @param host
	 *            ，主机信息
	 * @param power
	 *            ，处理能力权重
	 */
	public SmartRoundRobinProcessor(Object host, int power) {
		this(host, power, null);
	}

	/**
	 * 处理能力
	 */
	private int power;

	/**
	 * 获取处理器的处理能力，处理能力作为算法的调节权重。某个处理器的权重占同一组处理器权重之和的比例就是处理流量分配的比例。处理能力相同时，
	 * 分配的处理流量也相同。处理能力是2的处理器将比处理能力是1的处理器多出一倍的负载
	 * 
	 * @return，结果
	 */
	public int getPower() {
		return power;
	}

	/**
	 * 设置处理器的处理能力，处理能力作为算法的调节权重。某个处理器的权重占同一组处理器权重之和的比例就是处理流量分配的比例。处理能力相同时，
	 * 分配的处理流量也相同。处理能力是2的处理器将比处理能力是1的处理器多出一倍的负载
	 * 
	 * @param power
	 *            ，权重
	 */
	public void setPower(int power) {
		if (power <= 0) {
			throw new RuntimeException("Power应该为正整数");
		}
		this.power = power;
	}

	private int truePower;

	private int currentProcessQuantity;

	/**
	 * 获取真实的处理能力，将处理器组中的处理器权重除去最大公约数之后的数字
	 * 
	 * @return，结果
	 */
	public int getTruePower() {
		return truePower;
	}

	void setTruePower(int truePower) {
		this.truePower = truePower;
	}

	/**
	 * 获取或设置当前的处理量，每次轮询开始都会刷新为0
	 * 
	 * @return，结果
	 */
	public int getCurrentProcessQuantity() {
		return currentProcessQuantity;
	}

	void setCurrentProcessQuantity(int currentProcessQuantity) {
		this.currentProcessQuantity = currentProcessQuantity;
	}
}
