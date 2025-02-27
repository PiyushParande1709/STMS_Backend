namespace StoreManagementSystem.DTOs
{
    public class CartGetDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        
        //data from StockTable
        public string ProductName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public int Price { get; set; }
        public double? Discount { get; set; }
        public string? Discription { get; set; }
        public string Img1 { get; set; }
        
    }
}
