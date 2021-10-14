using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WormsWorld
{
    public class Program

    {
        public static void Main(string[] args)

        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)

        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((services) =>

                {
                    services.AddHostedService<WorldStarter>();

                    services.AddScoped<FoodGenerator>();
                    services.AddScoped<NameGenerator>();
                    services.AddScoped<WorldStateWriter>();
                    services.AddScoped<ActionPerformer>();
                });
        }
    }
}