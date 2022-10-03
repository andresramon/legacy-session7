using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.Domain.Entities;
using ShoppingCartApi.Domain.Entities.Base;
using ShoppingCartApi.Infrastructure.Database;

namespace ShoppingCartApi.Infrastructure.Repositories;

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