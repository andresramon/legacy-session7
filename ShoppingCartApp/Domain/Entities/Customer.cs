using ShoppingCartApp.Domain.Entities.Base;
using ShoppingCartApp.Domain.Entities.Data;

namespace ShoppingCartApp.Domain.Entities;

public class Customer : Aggregate<CustomerData>
{
    private string _name;

    public Customer(string name):base(new Id(Guid.NewGuid()))
    {
        _name = name;
    }

    public override CustomerData ToData()
    {
        return new CustomerData(Id, _name);
    }

    public override void Restore(CustomerData data)
    {
        Id = data.Id;
        _name = data.Name;
    }
}