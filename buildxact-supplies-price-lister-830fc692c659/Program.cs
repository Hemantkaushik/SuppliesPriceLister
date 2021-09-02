using buildxact_supplies;
using buildxact_supplies.Extension.buildxact_supplies.Extension;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace SuppliesPriceLister
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
           .UseStartup<Startup>();
    }
}
