using StoreManagementSystem.Models;

namespace StoreManagementSystem.Repository.Interface
{
    public interface IOrderRepo
    {
        Task<IEnumerable<Order>> GetOrder(string OrderNumber);

        Task<string> Order(Order order);

        Task EditOrder(Order order);

        Task<Order> GetOrderById(int id);

        Task<IEnumerable<Order>> GetOrderByUserId(int userId);

        Task<IEnumerable<Order>> AllOrders();
    }
}
