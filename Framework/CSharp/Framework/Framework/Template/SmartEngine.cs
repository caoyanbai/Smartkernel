/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Microsoft.VisualStudio.TextTemplating;

namespace Smartkernel.Framework.Template
{
    /// <summary>
    /// 引擎
    /// </summary>
    public class SmartEngine
    {
        private Engine engine;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SmartEngine()
        {
            engine = new Engine();
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="engineHost">引擎主机</param>
        /// <returns>处理的结果</returns>
        public string Process(SmartEngineHost engineHost)
        {
            return engine.ProcessTemplate(engineHost.Content, engineHost);
        }
    }
}
