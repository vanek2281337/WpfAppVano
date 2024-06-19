using System;
using System.Collections.Generic;
using System.Data;
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
using WpfAppVano.Services;

namespace WpfAppVano
{
    /// <summary>
    /// Логика взаимодействия для WindowOficiant.xaml
    /// </summary>
    public partial class WindowOficiant : Window
    {
        private string Role = "";
        public WindowOficiant()
        {

            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                dg_orders.ItemsSource = await UserServices.ShowOrder();
            });
        }

        private async void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            var Order = await UserServices.Orders(Convert.ToInt32(TextBox_Table.Text), Convert.ToInt32(TextBox_Clients.Text), TextBox_FoodDrink.Text);
            if (Order)
            {

                dg_orders.ItemsSource = await UserServices.ShowOrder();
            }
        }

        private async void Button_UpdateOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            {
                var Order = await UserServices.UpdateOrderStatus(Convert.ToInt32(TextBox_IdOrder.Text), Role);
                if (Order)
                {
                    MessageBox.Show("Статус обновлен");
                    dg_orders.ItemsSource = await UserServices.ShowOrder();
                }
            }

        }

         private void StatusAccept_Checked(object sender, RoutedEventArgs e)

            {
            Role = "Принят";
            }

         private void StatusBuy_Checked(object sender, RoutedEventArgs e)

            {
            Role = "Оплачен";
        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {

            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}

