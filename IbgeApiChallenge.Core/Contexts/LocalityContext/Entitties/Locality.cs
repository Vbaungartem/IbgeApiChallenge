using IbgeApiChallenge.Core.Contexts.SharedContext.Entities;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;

public class Locality : Entity
{
    public string IbgeCode { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public Guid StateId { get; private set; } = Guid.Empty;
    public State State { get; private set; } = null!;

    protected Locality(string ibgeCode)
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
