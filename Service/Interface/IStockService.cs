using StoreManagementSystem.DTOs;

namespace StoreManagementSystem.Service.Interface
{
    public interface IStockService
    {
        Task<StockGetDTO> InsertStock(StockPostDTO Stock);
        Task<IEnumerable<StockGetDTO>> GetAllStock();

        Task<StockGetDTO> GetById(int id);
        Task<StockGetDTO> UpdateStock(int id, StockPostDTO Stock);

        Task DeleteStock(int id);
    }
}
