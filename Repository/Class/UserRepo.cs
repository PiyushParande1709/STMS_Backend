using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;

namespace StoreManagementSystem.Repository.Class
{
    public class UserRepo : IUserRepo
    {
        private readonly StoreManagementContext _context;
        public UserRepo(StoreManagementContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }

        public async Task<User> GetUserById(int id)
        {
            User data = await _context.Users.FindAsync(id);
            return data;
        }

        public async Task<User> InsertUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _context.Users.ToList().Last();
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (await _context.Users.Where(x => x.Email==user.Email).FirstOrDefaultAsync());
  
        }

        public async Task<User> FindUser(string email,string passkey)
        {
            
            var data= await _context.Users.Where(x => x.Email == email &&  x.PassKey == passkey).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new Exception("User Not Found!");
            }
            else return data;
        }
    }
}
