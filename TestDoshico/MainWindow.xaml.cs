using System.Windows;
using TestDoshico.View.Quesiti;
using TestDoshico.Views.Clienti;

namespace TestDoshico
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_NuovoTest_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            QuesitiMainFrame quesitiMain = new QuesitiMainFrame();
            quesitiMain.Show();
            this.Close();
        }

        private void Bt_ListaClienti_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            ListaClienti listaClienti = new ListaClienti();
            listaClienti.Show();
            this.Close();
        }
    }
}
