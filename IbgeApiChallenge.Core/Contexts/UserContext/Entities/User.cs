using IbgeApiChallenge.Core.Contexts.SharedContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects;

namespace IbgeApiChallenge.Core.Contexts.UserContext.Entities;

public class User : Entity
{
    protected User()
    {
    }
    
    public User(string name, string givenName, Email email, Password password)
    {
        if (name.Length < 3)
            throw new Exception("Nome deve conter ao menos 3 caracteres");
        
        if (givenName.Length < 3)
            throw new Exception("Nome completo deve conter ao menos 3 caracteres");

        Name = name;
        GivenName = givenName;
        Email = email;
        Password = password;
    }
    
    
    public string Name { get; private set; } = string.Empty;
    public string GivenName { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    
    public List<Role> Roles { get; private set; } = new();
}