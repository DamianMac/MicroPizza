using Nancy;

namespace MicroPizza.NancyModules
{
    public class CartModule : NancyModule
    {
        public CartModule() : base("/cart")
        {
            Get["/"] = _ => View["home"];
        }
    }
}