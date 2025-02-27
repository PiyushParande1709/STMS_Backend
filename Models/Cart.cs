using System;
using System.Collections.Generic;

namespace StoreManagementSystem.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }

        public virtual Stock? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
