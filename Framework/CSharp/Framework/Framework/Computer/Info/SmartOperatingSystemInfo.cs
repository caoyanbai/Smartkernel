/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取OperatingSystemInfo
	/// </summary>
	public class SmartOperatingSystemInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartOperatingSystemInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取CodeSet
		/// </summary>
		public string CodeSet { get { return Infos["CodeSet"]; } }

		/// <summary>
		/// 获取CountryCode
		/// </summary>
		public string CountryCode { get { return Infos["CountryCode"]; } }

		/// <summary>
		/// 获取CreationClassName
		/// </summary>
		public string CreationClassName { get { return Infos["CreationClassName"]; } }

		/// <summary>
		/// 获取CSCreationClassName
		/// </summary>
		public string CsCreationClassName { get { return Infos["CSCreationClassName"]; } }

		/// <summary>
		/// 获取CSDVersion
		/// </summary>
		public string CsdVersion { get { return Infos["CSDVersion"]; } }

		/// <summary>
		/// 获取CSName
		/// </summary>
		public string CsName { get { return Infos["CSName"]; } }

		/// <summary>
		/// 获取CurrentTimeZone
		/// </summary>
		public string CurrentTimeZone { get { return Infos["CurrentTimeZone"]; } }

		/// <summary>
		/// 获取DataExecutionPrevention_32BitApplications
		/// </summary>
		public string DataExecutionPrevention32BitApplications { get { return Infos["DataExecutionPrevention_32BitApplications"]; } }

		/// <summary>
		/// 获取DataExecutionPrevention_Available
		/// </summary>
		public string DataExecutionPreventionAvailable { get { return Infos["DataExecutionPrevention_Available"]; } }

		/// <summary>
		/// 获取DataExecutionPrevention_Drivers
		/// </summary>
		public string DataExecutionPreventionDrivers { get { return Infos["DataExecutionPrevention_Drivers"]; } }

		/// <summary>
		/// 获取DataExecutionPrevention_SupportPolicy
		/// </summary>
		public string DataExecutionPreventionSupportPolicy { get { return Infos["DataExecutionPrevention_SupportPolicy"]; } }

		/// <summary>
		/// 获取Debug
		/// </summary>
		public string Debug { get { return Infos["Debug"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取Distributed
		/// </summary>
		public string Distributed { get { return Infos["Distributed"]; } }

		/// <summary>
		/// 获取EncryptionLevel
		/// </summary>
		public string EncryptionLevel { get { return Infos["EncryptionLevel"]; } }

		/// <summary>
		/// 获取ForegroundApplicationBoost
		/// </summary>
		public string ForegroundApplicationBoost { get { return Infos["ForegroundApplicationBoost"]; } }

		/// <summary>
		/// 获取FreePhysicalMemory
		/// </summary>
		public string FreePhysicalMemory { get { return Infos["FreePhysicalMemory"]; } }

		/// <summary>
		/// 获取FreeSpaceInPagingFiles
		/// </summary>
		public string FreeSpaceInPagingFiles { get { return Infos["FreeSpaceInPagingFiles"]; } }

		/// <summary>
		/// 获取FreeVirtualMemory
		/// </summary>
		public string FreeVirtualMemory { get { return Infos["FreeVirtualMemory"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取LargeSystemCache
		/// </summary>
		public string LargeSystemCache { get { return Infos["LargeSystemCache"]; } }

		/// <summary>
		/// 获取LastBootUpTime
		/// </summary>
		public string LastBootUpTime { get { return Infos["LastBootUpTime"]; } }

		/// <summary>
		/// 获取LocalDateTime
		/// </summary>
		public string LocalDateTime { get { return Infos["LocalDateTime"]; } }

		/// <summary>
		/// 获取Locale
		/// </summary>
		public string Locale { get { return Infos["Locale"]; } }

		/// <summary>
		/// 获取Manufacturer
		/// </summary>
		public string Manufacturer { get { return Infos["Manufacturer"]; } }

		/// <summary>
		/// 获取MaxNumberOfProcesses
		/// </summary>
		public string MaxNumberOfProcesses { get { return Infos["MaxNumberOfProcesses"]; } }

		/// <summary>
		/// 获取MaxProcessMemorySize
		/// </summary>
		public string MaxProcessMemorySize { get { return Infos["MaxProcessMemorySize"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取NumberOfLicensedUsers
		/// </summary>
		public string NumberOfLicensedUsers { get { return Infos["NumberOfLicensedUsers"]; } }

		/// <summary>
		/// 获取NumberOfProcesses
		/// </summary>
		public string NumberOfProcesses { get { return Infos["NumberOfProcesses"]; } }

		/// <summary>
		/// 获取NumberOfUsers
		/// </summary>
		public string NumberOfUsers { get { return Infos["NumberOfUsers"]; } }

		/// <summary>
		/// 获取Organization
		/// </summary>
		public string Organization { get { return Infos["Organization"]; } }

		/// <summary>
		/// 获取OSLanguage
		/// </summary>
		public string OSLanguage { get { return Infos["OSLanguage"]; } }

		/// <summary>
		/// 获取OSProductSuite
		/// </summary>
		public string OSProductSuite { get { return Infos["OSProductSuite"]; } }

		/// <summary>
		/// 获取OSType
		/// </summary>
		public string OSType { get { return Infos["OSType"]; } }

		/// <summary>
		/// 获取OtherTypeDescription
		/// </summary>
		public string OtherTypeDescription { get { return Infos["OtherTypeDescription"]; } }

		/// <summary>
		/// 获取PAEEnabled
		/// </summary>
		public string PaeEnabled { get { return Infos["PAEEnabled"]; } }

		/// <summary>
		/// 获取PlusProductID
		/// </summary>
		public string PlusProductID { get { return Infos["PlusProductID"]; } }

		/// <summary>
		/// 获取PlusVersionNumber
		/// </summary>
		public string PlusVersionNumber { get { return Infos["PlusVersionNumber"]; } }

		/// <summary>
		/// 获取Primary
		/// </summary>
		public string Primary { get { return Infos["Primary"]; } }

		/// <summary>
		/// 获取ProductType
		/// </summary>
		public string ProductType { get { return Infos["ProductType"]; } }

		/// <summary>
		/// 获取QuantumLength
		/// </summary>
		public string QuantumLength { get { return Infos["QuantumLength"]; } }

		/// <summary>
		/// 获取QuantumType
		/// </summary>
		public string QuantumType { get { return Infos["QuantumType"]; } }

		/// <summary>
		/// 获取RegisteredUser
		/// </summary>
		public string RegisteredUser { get { return Infos["RegisteredUser"]; } }

		/// <summary>
		/// 获取SerialNumber
		/// </summary>
		public string SerialNumber { get { return Infos["SerialNumber"]; } }

		/// <summary>
		/// 获取ServicePackMajorVersion
		/// </summary>
		public string ServicePackMajorVersion { get { return Infos["ServicePackMajorVersion"]; } }

		/// <summary>
		/// 获取ServicePackMinorVersion
		/// </summary>
		public string ServicePackMinorVersion { get { return Infos["ServicePackMinorVersion"]; } }

		/// <summary>
		/// 获取SizeStoredInPagingFiles
		/// </summary>
		public string SizeStoredInPagingFiles { get { return Infos["SizeStoredInPagingFiles"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取SuiteMask
		/// </summary>
		public string SuiteMask { get { return Infos["SuiteMask"]; } }

		/// <summary>
		/// 获取SystemDevice
		/// </summary>
		public string SystemDevice { get { return Infos["SystemDevice"]; } }

		/// <summary>
		/// 获取SystemDirectory
		/// </summary>
		public string SystemDirectory { get { return Infos["SystemDirectory"]; } }

		/// <summary>
		/// 获取SystemDrive
		/// </summary>
		public string SystemDrive { get { return Infos["SystemDrive"]; } }

		/// <summary>
		/// 获取TotalSwapSpaceSize
		/// </summary>
		public string TotalSwapSpaceSize { get { return Infos["TotalSwapSpaceSize"]; } }

		/// <summary>
		/// 获取TotalVirtualMemorySize
		/// </summary>
		public string TotalVirtualMemorySize { get { return Infos["TotalVirtualMemorySize"]; } }

		/// <summary>
		/// 获取TotalVisibleMemorySize
		/// </summary>
		public string TotalVisibleMemorySize { get { return Infos["TotalVisibleMemorySize"]; } }

		/// <summary>
		/// 获取Version
		/// </summary>
		public string Version { get { return Infos["Version"]; } }

		/// <summary>
		/// 获取WindowsDirectory
		/// </summary>
		public string WindowsDirectory { get { return Infos["WindowsDirectory"]; } }
	}
}