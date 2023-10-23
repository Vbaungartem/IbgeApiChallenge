using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using IbgeApiChallenge.Core.Contexts.SharedContext.ValueObjects;

namespace IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;

public class IbgeCode : ValueObject
{
    protected IbgeCode()
    {
    }

    public IbgeCode(string code)
    {
        if(code.Length != 2)
            AddNotification("IbgeCode.Code", "O código do IBGE do estado deve conter exatamente 2 caracteres.");
        
        if(!CheckIbgeCode(code)) 
            AddNotification("IbgeCode.Code", "O código do IBGE do estado deve ser composto por dois valores numéricos.");
        
        Code = code;
    }

    private bool CheckIbgeCode(string code)
    {
        return Regex.IsMatch(code, @"^\d+$");
    }
    
    public string Code { get; private set; }
}