﻿using Flunt.Notifications;
using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;

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
}

public record ResponseData(List<Locality> Localities);