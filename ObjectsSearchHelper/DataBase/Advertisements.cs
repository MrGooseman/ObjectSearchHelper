//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObjectsSearchHelper.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Advertisements
    {
        public int ID { get; set; }
        public Nullable<int> RealtorID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> PropertiesID { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Properties Properties { get; set; }
        public virtual Realtors Realtors { get; set; }
    }
}
