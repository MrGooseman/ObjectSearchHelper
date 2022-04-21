using ObjectsSearchHelper.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSearchHelper
{
    class CurrentUser
    {
        public CurrentUser(Users _user)
        {
            using(var promo=new DBEntities())
            {
                promo.Users.Load();
                promo.Clients.Load();
                promo.Realtors.Load();
                foreach(var user in promo.Clients.Local)
                {
                    if (user.User_ID == _user.ID) 
                    {
                        currentUser=new UserData { ID=user.ID, Surname=user.Surname, Name=user.Name, UserID= (int)user.User_ID};
                        return;
                    }
                }
                foreach (var user in promo.Realtors.Local)
                {
                    if (user.User_ID == _user.ID)
                    {
                        currentUser = new UserData { ID = user.ID, Surname = user.Surname, Name = user.Name, UserID = (int)user.User_ID };
                        return;
                    }
                }
            }
        }
        public static UserData currentUser { get; set; }
    }
    class UserData
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
    }
}
