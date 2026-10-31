using System;

namespace MyHttpServer.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PostAttribute : Attribute
    {
        public string Route { get; init; }
        public PostAttribute(string route)
        {
            Route = route;
        }
    }
}
