using Autofac;
using MicroPizza.Shopping;

namespace MicroPizza.Config
{
    public class ShoppingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ShoppingCartRepository>().As<IShoppingCartRepository>().SingleInstance();

        }
    }
}