using StoreManagementSystem.DTOs;
using StoreManagementSystem.Models;
using StoreManagementSystem.Repository.Interface;
using StoreManagementSystem.Service.Interface;

namespace StoreManagementSystem.Service.Class
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepo.DeleteUser(id);
        }

        public async Task<UserGetDTO> UpdateUser(int id, UserPutDTO user)
        {
            var response = await _userRepo.GetUserById(id);
            await MapToEntity(user, response);
            var data =await _userRepo.UpdateUser(response);
            return MapUserToGet(data);

        }

        public async Task<IEnumerable<UserGetDTO>> GetAllUser()
        {
            var data = await _userRepo.GetAllUsers();
            var response = data.Select(MapUserToGet);
            return response;
        }

        public async Task<UserGetDTO> GetById(int id)
        {
            var data = await _userRepo.GetUserById(id);
            return MapUserToGet(data);
        }

        public async Task<UserGetDTO> InsertUser(UserPostDTO user)
        {
            var response = await _userRepo.InsertUser(MapPostToUser(user));
            return MapUserToGet(response);
        }

        public async Task<UserGetDTO> FindUser(string email, string passkey)
        {
            var data= await _userRepo.FindUser(email, EncryptPass(passkey));
            if (data == null)
            {
                throw new Exception("User Not Found!");
            }
            else return MapUserToGet(data);
        }


        //Used to convert UserPostDto to User
        public User MapPostToUser(UserPostDTO user)
        {
            return new User
            {
                FullName = user.FullName,
                Email = user.Email,
                PassKey = EncryptPass(user.PassKey),
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Role = user.Role
            };
        }

        //Used to convert User to UserGetDto
        public UserGetDTO MapUserToGet(User user)
        {
            return new UserGetDTO
            {
                Id=user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PassKey = DecryptPass(user.PassKey),
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Role = user.Role
            };
        }

        //Used to Update Data
        public async Task MapToEntity(UserPutDTO newData,User currentData)
        {
            currentData.Address = newData.Address;
            currentData.Email = newData.Email;
            currentData.FullName = newData.FullName;
            currentData.PassKey = EncryptPass(newData.PassKey);
            currentData.Phone = newData.Phone;
            currentData.DateOfBirth = newData.DateOfBirth;
        }

        private string EncryptPass(string passkey)
        {
            string output="";
            foreach(char value in passkey)
            {
                int ans = (int)value + 10;
                if (ans > 126)
                {
                    ans = (ans-126)+31;//To keep the asscii value in the range of 32 to 126
                }
                output += ((char)ans).ToString();
            }
            return output;
        }

        private string DecryptPass(string passkey)
        {
            string output = "";
            foreach (char value in passkey)
            {
                int ans = (int)value - 10;
                if (ans < 32)
                {
                    ans = (ans + 126) - 31;//To keep the asscii value in the range of 32 to 126
                }
                output += ((char)ans).ToString();
            }
            return output;
        }

    }
}
