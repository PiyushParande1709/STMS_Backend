using StoreManagementSystem.DTOs;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;
using StoreManagementSystem.Service.Interface;

namespace StoreManagementSystem.Service.Class
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo) 
        { 
            _orderRepo= orderRepo;  
        }

        public async Task<IEnumerable<OrderGetDTO>> AllOrder()
        {
            var data = await _orderRepo.AllOrders();
            var res = data.Select(MapToGet);
            return res;
        }

        public async Task EditOrder(OrderPutDTO order,int id)
        {
           var data=await _orderRepo.GetOrderById(id);
           data.Status = order.Status;
           await _orderRepo.EditOrder(data);
        }

        public async Task<IEnumerable<OrderGetDTO>> GetOrder(string OrderNumber)
        {
            var data = await _orderRepo.GetOrder(OrderNumber);
            var res =data.Select(MapToGet);
            return res;
        }

        public async Task<IEnumerable<OrderGetDTO>> GetOrderByUserId(int userId)
        {
            var data = await _orderRepo.GetOrderByUserId(userId);
            var res = data.Select(MapToGet);
            return res;
        }

        public async Task<string> Order(OrderPostDTO order)
        {
            var data =MapToPost(order);
            return (await _orderRepo.Order(data));

        }

        private OrderGetDTO MapToGet(Order order)
        {
            return new OrderGetDTO
            {
                Id = order.Id,
                ProductId = order.ProductId,
                UserId = order.UserId,
                Status = order.Status,
                OrderNumber = order.OrderNumber,
                TotalPrice = order.TotalPrice,
                Quantity=order.Quantity,
                OrderDate=order.OrderDate
            };
        }

        private Order MapToPost(OrderPostDTO order)
        {
            return new Order
            {
                ProductId = order.ProductId,
                UserId = order.UserId,
                Status = order.Status,
                OrderNumber = order.OrderNumber,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
                OrderDate = DateTime.Now
            };
        }


    }
}
