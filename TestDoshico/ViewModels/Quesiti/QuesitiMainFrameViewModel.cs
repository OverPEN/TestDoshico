using CommonClasses.BaseClasses;
using Data.Enums;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using TestDoshico.Views.Quesiti;

namespace TestDoshico.ViewModels.Quesiti
{
    public class QuesitiMainFrameViewModel : BaseNotifyPropertyChanged
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
        
        #region Commands
        public BaseCommand AvantiCommand { get; set; }
        public BaseCommand GraficoCommand { get; set; }
        public BaseCommand GraficoComplessivoCommand { get; set; }
        public BaseCommand MenuPrincipaleCommand { get; set; }
        public BaseCommand AnnullaSelezioneCommand { get; set; }
        public BaseCommand SelectedItemChangedCommand { get; set; }
        #endregion

        public QuesitiMainFrameViewModel()
        {
            AvantiCommand = new BaseCommand(AvantiButtonPressed);
            GraficoCommand = new BaseCommand(GraficoButtonPressed);
            GraficoComplessivoCommand = new BaseCommand(GraficoComplessivoButtonPressed);
            MenuPrincipaleCommand = new BaseCommand(MenuPrincipaleButtonPressed);
            AnnullaSelezioneCommand = new BaseCommand(AnnullaSelezioneButtonPressed);
            SelectedItemChangedCommand = new BaseCommand(SelectedItemChangedFired);
            Cliente = new Cliente();
            TestDoshico = new Test();
            ListaClienti = DataManager.GetAllClienti();
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

        private bool CanUseButton(object obj)
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
                    MessageServices.ShowWarningMessage("Test Doshico", errorMessage);
            }
            catch(Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nella validazione campi!", ex);
                return false;
            }
            return result;
        }

        private void AvantiButtonPressed(object obj)
        {
            try
            {
                if(CanUseButton(obj))
                {
                    Page page = obj as Page;
                    if (page != null)
                    {
                        if (page.GetType() == typeof(DatiPersonali))
                        {
                            DataManager.WriteClienteToXMLFile(cliente);
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
                            DataManager.WriteTestToXMLFile(TestDoshico);
                        }
                    }
                    else
                        MessageServices.ShowWarningMessage("Test Doshico", "Errore durante il cambio pagina del Test Doshico");
                }
            }
            catch(Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore grave durante il cambio pagina del Test Doshico!", ex);
            }
        }

        private void GraficoButtonPressed(object obj)
        {
            try
            {
                if (CanUseButton(obj))
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
                        MessageServices.ShowWarningMessage("Test Doshico", "Errore nell'apertura del grafico!");
                }
            }
            catch(Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nell'apertura del grafico!", ex);
            }
        }

        private void GraficoComplessivoButtonPressed(object obj)
        {
            try
            {
                if (CanUseButton(obj))
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
                        MessageServices.ShowWarningMessage("Test Doshico", "Errore nell'apertura del grafico!");
                }
            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nell'apertura del grafico!", ex);
            }
        }

        private void MenuPrincipaleButtonPressed(object obj)
        {
            try
            {
                Window currentWindow = obj as Window;
                if (currentWindow != null)
                {
                    if (MessageServices.ShowYesNoMessage("Test Doshico", $"Tornare al Menù Principale? {Environment.NewLine} Eventuali dati inseriti o modificati sul Test Doshico in corso verranno persi!", MessageBoxResult.Yes))
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        currentWindow.Close();
                    }
                }
                else
                    MessageServices.ShowWarningMessage("Test Doshico", "Errore nel ritorno al Menù Principale!");
            }
            catch(Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nel ritorno al Menù Principale!", ex);
            }
        }

        private void AnnullaSelezioneButtonPressed(object obj)
        {
            ComboBox cmbCliente = obj as ComboBox;
            cmbCliente.SelectedItem = null;
            Cliente = new Cliente();
        }

    }
}
