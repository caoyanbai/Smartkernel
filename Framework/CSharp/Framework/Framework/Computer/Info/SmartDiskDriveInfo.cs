/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取DiskDriveInfo
	/// </summary>
	public class SmartDiskDriveInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartDiskDriveInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Availability
		/// </summary>
		public string Availability { get { return Infos["Availability"]; } }

		/// <summary>
		/// 获取BytesPerSector
		/// </summary>
		public string BytesPerSector { get { return Infos["BytesPerSector"]; } }

		/// <summary>
		/// 获取Capabilities
		/// </summary>
		public string Capabilities { get { return Infos["Capabilities"]; } }

		/// <summary>
		/// 获取CapabilityDescriptions
		/// </summary>
		public string CapabilityDescriptions { get { return Infos["CapabilityDescriptions"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取CompressionMethod
		/// </summary>
		public string CompressionMethod { get { return Infos["CompressionMethod"]; } }

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
		/// 获取DefaultBlockSize
		/// </summary>
		public string DefaultBlockSize { get { return Infos["DefaultBlockSize"]; } }

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
		/// 获取ErrorMethodology
		/// </summary>
		public string ErrorMethodology { get { return Infos["ErrorMethodology"]; } }

		/// <summary>
		/// 获取Index
		/// </summary>
		public string Index { get { return Infos["Index"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取InterfaceType
		/// </summary>
		public string InterfaceType { get { return Infos["InterfaceType"]; } }

		/// <summary>
		/// 获取LastErrorCode
		/// </summary>
		public string LastErrorCode { get { return Infos["LastErrorCode"]; } }

		/// <summary>
		/// 获取Manufacturer
		/// </summary>
		public string Manufacturer { get { return Infos["Manufacturer"]; } }

		/// <summary>
		/// 获取MaxBlockSize
		/// </summary>
		public string MaxBlockSize { get { return Infos["MaxBlockSize"]; } }

		/// <summary>
		/// 获取MaxMediaSize
		/// </summary>
		public string MaxMediaSize { get { return Infos["MaxMediaSize"]; } }

		/// <summary>
		/// 获取MediaLoaded
		/// </summary>
		public string MediaLoaded { get { return Infos["MediaLoaded"]; } }

		/// <summary>
		/// 获取MediaType
		/// </summary>
		public string MediaType { get { return Infos["MediaType"]; } }

		/// <summary>
		/// 获取MinBlockSize
		/// </summary>
		public string MinBlockSize { get { return Infos["MinBlockSize"]; } }

		/// <summary>
		/// 获取Model
		/// </summary>
		public string Model { get { return Infos["Model"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取NeedsCleaning
		/// </summary>
		public string NeedsCleaning { get { return Infos["NeedsCleaning"]; } }

		/// <summary>
		/// 获取NumberOfMediaSupported
		/// </summary>
		public string NumberOfMediaSupported { get { return Infos["NumberOfMediaSupported"]; } }

		/// <summary>
		/// 获取Partitions
		/// </summary>
		public string Partitions { get { return Infos["Partitions"]; } }

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
		/// 获取SCSIBus
		/// </summary>
		public string ScsiBus { get { return Infos["SCSIBus"]; } }

		/// <summary>
		/// 获取SCSILogicalUnit
		/// </summary>
		public string ScsiLogicalUnit { get { return Infos["SCSILogicalUnit"]; } }

		/// <summary>
		/// 获取SCSIPort
		/// </summary>
		public string ScsiPort { get { return Infos["SCSIPort"]; } }

		/// <summary>
		/// 获取SCSITargetId
		/// </summary>
		public string ScsiTargetID { get { return Infos["SCSITargetId"]; } }

		/// <summary>
		/// 获取SectorsPerTrack
		/// </summary>
		public string SectorsPerTrack { get { return Infos["SectorsPerTrack"]; } }

		/// <summary>
		/// 获取Signature
		/// </summary>
		public string Signature { get { return Infos["Signature"]; } }

		/// <summary>
		/// 获取Size
		/// </summary>
		public string Size { get { return Infos["Size"]; } }

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
		/// 获取TotalCylinders
		/// </summary>
		public string TotalCylinders { get { return Infos["TotalCylinders"]; } }

		/// <summary>
		/// 获取TotalHeads
		/// </summary>
		public string TotalHeads { get { return Infos["TotalHeads"]; } }

		/// <summary>
		/// 获取TotalSectors
		/// </summary>
		public string TotalSectors { get { return Infos["TotalSectors"]; } }

		/// <summary>
		/// 获取TotalTracks
		/// </summary>
		public string TotalTracks { get { return Infos["TotalTracks"]; } }

		/// <summary>
		/// 获取TracksPerCylinder
		/// </summary>
		public string TracksPerCylinder { get { return Infos["TracksPerCylinder"]; } }
	}
}