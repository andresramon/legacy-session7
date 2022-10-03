using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.AppServices.UseCases;
using ShoppingCartApi.Domain.Entities.Base;


namespace ShoppingCartApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckOutController : ControllerBase
{
    private readonly CalculateCartPriceUseCase _calculateCartPriceUseCase;

    public CheckOutController(
        CalculateCartPriceUseCase calculateCartPriceUseCase)
    {
        _calculateCartPriceUseCase = calculateCartPriceUseCase;
    }

    [HttpGet("GetCartTotal")]
    public decimal GetCartTotal(Guid shoppingCartId)
    {
        return _calculateCartPriceUseCase.CalculateCartTotal(new Id(shoppingCartId));
    }
}