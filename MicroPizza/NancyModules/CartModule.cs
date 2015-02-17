using MicroPizza.Messages;
using MicroPizza.Shopping;
using Nancy;
using Nimbus;

namespace MicroPizza.NancyModules
{
    public class CartModule : NancyModule
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IBus _bus;

        public CartModule(IShoppingCartRepository shoppingCartRepository, IBus bus) : base("/cart")
        {
            _shoppingCartRepository = shoppingCartRepository;
            _bus = bus;
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

                var command = new ProcessPaymentCommand{OrderId = order.Id, Amount = order.Price, CardName = "Joe Blogs"};
                _bus.Send(command);

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