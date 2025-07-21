using System;

namespace SecureShopAPI.Models;

public class UserRole : BaseEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    #region Navigation Properties

    public User? User { get; set; }
    public Role? Role { get; set; }

    #endregion
}
