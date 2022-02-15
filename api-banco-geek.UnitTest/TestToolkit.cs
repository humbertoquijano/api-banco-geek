using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.UnitTest
{
    public static class TestToolkit
    {
        public static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }

        public static void ConfigureDB(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<api_banco_geek.Infraestructure.ApiBancoGeekDbContext>(
                options => { options.UseSqlServer(connectionString); }, ServiceLifetime.Transient);
        }
    }
}
