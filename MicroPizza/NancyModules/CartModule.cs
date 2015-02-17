using MicroPizza.Shopping;
using Nancy;

namespace MicroPizza.NancyModules
{
    public class CartModule : NancyModule
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public CartModule(IShoppingCartRepository shoppingCartRepository) : base("/cart")
        {
            _shoppingCartRepository = shoppingCartRepository;
            Get["/"] = _ => View["home"];
            Post["place"] = _ =>
            {


                var order = new PizzaOrder();
                order.LineItems.Add("1 Pepperoni Pizza");
                order.LineItems.Add("1 Garlic Bread");
                order.Price = 19;

                _shoppingCartRepository.AddOrder(order);

                var url = "/cart/pay/" + order.Id;

                return Response.AsRedirect(url);
            };

            Get["pay/{orderid}"] = _ =>
            {

                var order = _shoppingCartRepository.Get(_.orderid);

                return View["pay", order];
            };

            Post["pay/{orderid}"] = _ =>
            {
                var order = _shoppingCartRepository.Get(_.orderid);

                var url = "/cart/check/" + (string)(order.Id.ToString());

                return Response.AsRedirect(url);
            };

            Get["check/{orderid}"] = _ =>
            {
                var order = _shoppingCartRepository.Get(_.orderid);


                return View["check", order];
            };

        }
    }
}