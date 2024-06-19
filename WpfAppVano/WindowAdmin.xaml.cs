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
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                dg_product.ItemsSource = await UserServices.ShowAll();
            });
        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {
            var page = new Orders();
            page.Show();
            Close();
        }

        private async void Button_Click_Smena(object sender, RoutedEventArgs e)
        {
            var User = await UserServices.UpdateUserSmena(TextBox_TimeSmena.Text, TextBox_IdSmena.Text);
            if (User)
            {
                MessageBox.Show("Cмена назначена");
                dg_product.ItemsSource = await UserServices.ShowAll();
            }
        }

        private void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            var page = new AddUser();
            page.Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_UpdateUserStatus(object sender, RoutedEventArgs e)
        {
            var User = await UserServices.UpdateUserStatus(TextBox_DeleteUser.Text);
            if (User)
            {
                MessageBox.Show("Успешно УВОЛЕН");
                dg_product.ItemsSource = await UserServices.ShowAll();
            }
        }
        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {

            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
