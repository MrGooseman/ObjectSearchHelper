using ObjectsSearchHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSearchHelper
{
    class ClientsCBClass
    {
        public ClientsCBClass()
        {
            using (var promo = new DBEntities())
            {
                promo.Clients.Load();
                foreach (var man in promo.Clients.Local)
                {
                    clients.Add(new RealtorData { ID = man.ID, Name = man.Name, Surname = man.Surname });
                }
            }
        }
        public ObservableCollection<RealtorData> clients = new ObservableCollection<RealtorData>();
        public RealtorData client { get; set; }
        public string selectedClient { get; set; }
    }
}
