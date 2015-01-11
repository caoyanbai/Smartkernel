/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.lang.reflect.*;
import java.util.*;

/**
 * 对象辅助类
 * 
 */
public class SmartObject {
	@SuppressWarnings("rawtypes")
	private static final HashMap<Class, Integer> TypeSizes = InitializeTypeSizes();

	@SuppressWarnings("rawtypes")
	private static HashMap<Class, Integer> InitializeTypeSizes() {
		HashMap<Class, Integer> dictionary = new HashMap<Class, Integer>();

		dictionary.put(Date.class, 8);
		dictionary.put(SmartEmptyObject.class, 8);
		dictionary.put(long.class, 8);
		dictionary.put(Long.class, 8);
		dictionary.put(int.class, 4);
		dictionary.put(Integer.class, 4);
		dictionary.put(short.class, 2);
		dictionary.put(Short.class, 2);
		dictionary.put(float.class, 4);
		dictionary.put(Float.class, 4);
		dictionary.put(double.class, 8);
		dictionary.put(Double.class, 8);
		dictionary.put(byte.class, 1);
		dictionary.put(Byte.class, 1);
		dictionary.put(char.class, 1);
		dictionary.put(Character.class, 1);

		return dictionary;
	}

	/**
	 * 确定对象的大小
	 * 
	 * @param obj
	 *            ，对象
	 * @return，结果
	 */
	@SuppressWarnings("rawtypes")
	public static int sizeOf(Object obj) {
		try {
			int size = 0;

			if (obj != null) {
				Queue<Object> objects = new LinkedList<Object>();
				Queue<Object> done = new LinkedList<Object>();

				objects.offer(obj);

				while (objects.size() > 0) {
					Object target = objects.poll();
					int targetSize = -1;

					done.offer(target);

					if (target == null) {
						targetSize = 0;
					} else {
						try {
							Class targetType = target.getClass();

							if (TypeSizes.containsKey(targetType)) {
								if (targetSize == -1) {
									targetSize = 0;
								}

								targetSize += TypeSizes.get(targetType);
							} else {
								targetSize = -2;
							}
						} catch (Exception err) {
							targetSize = -2;
						}
					}

					if (target != null && targetSize < 0) {
						Class targetType = target.getClass();
						Field[] fields = targetType.getFields();

						for (Field f : fields) {
							f.setAccessible(true);
							Object fieldValue = f.get(target);

							if (fieldValue != null
									&& !objects.contains(fieldValue)
									&& !done.contains(fieldValue)) {
								objects.offer(fieldValue);
							}
						}

						if (target instanceof Iterable) {
							if (target instanceof String) {
								String targetAsString = (String) target;
								size += targetAsString.length();
							} else {
								Iterable targetEnumerable = (Iterable) target;

								for (Object item : targetEnumerable) {
									if (item != null && !objects.contains(item)
											&& !done.contains(item)) {
										objects.offer(item);
									}
								}
							}
						}
					} else {
						size += targetSize;
					}
				}

				objects.clear();
				done.clear();
			}

			return size;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 是否是默认值
	 * 
	 * @param obj
	 *            ，类型
	 * @return，对象
	 */
	public static <T> boolean isDefaultValue(T obj) {
		if (obj instanceof Number) {
			return SmartNumeric.isZero(((Number) obj).doubleValue());
		} else if (obj instanceof Boolean) {
			return (Boolean) obj == false;
		} else {
			if (obj == null) {
				return true;
			} else {
				return false;
			}
		}
	}
}
