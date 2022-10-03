using ShoppingCartApi.AppServices.Data;
using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartApi.AppServices.Interfaces;

public interface ICartQueries
{
    List<CartProduct> getProductsFromCart(Id shoppingCartId);
}