using System.Windows.Controls;
using TestDoshico.ViewModels.Quesiti;

namespace TestDoshico.Views.Quesiti
{
    /// <summary>
    /// Logica di interazione per QuesttPt1.xaml
    /// </summary>
    public partial class QuesitiMente : Page
    {
        public QuesitiMente(QuesitiMainFrameViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
