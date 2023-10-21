using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword;

public static class Specifications
{
    public static Contract<Notification> Assert(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.OldPassword.Length, 40, "OldPassword",
                "Senha de autenticação inválida. A senha deve conter no máximo 40 caracteres.")
            .IsGreaterThan(request.OldPassword.Length, 8, "OldPassword",
                "Senha de autenticação inválida. A senha deve conter ao menos 8 caracteres.")
            .IsLowerThan(request.NewPassword.Length, 40, "NewPassword",
                "Nova senha inválida. A senha deve conter no máximo 40 caracteres.")
            .IsGreaterThan(request.NewPassword.Length, 8, "NewPassword",
                "NOva senha inválida. A senha deve conter ao menos 8 caracteres.");

}