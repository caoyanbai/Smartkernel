/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework;

import java.io.*;
import java.util.*;
import java.util.zip.*;

/**
 * 电话
 * 
 */
public class SmartMobilePhone {
	/**
	 * 所有
	 */
	public static final HashMap<Integer, SmartMobilePhone> All = new HashMap<Integer, SmartMobilePhone>();

	private int mobilePhone;

	private String country;

	private String province;

	private String city;

	private String type;

	/**
	 * 静态构造函数
	 * 
	 */
	static {
		try (InputStream inputStream = new SmartMobilePhone().getClass()
				.getResourceAsStream(
						"/smartkernel/framework/resources/MobilePhone.gz");
				GZIPInputStream gzipInputStream = new GZIPInputStream(
						inputStream);
				BufferedReader bufferedReader = new BufferedReader(
						new InputStreamReader(gzipInputStream, "utf8"))) {
			String line = "";
			while ((line = bufferedReader.readLine()) != null) {
				try {
					String[] fileds = line.split("\\^");
					SmartMobilePhone mobilePhone = new SmartMobilePhone();
					mobilePhone.setMobilePhone(Integer.parseInt(fileds[0]));
					mobilePhone.setCountry(fileds[1]);
					mobilePhone.setProvince(fileds[2]);
					mobilePhone.setCity(fileds[3]);
					mobilePhone.setType(fileds[4]);
					All.put(mobilePhone.getMobilePhone(), mobilePhone);
				} catch (Exception err) {

				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 找到电话信息
	 * 
	 * @param mobilePhone
	 *            ，电话
	 * @return，结果
	 */
	public static SmartMobilePhone find(String mobilePhone) {
		try {
			return All.get(Integer.parseInt(mobilePhone.substring(0, 7)));
		} catch (Exception err) {
		}
		return null;
	}

	/**
	 * 电话（前7位）
	 * 
	 * @return，电话（前7位）
	 */
	public int getMobilePhone() {
		return mobilePhone;
	}

	/**
	 * 电话（前7位）
	 * 
	 * @param mobilePhone
	 *            ，电话（前7位）
	 */
	public void setMobilePhone(int mobilePhone) {
		this.mobilePhone = mobilePhone;
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

	/**
	 * 类型
	 * 
	 * @return，类型
	 */
	public String getType() {
		return type;
	}

	/**
	 * 类型
	 * 
	 * @param type
	 *            ，类型
	 */
	public void setType(String type) {
		this.type = type;
	}
}
