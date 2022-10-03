using ShoppingCartApp.Domain.Entities;

namespace ShoppingCartApp.AppServices.Interfaces;

public interface IProductRepository
{
    public Product GetByCode(string productCode);
}