﻿using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using TestDoshico.Views.Clienti;

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
        public BaseCommand EliminaClienteCommand { get; set; }
        public BaseCommand EditClienteCommand { get; set; }

        public ListaClientiViewModel()
        {
            CercaCommand = new BaseCommand(CercaButtonPressed);
            EliminaClienteCommand = new BaseCommand(EliminaClienteButtonPressed);
            EditClienteCommand = new BaseCommand(EditClienteButtonPressed);
        }

        private async void CercaButtonPressed(object obj)
        {
            if (!String.IsNullOrEmpty(Filtro))
            {
                IList<Cliente> lst = await DataManager.GetAllClienti();
                ListaClienti = lst.Where(w => w.NomeCognome.ToLower().Contains(Filtro.ToLower())).ToList();
            }
            else
                ListaClienti = await DataManager.GetAllClienti();
        }

        private async void EliminaClienteButtonPressed(object obj)
        {
            try
            {
                if (await MessageServices.ShowYesNoMessage("Test Doshico", "Eliminare il Cliente selezionato?", ModernWpf.Controls.ContentDialogButton.Close))
                {

                    Guid id = obj != null ? Guid.Parse(obj.ToString()) : Guid.Empty;

                    if (id != Guid.Empty)
                    {
                        DataManager.EliminaClienteByID(id);
                        ListaClienti.Remove(ListaClienti.FirstOrDefault(f => f.ID == id));
                        CollectionViewSource.GetDefaultView(ListaClienti).Refresh();
                    }
                    else
                        await MessageServices.ShowWarningMessage("Test Doshico", "Errore durante l'eliminazione del Cliente selezionato!");
                }
                else
                    await MessageServices.ShowInformationMessage("Test Doshico", "Eliminazione annullata!");
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante l'eliminazione del Cliente selezionato!", ex);
            }
        }

        private async void EditClienteButtonPressed(object obj)
        {
            try
            {
                var parameters = (object[])obj;

                Guid id = parameters[0] != null ? Guid.Parse(parameters[0].ToString()) : Guid.Empty;
                ListaClienti listaClientiPage = parameters[1] != null ? parameters[1] as ListaClienti : null;

                if (id != Guid.Empty && listaClientiPage != null)
                {
                    Cliente clienteInEdit = ListaClienti.FirstOrDefault(f => f.ID == id);
                    DatiClienteViewModel viewModel = new DatiClienteViewModel(ref clienteInEdit);
                    DatiCliente datiClienteWindow = new DatiCliente(viewModel);
                    datiClienteWindow.Owner = Window.GetWindow(listaClientiPage);
                    datiClienteWindow.ShowDialog();
                }
                else
                    await MessageServices.ShowWarningMessage("Test Doshico", "Errore durante l'apertura della finestra di modifica!");
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante l'apertura della finestra di modifica!", ex);
            }
        }
    }
}
