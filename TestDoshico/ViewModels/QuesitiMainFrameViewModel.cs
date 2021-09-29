using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using TestDoshico.Views;

namespace TestDoshico.ViewModels
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
        #endregion

        public Cliente Cliente {
            get { return this.cliente; }
            set
            {
                this.cliente = value;
                this.OnPropertyChanged();
                AvantiCommand.RaiseCanExecuteChanged();
            }
        }
        public Emozioni Emozioni
        {
            get { return this.emozioni; }
            set
            {
                this.emozioni = value;
                OnPropertyChanged();
                AvantiCommand.RaiseCanExecuteChanged();
            }
        }
        public Mente Mente
        {
            get { return mente; }
            set
            {
                this.mente = value;
                OnPropertyChanged();
                AvantiCommand.RaiseCanExecuteChanged();
            }
        }
        public Prakriti Prakriti
        {
            get { return this.prakriti; }
            set
            {
                this.prakriti = value;
                this.OnPropertyChanged();
                AvantiCommand.RaiseCanExecuteChanged();
            }
        }
        public Vikriti Vikriti
        {
            get { return this.vikriti; }
            set
            {
                this.vikriti = value;
                OnPropertyChanged();
                AvantiCommand.RaiseCanExecuteChanged();
            }
        }

        public BaseCommand AvantiCommand { get; set; }
        public BaseCommand GraficoCommand { get; set; }
        public BaseCommand MenuPrincipaleCommand { get; set; }

        public QuesitiMainFrameViewModel()
        {
            AvantiCommand = new BaseCommand(AvantiButtonPressed, CanUseButton);
            GraficoCommand = new BaseCommand(GraficoButtonPressed, CanUseButton);
            MenuPrincipaleCommand = new BaseCommand(MenuPrincipaleButtonPressed);
            Cliente = new Cliente();
            TestDoshico = new Test();
        }

        private bool CanUseButton(object obj)
        {
            Page page = obj as Page;
            bool result = true;
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
                Xceed.Wpf.Toolkit.MessageBox.Show(errorMessage, "Errore di compilazione", MessageBoxButton.OK, MessageBoxImage.Warning);
            return result;
        }

        private void AvantiButtonPressed(object obj)
        {
            Page page = obj as Page;

            if(page.GetType() == typeof(DatiPersonali)){
                DataManager.WriteClienteToJsonFile(cliente);
                TestDoshico.IDCliente = Cliente.ID;
                if(Prakriti == null)
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
                DataManager.WriteTestToJsonFile(TestDoshico);
            }
        }

        private void GraficoButtonPressed(object obj)
        {
            Page page = obj as Page;

            if (page.GetType() == typeof(QuesitiPrakriti))
            {
                GraficoQuesitiViewModel graficoViewModel = new GraficoQuesitiViewModel(Prakriti, "Grafico Prakriti", "Legenda");
                GraficoQuesiti grafico = new GraficoQuesiti(graficoViewModel);
                grafico.Show();
            }
            if (page.GetType() == typeof(QuesitiVikriti))
            {
                GraficoQuesitiViewModel graficoViewModel = new GraficoQuesitiViewModel(Vikriti, "Grafico Vikriti", "Legenda");
                GraficoQuesiti grafico = new GraficoQuesiti(graficoViewModel);
                grafico.Show();
            }
            if (page.GetType() == typeof(QuesitiEmozioni))
            {
                GraficoQuesitiViewModel graficoViewModel = new GraficoQuesitiViewModel(Emozioni, "Grafico Emozioni", "Legenda");
                GraficoQuesiti grafico = new GraficoQuesiti(graficoViewModel);
                grafico.Show();
            }
            if (page.GetType() == typeof(QuesitiMente))
            {
                GraficoQuesitiViewModel graficoViewModel = new GraficoQuesitiViewModel(Mente, "Grafico Mente", "Legenda");
                GraficoQuesiti grafico = new GraficoQuesiti(graficoViewModel);
                grafico.Show();
            }
        }

        private void MenuPrincipaleButtonPressed(object obj)
        {
            Window currentWindow = obj as Window;

            if (MessageServices.ShowYesNoMessage("Test Doshico", $"Tornare al Menù Principale? {Environment.NewLine} Eventuali dati inseriti o modificati sul Test Doshico in corso verranno persi!", MessageBoxResult.Yes))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                currentWindow.Close();
            }
        }
        
    }
}
