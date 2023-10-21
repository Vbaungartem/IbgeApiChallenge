using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IUserAuthenticateRepository _userAuthenticateRepository;
    
    public Handler(IUserAuthenticateRepository userAuthenticateRepository)
    {
        _userAuthenticateRepository = userAuthenticateRepository;
    }
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request *************************************

        var res = Specifications.Assert(request);
        if (!res.IsValid)
            return new Response("Usuário ou senha inválidos.", status: 400, notifications: res.Notifications);
        

        #endregion

        #region Generate Objects *************************************
        User? user;
        try
        {
            user = await _userAuthenticateRepository.GetByEmailAsync(request.Email, cancellationToken);
            
            if (user is null)
                return new Response("Usuário não encontrado.", status: 404);
        }
        catch
        {
            return new Response("Não foi possível encontrar Usuário.", status: 500);
        }
        #endregion

        #region Verify Object ****************************************

        try
        {
            if (!user.Password.VerifyPassword(request.Password))
                return new Response("A senha inserida está incorreta.", status: 400);
        }
        catch
        {
            return new Response("Não foi possível verificar o Usuário.", status: 500);
        }

        #endregion

        #region Authenticate *****************************************

        try
        {
            ResponseData responseData;
            responseData = new ResponseData(
                
                id: user.Id.ToString(),
                name: user.GivenName,
                email: user.Email.Address,
                roles: user.Roles.Select(x => x.Name).ToArray()
                
            );

            return new Response("Autenticação realizada com sucesso!", responseData);
        }
        catch
        {
            return new Response("Não foi possível realizar sua autenticação.", status: 500);
        }
        #endregion
    }
}