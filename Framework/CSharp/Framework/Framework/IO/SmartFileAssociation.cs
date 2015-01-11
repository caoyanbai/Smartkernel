/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;

namespace Smartkernel.Framework.IO
{
    /// <summary>
    /// 文件关联
    /// </summary>
    public static class SmartFileAssociation
    {
        /// <summary>
        /// 设置文件关联
        /// </summary>
        /// <param name="extension">扩展名，例如.cgproj</param>
        /// <param name="id">程序ID（可以是任意的字符串）</param>
        /// <param name="description">描述</param>
        /// <param name="icon">图标</param>
        /// <param name="applicationPath">应用程序路径</param>
        public static void Associate(string extension, string id, string description, string icon, string applicationPath)
        {
            Registry.ClassesRoot.CreateSubKey(extension).SetValue("", id);
            if (id != null && id.Length > 0)
            {
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(id))
                {
                    if (description != null)
                    {
                        key.SetValue("", description);
                    }
                    if (icon != null)
                    {
                        key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));
                    }
                    if (applicationPath != null)
                    {
                        key.CreateSubKey(@"Shell\Open\Command").SetValue("", ToShortPathName(applicationPath) + " \"%1\"");
                    }
                }
            }
        }

        /// <summary>
        /// 是否已经设置过关联
        /// </summary>
        /// <param name="extension">扩展名，例如.cgproj</param>
        /// <returns>是否关联</returns>
        public static bool IsAssociated(string extension)
        {
            return (Registry.ClassesRoot.OpenSubKey(extension, false) != null);
        }

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath, [Out] StringBuilder lpszShortPath, uint cchBuffer);

        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = GetShortPathName(longName, s, iSize);
            return s.ToString();
        }
    }
}
