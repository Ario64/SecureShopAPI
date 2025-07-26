using Microsoft.EntityFrameworkCore;
using SecureShopAPI.Data;
using SecureShopAPI.DTOs.UserDto;
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

    //get all users
    public async Task<List<User>> GetAllUsers()
    {
        var users =await  _context.Users.ToListAsync();
        return users;
    }

    //add a new user
    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    //get a user by its Id
    public async Task<User> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        return user;
    }

    //update user password
    public async Task UpdateUser(User user)
    {
         _context.Users.Update(user);
        await  _context.SaveChangesAsync();
    }

    //delete a user 
    public async Task DeleteUser(User user)
    {
         _context.Users.Remove(user);
        await  _context.SaveChangesAsync();
    }
}