using ShoppingCartApp.AppServices.Data;
using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.AppServices.Interfaces;

public interface ICartQueries
{
    List<CartProduct> getProductsFromCart(Id shoppingCartId);
}