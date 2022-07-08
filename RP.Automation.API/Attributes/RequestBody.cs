using RestSharp;
using System;

namespace RP.Automation.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class RequestBody : Attribute
    {
        public void Set(RestRequest request, object value)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            request.AddJsonBody(value);
        }
    }
}
