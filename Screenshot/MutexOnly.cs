using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Screenshot
{
    class MutexOnly
    {
        /// <summary>
        /// 判断窗口是否已最小化
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        /// <summary>
        /// 判断窗口是否已最大化 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool IsZoomed(IntPtr hWnd);

        /// <summary>
        /// 获取当前系统中被激活的窗口
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 获取指定窗口的进程 ID 或线程 ID 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="ProcessId"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        /// <summary>
        /// 获取当前的进程 ID 或线程 ID 
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 根据窗体标题获取窗体句柄
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 设置窗体的位置大小等参数
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// <summary> 
        /// 该函数设置由不同线程产生的窗口的显示状态。
        /// </summary> 
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分。</param>
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零。</returns>
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        /// <summary> 
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄。</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零。</returns>
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, ref COPYDATASTRUCT lParam);

        private const int SW_NORMAL = 1; //正常弹出窗体
        private const int SW_MAXIMIZE = 3;//最大化窗体
        private const int SW_RESTORE = 9;

        private const int SWP_NOMOVE = 0x0002; //保持当前位置（x和y设定将被忽略） 
        private const int SWP_NOSIZE = 0x0001;//保持当前大小（cx和cy会被忽略）

        private const int WM_USER = 0x0400;
        public const int WM_OPENNEWFILE = WM_USER + 1;
        public const int WM_COPYDATA = 0x004A;

        /// <summary> 
        /// 显示已运行的程序主窗体
        /// </summary> 
        private static void HandleRunningInstance(IntPtr hwnd)
        {
            if (hwnd != IntPtr.Zero)
            {
                IntPtr hForwWnd = GetForegroundWindow();
                uint foreId = GetWindowThreadProcessId(hForwWnd, IntPtr.Zero);
                uint curId = GetCurrentThreadId();
                AttachThreadInput(curId, foreId, true);
                SetWindowPos(hwnd, new IntPtr(-1), 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE);
                SetWindowPos(hwnd, new IntPtr(-2), 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE);
                SetForegroundWindow(hwnd);            //放到前端 
                if (IsIconic(hwnd))
                {
                    ShowWindowAsync(hwnd, SW_RESTORE);
                }
                else if (IsZoomed(hwnd))
                {
                    ShowWindowAsync(hwnd, SW_MAXIMIZE);
                }
                else
                {
                    ShowWindowAsync(hwnd, SW_NORMAL);
                }
                AttachThreadInput(curId, foreId, false);
            }
        }

        /// <summary> 
        /// 通过 SendMessage 向指定句柄发送数据 
        /// </summary> 
        /// <param name="hWnd"> 接收方的窗口句柄 </param> 
        /// <param name="dwData"> 附加数据< /param> 
        /// <param name="lpdata"> 发送的数据 </param> 
        private static int SendCopyData(IntPtr hWnd, string fileName)
        {
            byte[] lpData = Encoding.UTF8.GetBytes(fileName);
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = (IntPtr)WM_OPENNEWFILE;
            cds.cbData = lpData.Length;
            cds.lpData = Marshal.AllocHGlobal(lpData.Length);
            Marshal.Copy(lpData, 0, cds.lpData, lpData.Length);
            IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(cds));
            Marshal.StructureToPtr(cds, lParam, true);
            int result = 0;
            try
            {
                result = SendMessage(hWnd, WM_COPYDATA, WM_OPENNEWFILE, ref cds);
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);
                Marshal.DestroyStructure(lParam, typeof(COPYDATASTRUCT));
                Marshal.FreeHGlobal(lParam);
            }
            return result;
        }
        /// <summary>
        /// 如果存在互斥体，则打开互斥窗体，否则调用 RunMethod 方法创建新的窗体
        /// </summary>
        /// <param name="RunMethod">回调函数</param>
        /// <param name="args">需要向互斥窗体传递的参数</param>
        public static void ShowMutexOnly(RunHandler RunMethod, string[] args)
        {
            bool b;
            Mutex m = new Mutex(true, ApplicationName, out b);
            if (b)
            {
                m.ReleaseMutex();
                RunMethod(args);
            }
            else
            {
                IntPtr hWnd = FindWindow(null, ApplicationName);
                if (hWnd != IntPtr.Zero)
                {
                    if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
                    {
                        SendCopyData(hWnd, args[0]);
                    }
                }
                HandleRunningInstance(hWnd);
            }
        }

        public static string ApplicationName
        {
            get { return "简单截屏工具"; }
        }
    }

    delegate void RunHandler(string[] args);

    /// <summary>
    /// 自定义消息传递的参数结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        public IntPtr lpData;
    }


    /*- readme
     * 
     * 
     * 如果需要向程序传递参数，请添加下面的方法
     * 
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MutexOnly.WM_COPYDATA)
            {
                COPYDATASTRUCT cds = (COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(COPYDATASTRUCT));
                int dwData = cds.dwData.ToInt32();
                if (dwData == MutexOnly.WM_OPENNEWFILE)
                {
                    byte[] lpData = new byte[cds.cbData];
                    Marshal.Copy(cds.lpData, lpData, 0, cds.cbData);
                    string fileName = Encoding.UTF8.GetString(lpData);
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        //此处取得其他进程传递的参数fileName，
                        //在这里添加你需要的操作
                    }
                }
                m.Result = (IntPtr)0;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
     * 
     * 
     ---*/
}
