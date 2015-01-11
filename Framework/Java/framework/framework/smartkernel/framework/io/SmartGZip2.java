/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.io;

import java.io.*;
import java.util.zip.*;

/**
 * GZip2（支持压缩之后保存文件名信息）
 *
 */
public class SmartGZip2 {
	/**
	 * 压缩文件
	 * 
	 * @param fileIn
	 *            ，输入文件
	 * @param fileOut
	 *            ，输出文件
	 */
	public static void compress(String fileIn, String fileOut) {
        fileIn = SmartFile.getFormatFilePath(fileIn);
        fileOut = SmartFile.getFormatFilePath(fileOut);
        
		try (FileInputStream fileStreamReader = new FileInputStream(fileIn)) {
			try (FileOutputStream fileStreamWriter = new FileOutputStream(
					fileOut)) {
				try (ZipOutputStream zipOutputStream = new ZipOutputStream(
						fileStreamWriter)) {
					ZipEntry zipEntry = new ZipEntry(
							SmartPath.getFileName(fileIn));
					zipOutputStream.putNextEntry(zipEntry);

					int data = -1;
					while ((data = fileStreamReader.read()) != -1) {
						zipOutputStream.write(data);
					}
				}
			}
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
