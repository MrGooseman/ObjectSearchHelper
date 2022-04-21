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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectsSearchHelper
{
    /// <summary>
    /// Логика взаимодействия для ObjPage.xaml
    /// </summary>
    public partial class ObjPage : Page
    {
        public ObjPage()
        {
            InitializeComponent();
            if(ListClass.myAdvertOpen)
            {
                DeleteButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                Description.IsReadOnly = false;
                Price.IsReadOnly = false;
                Square.IsReadOnly = false;
            }
            using (var promo = new DBEntities())
            {
                promo.Users.Load();
                promo.Realtors.Load();
                promo.Properties.Load();
                promo.Advertisements.Load();
                try
                {
                    if (promo.Realtors.Local.Contains(promo.Realtors.Local.First(p => p.User_ID == CurrentUser.currentUser.UserID))) NextButton.Visibility = Visibility.Visible;
                }
                catch
                {

                }
                Advertisements advert = promo.Advertisements.Local.First(p => p.ID == ListClass.selectedAdvert.ID);
                Description.Text = advert.Description;
                Square.Text = advert.Properties.Square.ToString();
                Price.Text = advert.Properties.Price.ToString();
                Adress.Text = advert.Properties.Area + ", " + advert.Properties.City + ", " + advert.Properties.Street + ", " + advert.Properties.HouseNumber;
                if(ListClass.selectedAdvert.image!=null) ObjImage.Source = ListClass.selectedAdvert.image;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListClass.myAdvertOpen = false;
            FrameClass.MainFrame.Navigate(new BuyPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (var promo=new DBEntities())
            {
                promo.Advertisements.Load();
                promo.Properties.Load();
                promo.Advertisements.Local.Remove(promo.Advertisements.Local.First(p => p.ID == ListClass.selectedAdvert.ID));
                promo.Properties.Local.Remove(promo.Properties.Local.First(p => p.ID == ListClass.selectedAdvert.propID));
                promo.SaveChanges();
            }
            ListClass.myAdvertOpen = false;
            FrameClass.MainFrame.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            using (var promo = new DBEntities())
            {
                try
                {
                    promo.Advertisements.Load();
                    promo.Advertisements.Local.First(p => p.ID == ListClass.selectedAdvert.ID).Description = Description.Text;
                    promo.Advertisements.Local.First(p => p.ID == ListClass.selectedAdvert.ID).Properties.Price = Convert.ToDecimal(Price.Text);
                    promo.Advertisements.Local.First(p => p.ID == ListClass.selectedAdvert.ID).Properties.Square = Convert.ToDecimal(Square.Text);
                    promo.SaveChanges();
                    MessageBox.Show("Сохранено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Не сохранено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            ListClass.myAdvertOpen = false;
            FrameClass.MainFrame.GoBack();
        }

        private void Square_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!Square.Text.Contains(".")
               && Square.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!Price.Text.Contains(".")
               && Price.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
