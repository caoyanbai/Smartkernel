/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.svn;

import java.io.*;
import java.util.*;

/**
 * Svn数据项
 * 
 */
public class SmartSvnItem implements Serializable {

	private static final long serialVersionUID = 1L;
	
	private String path;
	private Date lastModifyTime;
	private String lastModifyUser;

	/**
	 * 获取文件地址
	 * 
	 * @return，结果
	 */
	public String getPath() {
		return path;
	}

	void setPath(String path) {
		this.path = path;
	}

	/**
	 * 获取最后更新时间
	 * 
	 * @return，结果
	 */
	public Date getLastModifyTime() {
		return lastModifyTime;
	}

	void setLastModifyTime(Date lastModifyTime) {
		this.lastModifyTime = lastModifyTime;
	}

	/**
	 * 获取最后更新人
	 * 
	 * @return，结果
	 */
	public String getLastModifyUser() {
		return lastModifyUser;
	}

	void setLastModifyUser(String lastModifyUser) {
		this.lastModifyUser = lastModifyUser;
	}
}
