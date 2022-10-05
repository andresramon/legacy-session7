using ShoppingCartApi.Domain.Entities;

namespace ShoppingCartApi.AppServices.Interfaces
{
    public interface IProductRepository
    {
        public Product GetByCode(string productCode);
    }
}