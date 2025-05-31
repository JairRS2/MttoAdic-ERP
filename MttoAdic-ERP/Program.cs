using MttoAdic_ERP.Forms;
using Syncfusion.Licensing;
using Syncfusion.Windows.Forms;
using System;
using System.Windows.Forms;

namespace MttoAdic_ERP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH5ednVURWRfUUNyVko=");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            SkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2019Theme).Assembly);
            SkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);
            SkinManager.LoadAssembly(typeof(Syncfusion.HighContrastTheme.WinForms.HighContrastTheme).Assembly);
            Application.SetCompatibleTextRenderingDefault(false);


            frmLoginUrea loginForm = new frmLoginUrea();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                Application.Run(new MainForm());
            }
            else
            {

            }
        }
    }
}