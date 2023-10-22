using IbgeApiChallenge.Core.Contexts.SharedContext.ViewModels;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

public class LocalityStateVm : EntityVm
{
    protected LocalityStateVm()
    {
    }
    
    public LocalityStateVm(Guid id, string name, string ibgeCode, Guid stateId, StateVm state)
    {
        Id = id;
        Name = name;
        IbgeCode = ibgeCode;
        StateId = stateId;
        State = state;
    }
    public string Name { get; private set; }
    public string IbgeCode { get; private set; }
    public Guid StateId { get; private set; }
    public StateVm State { get; private set; }
}