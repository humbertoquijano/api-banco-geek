using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Infraestructure.Entities
{
    public class FibonacciValue
    {
        [Key]
        public int IdValue { get; set; }
        public decimal Value { get; set; }
    }
}
