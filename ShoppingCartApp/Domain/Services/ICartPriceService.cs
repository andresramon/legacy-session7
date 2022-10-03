using ShoppingCartApp.AppServices.Data;

namespace ShoppingCartApp.Domain.Services;

public interface ICartPriceService
{
    decimal CalculateCart(IEnumerable<CartProduct> products);
}