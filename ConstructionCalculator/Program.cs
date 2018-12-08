using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using log4net.Config;

namespace ConstructionCalculator
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            AppDomain.CurrentDomain.SetData("DataDirectory",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            XmlConfigurator.Configure();

            Application.Run(new MainForm());
        }
    }
}