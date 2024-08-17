using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Containeraization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                var confi=scope.ServiceProvider.GetService<IConfiguration>();
                Console.WriteLine(confi.GetSection("ConnectionStrings:DockerDbConnectionString").Value);
                Console.WriteLine(db.Database.CanConnect());
                db.Database.Migrate();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((s,c) => {
                        c.AddJsonFile("appsettings.json")
                         .AddJsonFile($"appsettings.{s.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                         .AddJsonFile($"secrets/appsettings.secrets.json", optional: true, reloadOnChange: true)
                         .AddEnvironmentVariables()
                         .Build();
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
