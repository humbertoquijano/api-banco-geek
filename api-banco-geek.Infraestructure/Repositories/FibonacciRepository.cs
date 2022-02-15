using api_banco_geek.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Infraestructure.Repositories
{
    public class FibonacciRepository : IFibonacciRepository
    {
        private readonly ApiBancoGeekDbContext _context;

        public FibonacciRepository(ApiBancoGeekDbContext context)
        {
            _context = context;
        }

        public bool IsNumberInFibonacci(decimal number)
        {
            return _context.FibonacciValue.Any(x => x.Value == number);
        }
    }
}
