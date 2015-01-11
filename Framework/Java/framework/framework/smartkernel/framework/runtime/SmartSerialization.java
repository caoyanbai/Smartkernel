/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.runtime;

import java.io.*;

import smartkernel.framework.io.*;

/**
 * 序列化
 * 
 */
public class SmartSerialization {
	/**
	 * 克隆对象
	 * 
	 * @param obj
	 *            ，对象
	 * @return，克隆之后的对象
	 */
	public static <T> T clone(Object obj) {
		try (ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
				ObjectOutputStream objectOutputStream = new ObjectOutputStream(
						byteArrayOutputStream)) {
			serialize(obj, objectOutputStream);
			try (ObjectInputStream objectInputStream = new ObjectInputStream(
					SmartStream.convert(byteArrayOutputStream))) {
				return deserialize(objectInputStream);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 序列化过程
	 * 
	 * @param obj
	 *            ，准备序列化的对象
	 * @param stream
	 *            ，序列化对象写入的流
	 */
	public static void serialize(Object obj, ObjectOutputStream stream) {
		try {
			stream.writeObject(obj);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 序列化过程
	 * 
	 * @param obj
	 *            ，准备序列化的对象
	 * @param filePath
	 *            ，序列化写入的文件
	 */
	public static void serialize(Object obj, String filePath) {
		String directoryName = SmartPath.getDirectoryName(filePath);
		if (!SmartDirectory.exists(directoryName)) {
			SmartDirectory.createDirectory(directoryName);
		}
		try (ObjectOutputStream stream = new ObjectOutputStream(
				new FileOutputStream(filePath))) {
			serialize(obj, stream);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 反序列化过程
	 * 
	 * @param stream
	 *            ，序列化对象的流
	 * @return，返回反序列化的对象
	 */
	@SuppressWarnings("unchecked")
	public static <T> T deserialize(ObjectInputStream stream) {
		try {
			return (T) stream.readObject();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 反序列化过程
	 * 
	 * @param filePath
	 *            ，读取序列化数据的文件
	 * @return，返回反序列化的对象
	 */
	public static <T> T deserialize(String filePath) {
		try (ObjectInputStream stream = new ObjectInputStream(
				new FileInputStream(filePath))) {
			return deserialize(stream);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
