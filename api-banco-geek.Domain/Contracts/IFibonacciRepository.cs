using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Domain.Contracts
{
    public interface IFibonacciRepository
    {
        bool IsNumberInFibonacci(decimal number);
    }
}
