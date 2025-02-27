using StoreManagementSystem.Models;

namespace StoreManagementSystem.Repository.Interface
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task DeleteUser(int id);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);

        Task<User> FindUser(string email, string passkey);
    }
}
