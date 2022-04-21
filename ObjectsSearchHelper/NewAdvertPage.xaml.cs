using Microsoft.Win32;
using ObjectsSearchHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectsSearchHelper
{
    /// <summary>
    /// Логика взаимодействия для NewAdvertPage.xaml
    /// </summary>
    public partial class NewAdvertPage : Page
    {
        public NewAdvertPage()
        {
            InitializeComponent();
            List<string> mas = new List<string>();
            foreach(var ril in CBViewModel.realtors)
            {
                mas.Add(ril.Surname + " " + ril.Name);
            }
            CBox.ItemsSource = mas;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.GoBack();
        }

        private void ImageLoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.PNG)|*.JPG;*.PNG";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;
            if (myDialog.ShowDialog() == true)
            {
                ObjImage.Source = new BitmapImage(new Uri(myDialog.FileName, UriKind.Absolute));
            }
        }

        private void ImageCleanButton_Click(object sender, RoutedEventArgs e)
        {
            ObjImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/default_object.png"));
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(Description.Text.Length>50||Description.Text=="")
            {
                MessageBox.Show("Проверьте правильность ввода (не более 50 символов)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Square.Text=="")
            {
                MessageBox.Show("Укажите площадь", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (AdressArea.Text == "")
            {
                MessageBox.Show("Укажите область", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (AdressCity.Text == "")
            {
                MessageBox.Show("Укажите город", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (AdressStreet.Text == "")
            {
                MessageBox.Show("Укажите улицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (AdressHouse.Text == "")
            {
                MessageBox.Show("Укажите номер дома", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Price.Text == "")
            {
                MessageBox.Show("Укажите цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using(var promo = new DBEntities())
            {
                promo.Advertisements.Load();
                promo.Properties.Load();
                promo.Users.Load();
                promo.Realtors.Load();
                string[] mas = CBViewModel.selectedRealtor.Split();
                promo.Properties.Add(new DataBase.Properties { Image = SaveImage(ObjImage.Source as BitmapSource), Square = Convert.ToDecimal(Square.Text), 
                    Price = Convert.ToDecimal(Price.Text), 
                    Area = AdressArea.Text, City = AdressCity.Text, 
                    Street = AdressStreet.Text, HouseNumber = AdressHouse.Text });
                promo.Advertisements.Add(new Advertisements { Description = Description.Text, 
                    RealtorID=promo.Realtors.Local.First(p=>p.Surname==mas[0]).ID, 
                    ClientID=CurrentUser.currentUser.ID, 
                    PropertiesID=promo.Properties.Local.First(p=>p.Street==AdressStreet.Text).ID});
                promo.SaveChanges();
            }
            FrameClass.MainFrame.GoBack();
        }
        public static byte[] SaveImage(BitmapSource bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(ms);

                return ms.GetBuffer();
            }
        }

        private void Description_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = false;
            }
        }

        private void Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = false;
            }
        }

        private void AdressHouse_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }
    }
}
