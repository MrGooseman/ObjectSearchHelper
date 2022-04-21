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
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page
    {
        public BuyPage()
        {
            InitializeComponent();
            ClientsCBClass client = new ClientsCBClass();
            List<string> mas = new List<string>();
            foreach(var _client in client.clients)
            {
                mas.Add(_client.Surname + " " + _client.Name);
            }
            BuyerBox.ItemsSource = mas;
            using(var promo=new DBEntities())
            {
                promo.Clients.Load();
                promo.Realtors.Load();
                promo.Advertisements.Load();
                SellerName.Text = promo.Clients.Local.First(p => p.ID == promo.Advertisements.Local.First(k => k.ID == ListClass.selectedAdvert.ID).ClientID).Surname + " " + promo.Clients.Local.First(p => p.ID == promo.Advertisements.Local.First(k => k.ID == ListClass.selectedAdvert.ID).ClientID).Name;

                RealtorName.Text = promo.Realtors.Local.First(p => p.ID == promo.Advertisements.Local.First(k => k.ID == ListClass.selectedAdvert.ID).RealtorID).Surname + " " + promo.Realtors.Local.First(p => p.ID == promo.Advertisements.Local.First(k => k.ID == ListClass.selectedAdvert.ID).RealtorID).Name;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new ListPage());
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недвижимость куплена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            using (var promo = new DBEntities())
            {
                promo.Advertisements.Load();
                promo.Properties.Load();
                promo.Advertisements.Remove(promo.Advertisements.First(p => p.ID == ListClass.selectedAdvert.ID));
                promo.Properties.Remove(promo.Properties.First(p => p.ID == ListClass.selectedAdvert.propID));
                promo.SaveChanges();
            }
            FrameClass.MainFrame.Navigate(new ListPage());
        }
    }
}
