using ShoppingCartApp.Domain.Entities.Data;

namespace ShoppingCartApp.Domain.Entities.Base;

public abstract class Aggregate<DataType> where DataType : EntityData
{
    public Id Id;

    protected Aggregate(Id id)
    {
        Id = id;
    }

    public abstract DataType ToData();
    public abstract  void Restore(DataType data);
  
    private bool Equals(Aggregate<DataType> other) 
    {
        return this.ToData() == other.ToData();
    }
}