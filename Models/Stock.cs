using System;
using System.Collections.Generic;

namespace StoreManagementSystem.Models
{
    public partial class Stock
    {
        public Stock()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public int Price { get; set; }
        public double? Discount { get; set; }
        public int? Quantity { get; set; }
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;
        public byte[] Img1 { get; set; } = null!;
        public byte[]? Img2 { get; set; }
        public byte[]? Img3 { get; set; }
        public string? Discription { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
