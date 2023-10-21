using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IUserUpdatePasswordRepository _userUpdatePasswordRepository;

    public Handler(IUserUpdatePasswordRepository userUpdatePasswordRepository)
    {
        _userUpdatePasswordRepository = userUpdatePasswordRepository;
    }


    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Assert Request *******************************************************

        try
        {
            var res = Specifications.Assert(request);
            if (!res.IsValid)
                return new Response("Requisição inválida.", status: 400, res.Notifications);
        }
        catch
        {
            return new Response("Não foi possível validar sua requisição.", status: 500); 
        }
        #endregion

        #region Validate Logged User and Generate Object ******************************************************
        
        User? user;
        try
        {
            if (request.Id != request.RequestedId)
                return new Response(
                    "O usuário autenticado não possui permissões para alterar a senha de outro usuário!", status: 400);
            
            user = await _userUpdatePasswordRepository.GetById(request.Id, cancellationToken);
            if (user is null)
                return new Response("E-mail/Usuário não cadastrado.", status: 404);
        }
        catch
        {
            return new Response("Não foi possível realizar sua requisição.", status: 500);
        }


        #endregion

        #region Validate User ********************************************************

        try
        {
            if (!user.Password.VerifyPassword(request.OldPassword))
                return new Response("E-mail ou senha inválidos.", status: 400);
            
        }
        catch
        {
            return new Response("Não foi possível validar o seu login.", status: 500);
        }

        #endregion

        #region Update Changes *******************************************************

        try
        {
            await _userUpdatePasswordRepository.UpdatePasswordUserAsync(user, request.NewPassword, cancellationToken);
        }
        catch (Exception e)
        {
            return new Response("Não foi possível realizar a alteração da sua senha.", status: 500);
        }

        var responseData = new ResponseData(
            user.Id.ToString(),
            user.GivenName,
            user.Email.Address
        );
        return new Response($"Sr. {responseData.Name}, sua senha foi atualizada com sucesso!", responseData);

        #endregion
    }
}