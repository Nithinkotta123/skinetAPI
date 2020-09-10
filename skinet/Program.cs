using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace skinet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactor = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands ON");
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes ON");
                    await StoreContextSeed.SeedAsync(context, loggerFactor);
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands OFF");
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes OFF");

                }
                catch(Exception ex)
                {
                    var logger = loggerFactor.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
            host.Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
