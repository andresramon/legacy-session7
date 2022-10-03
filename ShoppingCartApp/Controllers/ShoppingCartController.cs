using ShoppingCartApp.AppServices.UseCases;
using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.Controllers;

public class ShoppingCartController
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
    public Id CreateEmptyCart(string customer)
    {
       return _emptyCartUseCase.CreateFor(customer);
    }

    public void AddProduct(Id shoppingCartId , string productCode)
    {
        _addProductToCart.AddProduct(shoppingCartId, productCode);
    }
  
}