using IbgeApiChallenge.Core.Contexts.LocalityContext.ValueObjects;
using IbgeApiChallenge.Core.Contexts.SharedContext.Entities;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;

public class Locality : Entity
{
    public string IbgeCode { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Guid StateId { get; private set; } = Guid.Empty;
    public virtual State State { get; private set; } = null!;


    public void UpdateName(string name)
    {
        Name = name;
    }
    public void UpdateIbgeCode(string ibgeCode)
    {
        
        IbgeCode = ibgeCode;
    }

    public void UpdateStateId(Guid stateId)
    {
        StateId = stateId;
    }

    public void UpdateIbgeCodeWithoutSufixChanges(string ibgeCode)
    {
        var prefixCode = IbgeCode.Substring(0, 2);
        var code = ibgeCode.Substring(2, 5);
        var newCode = prefixCode + code;
        
        IbgeCode = newCode;
    }
    
    protected Locality()
    {
    }

    public Locality(string ibgeCode, string name, string stateId)
    {
        if (ibgeCode is null)
            throw new Exception("O codigo da Cidade não pode ser nulo.");

        if (name is null)
            throw new Exception("O nome da Cidade não pode ser nulo.");

        if (stateId.Equals(Guid.Empty))
            throw new Exception("O id da Cidade não pode ser nulo.");

        Name = name;
        StateId = Guid.Parse(stateId);
        IbgeCode = ibgeCode;

    }
}
