using ModernWpf.Controls;
using TestDoshico.ViewModels.Clienti;

namespace TestDoshico.Views.Clienti
{
    /// <summary>
    /// Logica di interazione per PrimoQuestionario.xaml
    /// </summary>
    public partial class NuovoCliente : Page
    {
        public NuovoCliente(NuovoClienteViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
