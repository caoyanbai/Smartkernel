/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取QuickFixEngineeringInfo
	/// </summary>
	public class SmartQuickFixEngineeringInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartQuickFixEngineeringInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取CSName
		/// </summary>
		public string CsName { get { return Infos["CSName"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取FixComments
		/// </summary>
		public string FixComments { get { return Infos["FixComments"]; } }

		/// <summary>
		/// 获取HotFixID
		/// </summary>
		public string HotFixID { get { return Infos["HotFixID"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取InstalledBy
		/// </summary>
		public string InstalledBy { get { return Infos["InstalledBy"]; } }

		/// <summary>
		/// 获取InstalledOn
		/// </summary>
		public string InstalledOn { get { return Infos["InstalledOn"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取ServicePackInEffect
		/// </summary>
		public string ServicePackInEffect { get { return Infos["ServicePackInEffect"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }
	}
}