namespace StoreManagementSystem.DTOs
{
    public class OrderPostDTO
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public int? Quantity { get; set; }
    }
}
