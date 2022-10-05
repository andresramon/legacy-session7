using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.Domain.Entities;
using ShoppingCartApi.Domain.Entities.Base;
using ShoppingCartApi.Infrastructure.Database;

namespace ShoppingCartApi.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly InMemoryDatabase _database;

        public ShoppingCartRepository(InMemoryDatabase database)
        {
            _database = database;
        }

        public void Create(ShoppingCart cart)
        {
            _database.ShoppingCarts.Add(cart.ToData());
        }

        public ShoppingCart Get(Id shoppingCartId)
        {
            var shoppingCartData = _database.ShoppingCarts.Single(cart => cart.Id == shoppingCartId);
            var shoppingCart = new ShoppingCart(new Customer("empty"));

            shoppingCart.Restore(shoppingCartData);

            return shoppingCart;
        }

        public void Save(ShoppingCart shoppingCart)
        {
            var index = _database.ShoppingCarts.FindIndex(cart => cart.Id == shoppingCart.Id);
            _database.ShoppingCarts[index] = shoppingCart.ToData();
        }
    }
}