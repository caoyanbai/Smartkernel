/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using Smartkernel.Framework.Text;
using System.Diagnostics;
using System.Text;

namespace Smartkernel.Framework.Diagnostics
{
    /// <summary>
    /// 进程
    /// </summary>
    public static class SmartProcess
    {
        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="filePath">待启动的程序路径</param>
        /// <param name="processWindowStyle">窗口样式</param>
        /// <param name="args">参数</param>
        public static void Start(string filePath, ProcessWindowStyle processWindowStyle = ProcessWindowStyle.Normal, string args = "")
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = filePath;
                process.StartInfo.Arguments = args;
                process.StartInfo.WindowStyle = processWindowStyle;
                process.Start();
            }
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名称，不带程序后缀.exe等</param>
        public static void Stop(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                process.EnableRaisingEvents = false;
                if (process.HasExited == false)
                {
                    //先尝试关闭主窗口，如果没有主窗口，就关闭主进程（关闭主窗口时会自动关闭主进程，反之不然，但是没有窗口的程序也只能通过关闭主进程关闭了）
                    if (process.CloseMainWindow() == false)
                    {
                        process.Kill();
                    }
                }
            }
        }

        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="encoding">编码</param>
        public static string ExecuteCommand(string command, Encoding encoding = null)
        {
            encoding = encoding ?? SmartEncoding.Default;

            string output = string.Empty;
            if (!string.IsNullOrWhiteSpace(command))
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.StandardErrorEncoding = encoding;
                    process.StartInfo.StandardOutputEncoding = encoding;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.WriteLine("exit");
                    output = process.StandardOutput.ReadToEnd();
                    while (!process.HasExited)
                    {
                        process.WaitForExit(1000);
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// 调用批处理程序文件
        /// </summary>
        /// <param name="filePath">批处理文件路径</param>
        /// <param name="encoding">编码</param>
        /// <returns>执行的结果</returns>
        public static string CallBatchFile(string filePath, Encoding encoding = null)
        {
            return ExecuteCommand(string.Format("call {0}", filePath), encoding);
        }

        /// <summary>
        /// 开打浏览器并浏览网页
        /// </summary>
        /// <param name="url">网页地址</param>
        public static void StartBrowser(string url)
        {
            Process.Start(url);
        }

        /// <summary>
        /// 通过记事本打开文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static void StartNotepad(string filePath)
        {
            Start("notepad.exe", ProcessWindowStyle.Normal, filePath);
        }
    }
}
