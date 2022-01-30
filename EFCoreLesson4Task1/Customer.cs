using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreLesson4Task1
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime? DateInSystem { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
