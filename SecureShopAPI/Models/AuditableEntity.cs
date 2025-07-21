﻿namespace SecureShopAPI.Models;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}
