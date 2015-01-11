/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取BaseBoard信息
	/// </summary>
	public class SmartBaseBoardInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartBaseBoardInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取ConfigOptions
		/// </summary>
		public string ConfigOptions { get { return Infos["ConfigOptions"]; } }

		/// <summary>
		/// 获取CreationClassName
		/// </summary>
		public string CreationClassName { get { return Infos["CreationClassName"]; } }

		/// <summary>
		/// 获取Depth
		/// </summary>
		public string Depth { get { return Infos["Depth"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取Height
		/// </summary>
		public string Height { get { return Infos["Height"]; } }

		/// <summary>
		/// 获取HostingBoard
		/// </summary>
		public string HostingBoard { get { return Infos["HostingBoard"]; } }

		/// <summary>
		/// 获取HotSwappable
		/// </summary>
		public string HotSwappable { get { return Infos["HotSwappable"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取Manufacturer
		/// </summary>
		public string Manufacturer { get { return Infos["Manufacturer"]; } }

		/// <summary>
		/// 获取Model
		/// </summary>
		public string Model { get { return Infos["Model"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取OtherIdentifyingInfo
		/// </summary>
		public string OtherIdentifyingInfo { get { return Infos["OtherIdentifyingInfo"]; } }

		/// <summary>
		/// 获取PartNumber
		/// </summary>
		public string PartNumber { get { return Infos["PartNumber"]; } }

		/// <summary>
		/// 获取PoweredOn
		/// </summary>
		public string PoweredOn { get { return Infos["PoweredOn"]; } }

		/// <summary>
		/// 获取Product
		/// </summary>
		public string Product { get { return Infos["Product"]; } }

		/// <summary>
		/// 获取Removable
		/// </summary>
		public string Removable { get { return Infos["Removable"]; } }

		/// <summary>
		/// 获取Replaceable
		/// </summary>
		public string Replaceable { get { return Infos["Replaceable"]; } }

		/// <summary>
		/// 获取RequirementsDescription
		/// </summary>
		public string RequirementsDescription { get { return Infos["RequirementsDescription"]; } }

		/// <summary>
		/// 获取RequiresDaughterBoard
		/// </summary>
		public string RequiresDaughterBoard { get { return Infos["RequiresDaughterBoard"]; } }

		/// <summary>
		/// 获取SerialNumber
		/// </summary>
		public string SerialNumber { get { return Infos["SerialNumber"]; } }

		/// <summary>
		/// 获取SKU
		/// </summary>
		public string Sku { get { return Infos["SKU"]; } }

		/// <summary>
		/// 获取SlotLayout
		/// </summary>
		public string SlotLayout { get { return Infos["SlotLayout"]; } }

		/// <summary>
		/// 获取SpecialRequirements
		/// </summary>
		public string SpecialRequirements { get { return Infos["SpecialRequirements"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取Tag
		/// </summary>
		public string Tag { get { return Infos["Tag"]; } }

		/// <summary>
		/// 获取Version
		/// </summary>
		public string Version { get { return Infos["Version"]; } }

		/// <summary>
		/// 获取Weight
		/// </summary>
		public string Weight { get { return Infos["Weight"]; } }

		/// <summary>
		/// 获取Width
		/// </summary>
		public string Width { get { return Infos["Width"]; } }
	}
}