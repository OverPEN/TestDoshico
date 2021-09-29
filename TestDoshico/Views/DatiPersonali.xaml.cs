using System.Windows.Controls;
using TestDoshico.ViewModels;

namespace TestDoshico.Views
{
    /// <summary>
    /// Logica di interazione per PrimoQuestionario.xaml
    /// </summary>
    public partial class DatiPersonali : Page
    {
        public DatiPersonali(QuesitiMainFrameViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();       
        }
    }
}
