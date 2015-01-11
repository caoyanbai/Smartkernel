/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 对象辅助类
	/// </summary>
	public static class SmartObject
	{
		private static readonly IDictionary<Type, int> TypeSizes = InitializeTypeSizes();

		private static IDictionary<Type, int> InitializeTypeSizes()
		{
			IDictionary<Type, int> dictionary = new Dictionary<Type, int>();

			dictionary.Add(typeof(DateTime), 8);
			dictionary.Add(typeof(SmartEmptyObject), 8);
			dictionary.Add(typeof(byte), 1);
			dictionary.Add(typeof(char), 1);
			dictionary.Add(typeof(long), 8);
			dictionary.Add(typeof(int), 4);
			dictionary.Add(typeof(short), 2);
			dictionary.Add(typeof(float), 4);
			dictionary.Add(typeof(double), 8);
			dictionary.Add(typeof(ulong), 8);
			dictionary.Add(typeof(uint), 4);
			dictionary.Add(typeof(ushort), 2);

			return dictionary;
		}

		/// <summary>
		/// 确定对象的大小
		/// </summary>
		/// <param name="obj">对象</param>
		/// <returns>结果</returns>
		public static int SizeOf(object obj)
		{
			int size = 0;

			if (obj != null)
			{
				Queue<object> objects = new Queue<object>();
				Queue<object> done = new Queue<object>();

				objects.Enqueue(obj);

				while (objects.Count > 0)
				{
					object target = objects.Dequeue();
					int targetSize = -1;

					done.Enqueue(target);

					if (target == null)
					{
						targetSize = 0;
					}
					else
					{
						try
						{
							Type targetType = target.GetType();

							if (targetType.IsEnum)
							{
								targetType = Enum.GetUnderlyingType(targetType);
							}

							if (TypeSizes.ContainsKey(targetType))
							{
								if (targetSize == -1)
								{
									targetSize = 0;
								}

								targetSize += TypeSizes[targetType];
							}
							else
							{
								if (targetType.IsValueType)
								{
									targetSize = Marshal.SizeOf(target);
								}
								else
								{
									if (target is Delegate)
									{
										targetSize += TypeSizes[typeof(SmartEmptyObject)];

									}
									else
									{
										targetSize = -2;
									}
								}
							}
						}
						catch (Exception)
						{
							targetSize = -2;
						}
					}

					if (target != null && targetSize < 0)
					{
						Type targetType = target.GetType();
						FieldInfo[] fields = targetType.GetFields(BindingFlags.Instance | BindingFlags.GetField | BindingFlags.Public | BindingFlags.NonPublic);

						foreach (FieldInfo f in fields)
						{
							object fieldValue = f.GetValue(target);

							if (fieldValue != null && !objects.Contains(fieldValue) && !done.Contains(fieldValue))
							{
								objects.Enqueue(fieldValue);
							}
						}

						if (target is IEnumerable)
						{
							if (target is string)
							{
								string targetAsString = target as string;
								size += targetAsString.Length;
							}
							else
							{
								IEnumerable targetEnumerable = target as IEnumerable;

								foreach (object item in targetEnumerable)
								{
									if (item != null && !objects.Contains(item) && !done.Contains(item))
									{
										objects.Enqueue(item);
									}
								}
							}
						}
					}
					else
					{
						size += targetSize;
					}
				}

				objects.Clear();
				done.Clear();
			}

			return size;
		}

		/// <summary>
		/// 是否是默认值
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="obj">对象</param>
		/// <returns>结果</returns>
		public static bool IsDefaultValue<T>(T obj)
		{
			if (default(T) == null)
			{
				if (obj == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return default(T).Equals(obj);
			}
		}
	}
}
