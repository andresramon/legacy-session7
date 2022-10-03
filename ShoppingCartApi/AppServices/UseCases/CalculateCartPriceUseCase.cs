using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.AppServices.UseCases.Exceptions;
using ShoppingCartApi.Domain.Entities.Base;
using ShoppingCartApi.Domain.Services;

namespace ShoppingCartApi.AppServices.UseCases;

public class CalculateCartPriceUseCase
{
    private readonly ICartPriceService _priceAppService;
    private readonly ICartQueries _cartQueries;

    public CalculateCartPriceUseCase(ICartPriceService priceAppService,ICartQueries cartQueries)
    {
        _priceAppService = priceAppService;
        _cartQueries = cartQueries;
    }

    public decimal CalculateCartTotal(Id shoppingCartId)
    {
        var products = _cartQueries.getProductsFromCart(shoppingCartId);

        if (products.Count == 0)
            throw new ShoppingCartNotFound();

        return _priceAppService.CalculateCart(products);
    }
}