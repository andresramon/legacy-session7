using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.Domain.Entities.Data;

public record ProductData(Id Id, string ProductCode,decimal ProductPrice): EntityData(Id);
