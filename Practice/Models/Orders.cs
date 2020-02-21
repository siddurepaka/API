using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int ItemId { get; set; }

        public virtual Items Item { get; set; }
    }
}
