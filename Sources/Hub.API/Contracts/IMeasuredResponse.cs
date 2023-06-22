using RestSharp;
using System;

namespace Hub.API.Contracts
{
    public interface IMeasuredResponse : IRestResponse
    {
        TimeSpan ExecutionTime { get; set; }
    }
}
