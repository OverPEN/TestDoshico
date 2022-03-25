using System.Windows;
using TestDoshico.ViewModels.Clienti;

namespace TestDoshico.Views.Clienti
{
    /// <summary>
    /// Logica di interazione per PrimoQuestionario.xaml
    /// </summary>
    public partial class DatiCliente : Window
    {
        public DatiCliente(DatiClienteViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
