using ObjectsSearchHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ObjectsSearchHelper
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LogTBox.Text))
            {
                MessageBox.Show("Введите корректный логин", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                LogTBox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(PassTBox.Text))
            {
                MessageBox.Show("Введите корректный пароль", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                PassTBox.Focus();
                return;
            }
            if (PassTBox.Text != PassTBoxRepeat.Text)
            {
                MessageBox.Show("Повторите пароль", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                PassTBoxRepeat.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(SurTBox.Text))
            {
                MessageBox.Show("Введите корректную фамилию", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                SurTBox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(NameTBox.Text))
            {
                MessageBox.Show("Введите корректное имя", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                NameTBox.Focus();
                return;
            }
            using (var promo = new DBEntities())
            {
                promo.Users.Load();
                promo.Clients.Load();
                foreach(var user in promo.Users.Local)
                {
                    if(user.Login==LogTBox.Text&&user.Password==PassTBox.Text)
                    {
                        MessageBox.Show("Логин уже занят, попробуйте другой", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                promo.Users.Local.Add(new Users { Login=LogTBox.Text, Password=PassTBox.Text});
                promo.Clients.Local.Add(new Clients { Surname=SurTBox.Text, Name=NameTBox.Text, User_ID=promo.Users.Local.First(p=>p.Login==LogTBox.Text).ID});
                promo.SaveChanges();
                MessageBox.Show("Сохранено", "Успех", MessageBoxButton.OK);
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
