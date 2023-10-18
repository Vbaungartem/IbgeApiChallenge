using System.Text.RegularExpressions;
using IbgeApiChallenge.Core.Contexts.SharedContext.Extensions;

namespace IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects;

public partial class Email
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string address)
    {
        if(address is null)
            throw new Exception("E-mail inválido");

        if (!EmailRegex().IsMatch(address))
            throw new Exception("E-mail inválido");
        
        Address = address; 
    }
    
    public string Address { get; private set; }
    public string Hash => Address.ToBase64();
    
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}