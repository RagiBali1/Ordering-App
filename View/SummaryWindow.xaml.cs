using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Projekt.Repository;
using WPF_Projekt.Model;

namespace WPF_Projekt.View
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        private SummaryRepository repository;
        public SummaryWindow()
        {
            repository = new SummaryRepository(new ShopContext());
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Köszönjük rendelését!");
            Environment.Exit(0);
        }

        private void back_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
