using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create;

public class Specifications
{
    public static async Task<Contract<Notification>> Assert(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerOrEqualsThan(request.IbgeCode.Length, 7, "IbgeCode", "O código do IBGE deve conter exatamente 7 caracteres.")
            .IsGreaterOrEqualsThan(request.IbgeCode.Length, 7, "IbgeCode", "O código do IBGE deve conter exatamente 7 caracteres.")
            .IsLowerOrEqualsThan(request.Name.Length, 50, "Name", "O nome da localidade não pode conter mais do que 50 caracteres")
            .IsGreaterOrEqualsThan(request.Name.Length, 3, "Name", "O nome da localidade deve conter ao menos 3 caracteres");
}
