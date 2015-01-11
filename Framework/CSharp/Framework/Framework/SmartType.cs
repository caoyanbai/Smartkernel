/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 类型操作相关功能
	/// </summary>
	public static class SmartType
	{
		//反射如果增加缓存性能会更差，这一点与感觉相悖。直接进行反射的性能反而更好

		/// <summary>
		/// 创建的类型对象
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>创建的对象</returns>
		public static object CreateInstance(Type type)
		{
			return Activator.CreateInstance(type);
		}

		/// <summary>
		/// 获得某种类型的属性集合，包括公共属性和非公共属性
		/// </summary>
		/// <param name="type">要反射的类型</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>属性的数组</returns>
		public static PropertyInfo[] GetProperties(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			return type.GetProperties(bindingFlags);
		}

		/// <summary>
		/// 获得拥有某种特性标识的某种类型的属性集合，包括公共属性和非公共属性
		/// </summary>
		/// <typeparam name="TAttribute">特性的类型</typeparam>
		/// <param name="type">要反射的类型</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>属性的数组</returns>
		public static PropertyInfo[] GetPropertiesWithAttribute<TAttribute>(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) where TAttribute : Attribute
		{
			var list = new List<PropertyInfo>();
			foreach (var propertyInfo in type.GetProperties(bindingFlags))
			{
				var attribute = (TAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(TAttribute), false);
				if (attribute != null)
				{
					list.Add(propertyInfo);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 获得某种类型的指定属性名称的属性对象
		/// </summary>
		/// <param name="type">某种类型</param>
		/// <param name="propertyName">属性名称</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>属性对象</returns>
		public static PropertyInfo GetProperty(Type type, string propertyName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var linq = from propertyInfo in GetProperties(type, bindingFlags)
			                    where propertyInfo.Name == propertyName
			                    select propertyInfo;
			return linq.Count() > 0 ? linq.ToList().First() : null;
		}

		/// <summary>
		/// 获得属性的类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="propertyName">属性名称</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>类型</returns>
		public static Type GetPropertyType(Type type, string propertyName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			return GetProperty(type, propertyName, bindingFlags).PropertyType;
		}

		/// <summary>
		/// 判断某种类型的指定属性名称的属性是否存在
		/// </summary>
		/// <param name="type">某种类型</param>
		/// <param name="propertyName">属性名称</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>是否存在</returns>
		public static bool ContainsProperty(Type type, string propertyName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			return GetProperty(type, propertyName, bindingFlags) != null;
		}

		/// <summary>
		/// 获得某种类型的字段集合，包括公共字段和非公共字段
		/// </summary>
		/// <param name="type">要反射的类型</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>字段的数组</returns>
		public static FieldInfo[] GetFields(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			return type.GetFields(bindingFlags);
		}

		/// <summary>
		/// 获得拥有某种特性标识的某种类型的字段集合，包括公共字段和非公共字段
		/// </summary>
		/// <typeparam name="TAttribute">特性的类型</typeparam>
		/// <param name="type">要反射的类型</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>字段的数组</returns>
		public static FieldInfo[] GetFieldsWithAttribute<TAttribute>(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) where TAttribute : Attribute
		{
			var list = new List<FieldInfo>();
			foreach (var fieldInfo in type.GetFields(bindingFlags))
			{
				var attribute = (TAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(TAttribute), false);
				if (attribute != null)
				{
					list.Add(fieldInfo);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 获得某种类型的指定字段名称的字段对象
		/// </summary>
		/// <param name="type">某种类型</param>
		/// <param name="fieldName">字段名称</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>字段对象</returns>
		public static FieldInfo GetField(Type type, string fieldName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var linq = from fieldInfo in GetFields(type, bindingFlags)
			                    where fieldInfo.Name == fieldName
			                    select fieldInfo;
			return linq.Count() > 0 ? linq.ToList().First() : null;
		}

		/// <summary>
		/// 获得字段的类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="fieldName">字段名称</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>类型</returns>
		public static Type GetFieldType(Type type, string fieldName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			return GetField(type, fieldName, bindingFlags).FieldType;
		}

		/// <summary>
		/// 判断某种类型的指定字段名称的字段是否存在
		/// </summary>
		/// <param name="type">某种类型</param>
		/// <param name="fieldName">字段名称</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>是否存在</returns>
		public static bool ContainsField(Type type, string fieldName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			return GetField(type, fieldName, bindingFlags) != null;
		}

		/// <summary>
		/// 获得类型的根类型，不包括object。只寻找到object的下一层
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>根类型</returns>
		public static Type GetRootType(Type type)
		{
			return type.BaseType != typeof(object) ? GetRootType(type.BaseType) : type;
		}

		private static List<Type> numbericTypes = new Type[] { typeof(BigInteger), typeof(int), typeof(uint), typeof(double), typeof(short), typeof(ushort), typeof(decimal), typeof(long), typeof(ulong), typeof(float), typeof(byte), typeof(sbyte) }.ToList();

		/// <summary>
		/// 判断是不是数字类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>是否数字类型</returns>
		public static bool IsNumbericType(Type type)
		{
			return numbericTypes.Contains(type);
		}

		/// <summary>
		/// 判断是不是可为null的类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>是不是可为null的类型</returns>
		public static bool IsNullType(Type type)
		{
			return !type.IsValueType || type.Name == "Nullable`1";
		}

		/// <summary>
		/// 判断是不是Nullable类型，Nullable类型是值类型的包装类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>是不是Nullable类型</returns>
		public static bool IsNullableType(Type type)
		{
			return type.Name == "Nullable`1";
		}

		/// <summary>
		/// 是否包含方法
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="methodName">方法名称</param>
		/// <returns>是否包含</returns>
		public static bool ContainsMethod(Type type, string methodName)
		{
			return type.GetMethod(methodName) != null;
		}

		/// <summary>
		/// 获取方法
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="methodName">方法名称</param>
		/// <returns>方法</returns>
		public static MethodInfo getMethod(Type type, string methodName)
		{
			return type.GetMethod(methodName);
		}

		/// <summary>
		/// 获得Nullable类型的实际类型，如果传递的类型不是Nullable类型，将会抛出异常
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>Nullable类型的实际类型</returns>
		public static Type GetNullableOriginType(Type type)
		{
			return type.GetGenericArguments()[0];
		}

		/// <summary>
		/// 创建类型的对象
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <returns>创建的对象</returns>
		public static T CreateInstance<T>() where T : new()
		{
			return Activator.CreateInstance<T>();
		}

		/// <summary>
		/// 从外部程序集创建类型的对象，在本地程序集中如果包含外部程序集实现的接口，则可以作为T传入
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="assemblyFilePath">程序集文件所在的路径</param>
		/// <param name="typeFullName">类型的全名，如果是内部类则无法创建</param>
		/// <returns>创建的对象</returns>
		public static T CreateInstance<T>(string assemblyFilePath, string typeFullName)
		{
			return (T)CreateInstance(assemblyFilePath, typeFullName);
		}

		/// <summary>
		/// 从外部程序集创建类型的对象
		/// </summary>
		/// <param name="assemblyFilePath">程序集文件所在的路径</param>
		/// <param name="typeFullName">类型的全名，如果是内部类则无法创建</param>
		/// <returns>创建的对象</returns>
		public static object CreateInstance(string assemblyFilePath, string typeFullName)
		{
			return Activator.CreateInstanceFrom(assemblyFilePath, typeFullName).Unwrap();
		}

		/// <summary>
		/// 设置对象的属性值，匿名对象不可通过这种方法赋值，但是只读属性可以通过这种方法赋值
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="name">属性名称</param>
		/// <param name="value">属性值，如果与属性类型不匹配，则抛出异常</param>
		/// <param name="bindingFlags">绑定标志</param>
		public static void SetPropertyValue(object obj, string name, object value, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var type = obj.GetType();

			var propertyInfo = type.GetProperty(name, bindingFlags);

			propertyInfo.SetValue(obj, value, null);
		}

		/// <summary>
		/// 设置对象的字段，私有字段可以通过这种方法赋值
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="name">字段名称</param>
		/// <param name="value">字段值，如果与字段类型不匹配，则抛出异常</param>
		/// <param name="bindingFlags">绑定标志</param>
		public static void SetFieldValue(object obj, string name, object value, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var type = obj.GetType();

			var fieldInfo = type.GetField(name, bindingFlags);

			fieldInfo.SetValue(obj, value);
		}

		/// <summary>
		/// 通过反射调用对象的方法，并返回值
		/// </summary>
		/// <param name="target">对象</param>
		/// <param name="methodName">方法名，区分大小写</param>
		/// <param name="args">方法的参数数组</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>方法调用返回的结果</returns>
		public static object MethodInvoke(object target, string methodName, object[] args = null, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Static)
		{
			return target.GetType().InvokeMember(methodName, bindingFlags, null, target, args, CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// 获取对象指定属性的值
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="propertyName">属性名</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>值</returns>
		public static object GetPropertyValue(object obj, string propertyName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var propertyInfo = GetProperty(obj.GetType(), propertyName, bindingFlags);
			return propertyInfo != null ? propertyInfo.GetValue(obj, null) : null;
		}

		/// <summary>
		/// 获得对象所有属性值的键值对列表
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>属性值的键值对列表</returns>
		public static Dictionary<string, object> GetPropertiesDictionary(object obj, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var dictionary = new Dictionary<string, object>();

			foreach (var propertyInfo in GetProperties(obj.GetType(), bindingFlags))
			{
				var key = propertyInfo.Name;
				var value = propertyInfo.GetValue(obj, null);
				dictionary.Add(key, value);
			}

			return dictionary;
		}

		/// <summary>
		/// 获取对象指定字段的值
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="fieldName">字段名</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>值</returns>
		public static object GetFieldValue(object obj, string fieldName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var fieldInfo = GetField(obj.GetType(), fieldName, bindingFlags);
			return fieldInfo != null ? fieldInfo.GetValue(obj) : null;
		}

		/// <summary>
		/// 获得对象字段值的列表
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="bindingFlags">绑定标志</param>
		/// <returns>字段值列表</returns>
		public static Dictionary<string, object> GetFieldsDictionary(object obj, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var dictionary = new Dictionary<string, object>();

			foreach (var fieldInfo in GetFields(obj.GetType(), bindingFlags))
			{
				var key = fieldInfo.Name;
				var value = fieldInfo.GetValue(obj) == null ? null : fieldInfo.GetValue(obj).ToString();
				dictionary.Add(key, value);
			}

			return dictionary;
		}

		/// <summary>
		/// 通过成员的简单拷贝进行对象克隆。实现浅表复制，只实现第一层成员的克隆。某些成员克隆失败，不会影响其他成员的克隆
		/// </summary>
		/// <param name="source">源对象</param>
		/// <param name="isCloneProperties">是否克隆属性</param>
		/// <param name="isCloneFields">是否克隆字段</param>
		/// <param name="propertiesBindingFlags">属性的绑定标志</param>
		/// <param name="fieldsBindingFlags">字段的绑定标志</param>
		/// <returns>新的克隆对象</returns>
		public static object MembersSimpleClone(object source, bool isCloneProperties = true, bool isCloneFields = true, BindingFlags propertiesBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, BindingFlags fieldsBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var type = source.GetType();
			var result = CreateInstance(type);
			return MembersSimpleCopy(source, result);
		}

		/// <summary>
		/// 通过成员的简单拷贝进行对象复制。实现浅表复制，只实现第一层成员的复制。某些成员复制失败，不会影响其他成员的复制
		/// </summary>
		/// <param name="source">源对象</param>
		/// <param name="target">目标对象</param>
		/// <param name="isCopyProperties">是否复制属性</param>
		/// <param name="isCopyFields">是否复制字段</param>
		/// <param name="propertiesBindingFlags">属性的绑定标志</param>
		/// <param name="fieldsBindingFlags">字段的绑定标志</param>
		/// <returns>新的复制对象</returns>
		public static object MembersSimpleCopy(object source, object target, bool isCopyProperties = true, bool isCopyFields = true, BindingFlags propertiesBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, BindingFlags fieldsBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var typeSource = source.GetType();
			var typeTarget = target.GetType();

			//复制属性值
			if (isCopyProperties)
			{
				foreach (var propertyInfoTarget in GetProperties(typeTarget, propertiesBindingFlags))
				{
					if (ContainsProperty(typeSource, propertyInfoTarget.Name, propertiesBindingFlags))
					{
						try
						{
							propertyInfoTarget.SetValue(target, GetPropertyValue(source, propertyInfoTarget.Name, propertiesBindingFlags), null);
						}
						catch
						{
						}
					}
				}
			}
			//复制字段值
			if (isCopyFields)
			{
				foreach (var fieldInfoTarget in GetFields(typeTarget, fieldsBindingFlags))
				{
					if (ContainsField(typeSource, fieldInfoTarget.Name, fieldsBindingFlags))
					{
						try
						{
							fieldInfoTarget.SetValue(target, GetFieldValue(source, fieldInfoTarget.Name, fieldsBindingFlags));
						}
						catch
						{
						}
					}
				}
			}
			return target;
		}

		/// <summary>
		/// 判断两个对象是否相等，可以比较两个对象中有null的情况，两个都为null认为是相等的
		/// </summary>
		/// <param name="left">要比较的对象</param>
		/// <param name="right">要比较的对象</param>
		/// <returns>比较的结果</returns>
		public static bool EqualsWithNull(object left, object right)
		{
			if (left == null && right == null)
			{
				return true;
			}
			return (left != null) && (right != null) && left.Equals(right);
		}

		/// <summary>
		/// 简单成员比较，如果成员相等，则认为是相等。类型不同的两个对象也可以比较，主要相同名称的成员相等就认为是相等
		/// </summary>
		/// <param name="source">源对象</param>
		/// <param name="target">目标对象</param>
		/// <param name="isCompareProperties">是否比较属性</param>
		/// <param name="isCompareFields">是否比较字段</param>
		/// <param name="propertiesBindingFlags">属性的绑定标志</param>
		/// <param name="fieldsBindingFlags">字段的绑定标志</param>
		/// <returns>是否相等</returns>
		public static bool MembersSimpleCompare(object source, object target, bool isCompareProperties = true, bool isCompareFields = true, BindingFlags propertiesBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, BindingFlags fieldsBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
		{
			var typeSource = source.GetType();
			var typeTarget = target.GetType();

			//判断属性值
			if (isCompareProperties)
			{
				foreach (var propertyInfoTarget in GetProperties(typeSource, propertiesBindingFlags))
				{
					//存在相同的属性才去比较
					if (ContainsProperty(typeTarget, propertyInfoTarget.Name, propertiesBindingFlags))
					{
						var propertyInfoSource = GetProperty(typeSource, propertyInfoTarget.Name, propertiesBindingFlags);
						var sourceValue = propertyInfoSource.GetValue(source, null);

						var targetValue = SmartType.GetPropertyValue(target, propertyInfoTarget.Name, propertiesBindingFlags);
						if (!EqualsWithNull(sourceValue, targetValue))
						{
							return false;
						}
					}
				}
			}
			//判断字段值
			if (isCompareFields)
			{
				foreach (var fieldInfoTarget in GetFields(typeSource, fieldsBindingFlags))
				{
					//存在相同的属性才去比较
					if (ContainsField(typeTarget, fieldInfoTarget.Name, fieldsBindingFlags))
					{
						var fieldInfoSource = GetField(typeSource, fieldInfoTarget.Name, fieldsBindingFlags);
						var sourceValue = fieldInfoSource.GetValue(source);

						var targetValue = SmartType.GetFieldValue(target, fieldInfoTarget.Name, fieldsBindingFlags);
						if (!EqualsWithNull(sourceValue, targetValue))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		/// <summary>
		/// 是否可枚举类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>结果</returns>
		public static bool IsEnumerable(Type type)
		{
			Type referenceType = typeof(IEnumerable);
			return referenceType.IsAssignableFrom(type);
		}

		/// <summary>
		/// 是否集合类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>结果</returns>
		public static bool IsCollection(Type type)
		{
			Type referenceType = typeof(ICollection);
			return referenceType.IsAssignableFrom(type);
		}

		/// <summary>
		/// 是否字典类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>结果</returns>
		public static bool IsDictionary(Type type)
		{
			Type referenceType = typeof(IDictionary);
			return referenceType.IsAssignableFrom(type);
		}

		/// <summary>
		/// 是否数组类型
		/// </summary>
		/// <param name="type">类型</param>
		/// <returns>结果</returns>
		public static bool IsArray(Type type)
		{
			return type.IsArray;
		}

		/// <summary>
		/// 是否实现某个接口
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="interfaceType">接口类型</param>
		/// <returns>结果</returns>
		public static bool IsInterface(Type type, Type interfaceType)
		{
			return type.GetInterface(interfaceType.FullName) != null;
		}

		/// <summary>
		/// 获得所有公开静态成员属性的值列表
		/// </summary>
		/// <typeparam name="TClass">类类型</typeparam>
		/// <typeparam name="TProperty">属性类型</typeparam>
		/// <returns>结果</returns>
		public static List<TProperty> GetAllPublicStaticPropertyValues<TClass, TProperty>()
		{
			return typeof(TClass).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).Where(property =>
				{
					return property.PropertyType == typeof(TProperty);
				}).Select(property =>
				{
					return (TProperty)property.GetValue(typeof(TClass), null);
				}).ToList();
		}

		/// <summary>
		/// 获得所有公开静态成员属性的值列表
		/// </summary>
		/// <typeparam name="TProperty">属性类型</typeparam>
		/// <param name="type">类型</param>
		/// <returns>结果</returns>
		public static List<TProperty> GetAllPublicStaticPropertyValues<TProperty>(Type type)
		{
			return type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).Where(property =>
				{
					return property.PropertyType == typeof(TProperty);
				}).Select(property =>
				{
					return (TProperty)property.GetValue(type, null);
				}).ToList();
		}
	}
}
