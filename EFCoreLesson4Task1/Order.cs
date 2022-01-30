using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreLesson4Task1
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Customer CustomerNoNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
