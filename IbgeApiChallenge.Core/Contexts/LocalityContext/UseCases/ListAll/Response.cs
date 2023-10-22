using System.Security.AccessControl;
using Flunt.Notifications;
using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll;

public class Response : SharedContext.UseCases.Response
{
    protected Response()
    {
    }

    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }

    public Response(string message, ResponseData responseData)
    {
        Message = message;
        Status = 200;
        ResponseData = responseData;
    }

    public ResponseData? ResponseData { get; set; }
    public ResponseData2? ResponseData2 { get; set; }
}

public class ResponseData2
{
    protected ResponseData2()
    {
    }

    public ResponseData2(
        string id, 
        string name, 
        string stateName, 
        string stateAcronym, 
        string ibgeCode)
    {
        Id = id;
        Name = name;
        StateName = stateName;
        StateAcronym = stateAcronym;
        IbgeCode = ibgeCode;
    }
    
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string StateName { get; set; } = string.Empty;
    public string StateAcronym { get; set; } = string.Empty;
    public string IbgeCode { get; set; } = string.Empty;
}

public record ResponseData(List<LocalityVm> Localities);