namespace ShoppingCartApp.Domain.Entities.Base;

public record Id
{
    private readonly Guid _guid;

    public Id(Guid guid)
    {
        _guid = guid;
    }

    public Id()
    {
        _guid = Guid.NewGuid();
    }
   
}