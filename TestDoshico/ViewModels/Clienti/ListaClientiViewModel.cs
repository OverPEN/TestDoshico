﻿using CommonClasses.BaseClasses;
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

        public ListaClientiViewModel()
        {
            CercaCommand = new BaseCommand(CercaButtonPressed);
            MenuPrincipaleCommand = new BaseCommand(MenuPrincipaleButtonPressed);
        }

        private void CercaButtonPressed(object obj)
        {
            IList<Cliente> lst = new List<Cliente>();
            if(!String.IsNullOrEmpty(Filtro))
                lst = DataManager.GetAllClienti().Where(w=>w.NomeCognome.ToLower().Contains(Filtro.ToLower())).ToList();
            else
                lst = DataManager.GetAllClienti();
            if(lst.Count>0)
                ListaClienti = lst;
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
