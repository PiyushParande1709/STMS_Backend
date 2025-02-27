using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;

namespace StoreManagementSystem.Repository.Class
{
    public class CartRepo : ICartRepo
    {
        private readonly StoreManagementContext _context;
        public CartRepo(StoreManagementContext context) {
            _context = context;
        }

        public async Task<Cart> AddCart(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return _context.Carts.ToList().Last();
        }

        public async Task DeleteCart(int id)
        {
            Cart cart= await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<IEnumerable<Cart>> GetCartById(int id)
        {
            var data=await _context.Carts.Where(x=>x.UserId==id).ToListAsync();
            return data;
        }
    }
}
