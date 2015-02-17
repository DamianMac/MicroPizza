using Nancy;
using Nancy.Responses;
using Nimbus;

namespace MicroPizza.NancyModules
{
    public class HomeModule : NancyModule
    {
        private readonly IBus _bus;

        
        public HomeModule(IBus bus)
            : base("/")
        {
            _bus = bus;

            Get["/"] = _ => Response.AsRedirect("/cart");
        }
    }
}