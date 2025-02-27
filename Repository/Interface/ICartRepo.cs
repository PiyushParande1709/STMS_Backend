using StoreManagementSystem.Models;

namespace StoreManagementSystem.Repository.Interface
{
    public interface ICartRepo
    {
        Task<Cart> AddCart(Cart cart);
        Task DeleteCart(int id);

        Task<IEnumerable<Cart>> GetAll();  

        Task<IEnumerable<Cart>> GetCartById(int id);

    }
}
