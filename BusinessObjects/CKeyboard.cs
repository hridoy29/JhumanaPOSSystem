using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace POSsible.BusinessObjects
{
    class CKeyboard
    {
        public const int HWND_BOTTOM = 0x0001;
        public const int HWND_TOP = 0x0000;
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;
        public const int SWP_NOSENDCHANGING = 0x0400;

        public Process process;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
        int hWnd, // window handle
        int hWndInsertAfter, // placement-order handle
        int X, // horizontal position
        int Y, // vertical position
        int cx, // width
        int cy, // height
        uint uFlags); // window positioning flags

        //[DllImport("user32.dll", EntryPoint = "ShowWindow")]
        //public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(int hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        public void showKeyPad(System.Windows.Forms.Form form)
        {
            process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "c:\\WINDOWS\\system32\\osk.exe";
            process.StartInfo.Arguments = "";
            process.StartInfo.WorkingDirectory = "c:\\";
            process.Start(); // Start Onscreen Keyboard
            process.WaitForInputIdle();

            SetWindowPos((int)process.MainWindowHandle,
                                HWND_BOTTOM,
                                (Screen.PrimaryScreen.Bounds.Width - 968) / 2 , Screen.PrimaryScreen.Bounds.Height - 350, 968, 350,
                                SWP_SHOWWINDOW | SWP_NOZORDER
                               );


            //SetWindowPos((int)process.MainWindowHandle,
            //                    (int)form.Handle,
            //                    form.Left + 10, form.Top + (form.Height - 350), 800, 350,
            //                    CKeyboard.SWP_SHOWWINDOW | CKeyboard.SWP_NOZORDER
            //                   );

        }

        public void closeKeyPad()
        {
            process.CloseMainWindow();
        }
    }
}
