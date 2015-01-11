/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取ProcessorInfo
	/// </summary>
	public class SmartProcessorInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartProcessorInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取AddressWidth
		/// </summary>
		public string AddressWidth { get { return Infos["AddressWidth"]; } }

		/// <summary>
		/// 获取Architecture
		/// </summary>
		public string Architecture { get { return Infos["Architecture"]; } }

		/// <summary>
		/// 获取Availability
		/// </summary>
		public string Availability { get { return Infos["Availability"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取ConfigManagerErrorCode
		/// </summary>
		public string ConfigManagerErrorCode { get { return Infos["ConfigManagerErrorCode"]; } }

		/// <summary>
		/// 获取ConfigManagerUserConfig
		/// </summary>
		public string ConfigManagerUserConfig { get { return Infos["ConfigManagerUserConfig"]; } }

		/// <summary>
		/// 获取CpuStatus
		/// </summary>
		public string CpuStatus { get { return Infos["CpuStatus"]; } }

		/// <summary>
		/// 获取CreationClassName
		/// </summary>
		public string CreationClassName { get { return Infos["CreationClassName"]; } }

		/// <summary>
		/// 获取CurrentClockSpeed
		/// </summary>
		public string CurrentClockSpeed { get { return Infos["CurrentClockSpeed"]; } }

		/// <summary>
		/// 获取CurrentVoltage
		/// </summary>
		public string CurrentVoltage { get { return Infos["CurrentVoltage"]; } }

		/// <summary>
		/// 获取DataWidth
		/// </summary>
		public string DataWidth { get { return Infos["DataWidth"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取DeviceID
		/// </summary>
		public string DeviceID { get { return Infos["DeviceID"]; } }

		/// <summary>
		/// 获取ErrorCleared
		/// </summary>
		public string ErrorCleared { get { return Infos["ErrorCleared"]; } }

		/// <summary>
		/// 获取ErrorDescription
		/// </summary>
		public string ErrorDescription { get { return Infos["ErrorDescription"]; } }

		/// <summary>
		/// 获取ExtClock
		/// </summary>
		public string ExtClock { get { return Infos["ExtClock"]; } }

		/// <summary>
		/// 获取Family
		/// </summary>
		public string Family { get { return Infos["Family"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取L2CacheSize
		/// </summary>
		public string L2CacheSize { get { return Infos["L2CacheSize"]; } }

		/// <summary>
		/// 获取L2CacheSpeed
		/// </summary>
		public string L2CacheSpeed { get { return Infos["L2CacheSpeed"]; } }

		/// <summary>
		/// 获取LastErrorCode
		/// </summary>
		public string LastErrorCode { get { return Infos["LastErrorCode"]; } }

		/// <summary>
		/// 获取Level
		/// </summary>
		public string Level { get { return Infos["Level"]; } }

		/// <summary>
		/// 获取LoadPercentage
		/// </summary>
		public string LoadPercentage { get { return Infos["LoadPercentage"]; } }

		/// <summary>
		/// 获取Manufacturer
		/// </summary>
		public string Manufacturer { get { return Infos["Manufacturer"]; } }

		/// <summary>
		/// 获取MaxClockSpeed
		/// </summary>
		public string MaxClockSpeed { get { return Infos["MaxClockSpeed"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取OtherFamilyDescription
		/// </summary>
		public string OtherFamilyDescription { get { return Infos["OtherFamilyDescription"]; } }

		/// <summary>
		/// 获取PNPDeviceID
		/// </summary>
		public string PnpDeviceID { get { return Infos["PNPDeviceID"]; } }

		/// <summary>
		/// 获取PowerManagementCapabilities
		/// </summary>
		public string PowerManagementCapabilities { get { return Infos["PowerManagementCapabilities"]; } }

		/// <summary>
		/// 获取PowerManagementSupported
		/// </summary>
		public string PowerManagementSupported { get { return Infos["PowerManagementSupported"]; } }

		/// <summary>
		/// 获取ProcessorId
		/// </summary>
		public string ProcessorID { get { return Infos["ProcessorId"]; } }

		/// <summary>
		/// 获取ProcessorType
		/// </summary>
		public string ProcessorType { get { return Infos["ProcessorType"]; } }

		/// <summary>
		/// 获取Revision
		/// </summary>
		public string Revision { get { return Infos["Revision"]; } }

		/// <summary>
		/// 获取Role
		/// </summary>
		public string Role { get { return Infos["Role"]; } }

		/// <summary>
		/// 获取SocketDesignation
		/// </summary>
		public string SocketDesignation { get { return Infos["SocketDesignation"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取StatusInfo
		/// </summary>
		public string StatusInfo { get { return Infos["StatusInfo"]; } }

		/// <summary>
		/// 获取Stepping
		/// </summary>
		public string Stepping { get { return Infos["Stepping"]; } }

		/// <summary>
		/// 获取SystemCreationClassName
		/// </summary>
		public string SystemCreationClassName { get { return Infos["SystemCreationClassName"]; } }

		/// <summary>
		/// 获取SystemName
		/// </summary>
		public string SystemName { get { return Infos["SystemName"]; } }

		/// <summary>
		/// 获取UniqueId
		/// </summary>
		public string UniqueID { get { return Infos["UniqueId"]; } }

		/// <summary>
		/// 获取UpgradeMethod
		/// </summary>
		public string UpgradeMethod { get { return Infos["UpgradeMethod"]; } }

		/// <summary>
		/// 获取Version
		/// </summary>
		public string Version { get { return Infos["Version"]; } }

		/// <summary>
		/// 获取VoltageCaps
		/// </summary>
		public string VoltageCaps { get { return Infos["VoltageCaps"]; } }
	}
}