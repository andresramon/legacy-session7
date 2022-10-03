using ShoppingCartApi.AppServices.Data;
using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.Domain.Entities.Base;
using ShoppingCartApi.Infrastructure.Database;

namespace ShoppingCartApi.Infrastructure.Queries;

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