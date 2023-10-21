using IbgeApiChallenge.Core.Contexts.SharedContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

public class State : Entity
{
    public string IbgeCode { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Acronym { get; private set; } = string.Empty;
    public List<Locality> LocalityList { get; set; } = new();

    protected State()
    {
    }

    public State(string ibgeCode, string name, string acronym)
    {
        if (ibgeCode is null)
            throw new Exception("O codigo do Estado não pode ser nulo.");

        if (name is null)
            throw new Exception("O nome do Estado não pode ser nulo.");

        if (acronym is null)
            throw new Exception("A sigla do Estado não pode ser nula.");

        Name = name;
        Acronym = acronym;
        IbgeCode = ibgeCode;
    }
}
