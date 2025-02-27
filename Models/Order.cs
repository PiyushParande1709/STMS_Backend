using System;
using System.Collections.Generic;

namespace StoreManagementSystem.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public double TotalPrice { get; set; }
        public string Status { get; set; } = null!;
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Stock? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
