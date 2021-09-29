using System.Windows;
using TestDoshico.ViewModels;
using TestDoshico.Views;

namespace TestDoshico
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class QuesitiMainFrame : Window
    {
        public QuesitiMainFrame()
        {
            InitializeComponent();
            Main.Content = new DatiPersonali(this.DataContext as QuesitiMainFrameViewModel);
        }
    }
}
