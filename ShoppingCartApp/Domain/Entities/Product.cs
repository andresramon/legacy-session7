using ShoppingCartApp.Domain.Entities.Base;
using ShoppingCartApp.Domain.Entities.Data;

namespace ShoppingCartApp.Domain.Entities;

public class Product : Aggregate<ProductData>
{
    private string _code;
    private decimal _productPrice;

    private Product(Id id, string code, decimal price):base(id)
    {
        _code = code;
        _productPrice = price;
    }

    public Product(Id id):base(id)
    {
    }

    public override ProductData ToData()
    {
        return new ProductData(Id, _code, _productPrice);
    }

    public override void Restore(ProductData data)
    {
        Id = data.Id;
        _code = data.ProductCode;
        _productPrice = data.ProductPrice;
    }

    public static IEnumerable<ProductData> GetListOfProductsData(IEnumerable<Product> products)
    {
      return products.Select(product => new ProductData(product.Id,product._code,product._productPrice));
    }

    public static IEnumerable<Product> GetListOfProducts(IEnumerable<ProductData> products)
    {
        return products.Select(product => new Product(product.Id,product.ProductCode,product.ProductPrice));
    }
}