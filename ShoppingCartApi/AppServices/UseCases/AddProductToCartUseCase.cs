using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.AppServices.UseCases.Exceptions;
using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartApi.AppServices.UseCases;

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