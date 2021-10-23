using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TestDoshico.ViewModels.Clienti
{
    public class ListaClientiViewModel : BaseNotifyPropertyChanged
    {
        #region Private Values
        private IList<Cliente> listaClienti;
        private String filtro;
        #endregion

        public IList<Cliente> ListaClienti
        {
            get { return this.listaClienti; }
            set
            {
                this.listaClienti = value;
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
        public BaseCommand EliminaClienteCommand { get; set; }

        public ListaClientiViewModel()
        {
            CercaCommand = new BaseCommand(CercaButtonPressed);
            MenuPrincipaleCommand = new BaseCommand(MenuPrincipaleButtonPressed);
            EliminaClienteCommand = new BaseCommand(EliminaClienteButtonPressed);
        }

        private void CercaButtonPressed(object obj)
        {
            if(!String.IsNullOrEmpty(Filtro))
                ListaClienti = DataManager.GetAllClienti().Where(w=>w.NomeCognome.ToLower().Contains(Filtro.ToLower())).ToList();
            else
                ListaClienti = DataManager.GetAllClienti();
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
        
        private void EliminaClienteButtonPressed(object obj)
        {
            if (MessageServices.ShowYesNoMessage("Test Doshico", "Eliminare il Cliente selezionato?", MessageBoxResult.No))
            {
                try
                {
                    Guid id = obj != null ? Guid.Parse(obj.ToString()) : Guid.Empty;

                    if (id != Guid.Empty)
                    {
                        DataManager.EliminaClienteByID(id);
                        MessageServices.ShowInformationMessage("TestDoshico", "Cliente eliminato con successo!");
                        CercaButtonPressed(null);
                    }
                    else
                        MessageServices.ShowWarningMessage("Test Doshico", "Errore durante l'eliminazione del Cliente selezionato!");
                }
                catch (Exception ex)
                {
                    MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante l'eliminazione del Cliente selezionato!", ex);
                }
            }
            else
                MessageServices.ShowInformationMessage("Test Doshico", "Eliminazione annullata!");
        }
    }
}
