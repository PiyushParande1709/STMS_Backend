namespace StoreManagementSystem.DTOs
{
    public class StockPostDTO
    {
        public string ProductName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public int Price { get; set; }
        public double? Discount { get; set; }
        public int? Quantity { get; set; }
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Img1 { get; set; } = null!;
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string? Discription { get; set; }

    }
}
