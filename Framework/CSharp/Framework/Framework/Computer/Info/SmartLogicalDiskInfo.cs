/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取LogicalDiskInfo
	/// </summary>
	public class SmartLogicalDiskInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartLogicalDiskInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Access
		/// </summary>
		public string Access { get { return Infos["Access"]; } }

		/// <summary>
		/// 获取Availability
		/// </summary>
		public string Availability { get { return Infos["Availability"]; } }

		/// <summary>
		/// 获取BlockSize
		/// </summary>
		public string BlockSize { get { return Infos["BlockSize"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取Compressed
		/// </summary>
		public string Compressed { get { return Infos["Compressed"]; } }

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
		/// 获取DriveType
		/// </summary>
		public string DriveType { get { return Infos["DriveType"]; } }

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
		/// 获取FileSystem
		/// </summary>
		public string FileSystem { get { return Infos["FileSystem"]; } }

		/// <summary>
		/// 获取FreeSpace
		/// </summary>
		public string FreeSpace { get { return Infos["FreeSpace"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取LastErrorCode
		/// </summary>
		public string LastErrorCode { get { return Infos["LastErrorCode"]; } }

		/// <summary>
		/// 获取MaximumComponentLength
		/// </summary>
		public string MaximumComponentLength { get { return Infos["MaximumComponentLength"]; } }

		/// <summary>
		/// 获取MediaType
		/// </summary>
		public string MediaType { get { return Infos["MediaType"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取NumberOfBlocks
		/// </summary>
		public string NumberOfBlocks { get { return Infos["NumberOfBlocks"]; } }

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
		/// 获取ProviderName
		/// </summary>
		public string ProviderName { get { return Infos["ProviderName"]; } }

		/// <summary>
		/// 获取Purpose
		/// </summary>
		public string Purpose { get { return Infos["Purpose"]; } }

		/// <summary>
		/// 获取QuotasDisabled
		/// </summary>
		public string QuotasDisabled { get { return Infos["QuotasDisabled"]; } }

		/// <summary>
		/// 获取QuotasIncomplete
		/// </summary>
		public string QuotasIncomplete { get { return Infos["QuotasIncomplete"]; } }

		/// <summary>
		/// 获取QuotasRebuilding
		/// </summary>
		public string QuotasRebuilding { get { return Infos["QuotasRebuilding"]; } }

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
		/// 获取SupportsDiskQuotas
		/// </summary>
		public string SupportsDiskQuotas { get { return Infos["SupportsDiskQuotas"]; } }

		/// <summary>
		/// 获取SupportsFileBasedCompression
		/// </summary>
		public string SupportsFileBasedCompression { get { return Infos["SupportsFileBasedCompression"]; } }

		/// <summary>
		/// 获取SystemCreationClassName
		/// </summary>
		public string SystemCreationClassName { get { return Infos["SystemCreationClassName"]; } }

		/// <summary>
		/// 获取SystemName
		/// </summary>
		public string SystemName { get { return Infos["SystemName"]; } }

		/// <summary>
		/// 获取VolumeDirty
		/// </summary>
		public string VolumeDirty { get { return Infos["VolumeDirty"]; } }

		/// <summary>
		/// 获取VolumeName
		/// </summary>
		public string VolumeName { get { return Infos["VolumeName"]; } }

		/// <summary>
		/// 获取VolumeSerialNumber
		/// </summary>
		public string VolumeSerialNumber { get { return Infos["VolumeSerialNumber"]; } }
	}
}