namespace SecureShopAPI.Models;

public class User : AuditableEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    #region Navigation Properties

    public ICollection<UserRole>?   UserRoles { get; set; }

    #endregion

}
