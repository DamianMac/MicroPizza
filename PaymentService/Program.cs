using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serilog;
using Serilog.Extras.Topshelf;
using Topshelf;

namespace PaymentService
{
    class Program
    {
        static void Main(string[] args)
        {


            var builder = new ContainerBuilder();

            builder.RegisterType<PaymentServiceRunner>().AsSelf();
            builder.RegisterModule<NimbusModule>();

            var container = builder.Build();

            Log.Logger = new LoggerConfiguration()
      .Enrich.WithProperty("App", "Payment")
      .Enrich.WithProperty("Host", Environment.MachineName)
      .MinimumLevel.Debug()
      .WriteTo.Seq("http://localhost:5341")
      .WriteTo.ColoredConsole()
      .CreateLogger();



            HostFactory.Run(x =>
            {

                x.Service<PaymentServiceRunner>(s =>
                {
                    s.ConstructUsing(name => container.Resolve<PaymentServiceRunner>());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.UseSerilog();
                x.SetDescription("Pizza Payment Service");
                x.SetDisplayName("Pizza Payment Service");
                x.SetServiceName("PizzaPaymentService");
            });

        }
    }
}
