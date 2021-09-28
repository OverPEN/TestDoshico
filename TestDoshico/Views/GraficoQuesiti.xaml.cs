using System.Windows;
using TestDoshico.ViewModels;

namespace TestDoshico.Views
{
    /// <summary>
    /// Logica di interazione per GraficoQuesiti.xaml
    /// </summary>
    public partial class GraficoQuesiti : Window
    {
        public GraficoQuesiti(GraficoQuesitiViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
