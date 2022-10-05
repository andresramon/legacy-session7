using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.Domain.Entities;
using ShoppingCartApi.Infrastructure.Database;

namespace ShoppingCartApi.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InMemoryDatabase _database;

        public CustomerRepository(InMemoryDatabase database)
        {
            _database = database;
        }

        public Customer GetUserByName(string name)
        {
            var customer = new Customer(name);

            customer.Restore(_database.Customers.Single(c => c.Name==name));

            return customer;
        }
    }
}