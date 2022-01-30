using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreLesson4Task1
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int LineItem { get; set; }
        public int? ProdId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Prod { get; set; }
    }
}
