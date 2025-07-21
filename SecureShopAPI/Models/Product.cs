namespace SecureShopAPI.Models;

public class Product : AuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
