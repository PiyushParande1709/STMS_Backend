using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;

namespace StoreManagementSystem.Repository.Class
{
    public class OrderRepo : IOrderRepo
    {
        private readonly StoreManagementContext _context;
        public OrderRepo(StoreManagementContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Order>> AllOrders()
        {
            var data = await _context.Orders.ToListAsync();
            return data;
        }

        public async Task EditOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrder(string orderNumber)
        {
            var data = await _context.Orders.Where(x => x.OrderNumber == orderNumber).ToListAsync();
            return data;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var data=await _context.Orders.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<Order>> GetOrderByUserId(int userId)
        {
            var data =await _context.Orders.Where(x=>x.UserId==userId).ToListAsync();
            return data;
        }

        public async Task<string> Order(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.OrderNumber;

        }
    }
}
