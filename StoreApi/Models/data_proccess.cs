//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class data_proccess
    {
        public int id { get; set; }
        public string type_procces { get; set; }
        public string number_process { get; set; }
        public Nullable<System.DateTime> date_process { get; set; }
        public string depter { get; set; }
        public string location_depter { get; set; }
        public string department_depter { get; set; }
        public string creditor { get; set; }
        public string location_creditor { get; set; }
        public string department_creditor { get; set; }
        public Nullable<int> count { get; set; }
        public string give_date { get; set; }
        public Nullable<int> class_id { get; set; }
    
        public virtual class_data class_data { get; set; }
    }
}
