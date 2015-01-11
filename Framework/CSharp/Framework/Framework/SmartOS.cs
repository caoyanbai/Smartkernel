/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Smartkernel.Framework
{
	/// <summary>
	/// 操作系统
	/// </summary>
	public class SmartOS
	{
		/// <summary>
		/// 换行符号
		/// </summary>
		public static readonly string LineSeparator = Environment.NewLine;

		/// <summary>
		/// 目录分隔符号
		/// </summary>
		public static readonly string DirectorySeparator = Path.DirectorySeparatorChar.ToString();
	}
}
