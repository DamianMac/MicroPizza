using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using MicroPizza.Messages;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Logger.Serilog;
using Module = Autofac.Module;

namespace PaymentService
{
    public class NimbusModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            var typeProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly(), typeof(ProcessPaymentCommand).Assembly);
            var connectionString = ConfigurationManager.AppSettings["BusConnectionString"];


            builder.RegisterType<SerilogStaticLogger>()
       .AsImplementedInterfaces()
       .SingleInstance();

            builder.RegisterNimbus(typeProvider);
            builder.Register(componentContext => new BusBuilder()
                                 .Configure()
                                 .WithConnectionString(connectionString)
                                 .WithNames("Payment", Environment.MachineName)
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