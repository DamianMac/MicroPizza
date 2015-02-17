using System.Runtime.InteropServices;
using Autofac;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace MicroPizza
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override ILifetimeScope GetApplicationContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof (Bootstrapper).Assembly);

            return builder.Build();

        }

    
    }
}