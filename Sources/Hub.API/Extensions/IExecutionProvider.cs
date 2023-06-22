using Hub.API.Events;
using System;

namespace Hub.API.Extensions
{
    public interface IExecutionProvider
    {
        event EventHandler<ClientEventArgs> OnClientInitializedEvent;
        event EventHandler<ClientEventArgs> OnRequestTimeoutEvent;
        event EventHandler<RequestEventArgs> OnMakingRequestEvent;
        event EventHandler<ResponseEventArgs> OnRequestMadeEvent;
        event EventHandler<ResponseEventArgs> OnRequestFailedEvent;
    }
}
