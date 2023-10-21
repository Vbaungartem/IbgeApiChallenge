using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate;

public class Specifications
{
    public static Contract<Notification> Assert(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Password.Length, 40, "Password", "A senha não pode conter mais de 40 caracteres.")
            .IsGreaterThan(request.Password.Length, 8, "Password", "A senha não pode conter menos de 8 caracteres")
            .IsEmail(request.Email, "Email", "O E-mail passado é inválido!");
}