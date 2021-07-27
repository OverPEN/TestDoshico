using System.Windows.Controls;
using TestDoshico.ViewModels;

namespace TestDoshico.Views
{
    /// <summary>
    /// Logica di interazione per QuesttPt1.xaml
    /// </summary>
    public partial class QuesitiVikriti : Page
    {
        public QuesitiVikriti(MainWindowViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
