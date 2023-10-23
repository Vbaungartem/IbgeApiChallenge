using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;
using IbgeApiChallenge.Core.Contexts.SharedContext.Entities;
using IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;

namespace IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

public class State : Entity
{
    public string IbgeCode { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Acronym { get; private set; }
    public List<Locality> LocalityList { get; set; } = new();

    protected State()
    {
    }
    public void UpdateName(string name)
    {
        Name = name;
    }
    public void UpdateIbgeCode(string ibgeCode)
    {
        IbgeCode = ibgeCode;
    }
    public void UpdateAcronym(string acronym)
    {
        Acronym = acronym;
    }
    
    public State(string ibgeCode, string name, string acronym)
    {
        if (ibgeCode is null)
            throw new Exception("O codigo do Estado não pode ser nulo.");

        if (name is null)
            throw new Exception("O nome do Estado não pode ser nulo.");

        Name = name;
        Acronym = acronym;
        IbgeCode = ibgeCode;
    }
}
