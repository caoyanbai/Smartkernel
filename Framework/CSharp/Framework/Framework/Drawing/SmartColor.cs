/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Drawing;

namespace Smartkernel.Framework.Drawing
{
    /// <summary>
    /// Color相关
    /// </summary>
    public static class SmartColor
    {
        private const int shadowAdj = -333;

        private const int hilightAdj = 500;

        private const int hlsMax = 240;

        private const int rgbMax = 0xff;

        private const int undefined = 160;

        private static void CalculateHls(Color color, out int hue, out int luminosity, out int saturation)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            var max = Math.Max(Math.Max(r, g), b);
            var min = Math.Min(Math.Min(r, g), b);
            var maxPlusMin = max + min;
            luminosity = ((maxPlusMin * hlsMax) + rgbMax) / 510;
            var maxMinusMin = max - min;
            if (maxMinusMin == 0)
            {
                saturation = 0;
                hue = undefined;
            }
            else
            {
                if (luminosity <= 120)
                {
                    saturation = ((maxMinusMin * hlsMax) + (maxPlusMin / 2)) / maxPlusMin;
                }
                else
                {
                    saturation = ((maxMinusMin * hlsMax) + ((510 - maxPlusMin) / 2)) / (510 - maxPlusMin);
                }
                var rMax = (((max - r) * 40) + (maxMinusMin / 2)) / maxMinusMin;
                var gMax = (((max - g) * 40) + (maxMinusMin / 2)) / maxMinusMin;
                var bMax = (((max - b) * 40) + (maxMinusMin / 2)) / maxMinusMin;
                if (r == max)
                {
                    hue = bMax - gMax;
                }
                else if (g == max)
                {
                    hue = (80 + rMax) - bMax;
                }
                else
                {
                    hue = (undefined + gMax) - rMax;
                }
                if (hue < 0)
                {
                    hue += hlsMax;
                }
                if (hue > hlsMax)
                {
                    hue -= hlsMax;
                }
            }
        }

        private static Color GetColorFromHls(int hue, int luminosity, int saturation)
        {
            byte r;
            byte g;
            byte b;
            if (saturation == 0)
            {
                r = g = b = (byte)((luminosity * 0xff) / hlsMax);
            }
            else
            {
                int n2;
                if (luminosity <= 120)
                {
                    n2 = ((luminosity * (hlsMax + saturation)) + 120) / hlsMax;
                }
                else
                {
                    n2 = (luminosity + saturation) - (((luminosity * saturation) + 120) / hlsMax);
                }
                var n1 = (2 * luminosity) - n2;
                r = (byte)(((HueToRgb(n1, n2, hue + 80) * 0xff) + 120) / hlsMax);
                g = (byte)(((HueToRgb(n1, n2, hue) * 0xff) + 120) / hlsMax);
                b = (byte)(((HueToRgb(n1, n2, hue - 80) * 0xff) + 120) / hlsMax);
            }
            return Color.FromArgb(r, g, b);
        }

        private static int NewLuma(int luminosity, int n, bool scale)
        {
            if (n == 0)
            {
                return luminosity;
            }
            if (scale)
            {
                if (n > 0)
                {
                    return (int)(((luminosity * (0x3e8 - n)) + (0xf1 * n)) / ((long)0x3e8));
                }
                return ((luminosity * (n + 0x3e8)) / 0x3e8);
            }
            var result = luminosity;
            result += (int)((n * hlsMax) / ((long)0x3e8));
            if (result < 0)
            {
                result = 0;
            }
            if (result > hlsMax)
            {
                result = hlsMax;
            }
            return result;
        }

        private static int HueToRgb(int n1, int n2, int hue)
        {
            if (hue < 0)
            {
                hue += hlsMax;
            }
            if (hue > hlsMax)
            {
                hue -= hlsMax;
            }
            if (hue < 40)
            {
                return (n1 + ((((n2 - n1) * hue) + 20) / 40));
            }
            if (hue < 120)
            {
                return n2;
            }
            if (hue < 160)
            {
                return (n1 + ((((n2 - n1) * (160 - hue)) + 20) / 40));
            }
            return n1;
        }

        /// <summary>
        /// 使颜色变暗
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="factor">变暗的百分比</param>
        /// <returns>变暗之后的颜色</returns>
        public static Color Darken(Color color, float factor)
        {
            int hue;
            int luminosity;
            int saturation;
            CalculateHls(color, out hue, out luminosity, out saturation);
            var luma = NewLuma(luminosity, shadowAdj, true);
            return GetColorFromHls(hue, luma - ((int)(luma * factor)), saturation);
        }

        /// <summary>
        /// 使眼色变亮
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="factor">变亮的百分比</param>
        /// <returns>变亮之后的颜色</returns>
        public static Color Lighten(Color color, float factor)
        {
            int hue;
            int luminosity;
            int saturation;
            CalculateHls(color, out hue, out luminosity, out saturation);
            var luma = NewLuma(luminosity, hilightAdj, true);
            return GetColorFromHls(hue, luminosity + ((int)((luma - luminosity) * factor)), saturation);
        }

        /// <summary>
        /// 获得十六进制字符串表示
        /// </summary>
        /// <param name="color">颜色</param>
        /// <returns>字符串表示</returns>
        public static string ToHex(Color color)
        {
            var r = Convert.ToString(color.R, 16);
            if (r.Length < 2)
            {
                r = "0" + r;
            }
            var g = Convert.ToString(color.G, 16);
            if (g.Length < 2)
            {
                g = "0" + g;
            }
            var b = Convert.ToString(color.B, 16);
            if (b.Length < 2)
            {
                b = "0" + b;
            }
            return string.Format("#{0}{1}{2}", r, g, b);
        }
    }
}
