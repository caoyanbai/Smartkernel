/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Smartkernel.Framework.Collections
{
	/// <summary>
	/// 集合类的辅助工具
	/// </summary>
	public static class SmartCollection
	{
		/// <summary>
		/// 将多个枚举类型合并成一个
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="lists">多个枚举类型</param>
		/// <returns>结果</returns>
		public static IEnumerable<T> UnionAll<T>(IEnumerable<IEnumerable<T>> lists)
		{
			if (lists != null)
			{
				foreach (var list in lists)
				{
					if (list != null)
					{
						foreach (var item in list)
						{
							yield return item;
						}
					}
				}
			}
		}

		/// <summary>
		/// 判断集合是否为空或null
		/// </summary>
		/// <param name="list">集合</param>
		/// <returns>是否为空</returns>
		public static bool IsNullOrEmpty(ICollection list)
		{
			return list == null || list.Count == 0;
		}

		/// <summary>
		/// 随机排序
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="list">列表</param>
		public static void RandomSort<T>(List<T> list)
		{
			var temp = new List<T>();
			foreach (var item in list)
			{
				var index = SmartRandom.NextInt(0, temp.Count);
				temp.Insert(index, item);
			}
			list.Clear();
			list.AddRange(temp);
		}

		/// <summary>
		/// 获得集合的字符串表示
		/// </summary>
		/// <param name="list">集合</param>
		/// <param name="leftEmbodySymbol">左包含符</param>
		/// <param name="rightEmbodySymbol">右包含符</param>
		/// <param name="splitSymbol">分隔符</param>
		/// <returns>字符串表示</returns>
		public static string ToJoinString(IEnumerable list, string leftEmbodySymbol = "'", string rightEmbodySymbol = "'", string splitSymbol = "|")
		{
			var temp = new List<string>();
			var enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				temp.Add(leftEmbodySymbol + enumerator.Current + rightEmbodySymbol);
			}
			return temp.Aggregate((current, next) => current + splitSymbol + next);
		}

		/// <summary>
		/// 判断两个枚举类型是否相同，且具有相同数量的元素（每一个位置的值都相同）
		/// </summary>
		/// <param name="source">源</param>
		/// <param name="target">目标</param>
		/// <returns>是否相等</returns>
		public static bool EqualsByEachOne(IEnumerable source, IEnumerable target)
		{
			if (source == target)
			{
				return true;
			}

			if (source == null || target == null)
			{
				return false;
			}

			IEnumerator sourceEnumerator = source.GetEnumerator();
			IEnumerator targetEnumerator = target.GetEnumerator();

			bool sourceHasValue = sourceEnumerator.MoveNext();
			bool targetHasValue = targetEnumerator.MoveNext();

			while (sourceHasValue && targetHasValue)
			{
				if (!sourceEnumerator.Current.Equals(targetEnumerator.Current))
				{
					return false;
				}

				sourceHasValue = sourceEnumerator.MoveNext();
				targetHasValue = targetEnumerator.MoveNext();
			}

			//如果为false，说明元素数量不相等
			return !(sourceHasValue || targetHasValue);
		}
	}
}
