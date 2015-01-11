/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;

namespace Smartkernel.Framework.AddIn
{
	/// <summary>
	/// 插件的标识特性，实现插件类型时必须使用此标识
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class SmartAddInAttribute : Attribute
	{
		/// <summary>
		/// 插件的名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 插件的描述信息
		/// </summary>
		public string Description { get; set; }
	}
}
