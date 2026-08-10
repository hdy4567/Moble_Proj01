using System;
using System.Windows.Forms;

namespace Moble_Proj01.Form
{
    internal static class Program
    {
        public static System.Windows.Forms.Form[] Forms;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Forms = new System.Windows.Forms.Form[]
            {
                new README(0),
                new Preview(1),
                new MapView(2)
            };

            // 창 닫히는 이벤트 수신해서, 메모리 누수 방지 및 좀비 프로세스 방지 
            foreach (var form in Forms)
            {
                form.FormClosed += (s, e) => Application.Exit();
            }

            Application.Run(Forms[0]);
        }
    }
}