using ShoppingCartApp.AppServices.Interfaces;
using ShoppingCartApp.AppServices.UseCases.Exceptions;
using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.AppServices.UseCases;

public class AddProductToCartUseCase
{
    private readonly IShoppingCartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public AddProductToCartUseCase(IShoppingCartRepository cartRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public void AddProduct(Id cartId, string productCode)
    {
        var cart = _cartRepository.Get(cartId);
        
        if (cart == null)
        {
            throw new ShoppingCartNotFound();
        }
        
        var product = _productRepository.GetByCode(productCode);
        
        if (product == null)
        {
            throw new ProductNotFound();
        }
        
        cart.AddProduct(product);
        
        _cartRepository.Save(cart);
    }
}