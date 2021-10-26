using CommonClasses.BaseClasses;
using Data.Models;
using Data.Services;
using TestDoshico.Views.Clienti;

namespace TestDoshico.ViewModels.Clienti
{
    public class DatiClienteViewModel : BaseNotifyPropertyChanged
    {
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return this.cliente; }
            set
            {
                this.cliente = value;
                this.OnPropertyChanged();
            }
        }

        public BaseCommand SalvaCommand { get; set; }

        public DatiClienteViewModel(ref Cliente cliente)
        {
            this.Cliente = cliente;
            SalvaCommand = new BaseCommand(SalvaButtonPressed);
        }

        private void SalvaButtonPressed(object obj)
        {
            DatiCliente view = obj as DatiCliente;
            DataManager.AggiornaCliente(Cliente);

            if (view != null)
                view.Close();
        }
    }
}
