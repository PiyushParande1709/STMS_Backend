using StoreManagementSystem.DTOs;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;
using StoreManagementSystem.Service.Interface;

namespace StoreManagementSystem.Service.Class
{
    public class StockService : IStockService
    {
        private readonly IStockRepo _stockRepo;

        public StockService(IStockRepo stockRepo)
        {
            _stockRepo = stockRepo;
        }

        public async Task DeleteStock(int id)
        {
            await _stockRepo.DeleteStock(id);
        }

        public async Task<StockGetDTO> UpdateStock(int id, StockPostDTO stock)
        {
            var response = await _stockRepo.GetStockById(id);
            await MapToEntity(stock, response);
            var data = await _stockRepo.UpdateStock(response);
            return MapStockToGet(data);

        }

        public async Task<IEnumerable<StockGetDTO>> GetAllStock()
        {
            var data = await _stockRepo.GetAllStocks();
            var response = data.Select(MapStockToGet);
            return response;
        }

        public async Task<StockGetDTO> GetById(int id)
        {
            var data = await _stockRepo.GetStockById(id);
            var res= MapStockToGet(data);
            return res;
        }

        public async Task<StockGetDTO> InsertStock(StockPostDTO stock)
        {
            var response = await _stockRepo.InsertStock(MapPostToStock(stock));
            return MapStockToGet(response);
        }


        //Used to convert StockPostDto to Stock
        public Stock MapPostToStock(StockPostDTO stock)
        {
            return new Stock
            {
                ProductName = stock.ProductName,
                Brand = stock.Brand,
                Price = stock.Price,
                Discount = stock.Discount,
                Quantity = stock.Quantity,
                Type = stock.Type,
                Status = stock.Status,
                Img1 = Convert.FromBase64String(stock.Img1 ?? string.Empty),
                Img2 = Convert.FromBase64String(stock.Img2 ?? string.Empty),
                Img3 = Convert.FromBase64String(stock.Img3 ?? string.Empty),
                Discription = stock.Discription
            };
        }

        //Used to convert Stock to StockGetDto
        public StockGetDTO MapStockToGet(Stock stock)
        {
            return new StockGetDTO
            {
                Id=stock.Id,
                ProductName = stock.ProductName,
                Brand = stock.Brand,
                Price = stock.Price,
                Discount = stock.Discount,
                Quantity = stock.Quantity,
                Type = stock.Type,
                Status = stock.Status,
                Img1 = Convert.ToBase64String(stock.Img1),
                Img2 = stock.Img2 !=null? Convert.ToBase64String(stock.Img2):null,
                Img3 = stock.Img3 != null ? Convert.ToBase64String(stock.Img3) : null,
                Discription = stock.Discription
            };
        }

        //Used to Update Data
        public async Task MapToEntity(StockPostDTO stock, Stock currentData)
        {
            currentData.ProductName = stock.ProductName;
            currentData.Brand = stock.Brand;
            currentData.Price = stock.Price;
            currentData.Discount = stock.Discount;
            currentData.Quantity = stock.Quantity;
            currentData.Type = stock.Type;
            currentData.Status = stock.Status;
            currentData.Img1 = Convert.FromBase64String(stock.Img1);
            currentData.Img2 = Convert.FromBase64String(stock.Img1);
            currentData.Img3 = Convert.FromBase64String(stock.Img1);
            currentData.Discription = stock.Discription;
        }
    }
}
    
