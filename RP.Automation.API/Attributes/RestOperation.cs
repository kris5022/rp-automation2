using RestSharp;
using System;

namespace RP.Automation.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RestOperation : Attribute
    {
        public RestOperation()
        {
            Verb = Method.Get;
        }
        
        public int ReadWriteTimeout { get; set; }
        public string Resource { get; set; }
        public int ConnectionTimeout { get; set; }
        public Method Verb { get; set; }
    }
}
