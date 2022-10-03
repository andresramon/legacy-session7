namespace ShoppingCartApi.Domain.Entities.Base;

public record Id (Guid id)
{
    public Id():this(Guid.NewGuid())
    {
    }
    
}