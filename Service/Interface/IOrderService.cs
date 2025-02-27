using StoreManagementSystem.DTOs;
using StoreManagementSystem.Models;

namespace StoreManagementSystem.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderGetDTO>> GetOrder(string OrderNumber);
        Task<IEnumerable<OrderGetDTO>> GetOrderByUserId(int userId);

        Task<string> Order(OrderPostDTO order);

        Task EditOrder(OrderPutDTO order,int id);

        Task<IEnumerable<OrderGetDTO>> AllOrder();
    }
}
