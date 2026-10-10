using System;

namespace MyHttpServer.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GetAttribute : Attribute
    {
        public string Route { get; init; }
        public GetAttribute(string route)
        {
            Route = route;
        }
    }
}