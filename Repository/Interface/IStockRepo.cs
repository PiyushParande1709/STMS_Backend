using StoreManagementSystem.Models;

namespace StoreManagementSystem.Repository.Interface
{
    public interface IStockRepo
    {
        Task<IEnumerable<Stock>> GetAllStocks();
        Task<Stock> GetStockById(int id);
        Task DeleteStock(int id);
        Task<Stock> InsertStock(Stock stock);
        Task<Stock> UpdateStock(Stock stock);

       
    }
}
