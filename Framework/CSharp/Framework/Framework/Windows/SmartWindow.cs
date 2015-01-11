/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Drawing;
using System.Windows.Forms;

namespace Smartkernel.Framework.Windows
{
    /// <summary>
    /// 窗口操作相关
    /// </summary>
    public static class SmartWindow
    {
        /// <summary>
        /// 获得屏幕截图
        /// </summary>
        /// <returns>屏幕截图</returns>
        public static Bitmap CaptureScreen()
        {
            var rectangle = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            var bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(Point.Empty, Point.Empty, rectangle.Size);
                return bitmap;
            }
        }
    }
}
