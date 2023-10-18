namespace IbgeApiChallenge.Core.Contexts.SharedContext.Entities;

public class Entity
{
    protected Entity()
        => Id = Guid.NewGuid();
    
    public Guid Id { get; }
    
    public bool Equals(Guid id)
    {
        return Id == id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}