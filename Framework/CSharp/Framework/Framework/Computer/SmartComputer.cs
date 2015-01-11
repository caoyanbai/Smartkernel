/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Computer.Info;
using Smartkernel.Framework.Diagnostics;
using Smartkernel.Framework.Management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Smartkernel.Framework.Computer
{
	/// <summary>
	/// 本地计算机功能相关
	/// </summary>
	public class SmartComputer
	{
		/// <summary>
		/// 目录分隔符号
		/// </summary>
		public static readonly string DirectorySeparator = "\\";

		/// <summary>
		/// 换行符号
		/// </summary>
		public static readonly string LineSeparator = "\r\n";

		/// <summary>
		/// 获取是否是64位操作系统
		/// </summary>
		public static bool Is64BitOperatingSystem { get { return Environment.Is64BitOperatingSystem; } }

		/// <summary>
		/// 获取当前进程是不是64位进程
		/// </summary>
		public static bool Is64BitProcess { get { return Environment.Is64BitProcess; } }

		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

		/// <summary>
		/// 判断当前计算机是否联网
		/// </summary>
		/// <returns>是否联网</returns>
		public static bool IsConnected()
		{
			var connectionDescription = 0;
			return InternetGetConnectedState(out connectionDescription, 0);
		}

		/// <summary>
		/// 发出蜂鸣声
		/// </summary>
		/// <param name="frequency">频率</param>
		/// <param name="duration">时间长短</param>
		public static void Beep(int frequency = 50, int duration = 200)
		{
			Console.Beep(frequency, duration);
		}

		/// <summary>
		/// 获取本地计算机名称
		/// </summary>
		public static string MachineName { get { return Environment.MachineName; } }

		/// <summary>
		/// 获取系统启动后经过的时间
		/// </summary>
		public static TimeSpan RunTime { get { return TimeSpan.FromMilliseconds(Environment.TickCount); } }

		/// <summary>
		/// 获取当前已登录到 Windows 操作系统的人员的用户名
		/// </summary>
		public static string UserName { get { return Environment.UserName; } }

		/// <summary>
		/// 获取处理器数量（多核也认为是多个处理器）
		/// </summary>
		public static int ProcessorCount { get { return Environment.ProcessorCount; } }

		/// <summary>
		/// 获取System32目录
		/// </summary>
		public static string System32Directory { get { return Environment.SystemDirectory; } }

		/// <summary>
		/// 获取Program Files目录
		/// </summary>
		public static string ProgramFilesDirectory { get { return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles); } }

		/// <summary>
		/// 获取Windows目录
		/// </summary>
		public static string WindowsDirectory { get { return Directory.GetParent(Environment.SystemDirectory).FullName; } }

		/// <summary>
		/// 获取一个 Version 对象，该对象描述公共语言运行库的主版本、次版本、内部版本和修订号
		/// </summary>
		public static Version DotNetVersion { get { return Environment.Version; } }

		private static readonly Microsoft.VisualBasic.Devices.Computer computer = new Microsoft.VisualBasic.Devices.Computer();

		/// <summary>
		/// 获得当前计算机的各种信息简便操作对象（同于VB中的My功能）
		/// </summary>
		public static Microsoft.VisualBasic.Devices.Computer Computer { get { return computer; } }

		/// <summary>
		/// 立即关机
		/// </summary>
		public static void Close()
		{
			SmartProcess.ExecuteCommand("shutdown -s -f -t 00");
		}

		/// <summary>
		/// 立即重启
		/// </summary>
		public static void Restart()
		{
			SmartProcess.ExecuteCommand("shutdown -r");
		}

		/// <summary>
		/// 获得BIOS的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static SmartBiosInfo GetBiosInfo()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_BIOS");

			var infos = new List<SmartBiosInfo>();

			list.ForEach(item => infos.Add(new SmartBiosInfo(item)));

			return infos.First();
		}

		/// <summary>
		/// 获得CDROM的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartCdRomInfo> GetCdRomInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_CDROMDrive");

			var infos = new List<SmartCdRomInfo>();

			list.ForEach(item => infos.Add(new SmartCdRomInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得DiskDrive的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartDiskDriveInfo> GetDiskDriveInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_DiskDrive");

			var infos = new List<SmartDiskDriveInfo>();

			list.ForEach(item => infos.Add(new SmartDiskDriveInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得QuickFixEngineering的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartQuickFixEngineeringInfo> GetQuickFixEngineeringInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_QuickFixEngineering");

			var infos = new List<SmartQuickFixEngineeringInfo>();

			list.ForEach(item => infos.Add(new SmartQuickFixEngineeringInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得LogicalDisk的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartLogicalDiskInfo> GetLogicalDiskInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_LogicalDisk");

			var infos = new List<SmartLogicalDiskInfo>();

			list.ForEach(item => infos.Add(new SmartLogicalDiskInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得PhysicalMemory的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartPhysicalMemoryInfo> GetPhysicalMemoryInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_PhysicalMemory");

			var infos = new List<SmartPhysicalMemoryInfo>();

			list.ForEach(item =>
				{
					var formFactorKeyValuePair = default(KeyValuePair<string, string>);
					var memoryTypeKeyValuePair = default(KeyValuePair<string, string>);
					var enumerator = item.GetEnumerator();
					while (enumerator.MoveNext())
					{
						var keyValuePair = enumerator.Current;
						if (keyValuePair.Key.ToLower() == "FormFactor".ToLower())
						{
							formFactorKeyValuePair = keyValuePair;
						}
						if (keyValuePair.Key.ToLower() == "MemoryType".ToLower())
						{
							memoryTypeKeyValuePair = keyValuePair;
						}
					}
					item.Remove(formFactorKeyValuePair.Key);
					item.Remove(memoryTypeKeyValuePair.Key);
					item.Add(formFactorKeyValuePair.Key, ((SmartFormFactorType)Convert.ToInt32(formFactorKeyValuePair.Value)).ToString());
					item.Add(memoryTypeKeyValuePair.Key, ((SmartMemoryType)Convert.ToInt32(memoryTypeKeyValuePair.Value)).ToString());
					infos.Add(new SmartPhysicalMemoryInfo(item));
				});
			return infos;
		}

		/// <summary>
		/// 获得DesktopMonitor的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartDesktopMonitorInfo> GetDesktopMonitorInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_DesktopMonitor");
			var infos = new List<SmartDesktopMonitorInfo>();

			list.ForEach(item =>
				{
					var availabilityKeyValuePair = default(KeyValuePair<string, string>);
					var enumerator = item.GetEnumerator();
					while (enumerator.MoveNext())
					{
						var keyValuePair = enumerator.Current;
						if (keyValuePair.Key.ToLower() == "Availability".ToLower())
						{
							availabilityKeyValuePair = keyValuePair;
						}
					}
					item.Remove(availabilityKeyValuePair.Key);
					item.Add(availabilityKeyValuePair.Key, ((SmartAvailabilityType)Convert.ToInt32(availabilityKeyValuePair.Value)).ToString());
					infos.Add(new SmartDesktopMonitorInfo(item));
				});

			return infos;
		}

		/// <summary>
		/// 获得BaseBoard的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static SmartBaseBoardInfo GetBaseBoardInfo()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_BaseBoard");

			var infos = new List<SmartBaseBoardInfo>();

			list.ForEach(item => infos.Add(new SmartBaseBoardInfo(item)));

			return infos.First();
		}

		/// <summary>
		/// 获得SoundDevice的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartSoundDeviceInfo> GetSoundDeviceInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_SoundDevice");

			var infos = new List<SmartSoundDeviceInfo>();

			list.ForEach(item => infos.Add(new SmartSoundDeviceInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得OperatingSystem的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartOperatingSystemInfo> GetOperatingSystemInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_OperatingSystem");

			var infos = new List<SmartOperatingSystemInfo>();

			list.ForEach(item => infos.Add(new SmartOperatingSystemInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得处理器架构
		/// </summary>
		/// <param name="data">参数</param>
		/// <returns>架构</returns>
		private static string GetArchitecture(int data)
		{
			string result;
			switch (data)
			{
				case 0:
					result = "x86";
					break;
				case 1:
					result = "MIPS";
					break;
				case 2:
					result = "Alpha";
					break;
				case 3:
					result = "PowerPC";
					break;
				case 6:
					result = "Intel Itanium Processor Family (IPF)";
					break;
				case 9:
					result = "x64";
					break;
				default:
					result = "Unknown Architecture";
					break;
			}
			return result;
		}

		/// <summary>
		/// 获得Processor的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartProcessorInfo> GetProcessorInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_Processor");

			var infos = new List<SmartProcessorInfo>();

			list.ForEach(item =>
				{
					var architectureKeyValuePair = default(KeyValuePair<string, string>);
					var enumerator = item.GetEnumerator();
					while (enumerator.MoveNext())
					{
						var keyValuePair = enumerator.Current;
						if (keyValuePair.Key.ToLower() == "Architecture".ToLower())
						{
							architectureKeyValuePair = keyValuePair;
						}
					}
					item.Remove(architectureKeyValuePair.Key);
					item.Add(architectureKeyValuePair.Key, GetArchitecture(Convert.ToInt32(architectureKeyValuePair.Value)));
					infos.Add(new SmartProcessorInfo(item));
				});

			return infos;
		}

		/// <summary>
		/// 获得共享类型
		/// </summary>
		/// <param name="data">参数</param>
		/// <returns>类型信息</returns>
		private static string GetShareType(long data)
		{
			string result;
			switch (data)
			{
				case 0:
					result = "Disk Drive";
					break;
				case 1:
					result = "Print Queue";
					break;
				case 2:
					result = "Device";
					break;
				case 3:
					result = "IPC";
					break;
				case 2147483648:
					result = "Disk Drive Admin";
					break;
				case 2147483649:
					result = "Print Queue Admin";
					break;
				case 2147483650:
					result = "Device Admin";
					break;
				case 2147483651:
					result = "IPC Admin";
					break;
				default:
					result = "Unknown";
					break;
			}

			return result;
		}

		/// <summary>
		/// 获得Share的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartShareInfo> GetShareInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_Share");

			var infos = new List<SmartShareInfo>();

			list.ForEach(item =>
				{
					var typeKeyValuePair = default(KeyValuePair<string, string>);
					var enumerator = item.GetEnumerator();
					while (enumerator.MoveNext())
					{
						var keyValuePair = enumerator.Current;
						if (keyValuePair.Key.ToLower() == "Type".ToLower())
						{
							typeKeyValuePair = keyValuePair;
						}
					}
					item.Remove(typeKeyValuePair.Key);
					item.Add(typeKeyValuePair.Key, GetShareType(Convert.ToInt64(typeKeyValuePair.Value)));
					infos.Add(new SmartShareInfo(item));
				});

			return infos;
		}

		/// <summary>
		/// 获得Startup的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartStartupInfo> GetStartupInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_StartupCommand where User != '.DEFAULT' and User != 'NT AUTHORITY\\\\SYSTEM'");

			var infos = new List<SmartStartupInfo>();

			list.ForEach(item => infos.Add(new SmartStartupInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得VideoController的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static List<SmartVideoControllerInfo> GetVideoControllerInfos()
		{
			var list = SmartWmi.Query("SELECT * FROM Win32_VideoController");

			var infos = new List<SmartVideoControllerInfo>();

			list.ForEach(item => infos.Add(new SmartVideoControllerInfo(item)));

			return infos;
		}

		/// <summary>
		/// 获得操作系统的信息
		/// </summary>
		/// <returns>信息对象</returns>
		public static SmartSystemInfo GetSystemInfo()
		{
			return new SmartSystemInfo();
		}

	}
}