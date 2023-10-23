using System.Text.RegularExpressions;
using IbgeApiChallenge.Core.Contexts.SharedContext.ValueObjects;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.ValueObjects;

public class IbgeCode : ValueObject
{
    protected IbgeCode()
    {
    }

    public IbgeCode(string code)
    {
        if(code.Length != 7)
            AddNotification("IbgeCode.Code", "O código do IBGE da localidade deve conter exatamente 7 caracteres.");
        
        if(!CheckIbgeCode(code)) 
            AddNotification("IbgeCode.Code", "O código do IBGE da localidade deve ser composto por dois valores numéricos.");

        Code = code;
    }

    private bool CheckIbgeCode(string code)
    {
        return Regex.IsMatch(code, @"^\d+$");
    }
    
    public string Code { get; set; }
}