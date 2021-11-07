using System.Linq;
using System.Windows;

namespace TestDoshico.Views.Tests
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class DatiTest : Window
    {
        public DatiTest(ViewModels.Quesiti.QuesitiViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
            Quesiti.DatiPersonali datiPersonali = new Quesiti.DatiPersonali(viewModel);
            datiPersonali.comboBox.SelectedItem = viewModel.ListaClienti.FirstOrDefault(f => f.ID == viewModel.Cliente.ID);
            Main.Content = datiPersonali;
        }
    }
}
