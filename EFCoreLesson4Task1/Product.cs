using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreLesson4Task1
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProdId { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
