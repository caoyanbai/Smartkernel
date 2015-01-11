/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

import java.sql.*;
import java.util.*;
import java.util.Date;
import java.util.Map.*;

import javax.sql.rowset.*;

import smartkernel.framework.*;

/**
 * SQLite（jdbc:sqlite:C:/test.db）
 * 
 */
public class SmartSQLite {
	private static void handleParameters(
			SmartNamedParameterStatement namedParameterStatement,
			HashMap<String, Object> parameters) {
		if (parameters != null) {
			Iterator<Entry<String, Object>> iterator = parameters.entrySet()
					.iterator();
			while (iterator.hasNext()) {
				Entry<String, Object> entry = iterator.next();
				String name = entry.getKey();
				Object value = entry.getValue();

				if (value instanceof Long) {
					namedParameterStatement.setLong(name, (Long) value);
				} else if (value instanceof Integer) {
					namedParameterStatement.setInt(name, (Integer) value);
				} else if (value instanceof String) {
					namedParameterStatement.setString(name, (String) value);
				} else if (value instanceof Date) {
					namedParameterStatement.setString(name, SmartDateTime
							.format((Date) value, "yyyy-MM-dd HH:mm:ss.SSS"));
				} else {
					namedParameterStatement.setObject(name, value);
				}
			}
		}
	}

	/**
	 * 执行INSERT、UPDATE、DELETE以及不返回数据集的存储过程
	 * 
	 * @param connectionString
	 *            ，数据库连接字符串
	 * @param sentence
	 *            ，Sql命令或存储过程名
	 * @param parameters
	 *            ，参数数组
	 * @return，影响的行数
	 */
	public static int executeNonQuery(String connectionString, String sentence,
			HashMap<String, Object> parameters) {
		try (Connection connection = DriverManager
				.getConnection(connectionString);
				SmartNamedParameterStatement namedParameterStatement = new SmartNamedParameterStatement(
						connection, sentence)) {
			handleParameters(namedParameterStatement, parameters);
			return namedParameterStatement.executeUpdate();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 执行INSERT、UPDATE、DELETE以及不返回数据集的存储过程
	 * 
	 * @param connectionString
	 *            ，数据库连接字符串
	 * @param sentence
	 *            ，Sql命令或存储过程名
	 * @return，影响的行数
	 */
	public static int executeNonQuery(String connectionString, String sentence) {
		return executeNonQuery(connectionString, sentence, null);
	}

	/**
	 * 返回数据集的第一行第一列。数据库中为Null或空，都返回Null
	 * 
	 * @param connectionString
	 *            ，数据库连接字符串
	 * @param sentence
	 *            ，Sql命令或存储过程名
	 * @param parameters
	 *            ，参数数组
	 * @return，数据集的第一行第一列
	 */
	public static Object executeScalar(String connectionString,
			String sentence, HashMap<String, Object> parameters) {
		try (Connection connection = DriverManager
				.getConnection(connectionString);
				SmartNamedParameterStatement namedParameterStatement = new SmartNamedParameterStatement(
						connection, sentence)) {
			handleParameters(namedParameterStatement, parameters);
			try (ResultSet resultSet = namedParameterStatement.executeQuery()) {
				if (resultSet.next()) {
					return resultSet.getObject(1);
				} else {
					return null;
				}
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 返回数据集的第一行第一列。数据库中为Null或空，都返回Null
	 * 
	 * @param connectionString
	 *            ，数据库连接字符串
	 * @param sentence
	 *            ，Sql命令或存储过程名
	 * @return，数据集的第一行第一列
	 */
	public static Object executeScalar(String connectionString, String sentence) {
		return executeScalar(connectionString, sentence, null);
	}

	/**
	 * 填充数据集
	 * 
	 * @param connectionString
	 *            ，数据库连接字符串
	 * @param sentence
	 *            ，Sql语句或存储过程名
	 * @param parameters
	 *            ，参数数组
	 * @return，结果
	 */
	public static CachedRowSet fill(String connectionString, String sentence,
			HashMap<String, Object> parameters) {
		try (Connection connection = DriverManager
				.getConnection(connectionString);
				SmartNamedParameterStatement namedParameterStatement = new SmartNamedParameterStatement(
						connection, sentence)) {
			handleParameters(namedParameterStatement, parameters);
			try (ResultSet resultSet = namedParameterStatement.executeQuery()) {
				CachedRowSet cachedRowSet = RowSetProvider.newFactory()
						.createCachedRowSet();
				cachedRowSet.populate(resultSet);
				return cachedRowSet;
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 填充数据集
	 * 
	 * @param connectionString
	 *            ，数据库连接字符串
	 * @param sentence
	 *            ，Sql语句或存储过程名
	 * @return，结果
	 */
	public static CachedRowSet fill(String connectionString, String sentence) {
		return fill(connectionString, sentence, null);
	}
}
