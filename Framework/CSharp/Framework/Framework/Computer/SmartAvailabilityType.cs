/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
namespace Smartkernel.Framework.Computer
{
	/// <summary>
	/// 显示器状态
	/// </summary>
	public enum SmartAvailabilityType
	{
		/// <summary>
		/// Other
		/// </summary>
		Other = 1,

		/// <summary>
		/// Unknown
		/// </summary>
		Unknown = 2,

		/// <summary>
		/// RunningFullPower
		/// </summary>
		RunningFullPower = 3,

		/// <summary>
		/// Warning
		/// </summary>
		Warning = 4,

		/// <summary>
		/// InTest
		/// </summary>
		InTest = 5,

		/// <summary>
		/// NotApplicable
		/// </summary>
		NotApplicable = 6,

		/// <summary>
		/// PowerOff
		/// </summary>
		PowerOff = 7,

		/// <summary>
		/// OffLine
		/// </summary>
		OffLine = 8,

		/// <summary>
		/// OffDuty
		/// </summary>
		OffDuty = 9,

		/// <summary>
		/// Degraded
		/// </summary>
		Degraded = 10,

		/// <summary>
		/// NotInstalled
		/// </summary>
		NotInstalled = 11,

		/// <summary>
		/// InstallError
		/// </summary>
		InstallError = 12,

		/// <summary>
		/// PowerSaveUnknown
		/// </summary>
		PowerSaveUnknown = 13,

		/// <summary>
		/// PowerSaveLowPowerMode
		/// </summary>
		PowerSaveLowPowerMode = 14,

		/// <summary>
		/// PowerSaveStandby
		/// </summary>
		PowerSaveStandby = 15,

		/// <summary>
		/// PowerCycle
		/// </summary>
		PowerCycle = 16,

		/// <summary>
		/// PowerSaveWarning
		/// </summary>
		PowerSaveWarning = 17,

		/// <summary>
		/// Paused
		/// </summary>
		Paused = 18,

		/// <summary>
		/// NotReady
		/// </summary>
		NotReady = 19,

		/// <summary>
		/// NotConfigured
		/// </summary>
		NotConfigured = 20,

		/// <summary>
		/// Quiesced
		/// </summary>
		Quiesced = 21,

		/// <summary>
		/// NULL
		/// </summary>
		Null = 0
	}
}