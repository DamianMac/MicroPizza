using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Logger.Serilog;
using Module = Autofac.Module;

namespace DeliveryService
{
    public class NimbusModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            var typeProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly());
            var connectionString = ConfigurationManager.AppSettings["BusConnectionString"];


            builder.RegisterType<SerilogStaticLogger>()
       .AsImplementedInterfaces()
       .SingleInstance();

            builder.RegisterNimbus(typeProvider);
            builder.Register(componentContext => new BusBuilder()
                                 .Configure()
                                 .WithConnectionString(connectionString)
                                 .WithNames("Delivery", Environment.MachineName)
                                 .WithTypesFrom(typeProvider)
                                 .WithAutofacDefaults(componentContext)
                                  .WithSerilogLogger()
                                 .Build())
                   .As<IBus>()
                   .AutoActivate()
                   .OnActivated(c => c.Instance.Start())
                   .SingleInstance();

        }

    }
}