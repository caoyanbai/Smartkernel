/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 信息类的基类
	/// </summary>
	public class SmartInfo
	{
		/// <summary>
		/// 信息列表
		/// </summary>
		protected Dictionary<string, string> Infos;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartInfo(Dictionary<string, string> infos)
		{
			Infos = infos;
		}
	}
}