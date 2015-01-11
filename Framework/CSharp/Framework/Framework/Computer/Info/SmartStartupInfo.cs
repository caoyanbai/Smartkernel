/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System.Collections.Generic;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 获取StartupInfo
	/// </summary>
	public class SmartStartupInfo : SmartInfo
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="infos">信息列表</param>
		public SmartStartupInfo(Dictionary<string, string> infos)
			: base(infos)
		{
		}

		/// <summary>
		/// 获取Caption
		/// </summary>
		public string Caption { get { return Infos["Caption"]; } }

		/// <summary>
		/// 获取Command
		/// </summary>
		public string Command { get { return Infos["Command"]; } }

		/// <summary>
		/// 获取Description
		/// </summary>
		public string Description { get { return Infos["Description"]; } }

		/// <summary>
		/// 获取Location
		/// </summary>
		public string Location { get { return Infos["Location"]; } }

		/// <summary>
		/// 获取Name
		/// </summary>
		public string Name { get { return Infos["Name"]; } }

		/// <summary>
		/// 获取SettingID
		/// </summary>
		public string SettingID { get { return Infos["SettingID"]; } }

		/// <summary>
		/// 获取User
		/// </summary>
		public string User { get { return Infos["User"]; } }

		/// <summary>
		/// 获取UserSID
		/// </summary>
		public string UserSID { get { return Infos["UserSID"]; } }
	}
}