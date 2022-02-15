using api_banco_geek.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Domain.Contracts
{
    public interface INumberProcessor
    {
        public SumResult ProcessNumbers(SumArgs sumArgs);
    }
}
