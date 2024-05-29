using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private SummaryWindow summaryWindow = new SummaryWindow();
        private OrderRepository orep;
        private List<Stock> selectedOrder;
        private Op operation = Op.No;

        enum Op
        {
            Add,
            Upd,
            No
        }
        public OrderWindow()
        {
            InitializeComponent();
            orep = new OrderRepository(new ShopContext());
            LoadOrdersGrid();
        }

        private void Summary_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.summaryWindow == null || !this.summaryWindow.IsLoaded)
            {
                this.summaryWindow = new SummaryWindow();
                this.summaryWindow.Show();
            }
            else
            {

            this.summaryWindow.Show();
            }
        
        }

        private void LoadOrdersGrid()
        {
            selectedOrder = orep.GetOrders();
            Data_Grid.DataContext = selectedOrder;
        }


        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }

        private void new_Btn_Click(object sender, RoutedEventArgs e)
        {
            operation = Op.Add;
            plank_box.IsEnabled = true;
            beam_box.IsEnabled = true;
            osb_box.IsEnabled = true;
            panel_box.IsEnabled = true;
        }

        private void save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Add && plank_box.Text != "" && beam_box.Text != "" && osb_box.Text != "" && panel_box.Text != "")
            {
                orep.InsertOrder(new Stock
                {
                    Planks = plank_box.Text,
                    Beams = beam_box.Text,
                    OSB = osb_box.Text,
                    Panels = panel_box.Text,
                }
                );
                orep.Save();
                LoadOrdersGrid();
                plank_box.IsEnabled = false;
                beam_box.IsEnabled = false;
                osb_box.IsEnabled = false;
                panel_box.IsEnabled = false;
                plank_box.Text = "0";
                beam_box.Text = "0";
                osb_box.Text = "0";
                panel_box.Text = "0";
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
                plank_box.IsEnabled = true;
                beam_box.IsEnabled = true;
                osb_box.IsEnabled = true;
                panel_box.IsEnabled = true;
                Stock stck = orep.GetOrderById(selectedOrder[Data_Grid.SelectedIndex].Id);
                stck.Planks = plank_box.Text;
                stck.Beams = beam_box.Text;
                stck.OSB = osb_box.Text;
                stck.Panels = panel_box.Text;
                orep.UpdateOrder(stck);
                orep.Save();
                LoadOrdersGrid();
                operation = Op.No;
                plank_box.IsEnabled = false;
                beam_box.IsEnabled = false;
                osb_box.IsEnabled = false;
                panel_box.IsEnabled = false;
                plank_box.Text = "0";
                beam_box.Text = "0";
                osb_box.Text = "0";
                panel_box.Text = "0";
            }
            else
            {
                MessageBox.Show("Hiba lépett fel próbálja meg később!");
            }
        }

        private void delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            Stock stockDelete = orep.GetOrderById(selectedOrder[Data_Grid.SelectedIndex].Id);
            if (operation == Op.Upd)
            {
                orep.DeleteOrder(stockDelete.Id);
                orep.Save();
                LoadOrdersGrid();
                operation = Op.No;
                plank_box.IsEnabled = false;
                beam_box.IsEnabled = false;
                osb_box.IsEnabled = false;
                panel_box.IsEnabled = false;
                plank_box.Text = "0";
                beam_box.Text = "0";
                osb_box.Text = "0";
                panel_box.Text = "0";
            }
        }

        private void data_Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if ( selectedOrder.Count != 0)
            {
                plank_box.IsEnabled = true;
                beam_box.IsEnabled = true;
                osb_box.IsEnabled = true;
                panel_box.IsEnabled = true;
                plank_box.Text = selectedOrder[Data_Grid.SelectedIndex].Planks;
                beam_box.Text = selectedOrder[Data_Grid.SelectedIndex].Beams;
                osb_box.Text = selectedOrder[Data_Grid.SelectedIndex].OSB;
                panel_box.Text = selectedOrder[Data_Grid.SelectedIndex].Panels;
                operation = Op.Upd;
                orep.Save();
            }
            else
            {
                MessageBox.Show("Hiba lépett fel próbálja meg később!");
            }
        }
    }
}
