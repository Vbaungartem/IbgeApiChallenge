using IbgeApiChallenge.Core.Contexts.SharedContext.ViewModels;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

public class LocalityVm : EntityVm
{
    protected LocalityVm()
    {
    }
    
    public LocalityVm(Guid id, string name, string ibgeCode, string stateName, Guid stateId)
    {
        Id = id;
        Name = name;
        IbgeCode = ibgeCode;
        StateName = stateName;
        StateId = stateId;
    }
    public string Name { get; private set; }
    public string IbgeCode { get; private set; }
    public string StateName { get; private set; }
    public Guid StateId { get; private set; }
}