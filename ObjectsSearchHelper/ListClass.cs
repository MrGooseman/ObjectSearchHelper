using ObjectsSearchHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ObjectsSearchHelper
{
    class ListClass
    {
        public ListClass()
        {
            if(myAdvertOpen)
            {
                using (var promo = new DBEntities())
                {
                    promo.Advertisements.Load();
                    promo.Clients.Load();
                    promo.Properties.Load();
                    datas = new ObservableCollection<ListData>();
                    try
                    {
                        foreach (var advert in promo.Advertisements.Local.Where(p => p.IsDeleted == false && p.ClientID == promo.Clients.Local.First(o => o.User_ID == CurrentUser.currentUser.UserID).ID))
                        {
                            datas.Add(new ListData { ID = advert.ID, image = LoadImage(advert.Properties.Image), description = advert.Description, price = (decimal)advert.Properties.Price, propID = (int)advert.PropertiesID });
                        }
                    }
                    catch { }
                }
            }
            else
            {
                using (var promo = new DBEntities())
                {
                    promo.Advertisements.Load();
                    promo.Properties.Load();
                    datas = new ObservableCollection<ListData>();
                    try
                    {
                        foreach (var advert in promo.Advertisements.Local.Where(p => p.IsDeleted == false))
                        {
                            datas.Add(new ListData { ID = advert.ID, image = LoadImage(advert.Properties.Image), description = advert.Description, price = (decimal)advert.Properties.Price, propID = (int)advert.PropertiesID });
                        }
                    }
                    catch { }
                }
            }
        }
        public static bool myAdvertOpen { get; set; }
        public static BitmapSource LoadImage(Byte[] imageData)
        {
            if (imageData == null) return null;
            return (BitmapSource)new ImageSourceConverter().ConvertFrom(imageData);
        }
        public ObservableCollection<ListData> datas = new ObservableCollection<ListData>();
        public ListData selectedItem { get; set; }
        public static ListData selectedAdvert { get; set; }
    }
    class ListData
    {
        public int ID { get; set; }
        public BitmapSource image { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int propID { get; set; }
    }
}
