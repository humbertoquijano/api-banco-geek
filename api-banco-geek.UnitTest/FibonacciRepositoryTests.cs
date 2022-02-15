using api_banco_geek.Domain.Contracts;
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
    public class FibonacciRepositoryTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public FibonacciRepositoryTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        private void MustGet_Is_Not_Fibonacci()
        {
            FibonacciRepository repository = BuildFibonacciRepository();

            decimal testValue = 17;

            bool isFibonacci = repository.IsNumberInFibonacci(testValue);

            Assert.False(isFibonacci);
        }

        [Fact]
        private void MustGet_Is_Fibonacci()
        {
            FibonacciRepository repository = BuildFibonacciRepository();

            decimal testValue = 39088169;

            bool isFibonacci = repository.IsNumberInFibonacci(testValue);

            Assert.True(isFibonacci);
        }

        private FibonacciRepository BuildFibonacciRepository()
        {
            var builder = new ConfigurationBuilder();
            TestToolkit.BuildConfig(builder);
            var config = builder.Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    string connectionString = config.GetConnectionString("local");

                    TestToolkit.ConfigureDB(services, connectionString);

                    services.AddTransient<IFibonacciRepository, FibonacciRepository>();
                })
                .Build();

            FibonacciRepository repository = ActivatorUtilities.CreateInstance<FibonacciRepository>(host.Services);

            return repository;
        }
    }
}
