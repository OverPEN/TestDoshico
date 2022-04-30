using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TestDoshico
{
    /// <summary>
    /// Logica di interazione per About.xaml
    /// </summary>
    public partial class About : Window
    {
        IList<AssemblyData> assemblyList;
        public About()
        {
            InitializeComponent();
            assemblyList = new List<AssemblyData>();
            AppDomain.CurrentDomain.GetAssemblies().ToList()
                .ForEach(f => assemblyList.Add(new AssemblyData() { Assembly = f.GetName().Name, Versione = f.GetName().Version.ToString() }));
            AssemblyList.ItemsSource = assemblyList;
        }
    }
}
