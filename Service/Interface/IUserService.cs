using StoreManagementSystem.DTOs;

namespace StoreManagementSystem.Service.Interface
{
    public interface IUserService
    {
        Task<UserGetDTO> InsertUser(UserPostDTO user);
        Task<IEnumerable<UserGetDTO>> GetAllUser();

        Task<UserGetDTO> GetById(int id);
        Task<UserGetDTO> UpdateUser(int id,UserPutDTO user);

        Task DeleteUser(int id);

        Task<UserGetDTO> FindUser(string email, string passkey);
    }
}
