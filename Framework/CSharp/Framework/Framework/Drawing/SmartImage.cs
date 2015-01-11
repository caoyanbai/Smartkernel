/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace Smartkernel.Framework.Drawing
{
    /// <summary>
    /// 图像类
    /// </summary>
    public static class SmartImage
    {
        private static bool ThumbnailCallback()
        {
            return true;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceFilePath">原图片路径</param>
        /// <param name="thumbnailFilePath">缩略图保存的路径</param>
        /// <param name="scale">缩小的尺寸（宽或高的最大边）</param>
        public static void ToThumbnailImage(string sourceFilePath, string thumbnailFilePath, int scale)
        {
            using (var image = Image.FromFile(sourceFilePath))
            {
                float oldHeight = image.Height;
                float oldWidth = image.Width;
                var height = 0;
                var width = 0;
                float propotion = 0;
                if (oldHeight > oldWidth)
                {
                    height = scale;
                    propotion = oldHeight / scale;
                    width = Convert.ToInt16(oldWidth / propotion);
                }
                else
                {
                    width = scale;
                    propotion = oldWidth / scale;
                    height = Convert.ToInt16(oldHeight / propotion);
                }

                using (var thumbnailImage = image.GetThumbnailImage(width, height, ThumbnailCallback, IntPtr.Zero))
                {
                    using (var output = new Bitmap(thumbnailImage))
                    {
                        output.Save(thumbnailFilePath, ImageFormat.Jpeg);
                    }
                }
            }
        }

        /// <summary>
        /// 调整图片大小
        /// </summary>
        /// <param name="originalImage">原始图片</param>
        /// <param name="newSize">新的大小</param>
        /// <param name="disposeOriginal">是否释放原来的图片资源</param>
        /// <returns>调整之后的图片</returns>
        public static Bitmap Resize(Bitmap originalImage, Size newSize, bool disposeOriginal = true)
        {
            Bitmap resizedImage = null;

            var pixelFormats = new[] { PixelFormat.Format1bppIndexed, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed, PixelFormat.Format8bppIndexed, PixelFormat.Undefined, PixelFormat.DontCare, PixelFormat.Format16bppArgb1555, PixelFormat.Format16bppGrayScale };

            if (!pixelFormats.ToList().Contains(originalImage.PixelFormat))
            {
                if (originalImage.Width > originalImage.Height)
                {
                    resizedImage = new Bitmap(newSize.Width, (int)Math.Floor((newSize.Width * originalImage.Height) / (double)originalImage.Width), originalImage.PixelFormat);
                }
                else if (originalImage.Width < originalImage.Height)
                {
                    resizedImage = new Bitmap(newSize.Height, (int)Math.Floor((newSize.Height * originalImage.Height) / (double)originalImage.Width), originalImage.PixelFormat);
                }
                else
                {
                    resizedImage = new Bitmap(newSize.Width, newSize.Width, originalImage.PixelFormat);
                }
                resizedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

                using (var resizedImageGraphic = Graphics.FromImage(resizedImage))
                {
                    resizedImageGraphic.CompositingQuality = CompositingQuality.HighQuality;
                    resizedImageGraphic.SmoothingMode = SmoothingMode.HighQuality;
                    resizedImageGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    resizedImageGraphic.DrawImage(originalImage, 0, 0, resizedImage.Width, resizedImage.Height);
                }

                if (disposeOriginal)
                {
                    originalImage.Dispose();
                }
            }

            return resizedImage;
        }

        /// <summary>
        /// 修剪图片
        /// </summary>
        /// <param name="originalImage">原始图片</param>
        /// <param name="croppedArea">修剪区域</param>
        /// <param name="disposeOriginal">是否释放资源</param>
        /// <returns>修剪之后的图片</returns>
        public static Bitmap Crop(Bitmap originalImage, Rectangle croppedArea, bool disposeOriginal = true)
        {
            var croppedImage = new Bitmap(croppedArea.Width, croppedArea.Height, originalImage.PixelFormat);
            croppedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
            using (var croppedImageGraphic = Graphics.FromImage(croppedImage))
            {
                croppedImageGraphic.DrawImage(originalImage, 0, 0, croppedArea, GraphicsUnit.Pixel);
            }

            if (disposeOriginal)
            {
                originalImage.Dispose();
            }

            return croppedImage;
        }

        /// <summary>
        /// 转换图片格式
        /// </summary>
        /// <param name="originalImage">原始图片</param>
        /// <param name="format">新格式</param>
        /// <param name="disposeOriginal">是否释放原始图片的资源</param>
        /// <returns>转换之后的图片</returns>
        public static Bitmap ToImageFormat(Bitmap originalImage, ImageFormat format, bool disposeOriginal = true)
        {
            Bitmap newImage = null;
            var newImageStream = new MemoryStream();
            originalImage.Save(newImageStream, format);
            newImage = new Bitmap(newImageStream);

            if (disposeOriginal)
            {
                originalImage.Dispose();
            }

            return newImage;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImage">原始图片</param>
        /// <param name="scale">缩小的尺寸（宽或高的最大边）</param>
        public static Bitmap ToThumbnailImage(Bitmap originalImage, int scale)
        {
            float oldHeight = originalImage.Height;
            float oldWidth = originalImage.Width;
            var height = 0;
            var width = 0;
            float propotion = 0;
            if (oldHeight > oldWidth)
            {
                height = scale;
                propotion = oldHeight / scale;
                width = Convert.ToInt16(oldWidth / propotion);
            }
            else
            {
                width = scale;
                propotion = oldWidth / scale;
                height = Convert.ToInt16(oldHeight / propotion);
            }

            return new Bitmap(originalImage.GetThumbnailImage(width, height, ThumbnailCallback, IntPtr.Zero));
        }

        /// <summary>
        /// 转换为BitmapImage格式
        /// </summary>
        /// <param name="originalImage">原始图像</param>
        /// <returns>结果</returns>
        public static BitmapImage ToBitmapImage(Bitmap originalImage)
        {
            //这里不能释放MemoryStream，否则无法获得BitmapImage
            MemoryStream memoryStream = new MemoryStream();
            originalImage.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();
            return bitmapImage;
        }
    }
}
