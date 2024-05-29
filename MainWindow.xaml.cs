using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Projekt.Model;
using WPF_Projekt.View;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonalDataWindow personalDatawindow = new PersonalDataWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CheckDatabaseConnection()
        {
            try
            {
                ShopContext dbcontext = new ShopContext();
                if (!dbcontext.Database.CanConnect())
                {
                    MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz!");
                    Environment.Exit(1);
                }
            }
            catch
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz!");
                Environment.Exit(1);
            }
        }

        private void btn_startorder_Click(object sender, RoutedEventArgs e)
        {
            if (this.personalDatawindow == null || !this.personalDatawindow.IsLoaded)
            {
                this.personalDatawindow = new PersonalDataWindow();
                this.personalDatawindow.Show();
            }
            else
            {
                this.personalDatawindow.Show();
            }
        }


    }
}