using StoreManagementSystem.DTOs;

namespace StoreManagementSystem.Service.Interface
{
    public interface ICartService
    {
        Task<CartGetDTO> AddToCart(CartPostDTO cartPostDTO);
        Task DeleteCart(int id);
        Task<IEnumerable<CartGetDTO>> GetAll();

        Task<IEnumerable<CartGetDTO>> GetCartById(int id);
    }
}
