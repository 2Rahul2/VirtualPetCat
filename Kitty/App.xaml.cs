using System.Configuration;
using System.Data;
using System.Windows;

namespace Kitty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "Virtual Pet Cat";
            mutex = new Mutex(true, appName, out bool isNewInstance);

            if (!isNewInstance)
            {
                MessageBox.Show("The application is already running.", "Single Instance");
                Environment.Exit(0); 
            }

            base.OnStartup(e); 
        }
    }

}
