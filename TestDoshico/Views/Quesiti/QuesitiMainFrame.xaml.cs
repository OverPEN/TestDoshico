using System.Windows;
using TestDoshico.ViewModels.Quesiti;
using TestDoshico.Views.Quesiti;

namespace TestDoshico.View.Quesiti
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
