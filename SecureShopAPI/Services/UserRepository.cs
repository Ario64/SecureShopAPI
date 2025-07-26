using Microsoft.EntityFrameworkCore;
using SecureShopAPI.Data;
using SecureShopAPI.Models;
using SecureShopAPI.Repositories;

namespace SecureShopAPI.Services;

public class UserRepository : IUserRepository
{
    private readonly SecureShopContext _context;

    public UserRepository(SecureShopContext context)
    {
        _context = context;
    }


    public async Task<List<User>> GetAllUser()
    {
        var users =await  _context.Users.ToListAsync();
        return users;
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        return user;
    }

    public async Task UpdateUser(User user)
    {
         _context.Users.Update(user);
        await  _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var user = await  GetById(id);
         _context.Users.Remove(user);
        await  _context.SaveChangesAsync();
    }
}