using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create;

public static class Specifications
{
    public static async Task<Contract<Notification>> Assert(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerOrEqualsThan(request.IbgeCode.Length, 2, "IbgeCode", "O código do IBGE deve conter exatamente 2 caracteres.")
            .IsGreaterOrEqualsThan(request.IbgeCode.Length, 2, "IbgeCode", "O código do IBGE deve conter exatamente 2 caracteres.")
            .IsLowerOrEqualsThan(request.Acronym.Length, 2, "Acronym", "O acrônimo do estado deve conter exatamente 2 caracteres.")
            .IsGreaterOrEqualsThan(request.Acronym.Length, 2, "Acronymm", "O acrônimo do estado deve conter exatamente 2 caracteres.")
            .IsLowerOrEqualsThan(request.Name.Length, 50, "Name", "O nome do estado não pode conter mais do que 50 caracteres")
            .IsGreaterOrEqualsThan(request.Name.Length, 3, "Name", "O nome do estado deve conter ao mesmo 3 caracteres");
}