/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取ShareInfo
	/// </summary>
	public class SmartShareInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartShareInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取AccessMask
		/// </summary>
		public string AccessMask { get { return Infos["AccessMask"]; } }

		/// <summary>
		/// 获取AllowMaximum
		/// </summary>
		public string AllowMaximum { get { return Infos["AllowMaximum"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取MaximumAllowed
		/// </summary>
		public string MaximumAllowed { get { return Infos["MaximumAllowed"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取Path
		/// </summary>
		public string Path { get { return Infos["Path"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取Type
		/// </summary>
		public string Type { get { return Infos["Type"]; } }
	}
}