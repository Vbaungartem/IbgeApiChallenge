using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create;

public static class Specifications
{
    public static Contract<Notification> Assert(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Name.Length, 250, "Name", "O nome deve conter menos que 250 caracteres")
            .IsGreaterThan(request.Name.Length, 3, "Name", "O nome deve conter ao menos 3 caracteres.")
            .IsLowerThan(request.Password.Length, 40, "Password", "A senha deve conter no máximo 40 caracteres.")
            .IsGreaterThan(request.Password.Length, 8, "Password", "A senha deve conter ao menos 8 caracteres.")
            .IsEmail(request.Email, "Email", "O e-mail inserido não é válido");
}