using CommonClasses.BaseClasses;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestDoshico.Views;

namespace TestDoshico.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
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
            }
        }
        public Emozioni Emozioni
        {
            get { return emozioni; }
            set
            {
                emozioni = value;
                OnPropertyChanged();
            }
        }
        public Mente Mente
        {
            get { return mente; }
            set
            {
                mente = value;
                OnPropertyChanged();
            }
        }
        public Prakriti Prakriti
        {
            get { return prakriti; }
            set
            {
                prakriti = value;
                OnPropertyChanged();
            }
        }
        public Vikriti Vikriti
        {
            get { return vikriti; }
            set
            {
                vikriti = value;
                OnPropertyChanged();
            }
        }

        public ICommand AvantiCommand { get; set; }

        public MainWindowViewModel()
        {
            Cliente = new Cliente();
            TestDoshico = new Test();
            AvantiCommand = new BaseCommand(AvantiButtonPressed);
        }

        private void AvantiButtonPressed(object obj)
        {
            Page page = obj as Page;

            if(page.GetType() == typeof(DatiPersonali)){
                TestDoshico.Cliente = Cliente;
                page.NavigationService.Navigate(new QuesitiPt1());
            }
        }
    }
}
