using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplePerfChart
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new FrmTestingForm());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex);
                //Application.Run(new FrmTestingForm());
            }

        }
    }
}