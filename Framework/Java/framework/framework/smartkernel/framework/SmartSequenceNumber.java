/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

/**
 * 递增序列号，可以把序列号对象放入全局容器中，使用Name进行区分。默认不是线程安全的。
 * 
 * @param <T>，序列号的类型
 */
public class SmartSequenceNumber<T extends Number> {

	/**
	 * 最后一次用于初始化的值
	 */
	private T start;

	/**
	 * 构造函数
	 * 
	 * @param current
	 *            ，初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始
	 * @param step
	 *            ，递增的步长，执行过程中也可以修改
	 * @param limit
	 *            ，边界限制
	 * @param name
	 *            ，序列号对象的名称，不指定的情况下，将自动产生
	 * @param isAutoInitialize
	 *            ,是否自动初始化，如果自动初始化，则到达边界时，使用最后一次初始化值进行初始化。否则，到达最大值时将停止递增
	 */
	public SmartSequenceNumber(T current, T step, T limit, String name,
			boolean isAutoInitialize) {
		if (SmartGeneric.moreThan(SmartGeneric.add(current, step), limit)) {
			throw new RuntimeException("Limit不能小于CurrentNumber与StepLength的和。");
		}

		setName(name == null ? SmartGuid.newGuid() : name);
		setLimit(limit);
		setCurrent(current);
		start = current;
		setStep(step);
		setIsAutoInitialize(isAutoInitialize);
	}

	/**
	 * 构造函数
	 * 
	 * @param current
	 *            ，初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始
	 * @param step
	 *            ，递增的步长，执行过程中也可以修改
	 * @param limit
	 *            ，边界限制
	 * @param name
	 *            ，序列号对象的名称，不指定的情况下，将自动产生
	 */
	public SmartSequenceNumber(T current, T step, T limit, String name) {
		this(current, step, limit, name, true);
	}

	/**
	 * 构造函数
	 * 
	 * @param current
	 *            ，初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始
	 * @param step
	 *            ，递增的步长，执行过程中也可以修改
	 * @param limit
	 *            ，边界限制
	 */
	public SmartSequenceNumber(T current, T step, T limit) {
		this(current, step, limit, null, true);
	}

	/**
	 * 获取是否是线程安全的
	 * 
	 * @return，获取是否是线程安全的
	 */
	public boolean isSynchronized() {
		return false;
	}

	/**
	 * 同步对象
	 * 
	 * @return，同步对象
	 */
	public Object syncRoot() {
		return this;
	}

	private String name;

	/**
	 * 获取序列号对象的名称
	 */
	public String getName() {
		return this.name;
	}

	private void setName(String name) {
		this.name = name;
	}

	private T limit;

	/**
	 * 获取边界限制
	 * 
	 * @return，结果
	 */
	public T getLimit() {
		return limit;
	}

	/**
	 * 设置边界限制
	 * 
	 * @param limit
	 *            ，边界限制
	 */
	public void setLimit(T limit) {
		this.limit = limit;
	}

	private T current;

	/**
	 * 获取当前的序列号
	 * 
	 * @return，结果
	 */
	public T getCurrent() {
		return current;
	}

	/**
	 * 设置当前的序列号
	 * 
	 * @param current
	 *            ，当前的序列号
	 */
	public void setCurrent(T current) {
		this.current = current;
	}

	/**
	 * 获取是否到达边界
	 * 
	 * @return，结果
	 */
	public boolean getIsArriveLimit() {
		return SmartGeneric.moreThan(SmartGeneric.add(current, step), limit);
	}

	private boolean isAutoInitialize;

	/**
	 * 获取是否自动初始化，如果自动初始化，则到达边界时，使用最后一次初始化值进行初始化。否则，到达最大值时将停止递增
	 * 
	 * @return，结果
	 */
	public boolean getIsAutoInitialize() {
		return isAutoInitialize;
	}

	/**
	 * 设置是否自动初始化，如果自动初始化，则到达边界时，使用最后一次初始化值进行初始化。否则，到达最大值时将停止递增
	 * 
	 * @param isAutoInitialize
	 *            ，是否自动初始化
	 */
	public void setIsAutoInitialize(boolean isAutoInitialize) {
		this.isAutoInitialize = isAutoInitialize;
	}

	// / <summary>
	// / 获取或设置递增的步长
	// / </summary>
	private T step;

	/**
	 * 获取递增的步长
	 * 
	 * @return，结果
	 */
	public T getStep() {
		return step;
	}

	/**
	 * 设置递增的步长
	 * 
	 * @param step
	 *            ，步长
	 */
	public void setStep(T step) {
		this.step = step;
	}

	/**
	 * 创建线程安全的序列号对象
	 * 
	 * @param sequenceNumber
	 *            ，非线程安全的序列号对象
	 * @return，线程安全的序列号对象
	 */
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public static SmartSequenceNumber<?> getSynchronized(
			SmartSequenceNumber<?> sequenceNumber) {
		if (sequenceNumber == null) {
			throw new RuntimeException("sequenceNumber参数不能为null。");
		}
		if (sequenceNumber.getClass() == SmartSyncSequenceNumber.class) {
			throw new RuntimeException("sequenceNumber已经是线程安全的对象了。");
		}
		return new SmartSyncSequenceNumber(sequenceNumber);
	}

	/**
	 * 线程安全的序列号
	 * 
	 * @param <T2>，类型
	 */
	private static class SmartSyncSequenceNumber<T2 extends Number> extends
			SmartSequenceNumber<T2> {
		private final Object syncRoot;

		/**
		 * 构造函数
		 * 
		 * @param sequenceNumber
		 *            ，非线程安全的序列号对象
		 */
		SmartSyncSequenceNumber(SmartSequenceNumber<T2> sequenceNumber) {
			super(sequenceNumber.start, sequenceNumber.step,
					sequenceNumber.limit, sequenceNumber.name,
					sequenceNumber.isAutoInitialize);
			syncRoot = sequenceNumber.syncRoot();
		}

		/**
		 * 获取是否是线程安全的
		 * 
		 * @return，获取是否是线程安全的
		 */
		public boolean isSynchronized() {
			return true;
		}

		/**
		 * 同步对象
		 * 
		 * @return，同步对象
		 */
		public Object syncRoot() {
			return syncRoot;
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see smartkernel.framework.SmartSequenceNumber#generate()
		 */
		public T2 generate() {
			synchronized (syncRoot) {
				return super.generate();
			}
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see
		 * smartkernel.framework.SmartSequenceNumber#initialize(java.lang.Number
		 * , java.lang.Number, java.lang.Number)
		 */
		public void initialize(T2 current, T2 step, T2 limit) {
			synchronized (syncRoot) {
				super.initialize(current, step, limit);
			}
		}
	}

	/**
	 * 初始化器
	 * 
	 * @param current
	 *            ，初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始
	 * @param step
	 *            ，递增的步长，执行过程中也可以修改
	 * @param limit
	 *            ，边界限制
	 */
	public void initialize(T current, T step, T limit) {
		if (SmartGeneric.moreThan(SmartGeneric.add(current, step), limit)) {
			throw new RuntimeException("Limit不能小于CurrentNumber与StepLength的和。");
		}
		setLimit(limit);
		setCurrent(current);
		start = current;
		setStep(step);
	}

	/**
	 * 生成当前的序列号，每调用一次就产生一个新的
	 * 
	 * @return，当前的序列号
	 */
	public T generate() {
		// 到达边界时，且设置为自动初始化，则完成初始化
		if (getIsArriveLimit() && getIsAutoInitialize()) {
			initialize(start, step, limit);
		}
		// 未到达边界时，继续递增
		if (!getIsArriveLimit()) {
			setCurrent(SmartGeneric.add(current, step));
		}
		return current;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.lang.Object#equals(java.lang.Object)
	 */
	@SuppressWarnings("unchecked")
	public boolean equals(Object obj) {
		SmartSequenceNumber<T> other = (SmartSequenceNumber<T>) obj;
		if (other == null) {
			return false;
		}
		return name.equals(other.name);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see java.lang.Object#hashCode()
	 */
	public int hashCode() {
		return name.hashCode();
	}
}
