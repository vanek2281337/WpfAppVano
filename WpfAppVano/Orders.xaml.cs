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
using WpfAppVano.Services;

namespace WpfAppVano
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();
            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                dg_orders.ItemsSource = await UserServices.ShowOrder();
            });
        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {

            var window = new WindowAdmin();
            window.Show();
            Close();
        }
    }
}
