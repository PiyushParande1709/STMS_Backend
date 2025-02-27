using StoreManagementSystem.DTOs;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;
using StoreManagementSystem.Service.Interface;

namespace StoreManagementSystem.Service.Class
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IStockRepo _stockRepo;
        public CartService(ICartRepo cartrepo, IStockRepo stockRepo) { 
            _cartRepo= cartrepo;
            _stockRepo= stockRepo;
        }
        public async Task<CartGetDTO> AddToCart(CartPostDTO cartPostDTO)
        {
            Cart data = MapToPost(cartPostDTO);
            Cart res= await _cartRepo.AddCart(data);
            var con=await MapToGet(res);
            return con;
        }

        public async Task DeleteCart(int id)
        {
            await _cartRepo.DeleteCart(id);
        }

        public async Task<IEnumerable<CartGetDTO>> GetAll()
        {
            var data = await _cartRepo.GetAll();
            
            List<CartGetDTO> list = new();
            foreach (var obj in data)
            {
                var a = await MapToGet(obj);
                list.Add(a);
            }
            return list;

        }

        public async Task<IEnumerable<CartGetDTO>> GetCartById(int id)
        {
            var data = await _cartRepo.GetCartById(id);
            List<CartGetDTO> list = new();
            foreach (var obj in data)
            {
                var a = await MapToGet(obj);
                list.Add(a);
            }
            return list;

        }

        public async Task<CartGetDTO> MapToGet(Cart data)
        {
            Stock productData =await _stockRepo.GetStockById((int)data.ProductId);

            var res= new CartGetDTO
            {
                Id = data.Id,
                UserId = data.UserId,
                ProductId = data.ProductId,
                Quantity = data.Quantity,
                TotalPrice = data.TotalPrice,

                ProductName = productData.ProductName,
                Brand = productData.Brand,
                Price = productData.Price,
                Img1 = Convert.ToBase64String(productData.Img1),
                Discount =productData.Discount,
                Discription=productData.Discription,
            };
            return res;

        }

        public Cart MapToPost(CartPostDTO data)
        {
            return new Cart
            {
                UserId=data.UserId,
                ProductId=data.ProductId,
                Quantity=data.Quantity,
                TotalPrice=data.TotalPrice
            };
        } 
    }
}
