using CommonClasses.BaseClasses;
using Data.Enums;
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
using TestDoshico.Views.Quesiti;

namespace TestDoshico.ViewModels.Quesiti
{
    public class QuesitiViewModel : BaseNotifyPropertyChanged
    {
        #region Private Values
        private Cliente cliente;
        private Emozioni emozioni;
        private Mente mente;
        private Prakriti prakriti;
        private Vikriti vikriti;
        private Test TestDoshico;
        private IList<Cliente> listaClienti;
        private bool canAnnullaSelezione;
        #endregion

        #region Public Values
        public Cliente Cliente {
            get { return this.cliente; }
            set
            {
                this.cliente = value;
                this.OnPropertyChanged();
            }
        }
        public Emozioni Emozioni
        {
            get { return this.emozioni; }
            set
            {
                this.emozioni = value;
                OnPropertyChanged();
            }
        }
        public Mente Mente
        {
            get { return mente; }
            set
            {
                this.mente = value;
                OnPropertyChanged();
            }
        }
        public Prakriti Prakriti
        {
            get { return this.prakriti; }
            set
            {
                this.prakriti = value;
                this.OnPropertyChanged();
            }
        }
        public Vikriti Vikriti
        {
            get { return this.vikriti; }
            set
            {
                this.vikriti = value;
                OnPropertyChanged();
            }
        }
        public IList<Cliente> ListaClienti
        {
            get { return this.listaClienti; }
            set
            {
                this.listaClienti = value;
                this.OnPropertyChanged();
            }
        }
        public bool CanAnnullaSelezione
        {
            get { return this.canAnnullaSelezione; }
            set
            {
                this.canAnnullaSelezione = value;
                this.OnPropertyChanged();
            }
        }
        public bool PresentiClientiRegistrati => ListaClienti.Count > 0;
        #endregion

        #region Commands
        public BaseCommand AvantiCommand { get; set; }
        public BaseCommand IndietroCommand { get; set; }
        public BaseCommand GraficoCommand { get; set; }
        public BaseCommand GraficoComplessivoCommand { get; set; }
        public BaseCommand AnnullaSelezioneCommand { get; set; }
        public BaseCommand SelectedItemChangedCommand { get; set; }
        #endregion

        public QuesitiViewModel()
        {
            AvantiCommand = new BaseCommand(AvantiButtonPressed);
            GraficoCommand = new BaseCommand(GraficoButtonPressed);
            GraficoComplessivoCommand = new BaseCommand(GraficoComplessivoButtonPressed);
            AnnullaSelezioneCommand = new BaseCommand(AnnullaSelezioneButtonPressed);
            SelectedItemChangedCommand = new BaseCommand(SelectedItemChangedFired);
            IndietroCommand = new BaseCommand(IndietroButtonPressed);
            Cliente = new Cliente();
            TestDoshico = new Test();
            ListaClienti = DataManager.GetAllClienti().Result;
        }

        public QuesitiViewModel(ref Test test)
        {
            AvantiCommand = new BaseCommand(AvantiUpdateButtonPressed);
            GraficoCommand = new BaseCommand(GraficoButtonPressed);
            GraficoComplessivoCommand = new BaseCommand(GraficoComplessivoButtonPressed);
            AnnullaSelezioneCommand = new BaseCommand(AnnullaSelezioneButtonPressed);
            SelectedItemChangedCommand = new BaseCommand(SelectedItemChangedFired);
            IndietroCommand = new BaseCommand(IndietroButtonPressed);
            Cliente = DataManager.GetClienteByID(test.IDCliente) != null ? DataManager.GetClienteByID(test.IDCliente).Result : new Cliente();
            TestDoshico = test;
            ListaClienti = DataManager.GetAllClienti().Result;
            Prakriti = test.QuesitiPrakriti;
            Vikriti = test.QuesitiVikriti;
            Mente = test.QuesitiMente;
            Emozioni = test.QuesitiEmozioni;
        }

        public void SelectedItemChangedFired(object obj)
        {
            SelectionChangedEventArgs eventArgs = (SelectionChangedEventArgs)obj;
            eventArgs.Handled = true;
            
            ComboBox cmbCliente = eventArgs.Source as ComboBox;
            
            if (cmbCliente.SelectedItem != null)
                CanAnnullaSelezione = true;
            else
                CanAnnullaSelezione = false;
        }

        private async Task<bool> CanUseButton(object obj)
        {
            bool result = true;
            try
            {
                Page page = obj as Page;
                string errorMessage = String.Empty;

                if (page != null)
                {
                    if (page.GetType() == typeof(DatiPersonali))
                    {
                        List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w => w.PropertyType == typeof(string) || w.PropertyType == typeof(int)).ToList();
                        foreach (PropertyInfo T in props)
                        {
                            if (T.GetValue(Cliente) == null)
                            {
                                var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                                result = false;
                                errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                            }
                        }
                    }
                    else if (page.GetType() == typeof(QuesitiPrakriti))
                    {
                        List<PropertyInfo> props = typeof(Prakriti).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
                        foreach (PropertyInfo T in props)
                        {
                            if ((TipoCaratteristicaEnum)T.GetValue(Prakriti) == TipoCaratteristicaEnum.Selezionare)
                            {
                                var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                                result = false;
                                errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                            }
                        }
                    }
                    else if (page.GetType() == typeof(QuesitiVikriti))
                    {
                        List<PropertyInfo> props = typeof(Vikriti).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
                        foreach (PropertyInfo T in props)
                        {
                            if ((TipoCaratteristicaEnum)T.GetValue(Vikriti) == TipoCaratteristicaEnum.Selezionare)
                            {
                                var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                                result = false;
                                errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                            }
                        }
                    }
                    else if (page.GetType() == typeof(QuesitiMente))
                    {
                        List<PropertyInfo> props = typeof(Mente).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
                        foreach (PropertyInfo T in props)
                        {
                            if ((TipoCaratteristicaEnum)T.GetValue(Mente) == TipoCaratteristicaEnum.Selezionare)
                            {
                                var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                                result = false;
                                errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                            }
                        }
                    }
                    else if (page.GetType() == typeof(QuesitiEmozioni))
                    {
                        List<PropertyInfo> props = typeof(Emozioni).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
                        foreach (PropertyInfo T in props)
                        {
                            if ((TipoCaratteristicaEnum)T.GetValue(Emozioni) == TipoCaratteristicaEnum.Selezionare)
                            {
                                var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                                result = false;
                                errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                            }
                        }
                    }
                }

                if (errorMessage != String.Empty)
                    await MessageServices.ShowWarningMessage("Test Doshico", errorMessage);
            }
            catch(Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nella validazione campi!", ex);
                return false;
            }
            return result;
        }

        private async void AvantiButtonPressed(object obj)
        {
            try
            {
                if(await CanUseButton(obj))
                {
                    Page page = obj as Page;
                    if (page != null)
                    {
                        if (page.GetType() == typeof(DatiPersonali))
                        {
                            await DataManager.WriteClienteToXMLFile(cliente);
                            TestDoshico.IDCliente = Cliente.ID;
                            if (Prakriti == null)
                                Prakriti = new Prakriti();
                            page.NavigationService.Navigate(new QuesitiPrakriti(this));
                        }
                        else if (page.GetType() == typeof(QuesitiPrakriti))
                        {
                            TestDoshico.QuesitiPrakriti = Prakriti;
                            if (Vikriti == null)
                                Vikriti = new Vikriti();
                            page.NavigationService.Navigate(new QuesitiVikriti(this));
                        }
                        else if (page.GetType() == typeof(QuesitiVikriti))
                        {
                            TestDoshico.QuesitiVikriti = Vikriti;
                            if (Mente == null)
                                Mente = new Mente();
                            page.NavigationService.Navigate(new QuesitiMente(this));
                        }
                        else if (page.GetType() == typeof(QuesitiMente))
                        {
                            TestDoshico.QuesitiMente = Mente;
                            if (Emozioni == null)
                                Emozioni = new Emozioni();
                            page.NavigationService.Navigate(new QuesitiEmozioni(this));
                        }
                        else if (page.GetType() == typeof(QuesitiEmozioni))
                        {
                            TestDoshico.QuesitiEmozioni = Emozioni;
                            await DataManager.WriteTestToXMLFile(TestDoshico);
                            //GraficoComplessivoButtonPressed(page);
                        }
                    }
                    else
                        await MessageServices.ShowWarningMessage("Test Doshico", "Errore durante il cambio pagina del Test Doshico");
                }
            }
            catch(Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante il cambio pagina del Test Doshico!", ex);
            }
        }

        private async void AvantiUpdateButtonPressed(object obj)
        {
            try
            {
                if (await CanUseButton (obj))
                {
                    Page page = obj as Page;
                    if (page != null)
                    {
                        if (page.GetType() == typeof(DatiPersonali))
                        {
                            await DataManager.WriteClienteToXMLFile(cliente);
                            TestDoshico.IDCliente = Cliente.ID;
                            if (Prakriti == null)
                                Prakriti = new Prakriti();
                            page.NavigationService.Navigate(new QuesitiPrakriti(this));
                        }
                        else if (page.GetType() == typeof(QuesitiPrakriti))
                        {
                            TestDoshico.QuesitiPrakriti = Prakriti;
                            if (Vikriti == null)
                                Vikriti = new Vikriti();
                            page.NavigationService.Navigate(new QuesitiVikriti(this));
                        }
                        else if (page.GetType() == typeof(QuesitiVikriti))
                        {
                            TestDoshico.QuesitiVikriti = Vikriti;
                            if (Mente == null)
                                Mente = new Mente();
                            page.NavigationService.Navigate(new QuesitiMente(this));
                        }
                        else if (page.GetType() == typeof(QuesitiMente))
                        {
                            TestDoshico.QuesitiMente = Mente;
                            if (Emozioni == null)
                                Emozioni = new Emozioni();
                            page.NavigationService.Navigate(new QuesitiEmozioni(this));
                        }
                        else if (page.GetType() == typeof(QuesitiEmozioni))
                        {
                            TestDoshico.QuesitiEmozioni = Emozioni;
                            await DataManager.AggiornaTest(TestDoshico);
                            Window.GetWindow(page).Close();
                            //GraficoComplessivoButtonPressed(page);
                        }
                    }
                    else
                        await MessageServices.ShowWarningMessage("Test Doshico", "Errore durante il cambio pagina del Test Doshico");
                }
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante il cambio pagina del Test Doshico!", ex);
            }
        }

        private async void GraficoButtonPressed(object obj)
        {
            try
            {
                if (await CanUseButton (obj))
                {
                    Page page = obj as Page;
                    if (page != null)
                    {
                        GraficoQuesitiViewModel graficoViewModel = new GraficoQuesitiViewModel();

                        if (page.GetType() == typeof(QuesitiPrakriti))
                            graficoViewModel = new GraficoQuesitiViewModel(Prakriti, "Grafico Prakriti", "Legenda");
                        else if (page.GetType() == typeof(QuesitiVikriti))
                            graficoViewModel = new GraficoQuesitiViewModel(Vikriti, "Grafico Vikriti", "Legenda");
                        else if (page.GetType() == typeof(QuesitiEmozioni))
                            graficoViewModel = new GraficoQuesitiViewModel(Emozioni, "Grafico Emozioni", "Legenda");
                        else if (page.GetType() == typeof(QuesitiMente))
                            graficoViewModel = new GraficoQuesitiViewModel(Mente, "Grafico Mente", "Legenda");
                        GraficoQuesiti grafico = new GraficoQuesiti(graficoViewModel);
                        grafico.Owner = Window.GetWindow(page);
                        grafico.Show();
                    }
                    else
                        await MessageServices.ShowWarningMessage("Test Doshico", "Errore nell'apertura del grafico!");
                }
            }
            catch(Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nell'apertura del grafico!", ex);
            }
        }

        private async void GraficoComplessivoButtonPressed(object obj)
        {
            try
            {
                if (await CanUseButton (obj))
                {
                    Page page = obj as Page;
                    if (page != null)
                    {
                        GraficoQuesitiViewModel graficoViewModel = new GraficoQuesitiViewModel();

                        if (TestDoshico.QuesitiEmozioni == null && Emozioni != null)
                            TestDoshico.QuesitiEmozioni = Emozioni;
                        
                        graficoViewModel = new GraficoQuesitiViewModel(TestDoshico, "Grafico Complessivo", "Legenda");
                        GraficoQuesiti grafico = new GraficoQuesiti(graficoViewModel);
                        grafico.Owner = Window.GetWindow(page);
                        grafico.Show();
                    }
                    else
                        await MessageServices.ShowWarningMessage("Test Doshico", "Errore nell'apertura del grafico!");
                }
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nell'apertura del grafico!", ex);
            }
        }

        private void AnnullaSelezioneButtonPressed(object obj)
        {
            ComboBox cmbCliente = obj as ComboBox;
            cmbCliente.SelectedItem = null;
            Cliente = new Cliente();
        }

        private async void IndietroButtonPressed(object obj)
        {
            try
            {
                Page page = obj as Page;
                if (page != null)
                {
                    if (page.GetType() == typeof(QuesitiPrakriti))
                    {
                        TestDoshico.QuesitiPrakriti = Prakriti;
                        if (Cliente == null)
                            Cliente = new Cliente();
                        page.NavigationService.Navigate(new DatiPersonali(this));
                    }
                    else if (page.GetType() == typeof(QuesitiVikriti))
                    {
                        TestDoshico.QuesitiVikriti = Vikriti;
                        if (Prakriti == null)
                            Prakriti = new Prakriti();
                        page.NavigationService.Navigate(new QuesitiPrakriti(this));
                    }
                    else if (page.GetType() == typeof(QuesitiMente))
                    {
                        TestDoshico.QuesitiMente = Mente;
                        if (Vikriti == null)
                            Vikriti = new Vikriti();
                        page.NavigationService.Navigate(new QuesitiVikriti(this));
                    }
                    else if (page.GetType() == typeof(QuesitiEmozioni))
                    {
                        TestDoshico.QuesitiEmozioni = Emozioni;
                        if (Mente == null)
                            Mente = new Mente();
                        page.NavigationService.Navigate(new QuesitiMente(this));
                    }
                }
                else
                    await MessageServices.ShowWarningMessage("Test Doshico", "Errore durante il cambio pagina del Test Doshico");
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante il cambio pagina del Test Doshico!", ex);
            }
        }
    }
}
