using ShoppingCartApi.Domain.Entities;

namespace ShoppingCartApi.AppServices.Interfaces;

public interface ICustomerRepository
{
    public Customer GetUserByName(string name);
}