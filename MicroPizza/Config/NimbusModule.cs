using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using MicroPizza.Messages;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Logger.Serilog;
using PaymentService.Messages;
using Serilog;
using Module = Autofac.Module;

namespace MicroPizza.Config
{
    public class NimbusModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {


            Log.Logger = new LoggerConfiguration()
      .Enrich.WithProperty("App", "Web")
      .Enrich.WithProperty("Host", Environment.MachineName)
      .MinimumLevel.Debug()
      .WriteTo.Seq("http://localhost:5341")
      .CreateLogger();


            var typeProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly(), typeof(ProcessPaymentCommand).Assembly, typeof(PaymentSuccessfulEvent).Assembly);
            var connectionString = ConfigurationManager.AppSettings["BusConnectionString"];


            builder.RegisterType<SerilogStaticLogger>()
       .AsImplementedInterfaces()
       .SingleInstance();

            builder.RegisterNimbus(typeProvider);
            builder.Register(componentContext => new BusBuilder()
                                 .Configure()
                                 .WithConnectionString(connectionString)
                                 .WithNames("Web", Environment.MachineName)
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