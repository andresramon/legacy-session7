using ShoppingCartApi.Domain.Entities.Base;
using ShoppingCartApi.Domain.Entities.Data;

namespace ShoppingCartApi.Infrastructure.Database;

public class InMemoryDatabase
{
    public InMemoryDatabase()
    {
        InitializeDatabase();
    }
    private  void InitializeDatabase()
    {
        Customers.Add(new CustomerData(new Id(),"John"));
        Products.Add(new ProductData(new Id(),"VOUCHER",new decimal(5)));
        Products.Add(new ProductData(new Id(),"T-SHIRT",new decimal(20)));
        Products.Add(new ProductData(new Id(),"MUG",new decimal(7.5)));
    }
    public List<ProductData> Products { get; } = new();
    public List<ShoppingCartData> ShoppingCarts { get; } = new();
    public List<CustomerData> Customers { get; } = new();
}