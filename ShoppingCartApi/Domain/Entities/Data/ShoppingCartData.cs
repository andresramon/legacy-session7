using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartApi.Domain.Entities.Data
{
    public record ShoppingCartData(Id Id, CustomerData Customer, IEnumerable<ProductData> Products): EntityData(Id);
}