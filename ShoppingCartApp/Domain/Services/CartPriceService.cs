using ShoppingCartApp.AppServices.Data;

namespace ShoppingCartApp.Domain.Services;

public class CartPriceService : ICartPriceService
{
    public decimal CalculateCart(IEnumerable<CartProduct> products)
    {
        return products.Sum(item => item.ProductPrice);
    }
}