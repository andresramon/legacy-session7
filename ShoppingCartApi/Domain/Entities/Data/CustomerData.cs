using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartApi.Domain.Entities.Data
{
    public record CustomerData(Id Id, string Name) : EntityData(Id);
}
