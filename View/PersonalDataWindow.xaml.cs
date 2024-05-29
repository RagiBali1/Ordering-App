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
using WPF_Projekt.Model;
using WPF_Projekt.Repository;

namespace WPF_Projekt.View
{
    /// <summary>
    /// Interaction logic for PersonalDataWindow.xaml
    /// </summary>
    public partial class PersonalDataWindow : Window
    {
        private OrderWindow orderWindow = new OrderWindow();
        private List<Customer> selectedCustomers;
        private PersonalDataRepository prepo;
        private Op operation = Op.No;

        enum Op
        {
            Add,
            Upd,
            No
        }
        public PersonalDataWindow()
        {
            prepo = new PersonalDataRepository(new ShopContext());
            InitializeComponent();
            LoadCustomerGrid();
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Continue_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderWindow == null || !this.orderWindow.IsLoaded)
            {
                this.orderWindow = new OrderWindow();
                this.orderWindow.Show();
            }
            else
            {
                this.orderWindow.Show();
            }
        }

        private void LoadCustomerGrid()
        {
            selectedCustomers = prepo.GetCustomers();
            data_Grid.DataContext = selectedCustomers;
        }

        private void new_Btn_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Add;
            name_box.IsEnabled = true;
            email_box.IsEnabled = true;
            city_box.IsEnabled = true;
        }

        private void save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Add && name_box.Text != "" && email_box.Text != "" &&  city_box.Text != "")
            {
                prepo.InsertCustomer(new Customer
                {
                    Name = name_box.Text,
                    Email = email_box.Text,
                    City = city_box.Text,
                });
                prepo.Save();
                LoadCustomerGrid();
                name_box.IsEnabled = false;
                email_box.IsEnabled = false;
                city_box.IsEnabled = false;
                name_box.Text = string.Empty;
                email_box.Text = string.Empty;
                city_box.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Hiba lépett fel próbálja meg később!");
            }
        }

        private void update_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Upd)
            {
                name_box.IsEnabled = true;
                email_box.IsEnabled = true;
                city_box.IsEnabled = true;
                Customer cust = prepo.GetCustomerById(selectedCustomers[data_Grid.SelectedIndex].Id);
                cust.Name = name_box.Text;
                cust.Email = email_box.Text;
                cust.City = city_box.Text;
                prepo.UpdateCustomer(cust);
                prepo.Save();
                LoadCustomerGrid();
                operation = Op.No;
                name_box.IsEnabled = false;
                email_box.IsEnabled = false;
                city_box.IsEnabled = false;
                name_box.Text = string.Empty;
                email_box.Text = string.Empty;
                city_box.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Hiba lépett fel próbálja meg később!");
            }
        }

        private void delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            Customer cust_del = prepo.GetCustomerById(selectedCustomers[data_Grid.SelectedIndex].Id);
            if (operation == Op.Upd)
            {
                prepo.DeleteCustomer(cust_del.Id);
                prepo.Save();
                LoadCustomerGrid();
                operation= Op.No;
            }
            name_box.Text = string.Empty;
            email_box.Text = string.Empty;
            city_box.Text = string.Empty;
        }

        private void data_Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (selectedCustomers.Count != 0)
            {
                name_box.IsEnabled = true;
                email_box.IsEnabled = true;
                city_box.IsEnabled = true;
                name_box.Text = selectedCustomers[data_Grid.SelectedIndex].Name;
                email_box.Text = selectedCustomers[data_Grid.SelectedIndex].Email;
                city_box.Text = selectedCustomers[data_Grid.SelectedIndex].City;
                operation = Op.Upd;
                prepo.Save();
            }
            else
            {
                MessageBox.Show("Hiba lépett fel próbálja meg később!");
            }
        }
    }
}
