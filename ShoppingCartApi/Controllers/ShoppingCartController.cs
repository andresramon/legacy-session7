using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.AppServices.UseCases;
using ShoppingCartApi.Domain.Entities.Base;


namespace ShoppingCartApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly CreateEmptyCartUseCase _emptyCartUseCase;
    private readonly AddProductToCartUseCase _addProductToCart;

    public ShoppingCartController(
        CreateEmptyCartUseCase cartUseCase,
        AddProductToCartUseCase addProductToCart)
    {
        _emptyCartUseCase = cartUseCase;
        _addProductToCart = addProductToCart;
    }
    [HttpPost("CreateEmptyCart")]
    public Id CreateEmptyCart(string customerName)
    {
       return _emptyCartUseCase.CreateFor(customerName);
    }
    [HttpPut("AddProduct")]
    public void AddProduct(Guid shoppingCartId , string productCode)
    {
        _addProductToCart.AddProduct(new Id(shoppingCartId), productCode);
    }
   
}