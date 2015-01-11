/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.Runtime.InteropServices;

namespace Smartkernel.Framework.Computer.Info
{
	/// <summary>
	/// 操作系统信息
	/// </summary>
	public class SmartSystemInfo
	{
		/// <summary>
		/// 获取MajorVersion
		/// </summary>
		public int MajorVersion { get { return Environment.OSVersion.Version.Major; } }

		/// <summary>
		/// 获取MinorVersion
		/// </summary>
		public int MinorVersion { get { return Environment.OSVersion.Version.Minor; } }

		/// <summary>
		/// 获取MajorRevision
		/// </summary>
		public int MajorRevision { get { return Environment.OSVersion.Version.MajorRevision; } }

		/// <summary>
		/// 获取MinorRevision
		/// </summary>
		public int MinorRevision { get { return Environment.OSVersion.Version.MinorRevision; } }

		/// <summary>
		/// 获取Revision
		/// </summary>
		public int Revision { get { return Environment.OSVersion.Version.Revision; } }

		/// <summary>
		/// 获取Build
		/// </summary>
		public int Build { get { return Environment.OSVersion.Version.Build; } }

		/// <summary>
		/// 获取VersionString
		/// </summary>
		public string VersionString { get { return Environment.OSVersion.Version.ToString(); } }

		/// <summary>
		/// 获取ServicePack
		/// </summary>
		public string ServicePack
		{
			get
			{
				var servicePack = String.Empty;
				var osVersionInfo = new SmartSystemInfoWin32Api.Osversioninfoex { dwOSVersionInfoSize = (uint)Marshal.SizeOf(typeof(SmartSystemInfoWin32Api.Osversioninfoex)) };
				if (SmartSystemInfoWin32Api.GetVersionEx(ref osVersionInfo))
				{
					servicePack = osVersionInfo.szCSDVersion;
				}
				return servicePack;
			}
		}

		/// <summary>
		/// 获取WindowsVersionType
		/// </summary>
		public SmartWindowsVersionType WindowsVersionType
		{
			get
			{
				var version = SmartWindowsVersionType.Unknown;
				var osVersionInfo = new SmartSystemInfoWin32Api.Osversioninfoex { dwOSVersionInfoSize = (uint)Marshal.SizeOf(typeof(SmartSystemInfoWin32Api.Osversioninfoex)) };
				var systemInfo = new SmartSystemInfoWin32Api.SystemInfo();
				SmartSystemInfoWin32Api.GetSystemInfo(ref systemInfo);
				if (SmartSystemInfoWin32Api.GetVersionEx(ref osVersionInfo))
				{
					switch (Environment.OSVersion.Platform)
					{
						case PlatformID.Win32Windows:
							{
								switch (osVersionInfo.dwMajorVersion)
								{
									case 4:
										{
											switch (osVersionInfo.dwMinorVersion)
											{
												case 0:
													if (osVersionInfo.szCSDVersion == "B" || osVersionInfo.szCSDVersion == "C")
													{
														version = SmartWindowsVersionType.Windows95OSR2;
													}
													else
													{
														version = SmartWindowsVersionType.Windows95;
													}
													break;
												case 10:
													if (osVersionInfo.szCSDVersion == "A")
													{
														version = SmartWindowsVersionType.Windows98Se;
													}
													else
													{
														version = SmartWindowsVersionType.Windows98;
													}
													break;
												case 90:
													version = SmartWindowsVersionType.WindowsMillennium;
													break;
											}
										}
										break;
								}
							}
							break;
						case PlatformID.Win32NT:
							{
								switch (osVersionInfo.dwMajorVersion)
								{
									case 3:
										version = SmartWindowsVersionType.WindowsNt351;
										break;
									case 4:
										switch (osVersionInfo.wProductType)
										{
											case 1:
												version = SmartWindowsVersionType.WindowsNt40;
												break;
											case 3:
												version = SmartWindowsVersionType.WindowsNt40Server;
												break;
										}
										break;
									case 5:
										{
											switch (osVersionInfo.dwMinorVersion)
											{
												case 0:
													version = SmartWindowsVersionType.Windows2000;
													break;
												case 1:
													version = SmartWindowsVersionType.WindowsXP;
													break;
												case 2:
													{
														if (osVersionInfo.wSuiteMask == SmartSystemInfoWin32Api.VerSuiteWhServer)
														{
															version = SmartWindowsVersionType.WindowsHomeServer;
														}
														else if (osVersionInfo.wProductType == SmartSystemInfoWin32Api.VerNtWorkstation && systemInfo.wProcessorArchitecture == SmartSystemInfoWin32Api.ProcessorArchitectureAmd64)
														{
															version = SmartWindowsVersionType.WindowsXPProfessionalx64;
														}
														else
														{
															version = SmartSystemInfoWin32Api.GetSystemMetrics(SmartSystemInfoWin32Api.SmServerr2) == 0 ? SmartWindowsVersionType.WindowsServer2003 : SmartWindowsVersionType.WindowsServer2003R2;
														}
													}
													break;
											}
										}
										break;
									case 6:
										{
											switch (osVersionInfo.dwMinorVersion)
											{
												case 0:
													{
														version = osVersionInfo.wProductType == SmartSystemInfoWin32Api.VerNtWorkstation ? SmartWindowsVersionType.WindowsVista : SmartWindowsVersionType.WindowsServer2008;
													}
													break;
												case 1:
													{
														version = osVersionInfo.wProductType == SmartSystemInfoWin32Api.VerNtWorkstation ? SmartWindowsVersionType.Windows7 : SmartWindowsVersionType.WindowsServer2008R2;
													}
													break;
											}
										}
										break;
								}
							}

							break;
					}
				}
				return version;
			}
		}

		/// <summary>
		/// 获取WindowsEditionType
		/// </summary>
		public SmartWindowsEditionType WindowsEditionType
		{
			get
			{
				var edition = SmartWindowsEditionType.Unknown;
				var osVersionInfo = new SmartSystemInfoWin32Api.Osversioninfoex { dwOSVersionInfoSize = (uint)Marshal.SizeOf(typeof(SmartSystemInfoWin32Api.Osversioninfoex)) };
				if (SmartSystemInfoWin32Api.GetVersionEx(ref osVersionInfo))
				{
					switch (osVersionInfo.dwMajorVersion)
					{
						case 4:
							{
								switch (osVersionInfo.wProductType)
								{
									case SmartSystemInfoWin32Api.VerNtWorkstation:
										edition = SmartWindowsEditionType.Workstation;
										break;
									case SmartSystemInfoWin32Api.VerNtServer:
										edition = (osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuiteEnterprise) != 0 ? SmartWindowsEditionType.EnterpriseServer : SmartWindowsEditionType.StandardServer;
										break;
								}
							}
							break;
						case 5:
							{
								switch (osVersionInfo.wProductType)
								{
									case SmartSystemInfoWin32Api.VerNtWorkstation:
										{
											edition = (osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuitePersonal) != 0 ? SmartWindowsEditionType.Home : SmartWindowsEditionType.Professional;
										}
										break;
									case SmartSystemInfoWin32Api.VerNtServer:
										{
											switch (osVersionInfo.dwMinorVersion)
											{
												case 0:
													{
														if ((osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuiteDatacenter) != 0)
														{
															edition = SmartWindowsEditionType.DatacenterServer;
														}
														else if ((osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuiteEnterprise) != 0)
														{
															edition = SmartWindowsEditionType.AdvancedServer;
														}
														else
														{
															edition = SmartWindowsEditionType.Server;
														}
													}
													break;
												default:
													{
														if ((osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuiteDatacenter) != 0)
														{
															edition = SmartWindowsEditionType.DatacenterServer;
														}
														else if ((osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuiteEnterprise) != 0)
														{
															edition = SmartWindowsEditionType.EnterpriseServer;
														}
														else if ((osVersionInfo.wSuiteMask & SmartSystemInfoWin32Api.VerSuiteBlade) != 0)
														{
															edition = SmartWindowsEditionType.WebEdition;
														}
														else
														{
															edition = SmartWindowsEditionType.StandardServer;
														}
													}
													break;
											}
										}
										break;
								}
							}
							break;
						case 6:
							{
								uint ed;
								if (SmartSystemInfoWin32Api.GetProductInfo(osVersionInfo.dwMajorVersion, osVersionInfo.dwMinorVersion, osVersionInfo.wServicePackMajor, osVersionInfo.wServicePackMinor, out ed))
								{
									switch (ed)
									{
										case SmartSystemInfoWin32Api.ProductBusiness:
											edition = SmartWindowsEditionType.Business;
											break;
										case SmartSystemInfoWin32Api.ProductBusinessN:
											edition = SmartWindowsEditionType.BusinessN;
											break;
										case SmartSystemInfoWin32Api.ProductClusterServer:
											edition = SmartWindowsEditionType.HpcEdition;
											break;
										case SmartSystemInfoWin32Api.ProductDatacenterServer:
											edition = SmartWindowsEditionType.DatacenterServer;
											break;
										case SmartSystemInfoWin32Api.ProductDatacenterServerCore:
											edition = SmartWindowsEditionType.DatacenterServerCoreInstallation;
											break;
										case SmartSystemInfoWin32Api.ProductEnterprise:
											edition = SmartWindowsEditionType.Enterprise;
											break;
										case SmartSystemInfoWin32Api.ProductEnterpriseN:
											edition = SmartWindowsEditionType.EnterpriseN;
											break;
										case SmartSystemInfoWin32Api.ProductEnterpriseServer:
											edition = SmartWindowsEditionType.EnterpriseServer;
											break;
										case SmartSystemInfoWin32Api.ProductEnterpriseServerCore:
											edition = SmartWindowsEditionType.EnterpriseServerCoreInstallation;
											break;
										case SmartSystemInfoWin32Api.ProductEnterpriseServerCoreV:
											edition = SmartWindowsEditionType.EnterpriseServerWithoutHyperVCoreInstallation;
											break;
										case SmartSystemInfoWin32Api.ProductEnterpriseServerIa64:
											edition = SmartWindowsEditionType.EnterpriseServerForItaniumBasedSystems;
											break;
										case SmartSystemInfoWin32Api.ProductEnterpriseServerV:
											edition = SmartWindowsEditionType.EnterpriseServerWithoutHyperV;
											break;
										case SmartSystemInfoWin32Api.ProductHomeBasic:
											edition = SmartWindowsEditionType.HomeBasic;
											break;
										case SmartSystemInfoWin32Api.ProductHomeBasicN:
											edition = SmartWindowsEditionType.HomeBasicN;
											break;
										case SmartSystemInfoWin32Api.ProductHomePremium:
											edition = SmartWindowsEditionType.HomePremium;
											break;
										case SmartSystemInfoWin32Api.ProductHomePremiumN:
											edition = SmartWindowsEditionType.HomePremiumN;
											break;
										case SmartSystemInfoWin32Api.ProductHyperv:
											edition = SmartWindowsEditionType.HyperVServer;
											break;
										case SmartSystemInfoWin32Api.ProductMediumbusinessServerManagement:
											edition = SmartWindowsEditionType.EssentialBusinessManagementServer;
											break;
										case SmartSystemInfoWin32Api.ProductMediumbusinessServerMessaging:
											edition = SmartWindowsEditionType.EssentialBusinessMessagingServer;
											break;
										case SmartSystemInfoWin32Api.ProductMediumbusinessServerSecurity:
											edition = SmartWindowsEditionType.EssentialBusinessSecurityServer;
											break;
										case SmartSystemInfoWin32Api.ProductServerForSmallbusiness:
											edition = SmartWindowsEditionType.EssentialServerSolutions;
											break;
										case SmartSystemInfoWin32Api.ProductServerForSmallbusinessV:
											edition = SmartWindowsEditionType.EssentialServerSolutionsWithoutHyperV;
											break;
										case SmartSystemInfoWin32Api.ProductSmallbusinessServer:
											edition = SmartWindowsEditionType.SmallBusinessServer;
											break;
										case SmartSystemInfoWin32Api.ProductStandardServer:
											edition = SmartWindowsEditionType.StandardServer;
											break;
										case SmartSystemInfoWin32Api.ProductStandardServerCore:
											edition = SmartWindowsEditionType.StandardServerCoreInstallation;
											break;
										case SmartSystemInfoWin32Api.ProductStandardServerCoreV:
											edition = SmartWindowsEditionType.StandardServerWithoutHyperVCoreInstallation;
											break;
										case SmartSystemInfoWin32Api.ProductStandardServerV:
											edition = SmartWindowsEditionType.StandardServerWithoutHyperV;
											break;
										case SmartSystemInfoWin32Api.ProductStarter:
											edition = SmartWindowsEditionType.Starter;
											break;
										case SmartSystemInfoWin32Api.ProductStorageEnterpriseServer:
											edition = SmartWindowsEditionType.EnterpriseStorageServer;
											break;
										case SmartSystemInfoWin32Api.ProductStorageExpressServer:
											edition = SmartWindowsEditionType.ExpressStorageServer;
											break;
										case SmartSystemInfoWin32Api.ProductStorageStandardServer:
											edition = SmartWindowsEditionType.StandardStorageServer;
											break;
										case SmartSystemInfoWin32Api.ProductStorageWorkgroupServer:
											edition = SmartWindowsEditionType.WorkgroupStorageServer;
											break;
										case SmartSystemInfoWin32Api.ProductUndefined:
											edition = SmartWindowsEditionType.Unknown;
											break;
										case SmartSystemInfoWin32Api.ProductUltimate:
											edition = SmartWindowsEditionType.Ultimate;
											break;
										case SmartSystemInfoWin32Api.ProductUltimateN:
											edition = SmartWindowsEditionType.UltimateN;
											break;
										case SmartSystemInfoWin32Api.ProductWebServer:
											edition = SmartWindowsEditionType.WebServer;
											break;
										case SmartSystemInfoWin32Api.ProductWebServerCore:
											edition = SmartWindowsEditionType.WebServerCoreInstallation;
											break;
									}
								}
							}
							break;
					}
				}
				return edition;
			}
		}

		#region Nested type: SmartSystemInfoWin32Api

		/// <summary>
		/// SmartSystemInfoWin32Api
		/// </summary>
		internal static class SmartSystemInfoWin32Api
		{
			internal const byte VerNtWorkstation = 1;

			internal const byte VerNtDomainController = 2;

			internal const byte VerNtServer = 3;

			internal const ushort VerSuiteSmallbusiness = 1;

			internal const ushort VerSuiteEnterprise = 2;

			internal const ushort VerSuiteTerminal = 16;

			internal const ushort VerSuiteDatacenter = 128;

			internal const ushort VerSuiteSingleuserts = 256;

			internal const ushort VerSuitePersonal = 512;

			internal const ushort VerSuiteBlade = 1024;

			internal const ushort VerSuiteWhServer = 32768;

			internal const uint ProductUndefined = 0x00000000;

			internal const uint ProductUltimate = 0x00000001;

			internal const uint ProductHomeBasic = 0x00000002;

			internal const uint ProductHomePremium = 0x00000003;

			internal const uint ProductEnterprise = 0x00000004;

			internal const uint ProductHomeBasicN = 0x00000005;

			internal const uint ProductBusiness = 0x00000006;

			internal const uint ProductStandardServer = 0x00000007;

			internal const uint ProductDatacenterServer = 0x00000008;

			internal const uint ProductSmallbusinessServer = 0x00000009;

			internal const uint ProductEnterpriseServer = 0x0000000A;

			internal const uint ProductStarter = 0x0000000B;

			internal const uint ProductDatacenterServerCore = 0x0000000C;

			internal const uint ProductStandardServerCore = 0x0000000D;

			internal const uint ProductEnterpriseServerCore = 0x0000000E;

			internal const uint ProductEnterpriseServerIa64 = 0x0000000F;

			internal const uint ProductBusinessN = 0x00000010;

			internal const uint ProductWebServer = 0x00000011;

			internal const uint ProductClusterServer = 0x00000012;

			internal const uint ProductHomeServer = 0x00000013;

			internal const uint ProductStorageExpressServer = 0x00000014;

			internal const uint ProductStorageStandardServer = 0x00000015;

			internal const uint ProductStorageWorkgroupServer = 0x00000016;

			internal const uint ProductStorageEnterpriseServer = 0x00000017;

			internal const uint ProductServerForSmallbusiness = 0x00000018;

			internal const uint ProductSmallbusinessServerPremium = 0x00000019;

			internal const uint ProductHomePremiumN = 0x0000001A;

			internal const uint ProductEnterpriseN = 0x0000001B;

			internal const uint ProductUltimateN = 0x0000001C;

			internal const uint ProductWebServerCore = 0x0000001D;

			internal const uint ProductMediumbusinessServerManagement = 0x0000001E;

			internal const uint ProductMediumbusinessServerSecurity = 0x0000001F;

			internal const uint ProductMediumbusinessServerMessaging = 0x00000020;

			internal const uint ProductServerForSmallbusinessV = 0x00000023;

			internal const uint ProductStandardServerV = 0x00000024;

			internal const uint ProductEnterpriseServerV = 0x00000026;

			internal const uint ProductStandardServerCoreV = 0x00000028;

			internal const uint ProductEnterpriseServerCoreV = 0x00000029;

			internal const uint ProductHyperv = 0x0000002A;

			internal const ushort ProcessorArchitectureIntel = 0;

			internal const ushort ProcessorArchitectureIa64 = 6;

			internal const ushort ProcessorArchitectureAmd64 = 9;

			internal const ushort ProcessorArchitectureUnknown = 0xFFFF;

			internal const int SmServerr2 = 89;

			[DllImport("Kernel32.dll")]
			internal static extern bool GetProductInfo(uint osMajorVersion, uint osMinorVersion, uint spMajorVersion, uint spMinorVersion, out uint edition);

			[DllImport("kernel32.dll")]
			internal static extern bool GetVersionEx(ref Osversioninfoex osVersionInfo);

			[DllImport("kernel32.dll")]
			internal static extern void GetSystemInfo(ref SystemInfo pSi);

			[DllImport("user32.dll")]
			internal static extern int GetSystemMetrics(int nIndex);

			#region Nested type: Osversioninfoex

			/// <summary>
			/// OSVERSIONINFOEX
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			internal struct Osversioninfoex
			{
				/// <summary>
				/// dwOSVersionInfoSize
				/// </summary>
				public uint dwOSVersionInfoSize;

				/// <summary>
				/// dwMajorVersion
				/// </summary>
				public uint dwMajorVersion;

				/// <summary>
				/// dwMinorVersion
				/// </summary>
				public uint dwMinorVersion;

				/// <summary>
				/// dwBuildNumber
				/// </summary>
				public uint dwBuildNumber;

				/// <summary>
				/// dwPlatformId
				/// </summary>
				public uint dwPlatformId;

				/// <summary>
				/// szCSDVersion
				/// </summary>
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
				public string szCSDVersion;

				/// <summary>
				/// wServicePackMajor
				/// </summary>
				public ushort wServicePackMajor;

				/// <summary>
				/// wServicePackMinor
				/// </summary>
				public ushort wServicePackMinor;

				/// <summary>
				/// wSuiteMask
				/// </summary>
				public ushort wSuiteMask;

				/// <summary>
				/// wProductType
				/// </summary>
				public byte wProductType;

				/// <summary>
				/// wReserved
				/// </summary>
				public byte wReserved;
			}

			#endregion

			#region Nested type: SystemInfo

			/// <summary>
			/// SYSTEM_INFO
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			internal struct SystemInfo
			{
				/// <summary>
				/// wProcessorArchitecture
				/// </summary>
				public uint wProcessorArchitecture;

				/// <summary>
				/// wReserved
				/// </summary>
				public uint wReserved;

				/// <summary>
				/// dwPageSize
				/// </summary>
				public uint dwPageSize;

				/// <summary>
				/// lpMinimumApplicationAddress
				/// </summary>
				public uint lpMinimumApplicationAddress;

				/// <summary>
				/// lpMaximumApplicationAddress
				/// </summary>
				public uint lpMaximumApplicationAddress;

				/// <summary>
				/// dwActiveProcessorMask
				/// </summary>
				public uint dwActiveProcessorMask;

				/// <summary>
				/// dwNumberOfProcessors
				/// </summary>
				public uint dwNumberOfProcessors;

				/// <summary>
				/// dwProcessorType
				/// </summary>
				public uint dwProcessorType;

				/// <summary>
				/// dwAllocationGranularity
				/// </summary>
				public uint dwAllocationGranularity;

				/// <summary>
				/// dwProcessorLevel
				/// </summary>
				public uint dwProcessorLevel;

				/// <summary>
				/// dwProcessorRevision
				/// </summary>
				public uint dwProcessorRevision;
			}

			#endregion
		}

		#endregion
	}
}