using ShoppingCartApp.Domain.Entities.Base;

namespace ShoppingCartApp.Domain.Entities.Data;

public record ShoppingCartData(Id Id, CustomerData Customer,IEnumerable<ProductData> Products): EntityData(Id);