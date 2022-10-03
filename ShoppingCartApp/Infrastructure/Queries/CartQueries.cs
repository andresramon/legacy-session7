using ShoppingCartApp.AppServices.Data;
using ShoppingCartApp.AppServices.Interfaces;
using ShoppingCartApp.Domain.Entities.Base;
using ShoppingCartApp.Infrastructure.Database;

namespace ShoppingCartApp.Infrastructure.Queries;

public class CartQueries : ICartQueries
{
    private readonly InMemoryDatabase _database;

    public CartQueries(InMemoryDatabase database)
    {
        _database = database;
    }
    public List<CartProduct> getProductsFromCart(Id shoppingCartId)
    {
        var cart = _database.ShoppingCarts.Single(cart => cart.Id == shoppingCartId);
        return cart.Products.Select(p => new CartProduct(p.ProductCode, p.ProductPrice)).ToList();
        
    }
}