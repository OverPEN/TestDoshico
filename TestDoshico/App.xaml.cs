using Data.Services;
using System.Windows;

namespace TestDoshico
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoggingService.StartLogger();
            LoggingService.LogInformation("Avvio di TestDoshico.");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LoggingService.LogInformation("Uscita da TestDoshico.");
            LoggingService.StopLogger();
            base.OnExit(e);
        }
    }
}
