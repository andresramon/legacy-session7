using ShoppingCartApp.AppServices.Interfaces;
using ShoppingCartApp.Domain.Entities;
using ShoppingCartApp.Domain.Entities.Base;
using ShoppingCartApp.Infrastructure.Database;

namespace ShoppingCartApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InMemoryDatabase _database;

    public ProductRepository(InMemoryDatabase database)
    {
        _database = database;
    }
    public Product GetByCode(string productCode)
    {
        var product = new Product(new Id());
        
        product.Restore(_database.Products.Single(data => data.ProductCode==productCode));
        
        return product;
    }
}