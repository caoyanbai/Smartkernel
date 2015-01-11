/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
package smartkernel.framework.drawing;

import java.awt.*;
import java.awt.image.*;
import java.io.*;

import javax.imageio.*;
import javax.imageio.stream.*;

import smartkernel.framework.io.*;

/**
 * 图像类
 * 
 */
public class SmartImage {

	/**
	 * 获取图像
	 * 
	 * @param filePath，文件路径
	 * @return，结果
	 */
	public static BufferedImage fromFile(String filePath) {
		try {
			return ImageIO.read(new File(filePath));
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 保存图像为文件
	 * 
	 * @param image
	 *            ，图像
	 * @param filePath
	 *            ，文件路径
	 */
	public static void saveImage(RenderedImage image, String filePath) {
		try {
			ImageIO.write(image, SmartPath.getExtension(filePath), new File(
					filePath));
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 转换为内存图像
	 * 
	 * @param image
	 *            ，图像
	 * @return，结果
	 */
	public static BufferedImage toBufferedImage(Image image) {
		int width = image.getWidth(null);
		int height = image.getHeight(null);

		BufferedImage bufferedImage = new BufferedImage(width, height,
				BufferedImage.TYPE_INT_RGB);
		Graphics g = bufferedImage.getGraphics();
		g.drawImage(image, 0, 0, null);
		g.dispose();

		return bufferedImage;
	}

	/**
	 * 生成缩略图
	 * 
	 * @param sourceFilePath
	 *            ，原图片路径
	 * @param thumbnailFilePath
	 *            ，缩略图保存的路径
	 * @param scale
	 *            ，缩小的尺寸（宽或高的最大边）
	 */
	public static void toThumbnailImage(String sourceFilePath,
			String thumbnailFilePath, int scale) {

		try {
			BufferedImage image = ImageIO.read(new File(sourceFilePath));
			float oldHeight = image.getHeight();
			float oldWidth = image.getWidth();
			int height = 0;
			int width = 0;
			float propotion = 0;
			if (oldHeight > oldWidth) {
				height = scale;
				propotion = oldHeight / scale;
				width = (int) (oldWidth / propotion);
			} else {
				width = scale;
				propotion = oldWidth / scale;
				height = (int) (oldHeight / propotion);
			}

			Image thumbnailImage = image.getScaledInstance(width, height,
					Image.SCALE_SMOOTH);
			saveImage(toBufferedImage(thumbnailImage), thumbnailFilePath);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 生成缩略图
	 * 
	 * @param originalImage
	 *            ，原始图片
	 * @param scale
	 *            ，缩小的尺寸（宽或高的最大边）
	 */
	public static BufferedImage toThumbnailImage(BufferedImage originalImage,
			int scale) {

		try {
			BufferedImage image = originalImage;
			float oldHeight = image.getHeight();
			float oldWidth = image.getWidth();
			int height = 0;
			int width = 0;
			float propotion = 0;
			if (oldHeight > oldWidth) {
				height = scale;
				propotion = oldHeight / scale;
				width = (int) (oldWidth / propotion);
			} else {
				width = scale;
				propotion = oldWidth / scale;
				height = (int) (oldHeight / propotion);
			}

			Image thumbnailImage = image.getScaledInstance(width, height,
					Image.SCALE_SMOOTH);
			return toBufferedImage(thumbnailImage);
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}

	/**
	 * 调整图片大小
	 * 
	 * @param originalImage
	 *            ，原始图片
	 * @param newWidth
	 *            ，新的大小
	 * @param newHeight
	 *            ，新的大小
	 * @return，调整之后的图片
	 */
	public static BufferedImage resize(BufferedImage originalImage,
			int newWidth, int newHeight) {
		int originalWidth = originalImage.getWidth();
		int originalHeight = originalImage.getHeight();

		if (originalWidth > originalHeight) {
			newHeight = (int) Math
					.floor(((newWidth * originalHeight) / (double) originalWidth));
		} else if (originalWidth < originalHeight) {
			newWidth = newHeight;
			newHeight = (int) Math
					.floor(((newHeight * originalHeight) / (double) originalWidth));
		} else {
			newHeight = newWidth;
		}

		BufferedImage bufferedImage = new BufferedImage(newWidth, newHeight,
				originalImage.getType());
		Graphics2D g = bufferedImage.createGraphics();
		g.setRenderingHint(RenderingHints.KEY_INTERPOLATION,
				RenderingHints.VALUE_INTERPOLATION_BILINEAR);
		g.drawImage(originalImage, 0, 0, newWidth, newHeight, 0, 0,
				originalWidth, originalHeight, null);
		g.dispose();
		return bufferedImage;
	}

	/**
	 * 修剪图片
	 * 
	 * @param originalImage
	 *            ，原始图片
	 * @param croppedArea
	 *            ，修剪区域
	 * @return，修剪之后的图片
	 */
	public static BufferedImage crop(BufferedImage originalImage,
			Rectangle croppedArea) {
		return originalImage.getSubimage(0, 0, croppedArea.width,
				croppedArea.height);
	}

	/**
	 * 转换图片格式
	 * 
	 * @param originalImage
	 *            ，原始图片
	 * @param format
	 *            ，新格式
	 * @return，转换之后的图片
	 */
	public static BufferedImage toImageFormat(BufferedImage originalImage,
			String format) {
		try {
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			MemoryCacheImageOutputStream memoryCacheImageOutputStream = new MemoryCacheImageOutputStream(
					byteArrayOutputStream);
			ImageIO.write(originalImage, format, memoryCacheImageOutputStream);

			return ImageIO.read(SmartStream.convert(byteArrayOutputStream));
		} catch (Exception err) {
			throw new RuntimeException(err);
		}
	}
}
