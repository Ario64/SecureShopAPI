using SecureShopAPI.Data;
using SecureShopAPI.Repositories;
using SecureShopAPI.Services;

namespace SecureShopAPI.UnitOfWorkService;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly SecureShopContext _context;

    public UnitOfWork(SecureShopContext context)
    {
        _context = context;
    }

    #region UserRepository

    private IUserRepository _userRepository;
    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository ??= new UserRepository(_context);
        }
    }

    #endregion

    #region Save Changes

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        _context.Dispose();
    }

    #endregion

}