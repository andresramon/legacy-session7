using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.Domain.Entities.Data;

public record CustomerData(Id Id, string Name) : EntityData(Id);
