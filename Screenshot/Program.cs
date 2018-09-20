using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{
    static class Program
    {
        /// <summary> 
        /// 应用程序的主入口点。 
        /// </summary> 
        [STAThread]
        static void Main(string[] args)
        {
            MutexOnly.ShowMutexOnly(Run, args);
        }

        private static void Run(string[] args)
        {
            DWMState = GetDWMUseState() && DwmIsCompositionEnabled();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        public static bool DWMState;

        private static bool GetDWMUseState()
        {
            return System.Environment.OSVersion.Version.Major >= 6;
        }
        /// <summary>
        /// 获取桌面启用DWM 组合的状态。
        /// </summary>
        /// <returns></returns>
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
    }
}
