/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.net;

import java.io.*;
import java.util.*;
import java.util.zip.*;

/**
 * 电话
 * 
 */
public class SmartIPRegion {
	/**
	 * 所有
	 */
	public static final HashMap<Integer, SmartIPRegion> All = new HashMap<Integer, SmartIPRegion>();

	private String country;

	private String province;

	private String city;


	/**
	 * 静态构造函数
	 * 
	 */
	static {
		try (InputStream inputStream = new SmartIPRegion().getClass()
				.getResourceAsStream(
						"/smartkernel/framework/resources/IPRegion.gz");
				GZIPInputStream gzipInputStream = new GZIPInputStream(
						inputStream);
				BufferedReader bufferedReader = new BufferedReader(
						new InputStreamReader(gzipInputStream, "utf8"))) {
			String line = "";
			while ((line = bufferedReader.readLine()) != null) {
				try {
					String[] fileds = line.split("\\^");
					SmartIPRegion ipRegion = new SmartIPRegion();
					ipRegion.setID(Integer.parseInt(fileds[0]));
					ipRegion.setStartValue(Long.parseLong(fileds[1]));
					ipRegion.setEndValue(Long.parseLong(fileds[2]));
					ipRegion.setCountry(fileds[3]);
					ipRegion.setProvince(fileds[4]);
					ipRegion.setCity(fileds[5]);
					ipRegion.setStartIP(fileds[6]);
					ipRegion.setEndIP(fileds[7]);
					All.put(ipRegion.getID(), ipRegion);
				} catch (Exception err) {

				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 同过IP的数字找到一个包含该IP数字的区间
	 * 
	 * @param ipNumber
	 *            ，IP数字
	 * @return，结果
	 */
	private static int findID(long ipNumber) {
		if (ipNumber <= 0) {
			return 0;
		}
		int firstID = 1;
		int lastID = All.size();
		int resultID = -1;
		int middleID = 0;

		while (firstID <= lastID) {
			middleID = (firstID + lastID) / 2;

			SmartIPRegion current = All.get(middleID);

			if (ipNumber > current.getEndValue()) {
				firstID = middleID + 1;
			} else if (ipNumber < current.getStartValue()) {
				lastID = middleID - 1;
			} else {
				resultID = middleID;
				break;
			}
		}
		if (resultID > 0) {
			return resultID;
		} else {
			return 0;
		}
	}

	/**
	 * 同过IP的数字找到一个包含该IP数字的区间
	 * 
	 * @param ipNumber
	 *            ，IP数字
	 * @return，结果
	 */
	public static SmartIPRegion find(long ipNumber) {
		try {
			return All.get(findID(ipNumber));
		} catch (Exception err) {
		}
		return null;
	}

	private int id;

	/**
	 * 编号
	 * 
	 * @return，编号
	 */
	public int getID() {
		return id;
	}

	/**
	 * 编号
	 * 
	 * @param id
	 *            ，编号
	 */
	public void setID(int id) {
		this.id = id;
	}

	private long startValue;

	/**
	 * 开始值
	 * 
	 * @return，开始值
	 */
	public long getStartValue() {
		return startValue;
	}

	/**
	 * 开始值
	 * 
	 * @param startValue
	 *            ，开始值
	 */
	public void setStartValue(long startValue) {
		this.startValue = startValue;
	}

	private long endValue;

	/**
	 * 结束值
	 * 
	 * @return，结束值
	 */
	public long getEndValue() {
		return endValue;
	}

	/**
	 * 结束值
	 * 
	 * @param endValue
	 *            ，结束值
	 */
	public void setEndValue(long endValue) {
		this.endValue = endValue;
	}

	/**
	 * 国家
	 * 
	 * @return，国家
	 */
	public String getCountry() {
		return country;
	}

	/**
	 * 国家
	 * 
	 * @param country
	 *            ，国家
	 */
	public void setCountry(String country) {
		this.country = country;
	}

	/**
	 * 省份
	 * 
	 * @return，省份
	 */
	public String getProvince() {
		return province;
	}

	/**
	 * 省份
	 * 
	 * @param province
	 *            ，省份
	 */
	public void setProvince(String province) {
		this.province = province;
	}

	/**
	 * 城市
	 * 
	 * @return，城市
	 */
	public String getCity() {
		return city;
	}

	/**
	 * 城市
	 * 
	 * @param city
	 *            ，城市
	 */
	public void setCity(String city) {
		this.city = city;
	}

	private String startIP;

	/**
	 * 开始IP
	 * 
	 * @return，开始IP
	 */
	public String getStartIP() {
		return startIP;
	}

	/**
	 * 开始IP
	 * 
	 * @param startIP
	 *            ，开始IP
	 */
	public void setStartIP(String startIP) {
		this.startIP = startIP;
	}

	private String endIP;

	/**
	 * 结束IP
	 * 
	 * @return，结束IP
	 */
	public String getEndIP() {
		return endIP;
	}

	/**
	 * 结束IP
	 * 
	 * @param endIP
	 *            ，结束IP
	 */
	public void setEndIP(String endIP) {
		this.endIP = endIP;
	}
}
