namespace SecureShopAPI.Models;

public class Role : BaseEntity
{
    public string RoleTitle { get; set; } = string.Empty;

    #region Navigation Properties

    public ICollection<UserRole>? UserRoles { get; set; }

    #endregion

}
