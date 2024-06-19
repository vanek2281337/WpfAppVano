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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private string Role = "";

        public AddUser()
        {
            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                dg_product.ItemsSource = await UserServices.ShowAll();
            });
        }

      

        private async void Button_RegUser(object sender, RoutedEventArgs e)
        {
            var User = await UserServices.Reg(TextBox_RegName.Text, TextBox_RegPassword.Text, Role);
            if(User)
            { 
                dg_product.ItemsSource = await UserServices.ShowAll();
            }

        }

        private void SetRolePovar_Checked(object sender, RoutedEventArgs e)
        {
            Role = "Повар";
        }

        private void SetRoleOfficiant_Checked(object sender, RoutedEventArgs e)
        {
            Role = "Официант";
        }

        private void SetRoleAdmin_Checked(object sender, RoutedEventArgs e)
        {
            Role = "Админ";
        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {

            var window = new WindowAdmin();
            window.Show();
            Close();
        }

    }
}
