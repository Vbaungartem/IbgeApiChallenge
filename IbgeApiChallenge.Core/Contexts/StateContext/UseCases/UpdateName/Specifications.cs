using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateName;
public static class Specifications
{
    public static Contract<Notification> Assert(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerOrEqualsThan(request.Name.Length, 50, "Name", 
                "O nome do estado não pode conter mais do que 50 caracteres")
            .IsGreaterOrEqualsThan(request.Name.Length, 3, "Name", 
                "O nome do estado deve conter ao mesmo 3 caracteres");
    
}