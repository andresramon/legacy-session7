using ShoppingCartApi.AppServices.Data;

namespace ShoppingCartApi.Domain.Services
{
    public interface ICartPriceService
    {
        decimal CalculateCart(IEnumerable<CartProduct> products);
    }
}