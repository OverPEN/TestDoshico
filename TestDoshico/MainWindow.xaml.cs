using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestDoshico.Views;

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

            //((PieSeries)Chart.Series[0]).ItemsSource = new KeyValuePair<string, int>[]
            //{
            //    new KeyValuePair<string, int> ("Mango", 10),
            //    new KeyValuePair<string, int> ("Banana", 36 ),
            //    new KeyValuePair<string, int> ("Grapes", 15 ),
            //    new KeyValuePair<string, int> ("Apple", 20 )
            //};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DatiPersonali();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new QuesttPt1();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new QuesttPt2();
        }
    }
}
