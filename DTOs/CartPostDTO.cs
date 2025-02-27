namespace StoreManagementSystem.DTOs
{
    public class CartPostDTO
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
    }
}
