
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreManagementSystem.DTOs;
using StoreManagementSystem.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreManagementSystem.Controllers
{
    [Route("[controller]/api/")]
    [ApiController]
    public class StoreManagementController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IStockService _stockService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        public StoreManagementController(IOrderService orderService,IUserService userService, IStockService stockService, ICartService cartService)
        {
            _userService = userService;
            _stockService = stockService;
            _cartService = cartService;
            _orderService = orderService;
        }

        private string CreateJWT(UserGetDTO user)
        {
                                                                      
            var jwtTokenHandler = new JwtSecurityTokenHandler();//this instance will be used to create and validate JWT Tokens.
            var key = Encoding.ASCII.GetBytes("DontKnowAboutThisButitISVeryVerySecretKey@!!...");//This encodes the key into a byte[]
            var payload = new ClaimsIdentity(new Claim[]
            {
                new("role", user.Role),
                new("name",user.FullName),
                new("id",user.Id.ToString())
            });
            var credentials=new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);//Signing the token

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = payload,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor); //Creates the token
            return jwtTokenHandler.WriteToken(token); //Converts the token into string and return it.
        }

        //Apis related to User table
        [Route("users")]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var data= await _userService.GetAllUser();
            return Ok(data);
        }
        [Route("addUser")]
        [HttpPost]
        public async Task<IActionResult> InsertUser(UserPostDTO user)
        {
            var data = await _userService.InsertUser(user);
            return Ok(data);
        }
        [Route("authenticate")]
        [HttpPost]
        public async Task<IActionResult> AuthUser(AuthenticateDTO data)
        {
            var response = await _userService.FindUser(data.Email,data.PassKey);
            var token = CreateJWT(response);
            if (response == null)
            {
                return BadRequest(new { message = "User Not Found" });
            }
            else return Ok(new {Token= token });
        }

        [Route("userById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var data = await _userService.GetById(id);
            return Ok(data);
        }

        [Route("updateUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id,UserPutDTO user)
        {
            var data = await _userService.UpdateUser(id,user);
            return Ok(data);
        }

        [Route("deleteUser/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            var response = new { message="User Deleted Successfully!!"};
            return Ok(response);

        }


        //Apis related to Stock table
        [Route("stocks")]
        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {
            var data = await _stockService.GetAllStock();
            return Ok(data);
        }

        [Route("addStock")]
        [HttpPost]
        public async Task<IActionResult> InsertStock(StockPostDTO stock)
        {
            var data = await _stockService.InsertStock(stock);
            return Ok(data);
        }

        [Route("StockById/{id}")]
        [HttpGet]

        public async Task<IActionResult> GetStock(int id)
        {
            var data = await _stockService.GetById(id);
            return Ok(data);
        }

        [Route("updateStock/{id}")]
        [HttpPut]

        public async Task<IActionResult> UpdateStock(int id, StockPostDTO stock)
        {
            var data = await _stockService.UpdateStock(id, stock);
            return Ok(data);
        }

        [Route("deleteStock/{id}")]
        [HttpDelete]

        public async Task<IActionResult> DeleteStock(int id)
        {
            await _stockService.DeleteStock(id);
            var response = new { message = "Product Deleted Successfully!!" };
            return Ok(response);

        }

        //Api Related to Cart Table
        [Route("getAllCart")]
        [HttpGet]

        public async Task<IActionResult> GetAllCart()
        {
            return Ok(await _cartService.GetAll());
        }

        [Route("deleteCart/{id}")]
        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
           await _cartService.DeleteCart(id);
           var response = new { message = "Cart Data Deleted Successfully!!" };
           return Ok(response);
        }

        [Route("addCart")]
        [HttpPost]

        public async Task<IActionResult> AddCart(CartPostDTO data)
        {
            var response = await _cartService.AddToCart(data);
            return Ok(response);
        }

        [Route("cart/{id}")]
        [HttpGet]

        public async Task<IActionResult> GetCart(int id)
        {
            var res = await _cartService.GetCartById(id);
            return Ok(res);
        }

        [Route("order")]
        [HttpPost]

        public async Task<IActionResult> Order(OrderPostDTO order)
        {
            var data = await _orderService.Order(order);
            return Ok(new { OrderNumber = data });
        }

        [Route("order/{orderNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetOrder(string orderNumber)
        {
            var data =await _orderService.GetOrder(orderNumber);
            return Ok(data);
        }

        [Route("allOrder")]
        [HttpGet]
        public async Task<IActionResult> AllOrder()
        {
            var data = await _orderService.AllOrder();
            return Ok(data);
        }

        [Route("orders/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetOrder(int userId)
        {
            var data = await _orderService.GetOrderByUserId(userId);
            return Ok(data);
        }

        [Route("order/{id}")]
        [HttpPut]
        public async Task<IActionResult> EditOrder(OrderPutDTO order,int id)
        {
            await _orderService.EditOrder(order, id);
            return Ok(new { message = "Order Updated!!" });
        }
    }
}
