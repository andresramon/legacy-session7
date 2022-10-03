using ShoppingCartApp.AppServices.Interfaces;
using ShoppingCartApp.AppServices.UseCases.Exceptions;
using ShoppingCartApp.Domain.Entities;
using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.AppServices.UseCases;

public class CreateEmptyCartUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly ICustomerRepository _customerRepository;

    public CreateEmptyCartUseCase(IShoppingCartRepository shoppingCartShoppingCartRepository, ICustomerRepository customerRepository)
    {
        _shoppingCartRepository = shoppingCartShoppingCartRepository;
        _customerRepository = customerRepository;
    }

    public Id CreateFor(string customerName)
    {
        var customer = _customerRepository.GetUserByName(customerName);
        
        if (customer == null)
        {
            throw new CustomerNotFound();
        }
        
        var cart = new ShoppingCart(customer);

        _shoppingCartRepository.Create(cart);
        
        return cart.Id;
    }
}