using ShoppingCartApp.Domain.Entities;

namespace ShoppingCartApp.AppServices.Interfaces;

public interface ICustomerRepository
{
    public Customer GetUserByName(string name);
}