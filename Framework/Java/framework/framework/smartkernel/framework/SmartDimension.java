/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.text.*;
import java.util.*;

/**
 * 维度
 * 
 */
public class SmartDimension {
	/**
	 * 获得可能
	 * 
	 * @param totalCount
	 *            ，总维度数
	 * @param joinCount
	 *            ，参与维度数（几个为true）
	 * @return，结果
	 */
	public static ArrayList<HashMap<Integer, Boolean>> getPossibly(
			int totalCount, int joinCount) {
		ArrayList<HashMap<Integer, Boolean>> result = new ArrayList<HashMap<Integer, Boolean>>();

		String maxFormat = "";
		String minFormat = "";

		for (int i = 0; i < totalCount; i++) {
			maxFormat = maxFormat + "1";
			minFormat = minFormat + "0";
		}

		int max = Integer.parseInt(maxFormat, 2);
		int min = Integer.parseInt(minFormat, 2);

		int count = 0;

		for (int i = min; i < max; i++) {
			count = 0;
			String current = new DecimalFormat(minFormat).format(Integer
					.parseInt(Integer.toBinaryString(i), 2));
			char[] array = current.toCharArray();
			HashMap<Integer, Boolean> item = new HashMap<Integer, Boolean>();

			for (int j = 0; j < array.length; j++) {
				if (array[j] == '1') {
					count++;
				}
				item.put(j, array[j] == '1');
			}
			if (count == joinCount) {
				result.add(item);
			}
		}

		return result;
	}
}
