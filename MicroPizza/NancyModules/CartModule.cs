using Nancy;

namespace MicroPizza.NancyModules
{
    public class CartModule : NancyModule
    {
        public CartModule() : base("/cart")
        {
            Get["/"] = _ => View["home"];
            Post["place"] = _ =>
            {

                return Response.AsRedirect("/cart/pay");
            };

            Get["pay"] = _ =>
            {
                return View["pay"];
            };

            Post["pay"] = _ =>
            {
                return Response.AsRedirect("/cart/check");
            };

            Get["check"] = _ =>
            {


                return View["check"];
            };

        }
    }
}