/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.IO;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace Smartkernel.Framework.Reflection
{
    /// <summary>
    /// 程序集信息类
    /// </summary>
    public class SmartAssemblyInfo
    {
        private readonly Assembly assembly;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="assembly">程序集</param>
        public SmartAssemblyInfo(Assembly assembly)
        {
            this.assembly = assembly;
        }

        /// <summary>
        /// 获取程序集的标题
        /// </summary>
        public string Title
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
                return attribute == null ? string.Empty : attribute.Title;
            }
        }

        /// <summary>
        /// 获取程序集的描述
        /// </summary>
        public string Description
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyDescriptionAttribute)) as AssemblyDescriptionAttribute;
                return attribute == null ? string.Empty : attribute.Description;
            }
        }

        /// <summary>
        /// 获得公司信息
        /// </summary>
        public string Company
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;
                return attribute == null ? string.Empty : attribute.Company;
            }
        }

        /// <summary>
        /// 获得产品信息
        /// </summary>
        public string Product
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyProductAttribute)) as AssemblyProductAttribute;
                return attribute == null ? string.Empty : attribute.Product;
            }
        }

        /// <summary>
        /// 获得版权信息
        /// </summary>
        public string Copyright
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
                return attribute == null ? string.Empty : attribute.Copyright;
            }
        }

        /// <summary>
        /// 获得商标信息
        /// </summary>
        public string Trademark
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyTrademarkAttribute)) as AssemblyTrademarkAttribute;
                return attribute == null ? string.Empty : attribute.Trademark;
            }
        }

        /// <summary>
        /// 获得配置信息
        /// </summary>
        public string Configuration
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyConfigurationAttribute)) as AssemblyConfigurationAttribute;
                return attribute == null ? string.Empty : attribute.Configuration;
            }
        }

        /// <summary>
        /// 公钥字符串
        /// </summary>
        public string PublicKey
        {
            get
            {
                return SmartByte.ToHex(assembly.GetName().GetPublicKey());
            }
        }

        /// <summary>
        /// 公钥标记
        /// </summary>
        public string PublicKeyToken
        {
            get
            {
                return SmartByte.ToHex(assembly.GetName().GetPublicKeyToken());
            }
        }

        /// <summary>
        /// 获取是否延迟签名
        /// </summary>
        public bool DelaySign
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyDelaySignAttribute)) as AssemblyDelaySignAttribute;
                return attribute != null && attribute.DelaySign;
            }
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        public string InformationalVersion
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
                return attribute == null ? string.Empty : attribute.InformationalVersion;
            }
        }

        /// <summary>
        /// 获取签名文件的键
        /// </summary>
        public string KeyFile
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(AssemblyKeyFileAttribute)) as AssemblyKeyFileAttribute;
                return attribute == null ? string.Empty : attribute.KeyFile;
            }
        }

        /// <summary>
        /// 获取文化名称
        /// </summary>
        public string CultureName
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(NeutralResourcesLanguageAttribute)) as NeutralResourcesLanguageAttribute;
                return attribute == null ? string.Empty : attribute.CultureName;
            }
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        public string SatelliteContractVersion
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(SatelliteContractVersionAttribute)) as SatelliteContractVersionAttribute;
                return attribute == null ? string.Empty : attribute.Version;
            }
        }

        /// <summary>
        /// 获取Com版本信息
        /// </summary>
        public string ComCompatibleVersion
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(ComCompatibleVersionAttribute)) as ComCompatibleVersionAttribute;
                return attribute == null ? string.Empty : attribute.MajorVersion + "." + attribute.MinorVersion + "." + "." + attribute.BuildNumber + attribute.RevisionNumber;
            }
        }

        /// <summary>
        /// 获取ComVisible
        /// </summary>
        public bool ComVisible
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(ComVisibleAttribute)) as ComVisibleAttribute;
                return attribute != null && attribute.Value;
            }
        }

        /// <summary>
        /// 获取Guid
        /// </summary>
        public string Guid
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(GuidAttribute)) as GuidAttribute;
                return attribute == null ? string.Empty : attribute.Value;
            }
        }

        /// <summary>
        /// 获取TypeLibVersion
        /// </summary>
        public string TypeLibVersion
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(TypeLibVersionAttribute)) as TypeLibVersionAttribute;
                return attribute == null ? string.Empty : attribute.MajorVersion + "." + attribute.MinorVersion;
            }
        }

        /// <summary>
        /// 获取CLSCompliant
        /// </summary>
        public bool ClsCompliant
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(CLSCompliantAttribute)) as CLSCompliantAttribute;
                return attribute != null && attribute.IsCompliant;
            }
        }

        /// <summary>
        /// 获取Debuggable
        /// </summary>
        public bool Debuggable
        {
            get
            {
                var attribute = GetCustomAttribute(typeof(DebuggableAttribute)) as DebuggableAttribute;
                return attribute != null && attribute.IsJITTrackingEnabled;
            }
        }

        /// <summary>
        /// 获取Location
        /// </summary>
        public string Location { get { return assembly.Location.ToLower(); } }

        /// <summary>
        /// 获取CodeBase
        /// </summary>
        public string CodeBase { get { return assembly.CodeBase.Replace("file:///", "").ToLower(); } }

        /// <summary>
        /// 获得程序集的短名称
        /// </summary>
        public string ShortName { get { return assembly.FullName.Split(',')[0]; } }

        /// <summary>
        /// 获得程序集所在的文件夹
        /// </summary>
        public string DirectoryPath
        {
            get
            {
                var result = assembly.Location;
                return SmartDirectory.GetFormatDirectoryPath(Path.GetDirectoryName(result));
            }
        }

        /// <summary>
        /// 获取FullName
        /// </summary>
        public string FullName { get { return assembly.FullName; } }

        /// <summary>
        /// 获取Name
        /// </summary>
        public string Name { get { return assembly.GetName().Name; } }

        /// <summary>
        /// 获取Version
        /// </summary>
        public Version Version
        {
            get
            {
                return assembly.GetName().Version; 
            }
        }

        /// <summary>
        /// 获取ImageRuntimeVersion
        /// </summary>
        public string ImageRuntimeVersion { get { return assembly.ImageRuntimeVersion; } }

        /// <summary>
        /// 获取GACLoaded
        /// </summary>
        public bool GacLoaded { get { return assembly.GlobalAssemblyCache; } }

        /// <summary>
        /// 获取BuildDate
        /// </summary>
        public DateTime BuildDate
        {
            get
            {
                return DateTime.Parse("2000-01-01").AddDays(this.Version.Build).AddSeconds(this.Version.Revision * 2);
            }
        }

        /// <summary>
        /// 获得指定的特性
        /// </summary>
        /// <param name="attributeType">特性类型</param>
        /// <returns>特性的实例</returns>
        private object GetCustomAttribute(Type attributeType)
        {
            var assemblyAttributes = assembly.GetCustomAttributes(attributeType, false);
            return assemblyAttributes.Length <= 0 ? null : assemblyAttributes[0];
        }
    }
}
