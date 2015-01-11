/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Microsoft.VisualStudio.TextTemplating;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Smartkernel.Framework.Template
{
    /// <summary>
    /// 引擎主机
    /// </summary>
    [Serializable]
    public class SmartEngineHost : ITextTemplatingEngineHost
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="content">模板文件内容</param>
        /// <param name="standardImports">标准的命名空间导入</param>
        /// <param name="standardAssemblyReferences">标准的程序集引用</param>
        public SmartEngineHost(string content, IList<string> standardImports = null, IList<string> standardAssemblyReferences = null)
        {
            this.Content = content;
            this.TemplateFile = string.Empty;
            this.Data = new Dictionary<string, object>();
            this.standardImports = standardImports ?? new string[] 
            { 
                    "System",
                    "System.Data",
                    "System.Collections",
                    "System.Collections.Generic",
                    "System.IO",
                    "System.Linq",
                    "System.Reflection",
                    "System.Text",
                    "System.Net",
                    "System.Web",
                    "Smartkernel.Framework",
                    "Smartkernel.Framework.Data",
                    "Smartkernel.Framework.Collections",
                    "Smartkernel.Framework.IO",
                    "Smartkernel.Framework.Text",
                    "Smartkernel.Framework.Net",
                    "Smartkernel.Framework.Web",
                    "Smartkernel.Framework.Template",
                    "Smartkernel.Framework.Xml",
                    "Microsoft.VisualStudio.TextTemplating"
            }.ToList();
            this.standardAssemblyReferences = standardAssemblyReferences ?? new string[] 
            { 
                typeof(System.Uri).Assembly.Location,
                typeof(System.Data.DataTable).Assembly.Location,
                typeof(System.Linq.Enumerable).Assembly.Location,
                typeof(SmartGuid).Assembly.Location,
                typeof(Engine).Assembly.Location,
                typeof(UIElement).Assembly.Location,
                typeof(FrameworkElement).Assembly.Location,
                typeof(Rect).Assembly.Location
            }.ToList();
        }

        /// <summary>
        /// 获取传递的数据
        /// </summary>
        public Dictionary<string, object> Data { get; set; }

        /// <summary>
        /// 获取或设置模板文件内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 获取或设置模板文件地址
        /// </summary>
        public string TemplateFile { get; set; }

        /// <summary>
        /// 获取或设置编译错误的信息
        /// </summary>
        public CompilerErrorCollection Errors { get; set; }

        private IList<string> standardAssemblyReferences;

        /// <summary>
        /// 获取标准的程序集引用
        /// </summary>
        public IList<string> StandardAssemblyReferences
        {
            get
            {
                return this.standardAssemblyReferences;
            }
        }

        private IList<string> standardImports;

        /// <summary>
        /// 获取标准的命名空间导入
        /// </summary>
        public IList<string> StandardImports
        {
            get
            {
                return this.standardImports;
            }
        }

        /// <summary>
        /// 加载引用的文件
        /// </summary>
        /// <param name="requestFileName">文件名</param>
        /// <param name="content">内容</param>
        /// <param name="location">位置</param>
        /// <returns>是否加载成功</returns>
        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
            content = System.String.Empty;
            location = System.String.Empty;
            content = this.Content;
            return true;
        }

        /// <summary>
        /// 获得主机选项
        /// </summary>
        /// <param name="optionName">选项名称</param>
        /// <returns>值</returns>
        public object GetHostOption(string optionName)
        {
            object returnObject;
            switch (optionName)
            {
                case "CacheAssemblies":
                    returnObject = true;
                    break;
                default:
                    returnObject = null;
                    break;
            }
            return returnObject;
        }

        /// <summary>
        /// 获取程序集引用
        /// </summary>
        /// <param name="assemblyReference">程序集引用</param>
        /// <returns>地址</returns>
        public string ResolveAssemblyReference(string assemblyReference)
        {
            if (File.Exists(assemblyReference))
            {
                return assemblyReference;
            }

            string candidate = Path.Combine(Path.GetDirectoryName(typeof(SmartEngineHost).Assembly.Location), assemblyReference);
            if (File.Exists(candidate))
            {
                return candidate;
            }

            return "";
        }

        /// <summary>
        /// ResolveDirectiveProcessor
        /// </summary>
        /// <param name="processorName">processorName</param>
        /// <returns></returns>
        public Type ResolveDirectiveProcessor(string processorName)
        {
            throw new Exception("Directive Processor not found");
        }

        /// <summary>
        /// ResolvePath
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns></returns>
        public string ResolvePath(string fileName)
        {
            if (fileName == null)
            {
                throw new Exception("the file name cannot be null");
            }

            if (File.Exists(fileName))
            {
                return fileName;
            }

            string candidate = Path.Combine(Path.GetDirectoryName(typeof(SmartEngineHost).Assembly.Location), fileName);
            if (File.Exists(candidate))
            {
                return candidate;
            }
            return fileName;
        }

        /// <summary>
        /// ResolveParameterValue
        /// </summary>
        /// <param name="directiveId">directiveId</param>
        /// <param name="processorName">processorName</param>
        /// <param name="parameterName">parameterName</param>
        /// <returns></returns>
        public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
        {
            if (directiveId == null)
            {
                throw new Exception("the directiveId cannot be null");
            }
            if (processorName == null)
            {
                throw new Exception("the processorName cannot be null");
            }
            if (parameterName == null)
            {
                throw new Exception("the parameterName cannot be null");
            }

            return String.Empty;
        }

        /// <summary>
        /// LogErrors
        /// </summary>
        /// <param name="errors">errors</param>
        public void LogErrors(CompilerErrorCollection errors)
        {
            Errors = errors;
        }

        private static AppDomain AppDomain = AppDomain.CreateDomain(SmartGuid.NewGuid());

        /// <summary>
        /// ProvideTemplatingAppDomain
        /// </summary>
        /// <param name="content">content</param>
        /// <returns></returns>
        public AppDomain ProvideTemplatingAppDomain(string content)
        {
            //给每个模板使用不同的应用程序域的话，将会造成极大的性能问题。所以这里只创建一次应用程序域，每次都在相同的应用程序域中进行。
            return AppDomain;
        }

        /// <summary>
        /// 创建新的应用程序域
        /// </summary>
        public static void CreateNewDomain()
        {
            AppDomain = AppDomain.CreateDomain(SmartGuid.NewGuid());
        }

        /// <summary>
        /// SetFileExtension
        /// </summary>
        /// <param name="extension">extension</param>
        public void SetFileExtension(string extension)
        {

        }

        /// <summary>
        /// SetOutputEncoding
        /// </summary>
        /// <param name="encoding">encoding</param>
        /// <param name="fromOutputDirective">fromOutputDirective</param>
        public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
        {

        }
    }
}
