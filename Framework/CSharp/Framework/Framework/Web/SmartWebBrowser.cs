/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Windows.Forms;

namespace Smartkernel.Framework.Web
{
    /// <summary>
    /// 浏览器
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public class SmartWebBrowser : IDisposable
    {
        private readonly WebBrowser webBrowser = new WebBrowser();

        /// <summary>
        /// 是否释放资源
        /// </summary>
        private bool isDisposed;

        #region IDisposable Members

        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SmartWebBrowser()
        {
            Dispose(true);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isDispose">是否释放</param>
        private void Dispose(bool isDispose)
        {
            if (isDisposed)
            {
                return;
            }
            if (isDispose)
            {
                webBrowser.Dispose();
            }
            isDisposed = true;
        }

        /// <summary>
        /// 给页面照相
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <returns>图像</returns>
        public Bitmap TakePicture(string url)
        {
            return TakePicture(url, new Size(1024, 768), new Size(1024, 768));
        }

        /// <summary>
        /// 给页面照相
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="pictureSize">图片的尺寸</param>
        /// <param name="webBrowserSize">浏览器的尺寸</param>
        /// <returns>图像</returns>
        public Bitmap TakePicture(string url, Size pictureSize = default(Size), Size webBrowserSize = default(Size))
        {
            if (pictureSize == default(Size))
            {
                pictureSize = new Size(1024, 768);
            }
            if (webBrowserSize == default(Size))
            {
                webBrowserSize = new Size(1024, 768);
            }
            webBrowser.ScriptErrorsSuppressed = false;
            webBrowser.ScrollBarsEnabled = false;
            webBrowser.Size = webBrowserSize;
            webBrowser.Navigate(url);
            while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            webBrowser.Stop();
            if (webBrowser.ActiveXInstance != null)
            {
                var pUnknown = webBrowser.ActiveXInstance;

                if (!Marshal.IsComObject(pUnknown))
                {
                    return null;
                }

                ISmartViewObject viewObject;
                var bitmap = new Bitmap(pictureSize.Width, pictureSize.Height);
                var rectangle = new Rectangle(new Point(0, 0), pictureSize);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    IntPtr viewObjectIntPtr;
                    Marshal.QueryInterface(Marshal.GetIUnknownForObject(pUnknown), ref IidIViewObject, out viewObjectIntPtr);
                    viewObject = Marshal.GetTypedObjectForIUnknown(viewObjectIntPtr, typeof(ISmartViewObject)) as ISmartViewObject;
                    if (viewObject != null)
                    {
                        viewObject.Draw((int)DVASPECT.DVASPECT_CONTENT, -1, IntPtr.Zero, null, IntPtr.Zero, graphics.GetHdc(), new SmartComrect(rectangle), null, IntPtr.Zero, 0);
                    }
                    Marshal.Release(viewObjectIntPtr);
                }
                return bitmap;
            }
            return null;
        }

        /// <summary>
        /// IID_IViewObject
        /// </summary>
        public static Guid IidIViewObject = new Guid("{0000010d-0000-0000-C000-000000000046}");

        /// <summary>
        /// IViewObject
        /// </summary>
        [ComImport, Guid("0000010d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ISmartViewObject
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="dwDrawAspect"></param>
            /// <param name="lindex"></param>
            /// <param name="pvAspect"></param>
            /// <param name="ptd"></param>
            /// <param name="hdcTargetDev"></param>
            /// <param name="hdcDraw"></param>
            /// <param name="lprcBounds"></param>
            /// <param name="lprcWBounds"></param>
            /// <param name="pfnContinue"></param>
            /// <param name="dwContinue"></param>
            /// <returns></returns>
            [PreserveSig]
            int Draw([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] SmartTagDvtargetdevice ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [In] SmartComrect lprcBounds, [In] SmartComrect lprcWBounds, IntPtr pfnContinue, [In] int dwContinue);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dwDrawAspect"></param>
            /// <param name="lindex"></param>
            /// <param name="pvAspect"></param>
            /// <param name="ptd"></param>
            /// <param name="hicTargetDev"></param>
            /// <param name="ppColorSet"></param>
            /// <returns></returns>
            [PreserveSig]
            int GetColorSet([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] SmartTagDvtargetdevice ptd, IntPtr hicTargetDev, [Out] SmartTagLogpalette ppColorSet);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dwDrawAspect"></param>
            /// <param name="lindex"></param>
            /// <param name="pvAspect"></param>
            /// <param name="pdwFreeze"></param>
            /// <returns></returns>
            [PreserveSig]
            int Freeze([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dwFreeze"></param>
            /// <returns></returns>
            [PreserveSig]
            int Unfreeze([In, MarshalAs(UnmanagedType.U4)] int dwFreeze);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="aspects"></param>
            /// <param name="advf"></param>
            /// <param name="pAdvSink"></param>
            void SetAdvise([In, MarshalAs(UnmanagedType.U4)] int aspects, [In, MarshalAs(UnmanagedType.U4)] int advf, [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="paspects"></param>
            /// <param name="advf"></param>
            /// <param name="pAdvSink"></param>
            void GetAdvise([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] paspects, [In, Out, MarshalAs(UnmanagedType.LPArray)] int[] advf, [In, Out, MarshalAs(UnmanagedType.LPArray)] IAdviseSink[] pAdvSink);
        }

        /// <summary>
        /// COMRECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class SmartComrect
        {
            /// <summary>
            /// left
            /// </summary>
            public int left;

            /// <summary>
            /// top
            /// </summary>
            public int top;

            /// <summary>
            /// right
            /// </summary>
            public int right;

            /// <summary>
            /// bottom
            /// </summary>
            public int bottom;

            /// <summary>
            /// COMRECT
            /// </summary>
            public SmartComrect() { }

            /// <summary>
            /// COMRECT
            /// </summary>
            /// <param name="r">Rectangle</param>
            public SmartComrect(Rectangle r)
            {
                left = r.X;
                top = r.Y;
                right = r.Right;
                bottom = r.Bottom;
            }

            /// <summary>
            /// COMRECT
            /// </summary>
            /// <param name="left">left</param>
            /// <param name="top">top</param>
            /// <param name="right">right</param>
            /// <param name="bottom">bottom</param>
            public SmartComrect(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /// <summary>
            /// FromXYWH
            /// </summary>
            /// <param name="x">x</param>
            /// <param name="y">y</param>
            /// <param name="width">width</param>
            /// <param name="height">height</param>
            /// <returns>return</returns>
            public static SmartComrect FromXYWH(int x, int y, int width, int height)
            {
                return new SmartComrect(x, y, x + width, y + height);
            }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>return</returns>
            public override string ToString()
            {
                return string.Concat(new object[] { "Left = ", left, " Top ", top, " Right = ", right, " Bottom = ", bottom });
            }
        }

        /// <summary>
        /// tagDVTARGETDEVICE
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class SmartTagDvtargetdevice
        {
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public int tdSize;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short tdDriverNameOffset;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short tdDeviceNameOffset;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short tdPortNameOffset;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short tdExtDevmodeOffset;
        }

        /// <summary>
        /// tagLOGPALETTE
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class SmartTagLogpalette
        {
            /// <summary>
            /// palVersion
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short palVersion;

            /// <summary>
            /// palNumEntries
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short palNumEntries;
        }
    }
}
