using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ObjectsSearchHelper.DataBase;

namespace ObjectsSearchHelper
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //if (Data_Check())
            //{
            //    //оригинал
            //    //CurrentUser user = new CurrentUser(promo.Users.Local.First(p => p.Login == LogTBox.Text && (p.Password == PassTBox.Text || p.Password == PassBox.Password)));
            //    //MainWindow mainWindow = new MainWindow();
            //    //mainWindow.Show();
            //    //Close();
            //    //return;
            //}
            string homePath = "https://localhost:5001/authenticate";
            HttpWebRequest request = WebRequest.CreateHttp(homePath+$"?login={LogTBox.Text}&password={PassTBox.Text}");
            request.Method = "GET";
            using(WebResponse response=request.GetResponse())
            {
                using (Stream stream=response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    MessageBox.Show(reader.ReadToEnd());
                }
            }
        }

        private bool Data_Check()
        {
            using (var promo = new DBEntities())
            {
                promo.Users.Load();
                try
                {
                    if (promo.Users.Local.Contains(promo.Users.Local.First(p => p.Login == LogTBox.Text && (p.Password == PassTBox.Text || p.Password == PassBox.Password))))
                    {
                        return true;
                    }

                }
                catch
                {

                }
                MessageBox.Show("Проверьте правильность ввода логина или пароля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }

        private void ShowPassCBox_Checked(object sender, RoutedEventArgs e)
        {
            PassTBox.Text = PassBox.Password;
            PassBox.Visibility = Visibility.Hidden;
            PassTBox.Visibility = Visibility.Visible;
        }

        private void ShowPassCBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PassBox.Password = PassTBox.Text;
            PassTBox.Visibility = Visibility.Hidden;
            PassBox.Visibility = Visibility.Visible;
        }
    }
}
