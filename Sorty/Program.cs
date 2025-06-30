using System;
using System.Threading;
using System.Windows.Forms;

namespace Sorty
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(true, "Sorty", out bool firstInstance))
            {
                if (firstInstance)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SortForm());
                }
                else
                {
                    MessageBox.Show(
                        "Another instance is already running!",
                        "Application is running...",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
        }
    }
}
