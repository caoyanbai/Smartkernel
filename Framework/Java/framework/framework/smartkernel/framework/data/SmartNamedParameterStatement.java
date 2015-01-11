/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.data;

import java.sql.*;
import java.util.*;
import java.util.Map.*;
import java.sql.Date;

public class SmartNamedParameterStatement implements AutoCloseable {

	private PreparedStatement statement;

	private Map<String, int[]> indexMap;

	/**
	 * 构造函数
	 * 
	 * @param connection
	 *            ，链接
	 * @param query
	 *            ，查询语句
	 */
	public SmartNamedParameterStatement(Connection connection, String query) {
		try {
			indexMap = new HashMap<String, int[]>();
			String parsedQuery = parse(query, indexMap);
			statement = connection.prepareStatement(parsedQuery);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 解析
	 * 
	 * @param query
	 *            ，查询语句
	 * @param paramMap
	 *            ，参数对
	 * @return，结果
	 */
	static final String parse(String query, Map<String, int[]> paramMap) {
		Map<String, List<Integer>> paramMapAux = new HashMap<String, List<Integer>>();
		int length = query.length();
		StringBuffer parsedQuery = new StringBuffer(length);
		boolean inSingleQuote = false;
		boolean inDoubleQuote = false;
		int index = 1;

		for (int i = 0; i < length; i++) {
			char c = query.charAt(i);
			if (inSingleQuote) {
				if (c == '\'') {
					inSingleQuote = false;
				}
			} else if (inDoubleQuote) {
				if (c == '"') {
					inDoubleQuote = false;
				}
			} else {
				if (c == '\'') {
					inSingleQuote = true;
				} else if (c == '"') {
					inDoubleQuote = true;
				} else if ((c == ':' || c == '@') && i + 1 < length
						&& Character.isJavaIdentifierStart(query.charAt(i + 1))) {
					int j = i + 2;
					while (j < length
							&& Character.isJavaIdentifierPart(query.charAt(j))) {
						j++;
					}
					String name = query.substring(i + 1, j);
					c = '?';
					i += name.length();

					List<Integer> indexList = paramMapAux.get(name);
					if (indexList == null) {
						indexList = new LinkedList<Integer>();
						paramMapAux.put(name, indexList);
					}
					indexList.add(index);

					index++;
				}
			}
			parsedQuery.append(c);
		}

		Set<Entry<String, List<Integer>>> set = paramMapAux.entrySet();
		for (Map.Entry<String, List<Integer>> entry : set) {
			List<Integer> list = entry.getValue();
			int[] indexes = new int[list.size()];
			int i = 0;
			for (Integer x : list) {
				indexes[i++] = x;
			}
			paramMap.put(entry.getKey(), indexes);
		}

		return parsedQuery.toString();
	}

	/**
	 * 获取参数索引
	 * 
	 * @param name
	 *            ，参数名
	 * @return，结果
	 */
	private int[] getIndexes(String name) {
		int[] indexes = indexMap.get(name);
		if (indexes == null) {
			throw new RuntimeException("找不到参数：" + name);
		}
		return indexes;
	}

	/**
	 * 设置参数对
	 * 
	 * @param name
	 *            ，参数名
	 * @param value
	 *            ，值
	 */
	public void setObject(String name, Object value) {
		int[] indexes = getIndexes(name);
		for (int i = 0; i < indexes.length; i++) {
			try {
				statement.setObject(indexes[i], value);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 设置参数对
	 * 
	 * @param name
	 *            ，参数名
	 * @param value
	 *            ，值
	 */
	public void setString(String name, String value) {
		int[] indexes = getIndexes(name);
		for (int i = 0; i < indexes.length; i++) {
			try {
				statement.setString(indexes[i], value);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 设置参数对
	 * 
	 * @param name
	 *            ，参数名
	 * @param value
	 *            ，值
	 */
	public void setInt(String name, int value) {
		int[] indexes = getIndexes(name);
		for (int i = 0; i < indexes.length; i++) {
			try {
				statement.setInt(indexes[i], value);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 设置参数对
	 * 
	 * @param name
	 *            ，参数名
	 * @param value
	 *            ，值
	 */
	public void setLong(String name, long value) {
		int[] indexes = getIndexes(name);
		for (int i = 0; i < indexes.length; i++) {
			try {
				statement.setLong(indexes[i], value);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 设置参数对
	 * 
	 * @param name
	 *            ，参数名
	 * @param value
	 *            ，值
	 */
	public void setTimestamp(String name, Timestamp value) {
		int[] indexes = getIndexes(name);
		for (int i = 0; i < indexes.length; i++) {
			Date date = new Date(value.getTime());
			try {
				statement.setDate(indexes[i], date);
			} catch (Exception err) {
				throw new RuntimeException(err);
			}
		}
	}

	/**
	 * 获取PreparedStatement
	 * 
	 * @return，结果
	 */
	public PreparedStatement getStatement() {
		return statement;
	}

	/**
	 * 执行
	 * 
	 * @return，结果
	 */
	public boolean execute() {
		try {
			return statement.execute();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 执行
	 * 
	 * @return，结果
	 */
	public ResultSet executeQuery() {
		try {
			statement.setFetchSize(1000);
			return statement.executeQuery();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 执行
	 * 
	 * @return，结果
	 */
	public int executeUpdate() {
		try {
			return statement.executeUpdate();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 关闭
	 */
	public void close() {
		try {
			statement.close();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * addBatch
	 */
	public void addBatch() {
		try {
			statement.addBatch();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 执行
	 * 
	 * @return，结果
	 */
	public int[] executeBatch() {
		try {
			return statement.executeBatch();
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
