using ShoppingCartApi.AppServices.Data;

namespace ShoppingCartApi.Domain.Services
{
    public class CartPriceService : ICartPriceService
    {
        public decimal CalculateCart(IEnumerable<CartProduct> products)
        {
            return products.Sum(item => item.ProductPrice);
        }
    }
}