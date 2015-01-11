/*
 * 项目：Smartkernel.Framework
 * 作者：曹艳白
 * 邮箱：caoyanbai@139.com
 */
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Smartkernel.Framework.Sms
{
    /// <summary>
    /// 西门子SMS短信猫发送接口，创建后应放置在容器内
    /// </summary>
    public partial class SmartSiemensSms
    {
        /// <summary>
        /// 同步对象
        /// </summary>
        private readonly object syncRoot = new object();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="directoryPath">用于存放短信猫dll的路径（必须有读写权限）</param>
        public SmartSiemensSms(string directoryPath = null)
        {
            if (directoryPath == null)
            {
                directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            path = string.Format(@"{0}\sms.dll", directoryPath);
            if (!File.Exists(path))
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    var bytes = SmartResource.Sms;
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                }
            }
        }

        /// <summary>
        /// 发送短信消息
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <param name="message">短信消息（长度应该在70个长度以内）</param>
        /// <returns>发送是否成功</returns>
        public bool Send(string phone, string message)
        {
            var intPtr = LoadLibrary(path);
            try
            {
                lock (syncRoot)
                {
                    //如果短信猫是关闭的则先开启
                    if (state == 0)
                    {
                        Open();
                    }
                    if (Sms_Send(new StringBuilder(phone), new StringBuilder(message)) != 1)
                    {
                        //如果发送失败说明还没有开启，需要重新开启
                        state = 0;
                        return false;
                    }
                    else
                    {
                        //如果发送成功，说明已经开启，不用再次开启了
                        state = 1;
                        System.Threading.Thread.Sleep(100);
                        return true;
                    }
                }
            }
            finally
            {
                FreeLibrary(intPtr);
            }
        }
    }

    public partial class SmartSiemensSms
    {
        private readonly string path;

        //当前使用的端口
        private uint port;

        //短信猫状态（0＝关闭，1＝运行）
        private int state;

        [DllImport("kernel32")]
        private static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport("kernel32")]
        private static extern IntPtr FreeLibrary(IntPtr hModule);

        [DllImport("sms.dll", EntryPoint = "Sms_Connection")]
        private static extern uint Sms_Connection(StringBuilder copyRight, uint port, uint rate, ref StringBuilder type, ref StringBuilder copyRightToCom);

        [DllImport("sms.dll", EntryPoint = "Sms_Disconnection")]
        private static extern uint Sms_Disconnection();

        [DllImport("sms.dll", EntryPoint = "Sms_Send")]
        private static extern uint Sms_Send(StringBuilder smsTelNum, StringBuilder smsText);

        [DllImport("sms.dll", EntryPoint = "Sms_Receive")]
        private static extern uint Sms_Receive(StringBuilder smsType, ref StringBuilder smsText);

        [DllImport("sms.dll", EntryPoint = "Sms_Delete")]
        private static extern uint Sms_Delete(StringBuilder smsIndex);

        [DllImport("sms.dll", EntryPoint = "Sms_AutoFlag")]
        private static extern uint Sms_AutoFlag();

        [DllImport("sms.dll", EntryPoint = "Sms_NewFlag")]
        private static extern uint Sms_NewFlag();

        //sms.dll文件的位置

        /// <summary>
        /// 打开短信猫
        /// </summary>
        private void Open()
        {
            var msg = new StringBuilder("");
            var copyRightToCom = new StringBuilder("");
            var copyRightStr = new StringBuilder("//北京诺亚公司(www.noahsoft.cn)授权使用本产品//");
            try
            {
                uint[] ports = { 2, 3, 4, 5, 6, 7, 8, 9 };
                var result = Sms_Connection(copyRightStr, port, 9600, ref msg, ref copyRightToCom);
                if (result == 1 && msg.ToString().Trim().ToLower() == "SIEMENS".ToLower())
                {
                    //打开成功
                    state = 1;
                    return;
                }
                state = 0;
                //打开未成功，先尝试关闭
                try
                {
                    Close();
                }
                catch { }
                //循环尝试每个端口
                foreach (var t in ports)
                {
                    port = t;
                    result = Sms_Connection(copyRightStr, port, 9600, ref msg, ref copyRightToCom);
                    System.Threading.Thread.Sleep(100);
                    //尝试到可以用的端口后退出循环
                    if (result == 1 && msg.ToString().Trim().ToLower() != "ERROR".ToLower())
                    {
                        state = 1;
                        return;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 关闭短信猫
        /// </summary>
        private static void Close()
        {
            GC.Collect();
            Sms_Disconnection();
            Thread.Sleep(100);
        }
    }
}
