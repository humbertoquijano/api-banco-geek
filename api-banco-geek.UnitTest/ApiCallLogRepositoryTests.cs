using api_banco_geek.Domain.Contracts;
using api_banco_geek.Domain.Models;
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
    public class ApiCallLogRepositoryTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ApiCallLogRepositoryTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Must_Insert_Record_OK()
        {
            SumArgs sumArgs = new SumArgs { A = 7, B = 10 };
            SumResult sumResult = new SumResult { ResultValue = 17, IsResultValueInFibonacci = false };

            ApiCallLogRepository repository = BuildApiCallLogRepository();

            bool saved = repository.AddEntry(sumArgs, sumResult);

            Assert.True(saved);
        }

        private ApiCallLogRepository BuildApiCallLogRepository()
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
                })
                .Build();

            ApiCallLogRepository repository = ActivatorUtilities.CreateInstance<ApiCallLogRepository>(host.Services);

            return repository;
        }
    }
}
