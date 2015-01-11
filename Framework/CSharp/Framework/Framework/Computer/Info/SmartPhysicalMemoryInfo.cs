/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取PhysicalMemoryInfo
	/// </summary>
	public class SmartPhysicalMemoryInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartPhysicalMemoryInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取BankLabel
		/// </summary>
		public string BankLabel { get { return Infos["BankLabel"]; } }

		/// <summary>
		/// 获取Capacity
		/// </summary>
		public string Capacity { get { return Infos["Capacity"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取CreationClassName
		/// </summary>
		public string CreationClassName { get { return Infos["CreationClassName"]; } }

		/// <summary>
		/// 获取DataWidth
		/// </summary>
		public string DataWidth { get { return Infos["DataWidth"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取DeviceLocator
		/// </summary>
		public string DeviceLocator { get { return Infos["DeviceLocator"]; } }

		/// <summary>
		/// 获取MemoryType
		/// </summary>
		public string MemoryType { get { return Infos["MemoryType"]; } }

		/// <summary>
		/// 获取HotSwappable
		/// </summary>
		public string HotSwappable { get { return Infos["HotSwappable"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取InterleaveDataDepth
		/// </summary>
		public string InterleaveDataDepth { get { return Infos["InterleaveDataDepth"]; } }

		/// <summary>
		/// 获取InterleavePosition
		/// </summary>
		public string InterleavePosition { get { return Infos["InterleavePosition"]; } }

		/// <summary>
		/// 获取Manufacturer
		/// </summary>
		public string Manufacturer { get { return Infos["Manufacturer"]; } }

		/// <summary>
		/// 获取FormFactor
		/// </summary>
		public string FormFactor { get { return Infos["FormFactor"]; } }

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
		/// 获取PositionInRow
		/// </summary>
		public string PositionInRow { get { return Infos["PositionInRow"]; } }

		/// <summary>
		/// 获取PoweredOn
		/// </summary>
		public string PoweredOn { get { return Infos["PoweredOn"]; } }

		/// <summary>
		/// 获取Removable
		/// </summary>
		public string Removable { get { return Infos["Removable"]; } }

		/// <summary>
		/// 获取Replaceable
		/// </summary>
		public string Replaceable { get { return Infos["Replaceable"]; } }

		/// <summary>
		/// 获取SerialNumber
		/// </summary>
		public string SerialNumber { get { return Infos["SerialNumber"]; } }

		/// <summary>
		/// 获取SKU
		/// </summary>
		public string Sku { get { return Infos["SKU"]; } }

		/// <summary>
		/// 获取Speed
		/// </summary>
		public string Speed { get { return Infos["Speed"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取Tag
		/// </summary>
		public string Tag { get { return Infos["Tag"]; } }

		/// <summary>
		/// 获取TotalWidth
		/// </summary>
		public string TotalWidth { get { return Infos["TotalWidth"]; } }

		/// <summary>
		/// 获取TypeDetail
		/// </summary>
		public string TypeDetail { get { return Infos["TypeDetail"]; } }

		/// <summary>
		/// 获取Version
		/// </summary>
		public string Version { get { return Infos["Version"]; } }
	}
}