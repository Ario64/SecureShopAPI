using SecureShopAPI.DTOs.UserDto;
using SecureShopAPI.Models;

namespace SecureShopAPI.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task AddUser(User user);
    Task<User> GetById(int id);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
}