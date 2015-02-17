using Nancy;
using Nancy.Responses;

namespace MicroPizza.NancyModules
{
    public class HomeModule : NancyModule
    {
        public HomeModule() : base("/")
        {
            Get["/"] = _ => Response.AsRedirect("/cart");
        }
    }
}