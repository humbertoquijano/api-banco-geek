using api_banco_geek.Domain.Models;
using api_banco_geek.Infraestructure.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Infraestructure.Extensions
{
    public static class Mapper
    {
        public static ApiCallLog BuildApiCalllog(SumArgs sumArgs, SumResult sumResult)
        {
            ApiCallLog apiCallLog = new ApiCallLog
            {
                CreatedAt = DateTime.Now,
                IsResultValueInFibonnaci = sumResult.IsResultValueInFibonacci,
                Request = JsonConvert.SerializeObject(sumArgs),
                ResultValue = sumResult.ResultValue,
                ValueA = sumArgs.A,
                ValueB =sumArgs.B
            };

            return apiCallLog;
        }
    }
}
