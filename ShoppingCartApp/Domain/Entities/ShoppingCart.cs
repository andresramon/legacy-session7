using ShoppingCartApp.Domain.Entities.Base;
using ShoppingCartApp.Domain.Entities.Data;

namespace ShoppingCartApp.Domain.Entities;

public class ShoppingCart : Aggregate<ShoppingCartData>
{
    private readonly Customer _customer;
    private readonly List<Product> _products; 
    
    
    public ShoppingCart(Customer customer) : this(new Id(),customer)
    {
    }

    public ShoppingCart(Id id, Customer customer) : base(id)
    {
        _customer = customer ?? throw new ArgumentNullException();
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException();
        }
        _products.Add(product);
    }
    
    public override ShoppingCartData ToData()
    {
        return new ShoppingCartData(Id,
           _customer.ToData(),
           Product.GetListOfProductsData(_products));
    }

   
    public override void Restore(ShoppingCartData data)
    {
        
        Id = data.Id;
        _customer.Restore(data.Customer);
        _products.AddRange( Product.GetListOfProducts(data.Products));
    }
}