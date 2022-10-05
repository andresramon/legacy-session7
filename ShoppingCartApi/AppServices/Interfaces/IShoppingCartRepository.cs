using ShoppingCartApi.Domain.Entities;
using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartApi.AppServices.Interfaces
{
    public interface IShoppingCartRepository
    {
        public void Create(ShoppingCart cart);
        ShoppingCart Get(Id id);
        void Save(ShoppingCart shoppingCart);
    }
}