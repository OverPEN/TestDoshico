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
                this.prakriti = value;
                this.OnPropertyChanged();
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
                if(Prakriti == null)
                    Prakriti = new Prakriti();
                page.NavigationService.Navigate(new QuesitiPrakriti());
            }
            if (page.GetType() == typeof(QuesitiPrakriti))
            {
                TestDoshico.QuesitiPrakriti = Prakriti;
                if (Vikriti == null)
                    Vikriti = new Vikriti();
                page.NavigationService.Navigate(new QuesitiVikriti());
            }
            if (page.GetType() == typeof(QuesitiVikriti))
            {
                TestDoshico.QuesitiVikriti = Vikriti;
                if (Mente == null)
                    Mente = new Mente();
                page.NavigationService.Navigate(new QuesitiMente());
            }
            if (page.GetType() == typeof(QuesitiMente))
            {
                TestDoshico.QuesitiMente = Mente;
                if (Emozioni == null)
                    Emozioni = new Emozioni();
                page.NavigationService.Navigate(new QuesitiEmozioni());
            }
            if (page.GetType() == typeof(QuesitiEmozioni))
            {
                TestDoshico.QuesitiEmozioni = Emozioni;
                //page.NavigationService.Navigate(new QuesitiPt4());
            }
        }
    }
}
