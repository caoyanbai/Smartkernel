/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 递增序列号，可以把序列号对象放入全局容器中，使用Name进行区分。默认不是线程安全的。
	/// </summary>
	/// <typeparam name="T">序列号的类型</typeparam>
	public class SmartSequenceNumber<T> where T : IComparable
	{
		/// <summary>
		/// 最后一次用于初始化的值
		/// </summary>
		private T start;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="current">初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始</param>
		/// <param name="step">递增的步长，执行过程中也可以修改</param>
		/// <param name="limit">边界限制</param>
		/// <param name="name">序列号对象的名称，不指定的情况下，将自动产生</param>
		/// <param name="isAutoInitialize">是否自动初始化，如果自动初始化，则到达边界时，使用最后一次初始化值进行初始化。否则，到达最大值时将停止递增</param>
		public SmartSequenceNumber(T current, T step, T limit, string name = null, bool isAutoInitialize = true)
		{
			if (SmartGeneric.MoreThan(SmartGeneric.Add(current, step), limit))
			{
				throw new Exception("Limit不能小于CurrentNumber与StepLength的和。");
			}

			Name = name ?? SmartGuid.NewGuid();
			Limit = limit;
			Current = current;
			start = current;
			Step = step;
			IsAutoInitialize = isAutoInitialize;
		}

		/// <summary>
		/// 获取是否是线程安全的
		/// </summary>
		public virtual bool IsSynchronized { get { return false; } }

		/// <summary>
		/// 同步对象
		/// </summary>
		public virtual object SyncRoot { get { return this; } }

		/// <summary>
		/// 获取序列号对象的名称
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 获取或设置边界限制
		/// </summary>
		public T Limit { get; set; }

		/// <summary>
		/// 获取当前的序列号
		/// </summary>
		public T Current { get; private set; }

		/// <summary>
		/// 获取是否到达边界
		/// </summary>
		public bool IsArriveLimit { get { return SmartGeneric.MoreThan(SmartGeneric.Add(Current, Step), Limit); } }

		/// <summary>
		/// 获取或设置是否自动初始化，如果自动初始化，则到达边界时，使用最后一次初始化值进行初始化。否则，到达最大值时将停止递增
		/// </summary>
		public bool IsAutoInitialize { get; set; }

		/// <summary>
		/// 获取或设置递增的步长
		/// </summary>
		public T Step { get; set; }

		/// <summary>
		/// 创建线程安全的序列号对象
		/// </summary>
		/// <param name="sequenceNumber">非线程安全的序列号对象</param>
		/// <returns>线程安全的序列号对象</returns>
		public static SmartSequenceNumber<T> Synchronized(SmartSequenceNumber<T> sequenceNumber)
		{
			if (sequenceNumber == null)
			{
				throw new Exception("sequenceNumber参数不能为null。");
			}
			if (sequenceNumber.GetType() == typeof(SmartSyncSequenceNumber<T>))
			{
				throw new Exception("sequenceNumber已经是线程安全的对象了。");
			}
			return new SmartSyncSequenceNumber<T>(sequenceNumber);
		}

		/// <summary>
		/// 初始化器
		/// </summary>
		/// <param name="current">初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始</param>
		/// <param name="step">递增的步长，执行过程中也可以修改</param>
		/// <param name="limit">边界限制</param>
		public virtual void Initialize(T current, T step, T limit)
		{
			if (SmartGeneric.MoreThan(SmartGeneric.Add(current, step), limit))
			{
				throw new Exception("Limit不能小于CurrentNumber与StepLength的和。");
			}
			Limit = limit;
			Current = current;
			start = current;
			Step = step;
		}

		/// <summary>
		/// 生成当前的序列号，每调用一次就产生一个新的
		/// </summary>
		/// <returns>当前的序列号</returns>
		public virtual T Generate()
		{
			//到达边界时，且设置为自动初始化，则完成初始化
			if (IsArriveLimit && IsAutoInitialize)
			{
				Initialize(start, Step, Limit);
			}
			//未到达边界时，继续递增
			if (!IsArriveLimit)
			{
				Current = SmartGeneric.Add(Current, Step);
			}
			return Current;
		}

		/// <summary>
		/// 判等方法
		/// </summary>
		/// <param name="obj">待比较的对象</param>
		/// <returns>是否相等</returns>
		public override bool Equals(object obj)
		{
			var other = obj as SmartSequenceNumber<T>;
			if (other == null)
			{
				return false;
			}
			return Name == other.Name;
		}

		/// <summary>
		/// 获得哈希码
		/// </summary>
		/// <returns>哈希码</returns>
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		#region Nested type: SmartSyncSequenceNumber

		/// <summary>
		/// 线程安全的序列号
		/// </summary>
		/// <typeparam name="T2">类型</typeparam>
		private sealed class SmartSyncSequenceNumber<T2> : SmartSequenceNumber<T2> where T2 : IComparable
		{
			private readonly object syncRoot;

			/// <summary>
			/// 构造函数
			/// </summary>
			/// <param name="sequenceNumber">非线程安全的序列号对象</param>
			internal SmartSyncSequenceNumber(SmartSequenceNumber<T2> sequenceNumber)
				: base(sequenceNumber.start, sequenceNumber.Step, sequenceNumber.Limit, sequenceNumber.Name, sequenceNumber.IsAutoInitialize)
			{
				syncRoot = sequenceNumber.SyncRoot;
			}

			/// <summary>
			/// 获取是否是线程安全的
			/// </summary>
			public override bool IsSynchronized { get { return true; } }

			/// <summary>
			/// 同步对象
			/// </summary>
			public override object SyncRoot { get { return syncRoot; } }

			/// <summary>
			/// 生成当前的序列号，每调用一次就产生一个新的
			/// </summary>
			/// <returns>当前的序列号</returns>
			public override T2 Generate()
			{
				lock (SyncRoot)
				{
					return base.Generate();
				}
			}

			/// <summary>
			/// 初始化器
			/// </summary>
			/// <param name="current">初始化的数值，第一个序号不包括初始化数值，而是从初始化数值递增的第一个数开始。也就是，current为0时，从1开始</param>
			/// <param name="step">递增的步长，执行过程中也可以修改</param>
			/// <param name="limit">边界限制</param>
			public override void Initialize(T2 current, T2 step, T2 limit)
			{
				lock (SyncRoot)
				{
					base.Initialize(current, step, limit);
				}
			}
		}

		#endregion
	}
}
