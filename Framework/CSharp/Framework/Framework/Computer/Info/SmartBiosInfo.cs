/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取BiosInfo
	/// </summary>
	public class SmartBiosInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartBiosInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取BiosCharacteristics
		/// </summary>
		public string BiosCharacteristics { get { return Infos["BiosCharacteristics"]; } }

		/// <summary>
		/// 获取BIOSVersion
		/// </summary>
		public string BiosVersion { get { return Infos["BIOSVersion"]; } }

		/// <summary>
		/// 获取BuildNumber
		/// </summary>
		public string BuildNumber { get { return Infos["BuildNumber"]; } }

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取CodeSet
		/// </summary>
		public string CodeSet { get { return Infos["CodeSet"]; } }

		/// <summary>
		/// 获取CurrentLanguage
		/// </summary>
		public string CurrentLanguage { get { return Infos["CurrentLanguage"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取IdentificationCode
		/// </summary>
		public string IdentificationCode { get { return Infos["IdentificationCode"]; } }

		/// <summary>
		/// 获取InstallableLanguages
		/// </summary>
		public string InstallableLanguages { get { return Infos["InstallableLanguages"]; } }

		/// <summary>
		/// 获取InstallDate
		/// </summary>
		public string InstallDate { get { return Infos["InstallDate"]; } }

		/// <summary>
		/// 获取LanguageEdition
		/// </summary>
		public string LanguageEdition { get { return Infos["LanguageEdition"]; } }

		/// <summary>
		/// 获取ListOfLanguages
		/// </summary>
		public string ListOfLanguages { get { return Infos["ListOfLanguages"]; } }

		/// <summary>
		/// 获取Manufacturer
		/// </summary>
		public string Manufacturer { get { return Infos["Manufacturer"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取OtherTargetOS
		/// </summary>
		public string OtherTargetOS { get { return Infos["OtherTargetOS"]; } }

		/// <summary>
		/// 获取PrimaryBIOS
		/// </summary>
		public string PrimaryBios { get { return Infos["PrimaryBIOS"]; } }

		/// <summary>
		/// 获取ReleaseDate
		/// </summary>
		public string ReleaseDate { get { return Infos["ReleaseDate"]; } }

		/// <summary>
		/// 获取SerialNumber
		/// </summary>
		public string SerialNumber { get { return Infos["SerialNumber"]; } }

		/// <summary>
		/// 获取SMBIOSBIOSVersion
		/// </summary>
		public string SmbiosbiosVersion { get { return Infos["SMBIOSBIOSVersion"]; } }

		/// <summary>
		/// 获取SMBIOSMajorVersion
		/// </summary>
		public string SmbiosMajorVersion { get { return Infos["SMBIOSMajorVersion"]; } }

		/// <summary>
		/// 获取SMBIOSMinorVersion
		/// </summary>
		public string SmbiosMinorVersion { get { return Infos["SMBIOSMinorVersion"]; } }

		/// <summary>
		/// 获取SMBIOSPresent
		/// </summary>
		public string SmbiosPresent { get { return Infos["SMBIOSPresent"]; } }

		/// <summary>
		/// 获取SoftwareElementID
		/// </summary>
		public string SoftwareElementID { get { return Infos["SoftwareElementID"]; } }

		/// <summary>
		/// 获取SoftwareElementState
		/// </summary>
		public string SoftwareElementState { get { return Infos["SoftwareElementState"]; } }

		/// <summary>
		/// 获取Status
		/// </summary>
		public string Status { get { return Infos["Status"]; } }

		/// <summary>
		/// 获取TargetOperatingSystem
		/// </summary>
		public string TargetOperatingSystem { get { return Infos["TargetOperatingSystem"]; } }

		/// <summary>
		/// 获取Version
		/// </summary>
		public string Version { get { return Infos["Version"]; } }
	}
}