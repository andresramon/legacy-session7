using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartApi.Domain.Entities.Data
{
    public record ProductData(Id Id, string ProductCode, decimal ProductPrice): EntityData(Id);
}
