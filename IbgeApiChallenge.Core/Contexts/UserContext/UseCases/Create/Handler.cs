using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Interfaces;
using IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IUserRepository _userRepository;

    public Handler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation *************************************

        try
        {
            var res = Specifications.Assert(request);
            if (!res.IsValid)
                return new Response("Requisição inválida.", status: 400, notifications: res.Notifications);
        }
        catch
        {
            return new Response("Não foi possível validar sua requisição.", status: 500);
        }

        #endregion
        #region Generate Objects *******************************

        Email email;
        Password password;
        User user;
        
        try
        {
            email = new Email(request.Email);
            password = new Password(request.Password);

            user = new User(
                name: request.Email,
                givenName: request.Name,
                email : email,
                password: password
            );
        }
        catch 
        {
            return new Response("Não foi possível instanciar sua requisição.", 500);
        }

        #endregion
        #region User Verification ******************************

        
        var exists = await _userRepository.AnyAsync(user.Email.Address, cancellationToken);
        if (exists)
            return new Response("Já existe um usuário cadastrado com este endereço de e-mail.", status: 400);

        #endregion
        #region Data Registration ******************************

        try
        {
            await _userRepository.AppendAndSaveAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível registrar o usuário.", 500);
        }

        var responseData = new ResponseData(user.Id, user.GivenName, user.Email.Address);

        return new Response(
            message: "Usuário registrado com sucesso!",
            responseData: responseData
        );
        #endregion
    }
}