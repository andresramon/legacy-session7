using ShoppingCartApp.AppServices.Data;

namespace ShoppingCartApp.Domain.Services;

public class CartPriceService : ICartPriceService
{
    public decimal CalculateCart(IEnumerable<CartProduct> products)
    {
        if (products.Count(p => p.ProductCode == "VOUCHER")>=2)
        {
            return CalculateVoucherPriceWithDiscount(products);
        }
        return CalculateFullPrice(products);
    }

    private decimal CalculateVoucherPriceWithDiscount(IEnumerable<CartProduct> products)
    {

        var numberOfVouchers = products.Count(p => p.ProductCode == "VOUCHER");
        var voucherPrice = products.First(p => p.ProductCode == "VOUCHER").ProductPrice;
        var discountedPrice = Math.Round((decimal)(numberOfVouchers / 2), 0, MidpointRounding.ToZero) * voucherPrice;
        return CalculateFullPrice(products) - discountedPrice;
    }

    private static decimal CalculateFullPrice(IEnumerable<CartProduct> products)
    {
        return products.Sum(item => item.ProductPrice);
    }
}