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
    class CBClass
    {
        public CBClass()
        {
            using (var promo = new DBEntities())
            {
                promo.Realtors.Load();
                foreach(var man in promo.Realtors.Local)
                {
                    realtors.Add(new RealtorData { ID = man.ID, Name = man.Name, Surname = man.Surname });
                }
            }
        }
        public ObservableCollection<RealtorData> realtors = new ObservableCollection<RealtorData>();
        public RealtorData realtor { get; set; }
        public  string selectedRealtor { get; set; }
    }
    class RealtorData
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}
