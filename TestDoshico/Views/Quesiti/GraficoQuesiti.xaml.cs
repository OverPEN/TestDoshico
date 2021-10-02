using System.Windows;
using TestDoshico.ViewModels.Quesiti;

namespace TestDoshico.Views.Quesiti
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
