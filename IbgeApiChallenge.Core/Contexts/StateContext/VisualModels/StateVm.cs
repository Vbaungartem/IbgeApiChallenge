using IbgeApiChallenge.Core.Contexts.SharedContext.ViewModels;

namespace IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;

public class StateVm : EntityVm
{
    protected StateVm()
    {
    }
    
    public StateVm(Guid id, string name, string acronym, string ibgeCode)
    {
        Id = id;
        Name = name;
        Acronym = acronym;
        IbgeCode = ibgeCode;
    }
    
    public Guid Id { get; private set; } = new();
    public string Name { get; private set; }
    public string Acronym { get; private set; }
    public string IbgeCode { get; private set; }
}