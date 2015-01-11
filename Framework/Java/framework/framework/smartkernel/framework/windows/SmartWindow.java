/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.windows;

import java.awt.*;
import java.awt.image.*;

/**
 * 窗口操作相关
 * 
 */
public class SmartWindow {
	/**
	 * 获得屏幕截图
	 * 
	 * @return，屏幕截图
	 */
	public static BufferedImage captureScreen() {
		try {
			Rectangle screenRect = new Rectangle(Toolkit.getDefaultToolkit()
					.getScreenSize());
			BufferedImage capture = new Robot().createScreenCapture(screenRect);
			return capture;
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
