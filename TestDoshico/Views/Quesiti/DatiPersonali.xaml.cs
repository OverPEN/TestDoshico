using System.Windows.Controls;
using TestDoshico.ViewModels.Quesiti;

namespace TestDoshico.Views.Quesiti
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
