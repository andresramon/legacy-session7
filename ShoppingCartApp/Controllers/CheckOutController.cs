using ShoppingCartApp.AppServices.UseCases;
using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.Controllers;

public class CheckOutController
{
    private readonly CalculateCartPriceUseCase _calculateCartPriceUseCase;

    public CheckOutController(
        CalculateCartPriceUseCase calculateCartPriceUseCase)
    {
        _calculateCartPriceUseCase = calculateCartPriceUseCase;
    }

    public decimal GetCartTotal(Id shoppingCartId)
    {
        return _calculateCartPriceUseCase.CalculateCartTotal(shoppingCartId);
    }
}