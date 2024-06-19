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
using WpfAppVano.Services;

namespace WpfAppVano
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click_Auth(object sender, RoutedEventArgs e)
        {
            var res = await UserServices.Auth(TextBox_Login.Text , TextBox_Password.Text );
            if (res != null)
            {
                MessageBox.Show("Успешно");
                switch(res)
                {
                    case "Администратор":
                        var page = new WindowAdmin();
                        page.Show();
                        Close();
                        break;
                    case "Повар":
                        var page2 = new WindowPovar();
                        page2.Show();
                        Close();
                        break;
                    case "Официант":
                        var page3 = new WindowOficiant();
                        page3.Show();
                        Close();
                        break;

                }
               
            }
            else
            {
                MessageBox.Show("Не успешно");
            }
        }
    }
}