using ShoppingCartApp.Domain.Entities.Data;

namespace ShoppingCartApp.Infrastructure.Database;

public class InMemoryDatabase
{
    public List<ProductData> Products { get; } = new();
    public List<ShoppingCartData> ShoppingCarts { get; } = new();
    public List<CustomerData> Customers { get; } = new();
}