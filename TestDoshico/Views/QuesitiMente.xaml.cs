using System.Windows.Controls;
using TestDoshico.ViewModels;

namespace TestDoshico.Views
{
    /// <summary>
    /// Logica di interazione per QuesttPt1.xaml
    /// </summary>
    public partial class QuesitiMente : Page
    {
        public QuesitiMente(MainWindowViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
