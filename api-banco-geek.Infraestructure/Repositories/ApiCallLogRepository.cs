using api_banco_geek.Domain.Contracts;
using api_banco_geek.Domain.Models;
using api_banco_geek.Infraestructure.Entities;
using api_banco_geek.Infraestructure.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Infraestructure.Repositories
{
    public class ApiCallLogRepository : IApiCallLogRepository
    {
        private readonly ILogger<ApiCallLogRepository> _logger;
        private readonly ApiBancoGeekDbContext _context;

        public ApiCallLogRepository(ILogger<ApiCallLogRepository> logger, ApiBancoGeekDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public bool AddEntry(SumArgs sumArgs, SumResult sumResult)
        {
            try
            {
                ApiCallLog apiCallLog = Mapper.BuildApiCalllog(sumArgs, sumResult);

                _context.Add(apiCallLog);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "args: {@sumResult}", sumResult);
                return false;
            }
        }
    }
}
