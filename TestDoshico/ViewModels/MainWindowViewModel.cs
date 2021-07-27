using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
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
    }
}
