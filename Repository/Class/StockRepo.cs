using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;

namespace StoreManagementSystem.Repository.Class
{
    public class StockRepo : IStockRepo
    {
        private readonly StoreManagementContext _context;
        public StockRepo(StoreManagementContext context)
        {
            _context = context;
        }

        public async Task DeleteStock(int id)
        {
            Stock stock = await _context.Stocks.FindAsync(id);
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            var data = await _context.Stocks.ToListAsync();
            return data;
        }

        public async Task<Stock> GetStockById(int id)
        {
            Stock data = await _context.Stocks.FindAsync(id);
            return data;
        }

        

        public async Task<Stock> InsertStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return _context.Stocks.ToList().Last();
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (await _context.Stocks.Where(x => x.ProductName==stock.ProductName).FirstOrDefaultAsync());
  
        }
    }
}
