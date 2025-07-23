namespace SecureShopAPI.DTOs.ProductDto;

public class UpdateProductDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}