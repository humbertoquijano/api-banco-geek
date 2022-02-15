using api_banco_geek.Domain.Contracts;
using api_banco_geek.Domain.Models;
using api_banco_geek.Domain.Services;
using api_banco_geek.Infraestructure.Entities;
using api_banco_geek.Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace api_banco_geek.UnitTest
{
    public class NumberProcessorTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public NumberProcessorTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void MustThrowsException_From_InvalidInput()
        {
            NumberProcessor processor = BuildNumberProcessor();

            SumArgs sumArgs = new SumArgs { A = -1, B = 25 };

            var exception = Record.Exception(() => processor.ProcessNumbers(sumArgs));

            Assert.NotNull(exception);
        }

        private NumberProcessor BuildNumberProcessor()
        {
            var builder = new ConfigurationBuilder();
            TestToolkit.BuildConfig(builder);
            var config = builder.Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    string connectionString = config.GetConnectionString("local");

                    TestToolkit.ConfigureDB(services, connectionString);

                    services.AddTransient<IApiCallLogRepository, ApiCallLogRepository>();
                    services.AddTransient<IFibonacciRepository, FibonacciRepository>();
                    services.AddTransient<INumberProcessor, NumberProcessor>();
                })
                .Build();

            NumberProcessor processor = ActivatorUtilities.CreateInstance<NumberProcessor>(host.Services);

            return processor;
        }
    }
}
