/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取DesktopMonitorInfo
	/// </summary>
	public class SmartDesktopMonitorInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartDesktopMonitorInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Availability
		/// </summary>
		public string Availability { get { return Infos["Availability"]; } }

		/// <summary>
		/// 获取Bandwidth
		/// </summary>
		public string Bandwidth { get { return Infos["Bandwidth"]; } }

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
		/// 获取CreationClassName
		/// </summary>
		public string CreationClassName { get { return Infos["CreationClassName"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取DeviceID
		/// </summary>
		public string DeviceID { get { return Infos["DeviceID"]; } }

		/// <summary>
		/// 获取DisplayType
		/// </summary>
		public string DisplayType { get { return Infos["DisplayType"]; } }

		/// <summary>
		/// 获取ErrorCleared
		/// </summary>
		public string ErrorCleared { get { return Infos["ErrorCleared"]; } }

		/// <summary>
		/// 获取ErrorDescription
		/// </summary>
		public string ErrorDescription { get { return Infos["ErrorDescription"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取IsLocked
		/// </summary>
		public string IsLocked { get { return Infos["IsLocked"]; } }

		/// <summary>
		/// 获取LastErrorCode
		/// </summary>
		public string LastErrorCode { get { return Infos["LastErrorCode"]; } }

		/// <summary>
		/// 获取MonitorManufacturer
		/// </summary>
		public string MonitorManufacturer { get { return Infos["MonitorManufacturer"]; } }

		/// <summary>
		/// 获取MonitorType
		/// </summary>
		public string MonitorType { get { return Infos["MonitorType"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取PixelsPerXLogicalInch
		/// </summary>
		public string PixelsPerXLogicalInch { get { return Infos["PixelsPerXLogicalInch"]; } }

		/// <summary>
		/// 获取PixelsPerYLogicalInch
		/// </summary>
		public string PixelsPerYLogicalInch { get { return Infos["PixelsPerYLogicalInch"]; } }

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
		/// 获取ScreenHeight
		/// </summary>
		public string ScreenHeight { get { return Infos["ScreenHeight"]; } }

		/// <summary>
		/// 获取ScreenWidth
		/// </summary>
		public string ScreenWidth { get { return Infos["ScreenWidth"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取StatusInfo
		/// </summary>
		public string StatusInfo { get { return Infos["StatusInfo"]; } }

		/// <summary>
		/// 获取SystemCreationClassName
		/// </summary>
		public string SystemCreationClassName { get { return Infos["SystemCreationClassName"]; } }

		/// <summary>
		/// 获取SystemName
		/// </summary>
		public string SystemName { get { return Infos["SystemName"]; } }
	}
}