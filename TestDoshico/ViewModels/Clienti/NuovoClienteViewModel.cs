using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using System.Windows;
using TestDoshico.Views.Clienti;

namespace TestDoshico.ViewModels.Clienti
{
    public class NuovoClienteViewModel : BaseNotifyPropertyChanged
    {
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return this.cliente; }
            set
            {
                this.cliente = value;
                this.OnPropertyChanged();
            }
        }

        public BaseCommand SalvaCommand { get; set; }

        public NuovoClienteViewModel()
        {
            Cliente = new Cliente();
            SalvaCommand = new BaseCommand(SalvaButtonPressed);
        }

        private async void SalvaButtonPressed(object obj)
        {
            if (await ValidatorService.ValidateAsync(Cliente))
            {
                await DataManager.WriteClienteToXMLFile(Cliente);

                if (obj is NuovoCliente view)
                {
                    MainWindow mainWindow = Window.GetWindow(view) as MainWindow;
                    if (await MessageServices.ShowYesNoMessage("Test Doshico", "Chiudere il Nuovo Cliente appena inserito?", ModernWpf.Controls.ContentDialogButton.Primary))
                        mainWindow.Main.Content = null;
                }
            }
        }
    }
}
