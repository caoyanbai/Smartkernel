/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.drawing;

import java.awt.*;

import smartkernel.framework.*;

/**
 * Color相关
 * 
 */
public class SmartColor {
	private static final int shadowAdj = -333;

	private static final int hilightAdj = 500;

	private static final int hlsMax = 240;

	private static final int rgbMax = 0xff;

	private static final int undefined = 160;

	private static void calculateHls(Color color, SmartRef<Integer> hue,
			SmartRef<Integer> luminosity, SmartRef<Integer> saturation) {
		int r = color.getRed();
		int g = color.getGreen();
		int b = color.getBlue();
		int max = Math.max(Math.max(r, g), b);
		int min = Math.min(Math.min(r, g), b);
		int maxPlusMin = max + min;
		luminosity.setValue(((maxPlusMin * hlsMax) + rgbMax) / 510);
		int maxMinusMin = max - min;
		if (maxMinusMin == 0) {
			saturation.setValue(0);
			;
			hue.setValue(undefined);
			;
		} else {
			if (luminosity.getValue() <= 120) {
				saturation.setValue(((maxMinusMin * hlsMax) + (maxPlusMin / 2))
						/ maxPlusMin);
			} else {
				saturation
						.setValue(((maxMinusMin * hlsMax) + ((510 - maxPlusMin) / 2))
								/ (510 - maxPlusMin));
			}
			int rMax = (((max - r) * 40) + (maxMinusMin / 2)) / maxMinusMin;
			int gMax = (((max - g) * 40) + (maxMinusMin / 2)) / maxMinusMin;
			int bMax = (((max - b) * 40) + (maxMinusMin / 2)) / maxMinusMin;
			if (r == max) {
				hue.setValue(bMax - gMax);
			} else if (g == max) {
				hue.setValue((80 + rMax) - bMax);
			} else {
				hue.setValue((undefined + gMax) - rMax);
			}
			if (hue.getValue() < 0) {
				hue.setValue(hue.getValue() + hlsMax);
			}
			if (hue.getValue() > hlsMax) {
				hue.setValue(hue.getValue() - hlsMax);
			}
		}
	}

	private static Color getColorFromHls(int hue, int luminosity, int saturation) {
		byte r;
		byte g;
		byte b;
		if (saturation == 0) {
			r = g = b = (byte) ((luminosity * 0xff) / hlsMax);
		} else {
			int n2;
			if (luminosity <= 120) {
				n2 = ((luminosity * (hlsMax + saturation)) + 120) / hlsMax;
			} else {
				n2 = (luminosity + saturation)
						- (((luminosity * saturation) + 120) / hlsMax);
			}
			int n1 = (2 * luminosity) - n2;
			r = (byte) (((hueToRgb(n1, n2, hue + 80) * 0xff) + 120) / hlsMax);
			g = (byte) (((hueToRgb(n1, n2, hue) * 0xff) + 120) / hlsMax);
			b = (byte) (((hueToRgb(n1, n2, hue - 80) * 0xff) + 120) / hlsMax);
		}
		return new Color(r, g, b);
	}

	private static int newLuma(int luminosity, int n, boolean scale) {
		if (n == 0) {
			return luminosity;
		}
		if (scale) {
			if (n > 0) {
				return (int) (((luminosity * (0x3e8 - n)) + (0xf1 * n)) / ((long) 0x3e8));
			}
			return ((luminosity * (n + 0x3e8)) / 0x3e8);
		}
		int result = luminosity;
		result += (int) ((n * hlsMax) / ((long) 0x3e8));
		if (result < 0) {
			result = 0;
		}
		if (result > hlsMax) {
			result = hlsMax;
		}
		return result;
	}

	private static int hueToRgb(int n1, int n2, int hue) {
		if (hue < 0) {
			hue += hlsMax;
		}
		if (hue > hlsMax) {
			hue -= hlsMax;
		}
		if (hue < 40) {
			return (n1 + ((((n2 - n1) * hue) + 20) / 40));
		}
		if (hue < 120) {
			return n2;
		}
		if (hue < 160) {
			return (n1 + ((((n2 - n1) * (160 - hue)) + 20) / 40));
		}
		return n1;
	}

	/**
	 * 使颜色变暗
	 * 
	 * @param color
	 *            ，颜色
	 * @param factor
	 *            ，变暗的百分比
	 * @return，变暗之后的颜色
	 */
	public static Color darken(Color color, float factor) {
		SmartRef<Integer> hue = new SmartRef<Integer>(0);
		SmartRef<Integer> luminosity = new SmartRef<Integer>(0);
		SmartRef<Integer> saturation = new SmartRef<Integer>(0);
		calculateHls(color, hue, luminosity, saturation);
		int luma = newLuma(luminosity.getValue(), shadowAdj, true);
		return getColorFromHls(hue.getValue(), luma - ((int) (luma * factor)),
				saturation.getValue());
	}

	/**
	 * 使眼色变亮
	 * 
	 * @param color
	 *            ，颜色
	 * @param factor
	 *            ，变亮的百分比
	 * @return，变亮之后的颜色
	 */
	public static Color lighten(Color color, float factor) {
		SmartRef<Integer> hue = new SmartRef<Integer>(0);
		SmartRef<Integer> luminosity = new SmartRef<Integer>(0);
		SmartRef<Integer> saturation = new SmartRef<Integer>(0);
		calculateHls(color, hue, luminosity, saturation);
		int luma = newLuma(luminosity.getValue(), hilightAdj, true);
		return getColorFromHls(hue.getValue(), luminosity.getValue()
				+ ((int) ((luma - luminosity.getValue()) * factor)),
				saturation.getValue());
	}

	/**
	 * 获得十六进制字符串表示
	 * 
	 * @param color
	 *            ，颜色
	 * @return，字符串表示
	 */
	public static String toHex(Color color) {
		String r = Integer.toString(color.getRed(), 16);
		if (r.length() < 2) {
			r = "0" + r;
		}
		String g = Integer.toString(color.getGreen(), 16);
		if (g.length() < 2) {
			g = "0" + g;
		}
		String b = Integer.toString(color.getBlue(), 16);
		if (b.length() < 2) {
			b = "0" + b;
		}
		return SmartString.format("#{0}{1}{2}", r, g, b);
	}
}
