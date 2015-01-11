/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Smartkernel.Framework.Collections.ObjectModel
{
	/// <summary>
	/// 只读字典类
	/// </summary>
	/// <typeparam name="TKey">键的类型</typeparam>
	/// <typeparam name="TValue">值的类型</typeparam>
	public class SmartReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary
	{
		/// <summary>
		/// 字典
		/// </summary>
		private readonly IDictionary<TKey, TValue> dictionary;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dictionary">字典对象</param>
		public SmartReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
		{
			this.dictionary = dictionary;
		}

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		void IDictionary.Add(object key, object value)
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		void IDictionary.Clear()
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 是否包含指定的键
		/// </summary>
		/// <param name="key">键</param>
		/// <returns>是否包含</returns>
		bool IDictionary.Contains(object key)
		{
			return ((IDictionary)dictionary).Contains(key);
		}

		/// <summary>
		/// 获得迭代器
		/// </summary>
		/// <returns>迭代器</returns>
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)dictionary).GetEnumerator();
		}

		/// <summary>
		/// 获取是否固定大小
		/// </summary>
		bool IDictionary.IsFixedSize { get { return true; } }

		/// <summary>
		/// 获取是否只读
		/// </summary>
		bool IDictionary.IsReadOnly { get { return true; } }

		/// <summary>
		/// 获取键的列表
		/// </summary>
		ICollection IDictionary.Keys { get { return ((IDictionary)dictionary).Keys; } }

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		/// <param name="key">键</param>
		void IDictionary.Remove(object key)
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 获取值的列表
		/// </summary>
		ICollection IDictionary.Values { get { return ((IDictionary)dictionary).Values; } }

		/// <summary>
		/// 只读索引访问
		/// </summary>
		/// <param name="key">键</param>
		/// <returns>值</returns>
		object IDictionary.this[object key] { get { return ((IDictionary)dictionary)[key]; } set { throw new Exception("ReadOnly，不能访问。"); } }

		/// <summary>
		/// 拷贝字段中指定索引区域的项
		/// </summary>
		/// <param name="array">要拷贝到的数组</param>
		/// <param name="arrayIndex">开始的索引</param>
		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			((ICollection)dictionary).CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// 获取是否线程安全
		/// </summary>
		bool ICollection.IsSynchronized { get { return ((ICollection)dictionary).IsSynchronized; } }

		/// <summary>
		/// 获取锁定对象
		/// </summary>
		object ICollection.SyncRoot { get { return ((ICollection)dictionary).SyncRoot; } }

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 获取字典中项的数量
		/// </summary>
		public int Count { get { return dictionary.Count; } }

		/// <summary>
		/// 字典中是否包含指定的键
		/// </summary>
		/// <param name="key">键</param>
		/// <returns>是否包含</returns>
		public bool ContainsKey(TKey key)
		{
			return dictionary.ContainsKey(key);
		}

		/// <summary>
		/// 获取字典的键列表
		/// </summary>
		public ICollection<TKey> Keys { get { return dictionary.Keys; } }

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		/// <param name="key">键</param>
		/// <returns>是否删除成功</returns>
		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 尝试获取指定键的值
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		/// <returns>是否成功</returns>
		public bool TryGetValue(TKey key, out TValue value)
		{
			return dictionary.TryGetValue(key, out value);
		}

		/// <summary>
		/// 获取字典的值列表
		/// </summary>
		public ICollection<TValue> Values { get { return dictionary.Values; } }

		/// <summary>
		/// 只读索引访问
		/// </summary>
		/// <param name="key">键</param>
		/// <returns>值</returns>
		public TValue this[TKey key] { get { return dictionary[key]; } set { throw new Exception("ReadOnly，不能访问。"); } }

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		/// <param name="item">项</param>
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 是否包含项
		/// </summary>
		/// <param name="item">项</param>
		/// <returns>是否包含</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return (dictionary).Contains(item);
		}

		/// <summary>
		/// 拷贝字段中指定索引区域的项
		/// </summary>
		/// <param name="array">要拷贝到的数组</param>
		/// <param name="arrayIndex">开始的索引</param>
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			(dictionary).CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// 获取是否只读
		/// </summary>
		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly { get { return true; } }

		/// <summary>
		/// 只读，不能访问
		/// </summary>
		/// <param name="item">项</param>
		/// <returns>是否删除成功</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new Exception("ReadOnly，不能访问。");
		}

		/// <summary>
		/// 获得迭代器
		/// </summary>
		/// <returns>迭代器</returns>
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return (dictionary).GetEnumerator();
		}

		/// <summary>
		/// 获得迭代器
		/// </summary>
		/// <returns>迭代器</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)dictionary).GetEnumerator();
		}
	}
}