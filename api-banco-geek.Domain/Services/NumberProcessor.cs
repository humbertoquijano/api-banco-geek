using api_banco_geek.Domain.Contracts;
using api_banco_geek.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Domain.Services
{
    public class NumberProcessor : INumberProcessor
    {
        private readonly ILogger<NumberProcessor> _logger;
        private readonly IFibonacciRepository _fibonacciRepository;
        private readonly IApiCallLogRepository _apiCallLogRepository;

        public NumberProcessor(ILogger<NumberProcessor> logger, IFibonacciRepository fibonacciRepository, IApiCallLogRepository apiCallLogRepository)
        {
            _logger = logger;
            _fibonacciRepository = fibonacciRepository;
            _apiCallLogRepository = apiCallLogRepository;
        }

        public SumResult ProcessNumbers(SumArgs sumArgs)
        {
            try
            {
                decimal total = sumArgs.A + sumArgs.B;

                SumResult sumResult = new SumResult
                {
                    ResultValue = total,
                    IsResultValueInFibonacci = _fibonacciRepository.IsNumberInFibonacci(total)
                };

                bool saved = _apiCallLogRepository.AddEntry(sumArgs, sumResult);

                if (!saved) { return null; }

                return sumResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "args: {@sumArgs}", sumArgs);
                return null;
            }
        }
    }
}
