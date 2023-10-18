using IbgeApiChallenge.Core.Contexts.SharedContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.UserContext.Entities;

public class Role : Entity
{
    public string Name { get; private set; } = string.Empty;
    public List<User> Users { get; set; } = new();
    
    protected Role()
    {
    }
    
    public Role(string name)
    {
        if (name is null)
            throw new Exception("O nome da role não pode ser nulo.");
        
        Name = name;
    }
}