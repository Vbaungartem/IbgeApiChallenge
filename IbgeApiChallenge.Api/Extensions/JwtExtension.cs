using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IbgeApiChallenge.Core;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create;
using Microsoft.IdentityModel.Tokens;

namespace IbgeApiChallenge.Api.Extensions;

public class JwtExtension
{
    // public static string Generate(ResponseData data)
    // {
    //     var handler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey);
    //     var credentials = new SigningCredentials(
    //         new SymmetricSecurityKey(key),
    //         SecurityAlgorithms.HmacSha256Signature);
    //
    //     var tokenDescriptor = new SecurityTokenDescriptor
    //     {
    //         Subject = GenerateClaims(data),
    //         Expires = DateTime.UtcNow.AddHours(8),
    //         SigningCredentials = credentials,
    //     };
    //     var token = handler.CreateToken(tokenDescriptor);
    //     return handler.WriteToken(token);
    // }
    // private static ClaimsIdentity GenerateClaims(ResponseData user)
    // {
    //     var claimsIdentity = new ClaimsIdentity();
    //     claimsIdentity.AddClaim(new Claim("Id", user.Id));
    //     claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
    //     claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
    //     // foreach (var role in user.Roles)
    //     //     claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
    //
    //     return claimsIdentity;
    // }
}