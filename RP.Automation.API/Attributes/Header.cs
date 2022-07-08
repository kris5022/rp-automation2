using RestSharp;
using System;

namespace RP.Automation.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class Header : Attribute
    {
        public string Name { get; set; }

        public void Set(RestRequest request, object value)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (value == null) return;
            request.AddParameter(Name, value, ParameterType.HttpHeader);
        }
    }
}
