using System;
using System.Collections.Generic;

namespace DEMOAPI3.Models
{
    public partial class Items
    {
        public Items()
        {
            Orders = new HashSet<Orders>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemPrice { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
