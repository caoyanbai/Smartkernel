/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.lang.annotation.Annotation;
import java.lang.reflect.*;
import java.math.*;
import java.net.*;
import java.util.*;
import java.io.*;

/**
 * 类型操作相关功能
 * 
 */
public class SmartType {
	/**
	 * 创建的类型对象
	 * 
	 * @param type
	 *            ，类型
	 * @return，创建的对象
	 */
	public static <T> T createInstance(Class<T> type) {
		try {
			return type.newInstance();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得某种类型的字段集合，包括公共字段和非公共字段
	 * 
	 * @param type
	 *            ，要反射的类型
	 * @return，字段的数组
	 */
	public static Field[] getFields(Class<?> type) {
		Field[] fields = type.getDeclaredFields();
		for (Field field : fields) {
			field.setAccessible(true);
		}
		return fields;
	}

	/**
	 * 获得某种类型的字段集合，包括公共字段和非公共字段
	 * 
	 * @param type
	 *            ，要反射的类型
	 * @param fieldName
	 *            ，字段名称
	 * @return，字段的数组
	 */
	public static Field getField(Class<?> type, String fieldName) {
		try {
			Field field = type.getDeclaredField(fieldName);
			field.setAccessible(true);
			return field;
		} catch (Exception err) {
			return null;
		}
	}

	/**
	 * 获得字段的类型
	 * 
	 * @param type
	 *            ，类型
	 * @param fieldName
	 *            ，字段名称
	 * @return，类型
	 */
	public static Class<?> getFieldType(Class<?> type, String fieldName) {
		return getField(type, fieldName).getType();
	}

	/**
	 * 判断某种类型的指定字段名称的字段是否存在
	 * 
	 * @param type
	 *            ，某种类型
	 * @param fieldName
	 *            ，字段名称
	 * @return，是否存在
	 */
	public static boolean containsField(Class<?> type, String fieldName) {
		return getField(type, fieldName) != null;
	}

	/**
	 * 获得类型的根类型，不包括object。只寻找到object的下一层
	 * 
	 * @param type
	 *            ，类型
	 * @return，根类型
	 */
	public static Class<?> getRootType(Class<?> type) {
		return type.getSuperclass() != Object.class ? getRootType(type
				.getSuperclass()) : type;
	}

	private static ArrayList<Class<?>> numbericTypes = new ArrayList<Class<?>>();

	static {
		numbericTypes.add(BigInteger.class);
		
		numbericTypes.add(Integer.class);
		numbericTypes.add(Double.class);
		numbericTypes.add(Short.class);
		numbericTypes.add(Long.class);
		numbericTypes.add(Float.class);
		numbericTypes.add(Byte.class);

		numbericTypes.add(int.class);
		numbericTypes.add(double.class);
		numbericTypes.add(short.class);
		numbericTypes.add(long.class);
		numbericTypes.add(float.class);
		numbericTypes.add(byte.class);
	}

	/**
	 * 判断是不是数字类型
	 * 
	 * @param type
	 *            ，类型
	 * @return，是否数字类型
	 */
	public static boolean isNumbericType(Class<?> type) {
		for (Class<?> numbericType : numbericTypes) {
			if (numbericType.equals(type)) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 是否包含方法
	 * 
	 * @param type
	 *            ，类型
	 * @param methodName
	 *            ，方法名称
	 * @return，是否包含
	 */
	public static boolean containsMethod(Class<?> type, String methodName) {
		Method[] methods = type.getDeclaredMethods();
		for (Method method : methods) {
			if (methodName.equalsIgnoreCase(method.getName())) {
				return true;
			}
		}

		return false;
	}

	/**
	 * 获取方法
	 * 
	 * @param type
	 *            ，类型
	 * @param methodName
	 *            ，方法名称
	 * @return，方法
	 */
	public static Method getMethod(Class<?> type, String methodName) {
		Method[] methods = type.getDeclaredMethods();
		for (Method method : methods) {
			if (methodName.equalsIgnoreCase(method.getName())) {
				return method;
			}
		}

		return null;
	}

	/**
	 * 从外部程序集创建类型的对象
	 * 
	 * @param assemblyFilePath
	 *            ，程序集文件所在的路径
	 * @param typeFullName
	 *            ，类型的全名，如果是内部类则无法创建
	 * @return，创建的对象
	 */
	public static Object createInstance(String assemblyFilePath,
			String typeFullName) {
		File file = new File(assemblyFilePath);
		try {
			try (URLClassLoader loader = new URLClassLoader(new URL[] { file
					.toURI().toURL() }, ClassLoader.getSystemClassLoader())) {
				return loader.loadClass(typeFullName).newInstance();
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 设置对象的字段，私有字段可以通过这种方法赋值
	 * 
	 * @param obj
	 *            ，对象
	 * @param name
	 *            ，字段名称
	 * @param value
	 *            ，字段值，如果与字段类型不匹配，则抛出异常
	 */
	public static void setFieldValue(Object obj, String fieldName, Object value) {
		Class<?> c = obj.getClass();
		Field field = getField(c, fieldName);
		field.setAccessible(true);
		try {
			field.set(obj, value);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获取对象指定字段的值
	 * 
	 * @param obj
	 *            ，对象
	 * @param fieldName
	 *            ，字段名
	 * @return，绑定标志
	 */
	public static Object getFieldValue(Object obj, String fieldName) {
		Class<?> c = obj.getClass();
		Field field = getField(c, fieldName);
		field.setAccessible(true);
		try {
			return field.get(obj);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 获得拥有某种特性标识的某种类型的字段集合，包括公共字段和非公共字段
	 * 
	 * @param type
	 *            ，要反射的类型
	 * @param attributeType
	 *            ，绑定标志
	 * @return，字段的数组
	 */
	public static Field[] getFieldsWithAttribute(Class<?> type,
			Class<? extends Annotation> attributeType) {
		Field[] fields = getFields(type);
		ArrayList<Field> result = new ArrayList<Field>();
		for (int i = 0; i < fields.length; i++) {
			Field field = fields[i];
			field.setAccessible(true);
			try {
				Annotation annotation = field.getAnnotation(attributeType);
				if (annotation != null) {
					result.add(field);
				}
			} catch (Exception err) {
			}
		}
		return SmartArray.toArray(result);
	}

	/**
	 * 获得对象字段值的列表
	 * 
	 * @param obj
	 *            ，对象
	 * @return，字段值列表
	 */
	public static HashMap<String, Object> getFieldsDictionary(Object obj) {
		HashMap<String, Object> dictionary = new HashMap<String, Object>();

		Field[] fields = getFields(obj.getClass());

		for (Field fieldInfo : fields) {
			String key = fieldInfo.getName();
			Object value = getFieldValue(obj, key);
			dictionary.put(key, value);
		}

		return dictionary;
	}

	/**
	 * 通过反射调用对象的方法，并返回值
	 * 
	 * @param target
	 *            ，对象
	 * @param methodName
	 *            ，方法名，区分大小写
	 * @param args
	 *            ，方法的参数数组
	 * @return，方法调用返回的结果
	 */
	public static Object methodInvoke(Object target, String methodName,
			Object[] args) {
		Class<?> c = target.getClass();
		Method method = getMethod(c, methodName);
		try {
			if (args == null) {
				return method.invoke(target);
			} else {
				return method.invoke(target, args);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 通过反射调用对象的方法，并返回值
	 * 
	 * @param target
	 *            ，对象
	 * @param methodName
	 *            ，方法名，区分大小写
	 * @return，方法调用返回的结果
	 */
	public static Object methodInvoke(Object target, String methodName) {
		return methodInvoke(target, methodName, null);
	}

	/**
	 * 通过成员的简单拷贝进行对象克隆。实现浅表复制，只实现第一层成员的克隆。某些成员克隆失败，不会影响其他成员的克隆
	 * 
	 * @param source
	 *            ，源对象
	 * @return，新的克隆对象
	 */
	public static Object membersSimpleClone(Object source) {
		Class<?> type = source.getClass();
		Object result = createInstance(type);
		return membersSimpleCopy(source, result);
	}

	/**
	 * 通过成员的简单拷贝进行对象复制。实现浅表复制，只实现第一层成员的复制。某些成员复制失败，不会影响其他成员的复制
	 * 
	 * @param source
	 *            ，源对象
	 * @param target
	 *            ，目标对象
	 * @return，新的复制对象
	 */
	public static Object membersSimpleCopy(Object source, Object target) {
		Class<?> typeSource = source.getClass();
		Class<?> typeTarget = target.getClass();

		Field[] fields = getFields(typeTarget);
		for (Field fieldInfoTarget : fields) {
			String fieldName = fieldInfoTarget.getName();
			if (containsField(typeSource, fieldName)) {
				try {
					Object value = getFieldValue(source, fieldName);
					setFieldValue(target, fieldName, value);
				} catch (Exception err) {
				}
			}
		}

		return target;
	}

	/**
	 * 判断两个对象是否相等，可以比较两个对象中有null的情况，两个都为null认为是相等的
	 * 
	 * @param left
	 *            ，要比较的对象
	 * @param right
	 *            ，要比较的对象
	 * @return，比较的结果
	 */
	public static boolean equalsWithNull(Object left, Object right) {
		if (left == null && right == null) {
			return true;
		}
		return (left != null) && (right != null) && left.equals(right);
	}

	/**
	 * 简单成员比较，如果成员相等，则认为是相等。类型不同的两个对象也可以比较，主要相同名称的成员相等就认为是相等
	 * 
	 * @param source
	 *            ，源对象
	 * @param target
	 *            ，目标对象
	 * @return
	 */
	public static boolean membersSimpleCompare(Object source, Object target) {
		Class<?> typeSource = source.getClass();
		Class<?> typeTarget = target.getClass();

		Field[] fields = getFields(typeSource);
		for (Field fieldInfoTarget : fields) {
			String fieldName = fieldInfoTarget.getName();
			// 存在相同的属性才去比较
			if (containsField(typeTarget, fieldName)) {
				Object sourceValue = getFieldValue(source, fieldName);

				Object targetValue = getFieldValue(target, fieldName);
				if (!equalsWithNull(sourceValue, targetValue)) {
					return false;
				}
			}
		}

		return true;
	}

	/**
	 * 是否可枚举类型
	 * 
	 * @param type
	 *            ，类型
	 * @return，结果
	 */
	public static boolean isEnumerable(Class<?> type) {
		return Iterable.class.isAssignableFrom(type);
	}

	/**
	 * 是否集合类型
	 * 
	 * @param type
	 *            ，类型
	 * @return，结果
	 */
	public static boolean isCollection(Class<?> type) {
		return Collection.class.isAssignableFrom(type);
	}

	/**
	 * 是否字典类型
	 * 
	 * @param type
	 *            ，类型
	 * @return，结果
	 */
	public static boolean isDictionary(Class<?> type) {
		return HashMap.class.isAssignableFrom(type);
	}

	/**
	 * 是否数组类型
	 * 
	 * @param type
	 *            ，类型
	 * @return，结果
	 */
	public static boolean isArray(Class<?> type) {
		return type.isArray();
	}

	/**
	 * 是否实现某个接口
	 * 
	 * @param type
	 *            ，类型
	 * @param interfaceType
	 *            ，接口类型
	 * @return，结果
	 */
	public static boolean isInterface(Class<?> type, Class<?> interfaceType) {
		Class<?>[] cs = type.getInterfaces();
		for (Class<?> c : cs) {
			if (c.equals(interfaceType)) {
				return true;
			}
		}
		return false;
	}
}
