/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Smartkernel.Framework.Template
{
    /// <summary>
    /// 模板生成器
    /// </summary>
    public class SmartTemplate
    {
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="templet">模板</param>
        /// <param name="data">参数</param>
        /// <param name="imports">命名空间</param>
        /// <param name="references">程序集引用</param>
        /// <returns>结果</returns>
        public static string Generate(string templet, Dictionary<string, object> data = null, List<string> imports = null, List<string> references = null)
        {
            SmartEngine engine = new SmartEngine();
            SmartEngineHost engineHost = new SmartEngineHost(templet);

            if (imports != null && imports.Count > 0)
            {
                imports.ForEach(item =>
                {
                    engineHost.StandardImports.Add(item);
                });
            }
            if (references != null && references.Count > 0)
            {
                references.ForEach(item =>
                {
                    engineHost.StandardAssemblyReferences.Add(item);
                });
            }

            if (data != null)
            {
                foreach (var kv in data)
                {
                    var key = kv.Key;
                    var value = kv.Value;
                    engineHost.Data.Add(key, value);
                }
            }
            string output = engine.Process(engineHost);
            string errors = string.Empty;
            for (int j = 0; j < engineHost.Errors.Count; j++)
            {
                errors = errors + @"\r" + engineHost.Errors[j];
            }
            if (!string.IsNullOrWhiteSpace(errors))
            {
                throw new Exception(errors);
            }
            else
            {
                return output;
            }
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="templet">模板</param>
        /// <param name="data">参数</param>
        /// <param name="filePath">保存路径</param>
        /// <param name="isOverWrite">是否覆盖</param>
        /// <param name="encoding">编码</param>
        /// <param name="imports">命名空间</param>
        /// <param name="references">程序集引用</param>
        public static void GenerateFile(string templet, string filePath, Dictionary<string, object> data = null, bool isOverWrite = false, Encoding encoding = null, List<string> imports = null, List<string> references = null)
        {
            encoding = encoding ?? Encoding.Unicode;//默认的编码格式会在一行上，只有Unicode才是多行，这样避免代码行数统计错误

            var code = Generate(templet, data);
            if (isOverWrite)
            {
                //覆盖
                File.Delete(filePath);
                SmartFile.Write(filePath, code, true, encoding);
            }
            else
            {
                //不覆盖
                if (!File.Exists(filePath))
                {
                    SmartFile.Write(filePath, code, true, encoding);
                }
            }
        }
    }
}
