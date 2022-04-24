using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            if (await CanSave(obj))
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

        private async Task<bool> CanSave(object obj)
        {
            bool result = true;
            try
            {
                string errorMessage = String.Empty;

                if (obj is Page page)
                {
                    List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w => w.PropertyType == typeof(string) || w.PropertyType == typeof(int?)).ToList();
                    foreach (PropertyInfo T in props)
                    {
                        if (T.GetValue(Cliente) == null || (T.PropertyType == typeof(int?) && Convert.ToInt32(T.GetValue(Cliente)) == 0))
                        {
                            var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                            result = false;
                            errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                        }
                    }
                }

                if (errorMessage != String.Empty)
                    await MessageServices.ShowWarningMessage("Test Doshico", errorMessage);
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nella validazione campi!", ex);
                return false;
            }
            return result;
        }
    }
}
