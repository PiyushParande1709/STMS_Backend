namespace StoreManagementSystem.DTOs
{
    public class UserPutDTO
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PassKey { get; set; }
        public long? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
