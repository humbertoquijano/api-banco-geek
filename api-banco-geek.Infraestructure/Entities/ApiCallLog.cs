using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Infraestructure.Entities
{
    public class ApiCallLog
    {
        [Key]
        public int IdApiCallLog { get; set; }
        public string Request { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }
        public decimal ResultValue { get; set; }
        public bool IsResultValueInFibonnaci { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
