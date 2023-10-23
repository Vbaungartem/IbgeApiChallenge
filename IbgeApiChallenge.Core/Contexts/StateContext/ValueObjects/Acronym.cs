using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;
using IbgeApiChallenge.Core.Contexts.SharedContext.ValueObjects;

namespace IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;

public class Acronym : ValueObject 
{
    protected Acronym()
    {
    }

    public Acronym(string acronymText)
    {
        if(acronymText.Length == 0)
            AddNotification("Acronym.AcronymText", "A sigla do estado não pode ser nula.");
        
        if(!CheckAcronym(acronymText))
            AddNotification("Acronym.AcronymText", "A sigla estado deve conter apenas letras (maiúsculas ou minúsculas).");
        
        AcronymText = acronymText.ToUpper();
    }

    private bool CheckAcronym(string text)
    {
        return Regex.IsMatch(text, @"^[a-zA-Z]+$");
    }

    public string AcronymText { get; private set; }
}