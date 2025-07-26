using SecureShopAPI.Repositories;

namespace SecureShopAPI.UnitOfWorkService;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public void SaveChanges();
    Task  SaveChangesAsync();
}