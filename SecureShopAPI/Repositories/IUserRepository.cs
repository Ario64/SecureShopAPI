using SecureShopAPI.Models;

namespace SecureShopAPI.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllUser();
    Task AddUser(User user);
    Task<User> GetById(int id);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}