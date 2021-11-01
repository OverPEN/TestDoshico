using System.Windows;
using TestDoshico.ViewModels.Quesiti;
using TestDoshico.Views.Clienti;
using TestDoshico.Views.Quesiti;
using TestDoshico.Views.Tests;

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

        private void NavigationView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if(args.SelectedItem == bt_NuovoTest)
            {
                QuesitiViewModel quesitiViewModel = new QuesitiViewModel();
                DatiPersonali datiPersonali = new DatiPersonali(quesitiViewModel);
                Main.NavigationService.Navigate(datiPersonali);
            }
            else if (args.SelectedItem == bt_ListaClienti)
            {
                ListaClienti listaClienti = new ListaClienti();
                Main.NavigationService.Navigate(listaClienti);
            }
            else if (args.SelectedItem == bt_ListaTest)
            {
                ListaTests listaTest = new ListaTests();
                Main.NavigationService.Navigate(listaTest);
            }
        }
    }
}
