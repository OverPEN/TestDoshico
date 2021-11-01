using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TestDoshico.ViewModels.Tests
{
    public class ListaTestsViewModel : BaseNotifyPropertyChanged
    {
        #region Private Values
        private IList<Test> listaTests;
        private String filtro;
        #endregion

        public IList<Test> ListaTests
        {
            get { return this.listaTests; }
            set
            {
                this.listaTests = value;
                this.OnPropertyChanged();
            }
        }
        public String Filtro
        {
            get { return this.filtro; }
            set
            {
                this.filtro = value;
                this.OnPropertyChanged();
            }
        }

        public BaseCommand CercaCommand { get; set; }
        public BaseCommand MenuPrincipaleCommand { get; set; }
        public BaseCommand EliminaTestCommand { get; set; }

        public ListaTestsViewModel()
        {
            CercaCommand = new BaseCommand(CercaButtonPressed);
        }

        private void CercaButtonPressed(object obj)
        {
            if(!String.IsNullOrEmpty(Filtro))
                ListaTests = DataManager.GetAllTests().Where(w=>DataManager.GetClienteByID(w.IDCliente).NomeCognome.ToLower().Contains(Filtro.ToLower())).ToList();
            else
                ListaTests = DataManager.GetAllTests();
        }

        private void MenuPrincipaleButtonPressed(object obj)
        {
            try
            {
                Window currentWindow = obj as Window;
                if (currentWindow != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    currentWindow.Close();
                }
                else
                    MessageServices.ShowWarningMessage("Test Doshico", "Errore nel ritorno al Menù Principale!");
            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nel ritorno al Menù Principale!", ex);
            }
        }
    }
}
