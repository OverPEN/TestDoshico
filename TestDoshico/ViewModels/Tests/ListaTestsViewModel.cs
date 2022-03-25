using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using TestDoshico.Views.Tests;

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
        public BaseCommand EliminaTestCommand { get; set; }
        public BaseCommand EditTestCommand { get; set; }

        public ListaTestsViewModel()
        {
            CercaCommand = new BaseCommand(CercaButtonPressed);
            EliminaTestCommand = new BaseCommand(EliminaTestButtonPressed);
            EditTestCommand = new BaseCommand(EditTestButtonPressed);
        }

        private async void CercaButtonPressed(object obj)
        {
            if (!String.IsNullOrEmpty(Filtro))
            {
                IList<Test> lst = await DataManager.GetAllTests();
                foreach (Test t in lst)
                {
                    Cliente c = await DataManager.GetClienteByID(t.IDCliente);
                    if (c.NomeCognome.ToLower().Contains(Filtro.ToLower()))
                        ListaTests.Add(t);
                }
            }
            else
                ListaTests = await DataManager.GetAllTests();
        }

        private async void EliminaTestButtonPressed(object obj)
        {
            try
            {
                if (await MessageServices.ShowYesNoMessage("Test Doshico", "Eliminare il Test selezionato?", ModernWpf.Controls.ContentDialogButton.Close))
                {

                    Guid id = obj != null ? Guid.Parse(obj.ToString()) : Guid.Empty;

                    if (id != Guid.Empty)
                    {
                        DataManager.EliminaTestByID(id);
                        ListaTests.Remove(ListaTests.FirstOrDefault(f => f.ID == id));
                        CollectionViewSource.GetDefaultView(ListaTests).Refresh();
                    }
                    else
                        await MessageServices.ShowWarningMessage("Test Doshico", "Errore durante l'eliminazione del Test selezionato!");
                }
                else
                    await MessageServices.ShowInformationMessage("Test Doshico", "Eliminazione annullata!");
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante l'eliminazione del Test selezionato!", ex);
            }
        }

        private async void EditTestButtonPressed(object obj)
        {
            try
            {
                var parameters = (object[])obj;

                Guid id = parameters[0] != null ? Guid.Parse(parameters[0].ToString()) : Guid.Empty;
                ListaTests listaTestsPage = parameters[1] != null ? parameters[1] as ListaTests : null;

                if (id != Guid.Empty && listaTestsPage != null)
                {
                    Test testInEdit = ListaTests.FirstOrDefault(f => f.ID == id);
                    Quesiti.QuesitiViewModel viewModel = new Quesiti.QuesitiViewModel(ref testInEdit);
                    DatiTest datiTestWindow = new DatiTest(viewModel);
                    datiTestWindow.Owner = Window.GetWindow(listaTestsPage);
                    datiTestWindow.ShowDialog();
                    ListaTests[ListaTests.IndexOf(ListaTests.FirstOrDefault(f => f.ID == testInEdit.ID))] = testInEdit;
                    CollectionViewSource.GetDefaultView(ListaTests).Refresh();
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
