/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取VideoControllerInfo
	/// </summary>
	public class SmartVideoControllerInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartVideoControllerInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取AdapterCompatibility
		/// </summary>
		public string AdapterCompatibility { get { return Infos["AdapterCompatibility"]; } }

		/// <summary>
		/// 获取AdapterDACType
		/// </summary>
		public string AdapterDacType { get { return Infos["AdapterDACType"]; } }

		/// <summary>
		/// 获取AdapterRAM
		/// </summary>
		public string AdapterRam { get { return Infos["AdapterRAM"]; } }

		/// <summary>
		/// 获取Availability
		/// </summary>
		public string Availability { get { return Infos["Availability"]; } }

		/// <summary>
		/// 获取CapabilityDescriptions
		/// </summary>
		public string CapabilityDescriptions { get { return Infos["CapabilityDescriptions"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取ColorTableEntries
		/// </summary>
		public string ColorTableEntries { get { return Infos["ColorTableEntries"]; } }

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
		/// 获取CurrentBitsPerPixel
		/// </summary>
		public string CurrentBitsPerPixel { get { return Infos["CurrentBitsPerPixel"]; } }

		/// <summary>
		/// 获取CurrentHorizontalResolution
		/// </summary>
		public string CurrentHorizontalResolution { get { return Infos["CurrentHorizontalResolution"]; } }

		/// <summary>
		/// 获取CurrentNumberOfColors
		/// </summary>
		public string CurrentNumberOfColors { get { return Infos["CurrentNumberOfColors"]; } }

		/// <summary>
		/// 获取CurrentNumberOfColumns
		/// </summary>
		public string CurrentNumberOfColumns { get { return Infos["CurrentNumberOfColumns"]; } }

		/// <summary>
		/// 获取CurrentNumberOfRows
		/// </summary>
		public string CurrentNumberOfRows { get { return Infos["CurrentNumberOfRows"]; } }

		/// <summary>
		/// 获取CurrentRefreshRate
		/// </summary>
		public string CurrentRefreshRate { get { return Infos["CurrentRefreshRate"]; } }

		/// <summary>
		/// 获取CurrentScanMode
		/// </summary>
		public string CurrentScanMode { get { return Infos["CurrentScanMode"]; } }

		/// <summary>
		/// 获取CurrentVerticalResolution
		/// </summary>
		public string CurrentVerticalResolution { get { return Infos["CurrentVerticalResolution"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取DeviceID
		/// </summary>
		public string DeviceID { get { return Infos["DeviceID"]; } }

		/// <summary>
		/// 获取DeviceSpecificPens
		/// </summary>
		public string DeviceSpecificPens { get { return Infos["DeviceSpecificPens"]; } }

		/// <summary>
		/// 获取DitherType
		/// </summary>
		public string DitherType { get { return Infos["DitherType"]; } }

		/// <summary>
		/// 获取DriverDate
		/// </summary>
		public string DriverDate { get { return Infos["DriverDate"]; } }

		/// <summary>
		/// 获取DriverVersion
		/// </summary>
		public string DriverVersion { get { return Infos["DriverVersion"]; } }

		/// <summary>
		/// 获取ErrorCleared
		/// </summary>
		public string ErrorCleared { get { return Infos["ErrorCleared"]; } }

		/// <summary>
		/// 获取ErrorDescription
		/// </summary>
		public string ErrorDescription { get { return Infos["ErrorDescription"]; } }

		/// <summary>
		/// 获取ICMIntent
		/// </summary>
		public string IcmIntent { get { return Infos["ICMIntent"]; } }

		/// <summary>
		/// 获取ICMMethod
		/// </summary>
		public string IcmMethod { get { return Infos["ICMMethod"]; } }

		/// <summary>
		/// 获取InfFilename
		/// </summary>
		public string InfFilename { get { return Infos["InfFilename"]; } }

		/// <summary>
		/// 获取InfSection
		/// </summary>
		public string InfSection { get { return Infos["InfSection"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取InstalledDisplayDrivers
		/// </summary>
		public string InstalledDisplayDrivers { get { return Infos["InstalledDisplayDrivers"]; } }

		/// <summary>
		/// 获取LastErrorCode
		/// </summary>
		public string LastErrorCode { get { return Infos["LastErrorCode"]; } }

		/// <summary>
		/// 获取MaxMemorySupported
		/// </summary>
		public string MaxMemorySupported { get { return Infos["MaxMemorySupported"]; } }

		/// <summary>
		/// 获取MaxNumberControlled
		/// </summary>
		public string MaxNumberControlled { get { return Infos["MaxNumberControlled"]; } }

		/// <summary>
		/// 获取MaxRefreshRate
		/// </summary>
		public string MaxRefreshRate { get { return Infos["MaxRefreshRate"]; } }

		/// <summary>
		/// 获取MinRefreshRate
		/// </summary>
		public string MinRefreshRate { get { return Infos["MinRefreshRate"]; } }

		/// <summary>
		/// 获取Monochrome
		/// </summary>
		public string Monochrome { get { return Infos["Monochrome"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取NumberOfColorPlanes
		/// </summary>
		public string NumberOfColorPlanes { get { return Infos["NumberOfColorPlanes"]; } }

		/// <summary>
		/// 获取NumberOfVideoPages
		/// </summary>
		public string NumberOfVideoPages { get { return Infos["NumberOfVideoPages"]; } }

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
		/// 获取ProtocolSupported
		/// </summary>
		public string ProtocolSupported { get { return Infos["ProtocolSupported"]; } }

		/// <summary>
		/// 获取ReservedSystemPaletteEntries
		/// </summary>
		public string ReservedSystemPaletteEntries { get { return Infos["ReservedSystemPaletteEntries"]; } }

		/// <summary>
		/// 获取SpecificationVersion
		/// </summary>
		public string SpecificationVersion { get { return Infos["SpecificationVersion"]; } }

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

		/// <summary>
		/// 获取SystemPaletteEntries
		/// </summary>
		public string SystemPaletteEntries { get { return Infos["SystemPaletteEntries"]; } }

		/// <summary>
		/// 获取TimeOfLastReset
		/// </summary>
		public string TimeOfLastReset { get { return Infos["TimeOfLastReset"]; } }

		/// <summary>
		/// 获取VideoArchitecture
		/// </summary>
		public string VideoArchitecture { get { return Infos["VideoArchitecture"]; } }

		/// <summary>
		/// 获取VideoMemoryType
		/// </summary>
		public string VideoMemoryType { get { return Infos["VideoMemoryType"]; } }

		/// <summary>
		/// 获取VideoMode
		/// </summary>
		public string VideoMode { get { return Infos["VideoMode"]; } }

		/// <summary>
		/// 获取VideoModeDescription
		/// </summary>
		public string VideoModeDescription { get { return Infos["VideoModeDescription"]; } }

		/// <summary>
		/// 获取VideoProcessor
		/// </summary>
		public string VideoProcessor { get { return Infos["VideoProcessor"]; } }
	}
}